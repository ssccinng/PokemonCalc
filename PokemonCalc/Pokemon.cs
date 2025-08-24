namespace PokemonCalc.Core;

/// <summary>
/// Immutable Pokemon species data
/// </summary>
public readonly record struct PokemonSpecies(
    string Name,
    PokemonType Type1,
    PokemonType? Type2,
    StatsTable BaseStats,
    double WeightKg,
    string[] Abilities,
    string? BaseSpecies = null
)
{
    public IReadOnlyList<PokemonType> Types => Type2.HasValue 
        ? new[] { Type1, Type2.Value } 
        : new[] { Type1 };
}

/// <summary>
/// Immutable move data
/// </summary>
public readonly record struct Move(
    string Name,
    PokemonType Type,
    MoveCategory Category,
    int BasePower,
    int Accuracy,
    int PP,
    string Description = "",
    int Priority = 0,
    bool MakesContact = false,
    bool IsSoundBased = false,
    bool IsPunchMove = false,
    bool IsBiteMove = false,
    bool IsBulletMove = false,
    bool IsSlicingMove = false
);

/// <summary>
/// Immutable ability data
/// </summary>
public readonly record struct Ability(
    string Name,
    string Description
);

/// <summary>
/// Immutable item data
/// </summary>
public readonly record struct Item(
    string Name,
    string Description,
    bool IsBerry = false,
    string? MegaEvolves = null
);

/// <summary>
/// Immutable Pokemon instance
/// </summary>
public readonly record struct Pokemon(
    PokemonSpecies Species,
    int Level,
    Nature Nature,
    StatsTable IVs,
    StatsTable EVs,
    string? Ability = null,
    string? Item = null,
    Status Status = Status.None,
    Gender Gender = Gender.Male,
    PokemonType? TeraType = null,
    int CurrentHP = -1,
    StatsTable StatStages = default,
    bool AbilityActive = true
)
{
    public StatsTable Stats => Core.Stats.CalculateStats(Species.BaseStats, IVs, EVs, Level, Nature);
    
    public int MaxHP => Stats.HP;
    
    public int ActualCurrentHP => CurrentHP < 0 ? MaxHP : Math.Min(CurrentHP, MaxHP);
    
    public bool HasType(PokemonType type) => TeraType == type || Species.Types.Contains(type);
    
    public bool HasAbility(string ability) => Ability?.Equals(ability, StringComparison.OrdinalIgnoreCase) == true;
    
    public bool HasItem(string item) => Item?.Equals(item, StringComparison.OrdinalIgnoreCase) == true;
    
    public Pokemon WithCurrentHP(int hp) => this with { CurrentHP = hp };
    
    public Pokemon WithStatStage(StatId stat, int stage) => 
        this with { StatStages = StatStages.WithStat(stat, stage) };
    
    public int GetEffectiveStat(StatId stat)
    {
        var baseStat = Stats[stat];
        return stat == StatId.HP ? baseStat : Core.Stats.ApplyStatStage(baseStat, StatStages[stat]);
    }
}