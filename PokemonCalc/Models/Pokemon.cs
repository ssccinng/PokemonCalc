using PokemonCalc.Data;

namespace PokemonCalc.Models;

/// <summary>
/// Represents a Pokemon instance with stats, level, and battle state
/// </summary>
public readonly record struct Pokemon(
    Species Species,
    int Level = 100,
    Nature Nature = default,
    Ability Ability = default,
    Item Item = default,
    StatsTable IVs = default,
    StatsTable EVs = default,
    StatsTable Boosts = default,
    int CurrentHP = -1,  // -1 means full HP
    StatusName Status = StatusName.None,
    GenderName? Gender = null,
    bool IsDynamaxed = false,
    int DynamaxLevel = 10,
    TypeName? TeraType = null)
{
    /// <summary>
    /// Calculate the actual stats for this Pokemon
    /// </summary>
    public StatsTable CalculateStats()
    {
        var stats = new StatsTable();

        foreach (StatID stat in Enum.GetValues<StatID>())
        {
            var baseStat = Species.BaseStats[stat];
            var iv = IVs[stat];
            var ev = EVs[stat];

            int calculatedStat;
            if (stat == StatID.HP)
            {
                // HP calculation: ((2 * Base + IV + EV/4) * Level / 100) + Level + 10
                calculatedStat = ((2 * baseStat + iv + ev / 4) * Level / 100) + Level + 10;
            }
            else
            {
                // Other stats: ((2 * Base + IV + EV/4) * Level / 100 + 5) * Nature
                calculatedStat = ((2 * baseStat + iv + ev / 4) * Level / 100) + 5;
                var natureMultiplier = Nature.GetMultiplier((StatIDExceptHP)stat);
                calculatedStat = (int)(calculatedStat * natureMultiplier);
            }

            stats = stats.WithStat(stat, calculatedStat);
        }

        return stats;
    }

    /// <summary>
    /// Get the current HP, accounting for Dynamax
    /// </summary>
    public int GetCurrentHP(StatsTable stats)
    {
        var maxHP = GetMaxHP(stats);
        return CurrentHP == -1 ? maxHP : Math.Min(CurrentHP, maxHP);
    }

    /// <summary>
    /// Get the maximum HP, accounting for Dynamax
    /// </summary>
    public int GetMaxHP(StatsTable stats)
    {
        if (IsDynamaxed && Species.BaseStats.HP != 1) // Shedinja exception
        {
            return (int)(stats.HP * (1.5 + 0.05 * DynamaxLevel));
        }
        return stats.HP;
    }

    /// <summary>
    /// Check if this Pokemon has a specific type (accounting for Tera type)
    /// </summary>
    public bool HasType(TypeName type)
    {
        if (TeraType.HasValue)
            return TeraType.Value == type;

        return Species.HasType(type);
    }

    /// <summary>
    /// Check if this Pokemon has the original type (ignoring Tera)
    /// </summary>
    public bool HasOriginalType(TypeName type) => Species.HasType(type);

    /// <summary>
    /// Get the effective types for this Pokemon
    /// </summary>
    public IReadOnlyList<TypeName> GetEffectiveTypes()
    {
        if (TeraType.HasValue)
            return new[] { TeraType.Value };

        return Species.Types;
    }

    /// <summary>
    /// Check if this Pokemon has a specific ability
    /// </summary>
    public bool HasAbility(string abilityName) =>
        Ability.Name.Equals(abilityName, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Check if this Pokemon has a specific item
    /// </summary>
    public bool HasItem(string itemName) =>
        Item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Check if this Pokemon has a specific status
    /// </summary>
    public bool HasStatus(StatusName status) => Status == status;

    /// <summary>
    /// Create a copy with default IVs (31 for all stats)
    /// </summary>
    public Pokemon WithMaxIVs() => this with
    {
        IVs = new StatsTable(31, 31, 31, 31, 31, 31)
    };

    /// <summary>
    /// Create a copy with no EVs
    /// </summary>
    public Pokemon WithNoEVs() => this with
    {
        EVs = new StatsTable(0, 0, 0, 0, 0, 0)
    };

    /// <summary>
    /// Create a copy with specific stat boost
    /// </summary>
    public Pokemon WithBoost(StatID stat, int stages) => this with
    {
        Boosts = Boosts.WithStat(stat, stages)
    };
}