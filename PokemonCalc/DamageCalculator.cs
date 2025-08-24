namespace PokemonCalc.Core;

/// <summary>
/// Main damage calculation engine following functional programming principles
/// </summary>
public static class DamageCalculator
{
    /// <summary>
    /// Calculate damage for a move from attacker to defender
    /// </summary>
    public static DamageResult CalculateDamage(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field = default,
        bool isCriticalHit = false,
        GenerationNum generation = GenerationNum.SV)
    {
        // Handle non-damaging moves
        if (move.Category == MoveCategory.Status || move.BasePower == 0)
        {
            return new DamageResult(
                DamageRolls: new[] { 0 },
                Description: $"{move.Name} deals no damage"
            );
        }

        // Get base damage using the current generation's formula
        var baseDamage = generation switch
        {
            >= GenerationNum.RSE => CalculateBaseDamageModern(attacker, defender, move, field, isCriticalHit),
            _ => throw new NotImplementedException($"Generation {generation} not implemented yet")
        };

        // Apply type effectiveness
        var defendingTypes = defender.TeraType.HasValue 
            ? new[] { defender.TeraType.Value }
            : defender.Species.Types.ToArray();
        
        var typeEffectiveness = TypeChart.GetTotalEffectiveness(move.Type, defendingTypes);
        baseDamage = (int)(baseDamage * typeEffectiveness);

        // Apply critical hit multiplier (after type effectiveness in modern gens)
        if (isCriticalHit)
        {
            baseDamage = (int)(baseDamage * 1.5);
        }

        // Calculate damage rolls (85% to 100% of base damage)
        var damageRolls = Enumerable.Range(85, 16)
            .Select(percent => Math.Max(1, baseDamage * percent / 100))
            .ToArray();

        var effectiveness = TypeChart.GetEffectivenessDescription(typeEffectiveness);
        var description = BuildDamageDescription(attacker, defender, move, isCriticalHit, effectiveness);

        return new DamageResult(
            DamageRolls: damageRolls,
            Description: description,
            IsCriticalHit: isCriticalHit,
            TypeEffectiveness: typeEffectiveness
        );
    }

    /// <summary>
    /// Calculate base damage using modern (Gen 3+) formula
    /// </summary>
    private static int CalculateBaseDamageModern(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field,
        bool isCriticalHit)
    {
        var level = attacker.Level;
        var power = move.BasePower;

        // Get attacking and defending stats
        var attackStat = move.Category == MoveCategory.Physical ? StatId.Attack : StatId.SpecialAttack;
        var defenseStat = move.Category == MoveCategory.Physical ? StatId.Defense : StatId.SpecialDefense;

        var attack = GetEffectiveAttackStat(attacker, attackStat, isCriticalHit);
        var defense = GetEffectiveDefenseStat(defender, defenseStat, isCriticalHit);

        // Base damage formula: ((((2 * Level / 5 + 2) * Power * Attack / Defense) / 50) + 2)
        var baseDamage = (((2 * level / 5 + 2) * power * attack / defense) / 50) + 2;

        // Apply modifiers
        baseDamage = ApplyModifiers(baseDamage, attacker, defender, move, field);

        return Math.Max(1, baseDamage);
    }

    /// <summary>
    /// Get effective attack stat considering stat stages and critical hits
    /// </summary>
    private static int GetEffectiveAttackStat(Pokemon attacker, StatId attackStat, bool isCriticalHit)
    {
        var baseStat = attacker.Stats[attackStat];
        var statStage = attacker.StatStages[attackStat];

        // Critical hits ignore negative stat stages for attacker
        if (isCriticalHit && statStage < 0)
            statStage = 0;

        return Core.Stats.ApplyStatStage(baseStat, statStage);
    }

    /// <summary>
    /// Get effective defense stat considering stat stages and critical hits
    /// </summary>
    private static int GetEffectiveDefenseStat(Pokemon defender, StatId defenseStat, bool isCriticalHit)
    {
        var baseStat = defender.Stats[defenseStat];
        var statStage = defender.StatStages[defenseStat];

        // Critical hits ignore positive stat stages for defender
        if (isCriticalHit && statStage > 0)
            statStage = 0;

        return Core.Stats.ApplyStatStage(baseStat, statStage);
    }

    /// <summary>
    /// Apply various damage modifiers
    /// </summary>
    private static int ApplyModifiers(
        int baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var damage = (double)baseDamage;

        // STAB (Same Type Attack Bonus)
        if (attacker.HasType(move.Type))
        {
            damage *= 1.5;
        }

        // Weather effects
        damage = ApplyWeatherModifiers(damage, move, field.Weather);

        // Terrain effects  
        damage = ApplyTerrainModifiers(damage, move, field.Terrain);

        // Item effects (simplified)
        damage = ApplyItemModifiers(damage, attacker, move);

        // Ability effects (simplified)
        damage = ApplyAbilityModifiers(damage, attacker, defender, move);

        return (int)Math.Floor(damage);
    }

    /// <summary>
    /// Apply weather-based damage modifiers
    /// </summary>
    private static double ApplyWeatherModifiers(double damage, Move move, WeatherType weather)
    {
        return weather switch
        {
            WeatherType.Sun or WeatherType.HarshSunshine when move.Type == PokemonType.Fire => damage * 1.5,
            WeatherType.Sun or WeatherType.HarshSunshine when move.Type == PokemonType.Water => damage * 0.5,
            WeatherType.Rain or WeatherType.HeavyRain when move.Type == PokemonType.Water => damage * 1.5,
            WeatherType.Rain or WeatherType.HeavyRain when move.Type == PokemonType.Fire => damage * 0.5,
            _ => damage
        };
    }

    /// <summary>
    /// Apply terrain-based damage modifiers
    /// </summary>
    private static double ApplyTerrainModifiers(double damage, Move move, TerrainType terrain)
    {
        return terrain switch
        {
            TerrainType.Electric when move.Type == PokemonType.Electric => damage * 1.3,
            TerrainType.Grassy when move.Type == PokemonType.Grass => damage * 1.3,
            TerrainType.Psychic when move.Type == PokemonType.Psychic => damage * 1.3,
            TerrainType.Misty when move.Type == PokemonType.Dragon => damage * 0.5,
            _ => damage
        };
    }

    /// <summary>
    /// Apply item-based damage modifiers (simplified)
    /// </summary>
    private static double ApplyItemModifiers(double damage, Pokemon attacker, Move move)
    {
        // Type-boosting items
        var itemBoost = attacker.Item?.ToLowerInvariant() switch
        {
            "charcoal" when move.Type == PokemonType.Fire => 1.2,
            "mystic water" when move.Type == PokemonType.Water => 1.2,
            "magnet" when move.Type == PokemonType.Electric => 1.2,
            "miracle seed" when move.Type == PokemonType.Grass => 1.2,
            "never-melt ice" when move.Type == PokemonType.Ice => 1.2,
            "black belt" when move.Type == PokemonType.Fighting => 1.2,
            "poison barb" when move.Type == PokemonType.Poison => 1.2,
            "soft sand" when move.Type == PokemonType.Ground => 1.2,
            "sharp beak" when move.Type == PokemonType.Flying => 1.2,
            "twisted spoon" when move.Type == PokemonType.Psychic => 1.2,
            "silver powder" when move.Type == PokemonType.Bug => 1.2,
            "hard stone" when move.Type == PokemonType.Rock => 1.2,
            "spell tag" when move.Type == PokemonType.Ghost => 1.2,
            "dragon fang" when move.Type == PokemonType.Dragon => 1.2,
            "black glasses" when move.Type == PokemonType.Dark => 1.2,
            "metal coat" when move.Type == PokemonType.Steel => 1.2,
            "pixie plate" when move.Type == PokemonType.Fairy => 1.2,
            _ => 1.0
        };

        return damage * itemBoost;
    }

    /// <summary>
    /// Apply ability-based damage modifiers (simplified)
    /// </summary>
    private static double ApplyAbilityModifiers(double damage, Pokemon attacker, Pokemon defender, Move move)
    {
        // Attacker abilities
        if (attacker.AbilityActive && attacker.Ability != null)
        {
            damage = attacker.Ability.ToLowerInvariant() switch
            {
                "huge power" or "pure power" => damage * 2.0,
                "adaptability" when attacker.HasType(move.Type) => damage / 1.5 * 2.0, // Replace STAB
                _ => damage
            };
        }

        // Defender abilities (damage reduction)
        if (defender.AbilityActive && defender.Ability != null)
        {
            damage = defender.Ability.ToLowerInvariant() switch
            {
                "thick fat" when move.Type is PokemonType.Fire or PokemonType.Ice => damage * 0.5,
                "water absorb" when move.Type == PokemonType.Water => 0,
                "volt absorb" when move.Type == PokemonType.Electric => 0,
                "flash fire" when move.Type == PokemonType.Fire => 0,
                _ => damage
            };
        }

        return damage;
    }

    /// <summary>
    /// Build descriptive text for the damage calculation
    /// </summary>
    private static string BuildDamageDescription(
        Pokemon attacker,
        Pokemon defender,
        Move move,
        bool isCriticalHit,
        string effectiveness)
    {
        var parts = new List<string>
        {
            $"{attacker.Species.Name} {move.Name} vs {defender.Species.Name}"
        };

        if (isCriticalHit)
            parts.Add("Critical hit!");

        if (!string.IsNullOrEmpty(effectiveness))
            parts.Add(effectiveness);

        return string.Join(" - ", parts);
    }
}