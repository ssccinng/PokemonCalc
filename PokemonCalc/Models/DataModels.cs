using PokemonCalc.Data;

namespace PokemonCalc.Models;

/// <summary>
/// Represents a Pokemon species with base stats and properties
/// </summary>
public readonly record struct Species(
    ID Id,
    string Name,
    TypeName PrimaryType,
    TypeName? SecondaryType,
    StatsTable BaseStats,
    double WeightKg,
    GenderName? FixedGender = null,
    string? BaseSpecies = null,
    IReadOnlyList<string>? Abilities = null,
    IReadOnlyList<string>? OtherFormes = null)
{
    public IReadOnlyList<TypeName> Types => SecondaryType.HasValue
        ? new[] { PrimaryType, SecondaryType.Value }
        : new[] { PrimaryType };

    public bool HasType(TypeName type) => PrimaryType == type || SecondaryType == type;
}

/// <summary>
/// Represents a Pokemon move with damage and effect properties
/// </summary>
public readonly record struct Move(
    ID Id,
    string Name,
    TypeName Type,
    MoveCategory Category,
    int BasePower,
    int Priority = 0,
    bool IsContact = false,
    bool IsPunch = false,
    bool IsBite = false,
    bool IsSound = false,
    bool IsBullet = false,
    bool IsSlicing = false,
    bool HasRecoil = false,
    bool HasCrashDamage = false,
    bool WillCrit = false,
    bool IgnoresDefense = false,
    StatIDExceptHP? OverrideOffensiveStat = null,
    StatIDExceptHP? OverrideDefensiveStat = null,
    int? MinHits = null,
    int? MaxHits = null)
{
    public bool IsMultiHit => MinHits.HasValue && MaxHits.HasValue;
    public bool IsPhysical => Category == MoveCategory.Physical;
    public bool IsSpecial => Category == MoveCategory.Special;
    public bool IsStatus => Category == MoveCategory.Status;
}

/// <summary>
/// Represents a Pokemon ability
/// </summary>
public readonly record struct Ability(
    ID Id,
    string Name,
    string Description = "")
{
    public static readonly Ability None = new(new ID(""), "");
}

/// <summary>
/// Represents a held item
/// </summary>
public readonly record struct Item(
    ID Id,
    string Name,
    bool IsBerry = false,
    bool IsMegaStone = false,
    string? MegaEvolves = null,
    string Description = "")
{
    public static readonly Item None = new(new ID(""), "");
}

/// <summary>
/// Represents a Pokemon nature affecting stats
/// </summary>
public readonly record struct Nature(
    ID Id,
    string Name,
    StatIDExceptHP? Increases = null,
    StatIDExceptHP? Decreases = null)
{
    public bool IsNeutral => !Increases.HasValue && !Decreases.HasValue;

    public double GetMultiplier(StatIDExceptHP stat)
    {
        if (Increases == stat) return 1.1;
        if (Decreases == stat) return 0.9;
        return 1.0;
    }
}

/// <summary>
/// Represents a type and its effectiveness chart
/// </summary>
public readonly record struct TypeChart(
    TypeName Type,
    IReadOnlyDictionary<TypeName, TypeEffectiveness> Effectiveness);

/// <summary>
/// Represents battle field conditions
/// </summary>
public readonly record struct Field(
    Weather Weather = Weather.None,
    Terrain Terrain = Terrain.None,
    bool IsCriticalHit = false,
    bool HasReflect = false,
    bool HasLightScreen = false,
    bool HasStealthRock = false,
    bool HasSpikes = false)
{
    public static readonly Field Default = new();
}