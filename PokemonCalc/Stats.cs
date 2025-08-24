namespace PokemonCalc.Core;

/// <summary>
/// Immutable stats table for Pokemon
/// </summary>
public readonly record struct StatsTable(
    int HP,
    int Attack,
    int Defense,
    int SpecialAttack,
    int SpecialDefense,
    int Speed
)
{
    public int this[StatId stat] => stat switch
    {
        StatId.HP => HP,
        StatId.Attack => Attack,
        StatId.Defense => Defense,
        StatId.SpecialAttack => SpecialAttack,
        StatId.SpecialDefense => SpecialDefense,
        StatId.Speed => Speed,
        _ => throw new ArgumentOutOfRangeException(nameof(stat))
    };

    public StatsTable WithStat(StatId stat, int value) => stat switch
    {
        StatId.HP => this with { HP = value },
        StatId.Attack => this with { Attack = value },
        StatId.Defense => this with { Defense = value },
        StatId.SpecialAttack => this with { SpecialAttack = value },
        StatId.SpecialDefense => this with { SpecialDefense = value },
        StatId.Speed => this with { Speed = value },
        _ => throw new ArgumentOutOfRangeException(nameof(stat))
    };

    public static StatsTable WithDefault(int value) => new(value, value, value, value, value, value);
}

/// <summary>
/// Static class for stat calculations following functional programming principles
/// </summary>
public static class Stats
{
    /// <summary>
    /// Calculate a single stat value for Gen 3+ mechanics
    /// </summary>
    public static int CalculateStat(
        StatId stat,
        int baseValue,
        int iv,
        int ev,
        int level,
        Nature nature = Nature.Serious)
    {
        if (stat == StatId.HP)
        {
            // Special case for Shedinja (base HP = 1)
            if (baseValue == 1) return 1;
            
            return (int)Math.Floor((double)(baseValue * 2 + iv + Math.Floor((double)ev / 4)) * level / 100) + level + 10;
        }
        else
        {
            var multiplier = GetNatureMultiplier(nature, stat);
            var baseStat = (int)Math.Floor((double)(baseValue * 2 + iv + Math.Floor((double)ev / 4)) * level / 100) + 5;
            return (int)Math.Floor(baseStat * multiplier);
        }
    }

    /// <summary>
    /// Calculate stats for a Pokemon with the given parameters
    /// </summary>
    public static StatsTable CalculateStats(
        StatsTable baseStats,
        StatsTable ivs,
        StatsTable evs,
        int level,
        Nature nature = Nature.Serious)
    {
        return new StatsTable(
            HP: CalculateStat(StatId.HP, baseStats.HP, ivs.HP, evs.HP, level, nature),
            Attack: CalculateStat(StatId.Attack, baseStats.Attack, ivs.Attack, evs.Attack, level, nature),
            Defense: CalculateStat(StatId.Defense, baseStats.Defense, ivs.Defense, evs.Defense, level, nature),
            SpecialAttack: CalculateStat(StatId.SpecialAttack, baseStats.SpecialAttack, ivs.SpecialAttack, evs.SpecialAttack, level, nature),
            SpecialDefense: CalculateStat(StatId.SpecialDefense, baseStats.SpecialDefense, ivs.SpecialDefense, evs.SpecialDefense, level, nature),
            Speed: CalculateStat(StatId.Speed, baseStats.Speed, ivs.Speed, evs.Speed, level, nature)
        );
    }

    /// <summary>
    /// Get nature stat multiplier for a given stat
    /// </summary>
    public static double GetNatureMultiplier(Nature nature, StatId stat)
    {
        var (boosted, hindered) = GetNatureModifications(nature);
        
        if (boosted == stat && hindered == stat) return 1.0;
        if (boosted == stat) return 1.1;
        if (hindered == stat) return 0.9;
        return 1.0;
    }

    /// <summary>
    /// Get which stats a nature boosts and hinders
    /// </summary>
    public static (StatId? boosted, StatId? hindered) GetNatureModifications(Nature nature) => nature switch
    {
        Nature.Adamant => (StatId.Attack, StatId.SpecialAttack),
        Nature.Bold => (StatId.Defense, StatId.Attack),
        Nature.Brave => (StatId.Attack, StatId.Speed),
        Nature.Calm => (StatId.SpecialDefense, StatId.Attack),
        Nature.Careful => (StatId.SpecialDefense, StatId.SpecialAttack),
        Nature.Gentle => (StatId.SpecialDefense, StatId.Defense),
        Nature.Hasty => (StatId.Speed, StatId.Defense),
        Nature.Impish => (StatId.Defense, StatId.SpecialAttack),
        Nature.Jolly => (StatId.Speed, StatId.SpecialAttack),
        Nature.Lax => (StatId.Defense, StatId.SpecialDefense),
        Nature.Lonely => (StatId.Attack, StatId.Defense),
        Nature.Mild => (StatId.SpecialAttack, StatId.Defense),
        Nature.Modest => (StatId.SpecialAttack, StatId.Attack),
        Nature.Naive => (StatId.Speed, StatId.SpecialDefense),
        Nature.Naughty => (StatId.Attack, StatId.SpecialDefense),
        Nature.Quiet => (StatId.SpecialAttack, StatId.Speed),
        Nature.Rash => (StatId.SpecialAttack, StatId.SpecialDefense),
        Nature.Relaxed => (StatId.Defense, StatId.Speed),
        Nature.Sassy => (StatId.SpecialDefense, StatId.Speed),
        Nature.Timid => (StatId.Speed, StatId.Attack),
        _ => (null, null) // Neutral natures
    };

    /// <summary>
    /// Apply stat stage boosts/drops to a stat value
    /// </summary>
    public static int ApplyStatStage(int baseStat, int stage)
    {
        if (stage == 0) return baseStat;
        
        var multiplier = stage > 0 
            ? (2 + stage) / 2.0 
            : 2.0 / (2 - stage);
            
        return (int)Math.Floor(baseStat * multiplier);
    }
}