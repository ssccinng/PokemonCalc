namespace PokemonCalc;

// Main damage calculation engine - functional style
public static class DamageCalculator
{
    /// <summary>
    /// Main damage calculation entry point
    /// </summary>
    public static BattleResult Calculate(
        IGeneration generation,
        PokemonState attacker,
        PokemonState defender,
        MoveState move,
        FieldState? field = null)
    {
        field ??= new FieldState();

        // Clone states to avoid mutation
        var attackerClone = attacker with { };
        var defenderClone = defender with { };
        var moveClone = move with { };
        var fieldClone = field with { };

        return generation.Num switch
        {
            GenerationNum.Gen1 or GenerationNum.Gen2 => CalculateGen12(generation, attackerClone, defenderClone, moveClone, fieldClone),
            GenerationNum.Gen3 => CalculateGen3(generation, attackerClone, defenderClone, moveClone, fieldClone),
            GenerationNum.Gen4 => CalculateGen4(generation, attackerClone, defenderClone, moveClone, fieldClone),
            GenerationNum.Gen5 or GenerationNum.Gen6 => CalculateGen56(generation, attackerClone, defenderClone, moveClone, fieldClone),
            GenerationNum.Gen7 or GenerationNum.Gen8 or GenerationNum.Gen9 => CalculateGen789(generation, attackerClone, defenderClone, moveClone, fieldClone),
            _ => throw new ArgumentException($"Unsupported generation: {generation.Num}")
        };
    }

    /// <summary>
    /// Modern calculation (Gen 7-9) - most complex
    /// </summary>
    private static BattleResult CalculateGen789(
        IGeneration gen,
        PokemonState attacker,
        PokemonState defender,
        MoveState move,
        FieldState field)
    {
        // Status moves typically don't deal damage
        if (move.Move?.Category == MoveCategory.Status)
        {
            return CreateNoDamageResult(attacker, defender, move, field, "Status move");
        }

        // Calculate type effectiveness
        var effectiveness = CalculateTypeEffectiveness(gen, move, defender, field);
        if (effectiveness.Multiplier == 0)
        {
            return CreateNoDamageResult(attacker, defender, move, field, "No effect");
        }

        // Calculate base power
        var basePower = CalculateBasePower(gen, attacker, defender, move, field);
        if (basePower == 0)
        {
            return CreateNoDamageResult(attacker, defender, move, field, "No base power");
        }

        // Calculate attack and defense stats
        var attackStat = CalculateAttackStat(gen, attacker, defender, move, field);
        var defenseStat = CalculateDefenseStat(gen, attacker, defender, move, field);

        // Calculate base damage using the standard formula
        var baseDamage = CalculateBaseDamage(attacker.Level, basePower, attackStat, defenseStat);

        // Apply all modifiers
        var finalDamage = ApplyAllModifiers(gen, attacker, defender, move, field, baseDamage, effectiveness.Multiplier);

        // Generate damage range (simulating 16 random rolls)
        var damageArray = GenerateDamageRange(finalDamage);

        var damageResult = new DamageResult(
            damageArray,
            (double)damageArray.Max() / (defender.CurrentHP ?? 100) * 100,
            (double)damageArray.Min() / (defender.CurrentHP ?? 100) * 100,
            (double)damageArray.Max() / (defender.CurrentHP ?? 100) * 100,
            $"{move.Name} vs {defender.Name}"
        );

        return new BattleResult(damageResult, effectiveness, attacker, defender, move, field);
    }

    /// <summary>
    /// Placeholder for other generations - simplified calculation
    /// </summary>
    private static BattleResult CalculateGen12(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field) =>
        CalculateSimplified(gen, attacker, defender, move, field);

    private static BattleResult CalculateGen3(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field) =>
        CalculateSimplified(gen, attacker, defender, move, field);

    private static BattleResult CalculateGen4(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field) =>
        CalculateSimplified(gen, attacker, defender, move, field);

    private static BattleResult CalculateGen56(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field) =>
        CalculateSimplified(gen, attacker, defender, move, field);

    private static BattleResult CalculateSimplified(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field)
    {
        // Simplified calculation for now
        var effectiveness = CalculateTypeEffectiveness(gen, move, defender, field);
        if (effectiveness.Multiplier == 0)
        {
            return CreateNoDamageResult(attacker, defender, move, field, "No effect");
        }

        var basePower = move.Move?.BasePower ?? move.BasePower ?? 80;
        var attackStat = CalculateAttackStat(gen, attacker, defender, move, field);
        var defenseStat = CalculateDefenseStat(gen, attacker, defender, move, field);

        var baseDamage = CalculateBaseDamage(attacker.Level, basePower, attackStat, defenseStat);
        var finalDamage = (int)(baseDamage * effectiveness.Multiplier);

        var damageArray = GenerateDamageRange(finalDamage);
        var damageResult = new DamageResult(
            damageArray,
            (double)damageArray.Max() / (defender.CurrentHP ?? 100) * 100,
            (double)damageArray.Min() / (defender.CurrentHP ?? 100) * 100,
            (double)damageArray.Max() / (defender.CurrentHP ?? 100) * 100
        );

        return new BattleResult(damageResult, effectiveness, attacker, defender, move, field);
    }

    /// <summary>
    /// Calculate type effectiveness
    /// </summary>
    private static EffectivenessResult CalculateTypeEffectiveness(IGeneration gen, MoveState move, PokemonState defender, FieldState field)
    {
        var moveType = move.Move?.Type ?? move.Type ?? TypeName.Normal;
        var defenderTypes = defender.Species?.Types ?? [TypeName.Normal];

        double effectiveness = 1.0;
        var description = "";

        foreach (var defenderType in defenderTypes)
        {
            var typeData = gen.Types.Get(defenderType.ToString().ToLowerInvariant());
            if (typeData?.Effectiveness.TryGetValue(moveType, out var eff) == true)
            {
                effectiveness *= eff;
            }
        }

        description = effectiveness switch
        {
            0 => "No effect",
            < 1 => "Not very effective",
            > 1 => "Super effective",
            _ => "Normal effectiveness"
        };

        return new EffectivenessResult(effectiveness, description);
    }

    /// <summary>
    /// Calculate base power including move-specific logic
    /// </summary>
    private static int CalculateBasePower(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field)
    {
        var basePower = move.Move?.BasePower ?? move.BasePower ?? 80;

        // Add move-specific base power calculations here
        // For now, return the basic base power
        return basePower;
    }

    /// <summary>
    /// Calculate effective attack stat
    /// </summary>
    private static int CalculateAttackStat(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field)
    {
        var stats = StatCalculations.CalculateFinalStats(attacker);
        var isPhysical = move.Move?.Category == MoveCategory.Physical || move.Category == MoveCategory.Physical;

        return isPhysical ? stats.Attack : stats.SpecialAttack;
    }

    /// <summary>
    /// Calculate effective defense stat
    /// </summary>
    private static int CalculateDefenseStat(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field)
    {
        var stats = StatCalculations.CalculateFinalStats(defender);
        var isPhysical = move.Move?.Category == MoveCategory.Physical || move.Category == MoveCategory.Physical;

        return isPhysical ? stats.Defense : stats.SpecialDefense;
    }

    /// <summary>
    /// Calculate base damage using the standard Pokemon formula
    /// </summary>
    private static int CalculateBaseDamage(int level, int basePower, int attack, int defense)
    {
        // Standard Pokemon damage formula: ((2 * Level / 5 + 2) * Power * Attack / Defense) / 50 + 2
        return ((2 * level / 5 + 2) * basePower * attack / defense) / 50 + 2;
    }

    /// <summary>
    /// Apply all final modifiers
    /// </summary>
    private static int ApplyAllModifiers(IGeneration gen, PokemonState attacker, PokemonState defender, MoveState move, FieldState field, int baseDamage, double typeEffectiveness)
    {
        var damage = (double)baseDamage;

        // Apply type effectiveness
        damage *= typeEffectiveness;

        // Apply STAB (Same Type Attack Bonus)
        var moveType = move.Move?.Type ?? move.Type ?? TypeName.Normal;
        var attackerTypes = attacker.Species?.Types ?? [TypeName.Normal];
        if (attackerTypes.Contains(moveType))
        {
            damage *= 1.5; // STAB
        }

        // Apply burn reduction for physical moves
        if (attacker.Status == StatusName.Burn &&
            (move.Move?.Category == MoveCategory.Physical || move.Category == MoveCategory.Physical))
        {
            damage *= 0.5;
        }

        return (int)Math.Round(damage);
    }

    /// <summary>
    /// Generate damage range (simulating random damage rolls)
    /// </summary>
    private static int[] GenerateDamageRange(int baseDamage)
    {
        var damageArray = new int[16];
        for (int i = 0; i < 16; i++)
        {
            // Random factor from 0.85 to 1.00 (like in Pokemon games)
            var randomFactor = 0.85 + (i / 15.0) * 0.15;
            damageArray[i] = Math.Max(1, (int)(baseDamage * randomFactor));
        }
        return damageArray;
    }

    /// <summary>
    /// Create a result for moves that deal no damage
    /// </summary>
    private static BattleResult CreateNoDamageResult(PokemonState attacker, PokemonState defender, MoveState move, FieldState field, string reason)
    {
        var damageResult = new DamageResult([0], 0, 0, 0, reason);
        var effectiveness = new EffectivenessResult(0, reason);
        return new BattleResult(damageResult, effectiveness, attacker, defender, move, field, reason);
    }
}