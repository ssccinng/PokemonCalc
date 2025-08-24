namespace PokemonCalc.Data;

/// <summary>
/// Represents a Pokemon generation number (1-9)
/// </summary>
public readonly record struct GenerationNum(int Value)
{
    public static implicit operator int(GenerationNum gen) => gen.Value;
    public static implicit operator GenerationNum(int value) => new(value);

    public static readonly GenerationNum Gen1 = 1;
    public static readonly GenerationNum Gen2 = 2;
    public static readonly GenerationNum Gen3 = 3;
    public static readonly GenerationNum Gen4 = 4;
    public static readonly GenerationNum Gen5 = 5;
    public static readonly GenerationNum Gen6 = 6;
    public static readonly GenerationNum Gen7 = 7;
    public static readonly GenerationNum Gen8 = 8;
    public static readonly GenerationNum Gen9 = 9;
}

/// <summary>
/// Represents a normalized ID string used for lookups
/// </summary>
public readonly record struct ID(string Value)
{
    public static implicit operator string(ID id) => id.Value;
    public static implicit operator ID(string value) => new(value);

    public override string ToString() => Value;
}

/// <summary>
/// Pokemon type names
/// </summary>
public enum TypeName
{
    Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
    Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
    Stellar, Typeless
}

/// <summary>
/// Stat identifiers
/// </summary>
public enum StatID
{
    HP, ATK, DEF, SPA, SPD, SPE
}

/// <summary>
/// Stat identifiers excluding HP
/// </summary>
public enum StatIDExceptHP
{
    ATK, DEF, SPA, SPD, SPE
}

/// <summary>
/// Gender names
/// </summary>
public enum GenderName
{
    M, F, N
}

/// <summary>
/// Status condition names
/// </summary>
public enum StatusName
{
    None, SLP, PSN, BRN, FRZ, PAR, TOX
}

/// <summary>
/// Move categories
/// </summary>
public enum MoveCategory
{
    Physical, Special, Status
}

/// <summary>
/// Battle weather conditions
/// </summary>
public enum Weather
{
    None, Sand, Sun, Rain, Hail, Snow, HarshSunshine, HeavyRain, StrongWinds
}

/// <summary>
/// Battle terrain conditions
/// </summary>
public enum Terrain
{
    None, Electric, Grassy, Psychic, Misty
}

/// <summary>
/// Nature names
/// </summary>
public enum NatureName
{
    Adamant, Bashful, Bold, Brave, Calm, Careful, Docile, Gentle, Hardy, Hasty,
    Impish, Jolly, Lax, Lonely, Mild, Modest, Naive, Naughty, Quiet, Quirky,
    Rash, Relaxed, Sassy, Serious, Timid
}

/// <summary>
/// Type effectiveness multipliers
/// </summary>
public enum TypeEffectiveness
{
    NoEffect = 0,
    NotVeryEffective = 50,  // 0.5x stored as 50 for integer math
    Normal = 100,           // 1.0x stored as 100
    SuperEffective = 200    // 2.0x stored as 200
}

/// <summary>
/// Represents a complete stats table
/// </summary>
public readonly record struct StatsTable(
    int HP = 0,
    int ATK = 0,
    int DEF = 0,
    int SPA = 0,
    int SPD = 0,
    int SPE = 0)
{
    public int this[StatID stat] => stat switch
    {
        StatID.HP => HP,
        StatID.ATK => ATK,
        StatID.DEF => DEF,
        StatID.SPA => SPA,
        StatID.SPD => SPD,
        StatID.SPE => SPE,
        _ => throw new ArgumentOutOfRangeException(nameof(stat))
    };

    public StatsTable WithStat(StatID stat, int value) => stat switch
    {
        StatID.HP => this with { HP = value },
        StatID.ATK => this with { ATK = value },
        StatID.DEF => this with { DEF = value },
        StatID.SPA => this with { SPA = value },
        StatID.SPD => this with { SPD = value },
        StatID.SPE => this with { SPE = value },
        _ => throw new ArgumentOutOfRangeException(nameof(stat))
    };
}