namespace PokemonCalc;

/// <summary>
/// Extension methods for easier usage of the PokemonCalc library
/// </summary>
public static class PokemonCalcExtensions
{
    /// <summary>
    /// Create a competitive Pokemon with standard setup
    /// </summary>
    public static PokemonState CreateCompetitive(
        this IGeneration generation,
        string name,
        NatureName nature = NatureName.Hardy,
        string? ability = null,
        string? item = null,
        string[]? moves = null,
        StatsTable? evs = null,
        PartialStatsTable? boosts = null)
    {
        return new PokemonState(
            generation,
            name,
            ability,
            item,
            nature,
            Level: 100,
            IVs: new StatsTable(31, 31, 31, 31, 31, 31), // Perfect IVs
            EVs: evs ?? new StatsTable(252, 252, 4, 0, 0, 0), // Default spread
            Boosts: boosts,
            Moves: moves
        );
    }

    /// <summary>
    /// Create a simple attacking move
    /// </summary>
    public static MoveState CreateAttackingMove(
        this IGeneration generation,
        string name,
        bool isCrit = false,
        int? basePowerOverride = null)
    {
        return new MoveState(
            generation,
            name,
            basePowerOverride,
            IsCrit: isCrit
        );
    }

    /// <summary>
    /// Quick damage calculation for common scenarios
    /// </summary>
    public static string QuickCalc(
        this IGeneration generation,
        string attackerName,
        string defenderName,
        string moveName,
        NatureName attackerNature = NatureName.Hardy,
        NatureName defenderNature = NatureName.Hardy,
        string? attackerItem = null,
        string? defenderItem = null)
    {
        var attacker = generation.CreateCompetitive(attackerName, attackerNature, item: attackerItem);
        var defender = generation.CreateCompetitive(defenderName, defenderNature, item: defenderItem);
        var move = generation.CreateAttackingMove(moveName);

        var result = DamageCalculator.Calculate(generation, attacker, defender, move);

        return $"{attackerName} {moveName} vs {defenderName}: {result.Damage.GetDamageRange()} ({result.Damage.GetPercentageRange()}) - {result.Effectiveness.Description}";
    }

    /// <summary>
    /// Check if a move is a guaranteed KO
    /// </summary>
    public static bool IsGuaranteedKO(this BattleResult result) => result.Damage.IsGuaranteedKO;

    /// <summary>
    /// Check if a move has KO potential
    /// </summary>
    public static bool HasKOPotential(this BattleResult result) => result.Damage.IsPossibleKO;

    /// <summary>
    /// Get damage summary string
    /// </summary>
    public static string GetSummary(this BattleResult result)
    {
        var koStatus = result.Damage.IsGuaranteedKO ? " (guaranteed KO!)"
                      : result.Damage.IsPossibleKO ? " (possible KO)"
                      : "";

        return $"{result.Damage.GetDamageRange()} ({result.Damage.GetPercentageRange()}) - {result.Effectiveness.Description}{koStatus}";
    }

    /// <summary>
    /// Calculate stats for a Pokemon without creating full state
    /// </summary>
    public static StatsTable CalculateStats(
        this IGeneration generation,
        string pokemonName,
        int level = 100,
        NatureName nature = NatureName.Hardy,
        StatsTable? ivs = null,
        StatsTable? evs = null)
    {
        var pokemon = new PokemonState(generation, pokemonName, Level: level, Nature: nature, IVs: ivs, EVs: evs);
        return StatCalculations.CalculateStats(pokemon);
    }

    /// <summary>
    /// Get type effectiveness multiplier
    /// </summary>
    public static double GetTypeEffectiveness(this IGeneration generation, TypeName moveType, TypeName defenderType)
    {
        var typeData = generation.Types.Get(moveType.ToString().ToLowerInvariant());
        return typeData?.Effectiveness.TryGetValue(defenderType, out var eff) == true ? eff : 1.0;
    }

    /// <summary>
    /// Get all Pokemon of a specific type
    /// </summary>
    public static IEnumerable<ISpecie> GetPokemonOfType(this IGeneration generation, TypeName type)
    {
        return generation.Species.Where(s => s.Types.Contains(type));
    }

    /// <summary>
    /// Get all moves of a specific type
    /// </summary>
    public static IEnumerable<IMove> GetMovesOfType(this IGeneration generation, TypeName type)
    {
        return generation.Moves.Where(m => m.Type == type);
    }

    /// <summary>
    /// Check if a Pokemon has a specific type
    /// </summary>
    public static bool HasType(this ISpecie pokemon, TypeName type)
    {
        return pokemon.Types.Contains(type);
    }

    /// <summary>
    /// Check if a Pokemon has STAB for a move
    /// </summary>
    public static bool HasSTAB(this ISpecie pokemon, TypeName moveType)
    {
        return pokemon.Types.Contains(moveType);
    }

    /// <summary>
    /// Get base stat total
    /// </summary>
    public static int GetBaseStatTotal(this ISpecie pokemon)
    {
        var stats = pokemon.BaseStats;
        return stats.HP + stats.Attack + stats.Defense + stats.SpecialAttack + stats.SpecialDefense + stats.Speed;
    }

    /// <summary>
    /// Create common EV spreads
    /// </summary>
    public static class CommonEVSpreads
    {
        public static StatsTable Physical => new(4, 252, 0, 0, 0, 252);      // Atk/Spe
        public static StatsTable Special => new(4, 0, 0, 252, 0, 252);       // SpA/Spe
        public static StatsTable Defensive => new(252, 0, 252, 0, 4, 0);     // HP/Def
        public static StatsTable SpecialDefensive => new(252, 0, 0, 0, 252, 4); // HP/SpD
        public static StatsTable Bulk => new(252, 0, 128, 0, 128, 0);        // HP/Def/SpD
        public static StatsTable Mixed => new(4, 128, 0, 128, 0, 252);       // Atk/SpA/Spe
    }
}