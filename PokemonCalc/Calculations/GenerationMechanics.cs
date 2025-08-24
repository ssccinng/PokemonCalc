using PokemonCalc.Data;
using PokemonCalc.Models;

namespace PokemonCalc.Calculations;

/// <summary>
/// Generation-specific damage calculation mechanics
/// </summary>
public static class GenerationMechanics
{
    /// <summary>
    /// Apply generation-specific damage modifiers
    /// </summary>
    public static double ApplyGenerationModifiers(
        double baseDamage,
        GenerationNum generation,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        return generation.Value switch
        {
            1 or 2 => ApplyGen12Mechanics(baseDamage, attacker, defender, move, field),
            3 => ApplyGen3Mechanics(baseDamage, attacker, defender, move, field),
            4 => ApplyGen4Mechanics(baseDamage, attacker, defender, move, field),
            5 or 6 => ApplyGen56Mechanics(baseDamage, attacker, defender, move, field),
            >= 7 => ApplyGen789Mechanics(baseDamage, attacker, defender, move, field),
            _ => baseDamage
        };
    }

    /// <summary>
    /// Generation 1-2 mechanics (simplified)
    /// </summary>
    private static double ApplyGen12Mechanics(
        double baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = baseDamage;

        // Gen 1-2 had different critical hit rates and calculations
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= 2.0; // Critical hits were 2x in early generations
        }

        // Badge boosts in Gen 1 (would require more context to implement properly)
        // Simplified: assume no badge boosts

        return modifiers;
    }

    /// <summary>
    /// Generation 3 mechanics
    /// </summary>
    private static double ApplyGen3Mechanics(
        double baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = baseDamage;

        // Gen 3 introduced abilities
        modifiers = ApplyAbilityEffects(modifiers, attacker, defender, move, field);

        // Gen 3 critical hits
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= 2.0;
        }

        return modifiers;
    }

    /// <summary>
    /// Generation 4 mechanics
    /// </summary>
    private static double ApplyGen4Mechanics(
        double baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = baseDamage;

        // Gen 4 refined the physical/special split
        modifiers = ApplyAbilityEffects(modifiers, attacker, defender, move, field);
        modifiers = ApplyItemEffects(modifiers, attacker, defender, move, field);

        // Gen 4+ critical hits
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= 2.0;
        }

        return modifiers;
    }

    /// <summary>
    /// Generation 5-6 mechanics
    /// </summary>
    private static double ApplyGen56Mechanics(
        double baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = baseDamage;

        modifiers = ApplyAbilityEffects(modifiers, attacker, defender, move, field);
        modifiers = ApplyItemEffects(modifiers, attacker, defender, move, field);

        // Gen 6+ critical hits are 1.5x
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= 1.5;
        }

        // Gen 6 introduced Mega Evolution
        if (attacker.Item.IsMegaStone)
        {
            // Simplified: assume mega evolution is active
            // In practice, this would require more complex state management
        }

        return modifiers;
    }

    /// <summary>
    /// Generation 7-8-9 mechanics
    /// </summary>
    private static double ApplyGen789Mechanics(
        double baseDamage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = baseDamage;

        modifiers = ApplyAbilityEffects(modifiers, attacker, defender, move, field);
        modifiers = ApplyItemEffects(modifiers, attacker, defender, move, field);

        // Gen 6+ critical hits
        if (field.IsCriticalHit || move.WillCrit)
        {
            modifiers *= 1.5;
        }

        // Z-Moves and Dynamax (simplified)
        if (attacker.IsDynamaxed)
        {
            // Max moves have different base powers
            // This would require move transformation logic
        }

        // Tera types in Gen 9
        if (attacker.TeraType.HasValue && move.Type == attacker.TeraType.Value)
        {
            // Tera STAB is different from regular STAB
            // This would require more sophisticated STAB calculation
        }

        return modifiers;
    }

    /// <summary>
    /// Apply ability effects to damage (simplified examples)
    /// </summary>
    private static double ApplyAbilityEffects(
        double damage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = damage;

        // Attacker abilities
        if (attacker.HasAbility("Blaze") && move.Type == TypeName.Fire)
        {
            var currentHP = attacker.GetCurrentHP(attacker.CalculateStats());
            var maxHP = attacker.GetMaxHP(attacker.CalculateStats());
            if (currentHP <= maxHP / 3)
            {
                modifiers *= 1.5; // Blaze activates at 1/3 HP or less
            }
        }

        if (attacker.HasAbility("Solar Power") && field.Weather == Weather.Sun)
        {
            if (move.IsSpecial)
            {
                modifiers *= 1.5; // Solar Power boosts special attacks in sun
            }
        }

        // Defender abilities
        if (defender.HasAbility("Water Absorb") && move.Type == TypeName.Water)
        {
            modifiers = 0; // Water Absorb negates water damage
        }

        return modifiers;
    }

    /// <summary>
    /// Apply item effects to damage (simplified examples)
    /// </summary>
    private static double ApplyItemEffects(
        double damage,
        Pokemon attacker,
        Pokemon defender,
        Move move,
        Field field)
    {
        var modifiers = damage;

        // Attacker items
        if (attacker.HasItem("Life Orb"))
        {
            modifiers *= 1.3; // Life Orb boosts damage by 30%
        }

        if (attacker.HasItem("Choice Band") && move.IsPhysical)
        {
            modifiers *= 1.5; // Choice Band boosts physical attacks
        }

        // Type-boosting items (simplified)
        if (attacker.HasItem("Charcoal") && move.Type == TypeName.Fire)
        {
            modifiers *= 1.2; // Fire-type boosting item
        }

        return modifiers;
    }
}