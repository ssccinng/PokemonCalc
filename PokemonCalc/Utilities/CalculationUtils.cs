using PokemonCalc.Data;
using PokemonCalc.Models;
using System.Text.RegularExpressions;

namespace PokemonCalc.Utilities;

/// <summary>
/// Utility functions for ID normalization and string processing
/// </summary>
public static class IDUtils
{
    private static readonly Regex NonAlphanumeric = new(@"[^a-zA-Z0-9]", RegexOptions.Compiled);

    /// <summary>
    /// Convert a string to a normalized ID
    /// </summary>
    public static ID ToID(string input)
    {
        if (string.IsNullOrEmpty(input))
            return new ID("");

        var normalized = NonAlphanumeric.Replace(input.ToLowerInvariant(), "");
        return new ID(normalized);
    }

    /// <summary>
    /// Check if two names match when normalized
    /// </summary>
    public static bool NamesMatch(string name1, string name2) =>
        ToID(name1).Value == ToID(name2).Value;
}

/// <summary>
/// Utility functions for stat calculations
/// </summary>
public static class StatUtils
{
    /// <summary>
    /// Calculate a single stat value
    /// </summary>
    public static int CalculateStat(
        StatID stat,
        int baseStat,
        int iv,
        int ev,
        int level,
        Nature nature)
    {
        if (stat == StatID.HP)
        {
            return CalculateHP(baseStat, iv, ev, level);
        }

        return CalculateOtherStat(baseStat, iv, ev, level, nature, (StatIDExceptHP)stat);
    }

    /// <summary>
    /// Calculate HP stat
    /// </summary>
    public static int CalculateHP(int baseStat, int iv, int ev, int level)
    {
        // HP formula: ((2 * Base + IV + EV/4) * Level / 100) + Level + 10
        return ((2 * baseStat + iv + ev / 4) * level / 100) + level + 10;
    }

    /// <summary>
    /// Calculate non-HP stat
    /// </summary>
    public static int CalculateOtherStat(
        int baseStat,
        int iv,
        int ev,
        int level,
        Nature nature,
        StatIDExceptHP stat)
    {
        // Other stats: ((2 * Base + IV + EV/4) * Level / 100 + 5) * Nature
        var baseStat_ = ((2 * baseStat + iv + ev / 4) * level / 100) + 5;
        var natureMultiplier = nature.GetMultiplier(stat);
        return (int)(baseStat_ * natureMultiplier);
    }

    /// <summary>
    /// Apply stat boost stages to a stat
    /// </summary>
    public static int ApplyBoosts(int baseStat, int stages)
    {
        // Clamp stages between -6 and +6
        stages = Math.Max(-6, Math.Min(6, stages));

        if (stages == 0) return baseStat;

        // Boost formula: stat * (2 + |stages|) / (2 + |stages| * sign)
        if (stages > 0)
        {
            return baseStat * (2 + stages) / 2;
        }
        else
        {
            return baseStat * 2 / (2 + Math.Abs(stages));
        }
    }

    /// <summary>
    /// Calculate damage stat with boosts
    /// </summary>
    public static int GetEffectiveStat(int baseStat, int stages) =>
        ApplyBoosts(baseStat, stages);
}

/// <summary>
/// Utility functions for type effectiveness calculations
/// </summary>
public static class TypeUtils
{
    /// <summary>
    /// Calculate type effectiveness multiplier
    /// </summary>
    public static double CalculateEffectiveness(
        TypeName attackType,
        IReadOnlyList<TypeName> defenderTypes,
        IReadOnlyDictionary<TypeName, IReadOnlyDictionary<TypeName, TypeEffectiveness>> typeChart)
    {
        double multiplier = 1.0;

        if (!typeChart.TryGetValue(attackType, out var effectiveness))
            return multiplier;

        foreach (var defenderType in defenderTypes)
        {
            if (effectiveness.TryGetValue(defenderType, out var effect))
            {
                multiplier *= (double)effect / 100.0; // Convert from integer storage to decimal
            }
        }

        return multiplier;
    }

    /// <summary>
    /// Check if a move gets STAB (Same Type Attack Bonus)
    /// </summary>
    public static bool GetSTAB(TypeName moveType, IReadOnlyList<TypeName> pokemonTypes) =>
        pokemonTypes.Contains(moveType);

    /// <summary>
    /// Calculate STAB multiplier
    /// </summary>
    public static double GetSTABMultiplier(TypeName moveType, IReadOnlyList<TypeName> pokemonTypes) =>
        GetSTAB(moveType, pokemonTypes) ? 1.5 : 1.0;
}

/// <summary>
/// Utility functions for damage calculations
/// </summary>
public static class DamageUtils
{
    /// <summary>
    /// Calculate critical hit multiplier for different generations
    /// </summary>
    public static double GetCriticalHitMultiplier(GenerationNum generation) => generation.Value switch
    {
        1 => 1.5,
        2 or 3 or 4 or 5 => 2.0,
        _ => 1.5 // Gen 6+
    };

    /// <summary>
    /// Apply random damage variation (85-100% of calculated damage)
    /// </summary>
    public static IEnumerable<int> GetDamageRange(int baseDamage)
    {
        for (int i = 85; i <= 100; i++)
        {
            yield return baseDamage * i / 100;
        }
    }

    /// <summary>
    /// Calculate weather multiplier for specific types
    /// </summary>
    public static double GetWeatherMultiplier(Weather weather, TypeName moveType) => weather switch
    {
        Weather.Sun when moveType == TypeName.Fire => 1.5,
        Weather.Sun when moveType == TypeName.Water => 0.5,
        Weather.Rain when moveType == TypeName.Water => 1.5,
        Weather.Rain when moveType == TypeName.Fire => 0.5,
        Weather.HarshSunshine when moveType == TypeName.Fire => 1.5,
        Weather.HarshSunshine when moveType == TypeName.Water => 0.0, // No effect
        Weather.HeavyRain when moveType == TypeName.Water => 1.5,
        Weather.HeavyRain when moveType == TypeName.Fire => 0.0, // No effect
        _ => 1.0
    };
}