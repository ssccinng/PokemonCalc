namespace PokemonCalc;

// Stat calculation functions - pure functional style
public static class StatCalculations
{
    /// <summary>
    /// Calculate a Pokemon's stat value
    /// </summary>
    public static int CalculateStat(
        IGeneration gen,
        StatId stat,
        int baseStat,
        int iv,
        int ev,
        int level,
        INature? nature = null)
    {
        if (gen.Num is GenerationNum.Gen1 or GenerationNum.Gen2)
        {
            return CalculateStatGen12(stat, baseStat, iv, ev, level);
        }

        return CalculateStatModern(stat, baseStat, iv, ev, level, nature);
    }

    /// <summary>
    /// Calculate stat for Generations 1-2 (different formula)
    /// </summary>
    private static int CalculateStatGen12(StatId stat, int baseStat, int iv, int ev, int level)
    {
        if (stat == StatId.HP)
        {
            return ((baseStat + iv) * 2 + (int)Math.Sqrt(ev) / 4) * level / 100 + level + 10;
        }
        else
        {
            return ((baseStat + iv) * 2 + (int)Math.Sqrt(ev) / 4) * level / 100 + 5;
        }
    }

    /// <summary>
    /// Calculate stat for Generations 3+ (modern formula)
    /// </summary>
    private static int CalculateStatModern(StatId stat, int baseStat, int iv, int ev, int level, INature? nature)
    {
        var natureMod = GetNatureModifier(stat, nature);

        if (stat == StatId.HP)
        {
            if (baseStat == 1) return 1; // Shedinja
            return (2 * baseStat + iv + ev / 4) * level / 100 + level + 10;
        }
        else
        {
            var baseStat_ = (2 * baseStat + iv + ev / 4) * level / 100 + 5;
            return (int)(baseStat_ * natureMod);
        }
    }

    /// <summary>
    /// Get nature modifier for a stat
    /// </summary>
    private static double GetNatureModifier(StatId stat, INature? nature)
    {
        if (nature == null) return 1.0;

        if (nature.Plus == stat) return 1.1;
        if (nature.Minus == stat) return 0.9;
        return 1.0;
    }

    /// <summary>
    /// Apply stat boosts/drops
    /// </summary>
    public static int ApplyBoost(int baseStat, int? boost)
    {
        if (boost == null || boost == 0) return baseStat;

        var multiplier = boost > 0
            ? (2 + boost) / 2.0
            : 2.0 / (2 - boost);

        return (int)(baseStat * multiplier);
    }

    /// <summary>
    /// Calculate all stats for a Pokemon
    /// </summary>
    public static StatsTable CalculateStats(PokemonState pokemon)
    {
        var species = pokemon.Species;
        if (species == null)
            throw new ArgumentException($"Unknown species: {pokemon.Name}");

        var nature = pokemon.Generation.Natures.Get(pokemon.Nature.ToString().ToLowerInvariant());
        var ivs = pokemon.GetIVs();
        var evs = pokemon.GetEVs();

        return new StatsTable(
            HP: CalculateStat(pokemon.Generation, StatId.HP, species.BaseStats.HP, ivs.HP, evs.HP, pokemon.Level, nature),
            Attack: CalculateStat(pokemon.Generation, StatId.Attack, species.BaseStats.Attack, ivs.Attack, evs.Attack, pokemon.Level, nature),
            Defense: CalculateStat(pokemon.Generation, StatId.Defense, species.BaseStats.Defense, ivs.Defense, evs.Defense, pokemon.Level, nature),
            SpecialAttack: CalculateStat(pokemon.Generation, StatId.SpecialAttack, species.BaseStats.SpecialAttack, ivs.SpecialAttack, evs.SpecialAttack, pokemon.Level, nature),
            SpecialDefense: CalculateStat(pokemon.Generation, StatId.SpecialDefense, species.BaseStats.SpecialDefense, ivs.SpecialDefense, evs.SpecialDefense, pokemon.Level, nature),
            Speed: CalculateStat(pokemon.Generation, StatId.Speed, species.BaseStats.Speed, ivs.Speed, evs.Speed, pokemon.Level, nature)
        );
    }

    /// <summary>
    /// Calculate the final stats with boosts applied
    /// </summary>
    public static StatsTable CalculateFinalStats(PokemonState pokemon)
    {
        var baseStats = CalculateStats(pokemon);
        var boosts = pokemon.GetBoosts();

        return new StatsTable(
            HP: baseStats.HP, // HP is never boosted in battle
            Attack: ApplyBoost(baseStats.Attack, boosts.Attack),
            Defense: ApplyBoost(baseStats.Defense, boosts.Defense),
            SpecialAttack: ApplyBoost(baseStats.SpecialAttack, boosts.SpecialAttack),
            SpecialDefense: ApplyBoost(baseStats.SpecialDefense, boosts.SpecialDefense),
            Speed: ApplyBoost(baseStats.Speed, boosts.Speed)
        );
    }
}