using PokemonCalc.Data;
using PokemonCalc.Models;
using PokemonCalc.Utilities;

namespace PokemonCalc.Calculations;

/// <summary>
/// Result of a damage calculation
/// </summary>
public readonly record struct DamageResult(
    IReadOnlyList<int> DamageValues,
    double TypeEffectiveness,
    bool IsCriticalHit,
    bool HasSTAB,
    string Description = "")
{
    public int MinDamage => DamageValues.Count > 0 ? DamageValues.Min() : 0;
    public int MaxDamage => DamageValues.Count > 0 ? DamageValues.Max() : 0;
    public double AverageDamage => DamageValues.Count > 0 ? DamageValues.Average() : 0;

    /// <summary>
    /// Calculate percentage damage against a target's HP
    /// </summary>
    public (double Min, double Max, double Average) GetPercentageDamage(int targetMaxHP)
    {
        if (targetMaxHP <= 0) return (0, 0, 0);

        return (
            Min: (double)MinDamage / targetMaxHP * 100,
            Max: (double)MaxDamage / targetMaxHP * 100,
            Average: AverageDamage / targetMaxHP * 100
        );
    }
}

/// <summary>
/// Core damage calculation functions using functional programming principles
/// </summary>
public static class DamageCalculator
{
    /// <summary>
    /// Calculate damage from an attacker to a defender
    /// </summary>
    public static DamageResult Calculate(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field = default,
        GenerationNum generation = default,
        IReadOnlyDictionary<TypeName, IReadOnlyDictionary<TypeName, TypeEffectiveness>>? typeChart = null)
    {
        if (generation.Value == 0) generation = GenerationNum.Gen9;

        // Status moves deal no damage
        if (move.IsStatus)
        {
            return new DamageResult(
                new[] { 0 },
                1.0,
                false,
                false,
                "Status move deals no damage");
        }

        var attackerStats = attacker.CalculateStats();
        var defenderStats = defender.CalculateStats();

        // Get offensive and defensive stats
        var (offensiveStat, defensiveStat) = GetRelevantStats(
            move, attackerStats, defenderStats, attacker.Boosts, defender.Boosts);

        // Calculate base damage
        var level = attacker.Level;
        var baseDamage = CalculateBaseDamage(level, move.BasePower, offensiveStat, defensiveStat);

        // Apply modifiers
        var modifiers = CalculateModifiers(
            attacker, defender, move, field, generation, typeChart);

        var finalDamage = (int)(baseDamage * modifiers.TotalMultiplier);

        // Apply damage variation (85-100%)
        var damageRange = DamageUtils.GetDamageRange(finalDamage).ToArray();

        return new DamageResult(
            damageRange,
            modifiers.TypeEffectiveness,
            field.IsCriticalHit || move.WillCrit,
            modifiers.HasSTAB,
            GenerateDescription(attacker, defender, move, modifiers));
    }

    /// <summary>
    /// Get the relevant offensive and defensive stats for a move
    /// </summary>
    private static (int Offensive, int Defensive) GetRelevantStats(
        Move move,
        StatsTable attackerStats,
        StatsTable defenderStats,
        StatsTable attackerBoosts,
        StatsTable defenderBoosts)
    {
        var offensiveStatId = move.OverrideOffensiveStat switch
        {
            StatIDExceptHP.ATK => StatID.ATK,
            StatIDExceptHP.SPA => StatID.SPA,
            _ => move.IsPhysical ? StatID.ATK : StatID.SPA
        };

        var defensiveStatId = move.OverrideDefensiveStat switch
        {
            StatIDExceptHP.DEF => StatID.DEF,
            StatIDExceptHP.SPD => StatID.SPD,
            _ => move.IsPhysical ? StatID.DEF : StatID.SPD
        };

        var offensiveStat = StatUtils.GetEffectiveStat(
            attackerStats[offensiveStatId],
            attackerBoosts[offensiveStatId]);

        var defensiveStat = StatUtils.GetEffectiveStat(
            defenderStats[defensiveStatId],
            defenderBoosts[defensiveStatId]);

        return (offensiveStat, defensiveStat);
    }

    /// <summary>
    /// Calculate base damage using the standard Pokemon damage formula
    /// </summary>
    private static int CalculateBaseDamage(int level, int basePower, int attack, int defense)
    {
        // Base damage formula: ((2 * Level / 5 + 2) * BasePower * Attack / Defense) / 50 + 2
        return ((2 * level / 5 + 2) * basePower * attack / defense) / 50 + 2;
    }

    /// <summary>
    /// Calculate all damage modifiers
    /// </summary>
    private static DamageModifiers CalculateModifiers(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field,
        GenerationNum generation,
        IReadOnlyDictionary<TypeName, IReadOnlyDictionary<TypeName, TypeEffectiveness>>? typeChart)
    {
        var modifiers = 1.0;

        // STAB (Same Type Attack Bonus)
        var hasSTAB = TypeUtils.GetSTAB(move.Type, attacker.GetEffectiveTypes());
        if (hasSTAB)
        {
            modifiers *= TypeUtils.GetSTABMultiplier(move.Type, attacker.GetEffectiveTypes());
        }

        // Type effectiveness
        var typeEffectiveness = 1.0;
        if (typeChart != null)
        {
            typeEffectiveness = TypeUtils.CalculateEffectiveness(
                move.Type, defender.GetEffectiveTypes(), typeChart);
            modifiers *= typeEffectiveness;
        }

        // Critical hit
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= DamageUtils.GetCriticalHitMultiplier(generation);
        }

        // Weather
        var weatherMultiplier = DamageUtils.GetWeatherMultiplier(field.Weather, move.Type);
        modifiers *= weatherMultiplier;

        // Terrain (simplified)
        if (field.Terrain != Terrain.None)
        {
            modifiers *= GetTerrainMultiplier(field.Terrain, move.Type);
        }

        // Status conditions
        if (attacker.HasStatus(StatusName.BRN) && move.IsPhysical)
        {
            modifiers *= 0.5; // Burn halves physical attack
        }

        return new DamageModifiers(
            modifiers,
            typeEffectiveness,
            hasSTAB,
            field.IsCriticalHit || move.WillCrit,
            weatherMultiplier);
    }

    /// <summary>
    /// Get terrain damage multiplier
    /// </summary>
    private static double GetTerrainMultiplier(Terrain terrain, TypeName moveType) => terrain switch
    {
        Terrain.Electric when moveType == TypeName.Electric => 1.3,
        Terrain.Grassy when moveType == TypeName.Grass => 1.3,
        Terrain.Psychic when moveType == TypeName.Psychic => 1.3,
        Terrain.Misty when moveType == TypeName.Fairy => 1.3,
        _ => 1.0
    };

    /// <summary>
    /// Generate a human-readable description of the calculation
    /// </summary>
    private static string GenerateDescription(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        DamageModifiers modifiers)
    {
        var parts = new List<string>();

        if (modifiers.HasSTAB)
            parts.Add("STAB");

        if (modifiers.TypeEffectiveness > 1)
            parts.Add("Super Effective");
        else if (modifiers.TypeEffectiveness < 1)
            parts.Add("Not Very Effective");

        if (modifiers.IsCriticalHit)
            parts.Add("Critical Hit");

        if (modifiers.WeatherMultiplier != 1.0)
            parts.Add("Weather");

        var description = $"{attacker.Species.Name} {move.Name} vs {defender.Species.Name}";
        if (parts.Count > 0)
            description += $" ({string.Join(", ", parts)})";

        return description;
    }
}

/// <summary>
/// Damage calculation modifiers
/// </summary>
internal readonly record struct DamageModifiers(
    double TotalMultiplier,
    double TypeEffectiveness,
    bool HasSTAB,
    bool IsCriticalHit,
    double WeatherMultiplier);