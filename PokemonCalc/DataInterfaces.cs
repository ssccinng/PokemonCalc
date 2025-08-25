namespace PokemonCalc;

// Core interface definitions - translated from TypeScript interface.ts
public interface IData<TName>
{
    string Id { get; }
    TName Name { get; }
    DataKind Kind { get; }
}

public enum DataKind
{
    Ability,
    Item,
    Move,
    Species,
    Type,
    Nature
}

public enum GenerationNum
{
    Gen1 = 1,
    Gen2 = 2,
    Gen3 = 3,
    Gen4 = 4,
    Gen5 = 5,
    Gen6 = 6,
    Gen7 = 7,
    Gen8 = 8,
    Gen9 = 9
}

public enum GenderName
{
    M,
    F,
    N
}

public enum StatId
{
    HP,
    Attack,
    Defense,
    SpecialAttack,
    SpecialDefense,
    Speed
}

public enum StatusName
{
    Sleep,
    Poison,
    Burn,
    Freeze,
    Paralysis,
    BadlyPoisoned
}

public enum GameType
{
    Singles,
    Doubles
}

public enum Terrain
{
    Electric,
    Grassy,
    Psychic,
    Misty
}

public enum Weather
{
    Sand,
    Sun,
    Rain,
    Hail,
    Snow,
    HarshSunshine,
    HeavyRain,
    StrongWinds
}

public enum NatureName
{
    Adamant, Bashful, Bold, Brave, Calm,
    Careful, Docile, Gentle, Hardy, Hasty,
    Impish, Jolly, Lax, Lonely, Mild,
    Modest, Naive, Naughty, Quiet, Quirky,
    Rash, Relaxed, Sassy, Serious, Timid
}

public enum TypeName
{
    Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
    Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
    Stellar, Unknown
}

public enum MoveCategory
{
    Physical,
    Special,
    Status
}

public enum MoveTarget
{
    AdjacentAlly,
    AdjacentAllyOrSelf,
    AdjacentFoe,
    All,
    AllAdjacent,
    AllAdjacentFoes,
    Allies,
    AllySide,
    AllyTeam,
    Any,
    FoeSide,
    Normal,
    RandomNormal,
    Scripted,
    Self
}

// Core data records using functional style
public record StatsTable(
    int HP = 0,
    int Attack = 0,
    int Defense = 0,
    int SpecialAttack = 0,
    int SpecialDefense = 0,
    int Speed = 0
);

public record PartialStatsTable(
    int? HP = null,
    int? Attack = null,
    int? Defense = null,
    int? SpecialAttack = null,
    int? SpecialDefense = null,
    int? Speed = null
);

public record MoveFlags(
    bool Contact = false,
    bool Bite = false,
    bool Sound = false,
    bool Punch = false,
    bool Bullet = false,
    bool Pulse = false,
    bool Slicing = false,
    bool Wind = false
);

// Core interfaces for data access
public interface IGeneration
{
    GenerationNum Num { get; }
    IAbilities Abilities { get; }
    IItems Items { get; }
    IMoves Moves { get; }
    ISpecies Species { get; }
    ITypes Types { get; }
    INatures Natures { get; }
}

public interface IAbilities : IEnumerable<IAbility>
{
    IAbility? Get(string id);
}

public interface IAbility : IData<string>
{
}

public interface IItems : IEnumerable<IItem>
{
    IItem? Get(string id);
}

public interface IItem : IData<string>
{
    string? MegaEvolves { get; }
    bool IsBerry { get; }
    (int BasePower, TypeName Type)? NaturalGift { get; }
}

public interface IMoves : IEnumerable<IMove>
{
    IMove? Get(string id);
}

public interface IMove : IData<string>
{
    int BasePower { get; }
    TypeName Type { get; }
    MoveCategory Category { get; }
    MoveFlags Flags { get; }
    MoveTarget Target { get; }
    (int, int)? Recoil { get; }
    bool HasCrashDamage { get; }
    bool WillCrit { get; }
    (int, int)? Drain { get; }
    int Priority { get; }
    bool IgnoreDefensive { get; }
    StatId? OverrideOffensiveStat { get; }
    StatId? OverrideDefensiveStat { get; }
    bool BreaksProtect { get; }
    bool IsZ { get; }
    bool IsMax { get; }
    int[]? Multihit { get; }
}

public interface ISpecies : IEnumerable<ISpecie>
{
    ISpecie? Get(string id);
}

public interface ISpecie : IData<string>
{
    TypeName[] Types { get; }
    StatsTable BaseStats { get; }
    double WeightKg { get; }
    bool IsNfe { get; }
    GenderName? Gender { get; }
    string[]? OtherFormes { get; }
    string? BaseSpecies { get; }
    string? PrimaryAbility { get; }
}

public interface ITypes : IEnumerable<IType>
{
    IType? Get(string id);
}

public interface IType : IData<TypeName>
{
    IReadOnlyDictionary<TypeName, double> Effectiveness { get; }
}

public interface INatures : IEnumerable<INature>
{
    INature? Get(string id);
}

public interface INature : IData<NatureName>
{
    StatId? Plus { get; }
    StatId? Minus { get; }
}
