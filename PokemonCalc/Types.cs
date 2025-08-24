namespace PokemonCalc.Core;

/// <summary>
/// Represents Pokemon generation numbers
/// </summary>
public enum GenerationNum
{
    RBY = 1,
    GSC = 2, 
    RSE = 3,
    DPPt = 4,
    BW = 5,
    XY = 6,
    SM = 7,
    SwSh = 8,
    SV = 9
}

/// <summary>
/// Represents Pokemon gender
/// </summary>
public enum Gender
{
    Male = 'M',
    Female = 'F', 
    Genderless = 'N'
}

/// <summary>
/// Represents Pokemon stats
/// </summary>
public enum StatId
{
    HP,
    Attack,
    Defense, 
    SpecialAttack,
    SpecialDefense,
    Speed
}

/// <summary>
/// Represents Pokemon status conditions
/// </summary>
public enum Status
{
    None,
    Sleep,
    Poison,
    Burn,
    Freeze,
    Paralysis,
    BadlyPoisoned
}

/// <summary>
/// Represents move categories
/// </summary>
public enum MoveCategory
{
    Physical,
    Special,
    Status
}

/// <summary>
/// Represents Pokemon types
/// </summary>
public enum PokemonType
{
    Normal,
    Fighting,
    Flying,
    Poison,
    Ground,
    Rock,
    Bug,
    Ghost,
    Steel,
    Fire,
    Water,
    Grass,
    Electric,
    Psychic,
    Ice,
    Dragon,
    Dark,
    Fairy,
    Stellar,
    Unknown
}

/// <summary>
/// Represents terrain types
/// </summary>
public enum TerrainType
{
    None,
    Electric,
    Grassy,
    Psychic,
    Misty
}

/// <summary>
/// Represents weather conditions
/// </summary>
public enum WeatherType
{
    None,
    Sand,
    Sun,
    Rain,
    Hail,
    Snow,
    HarshSunshine,
    HeavyRain,
    StrongWinds
}

/// <summary>
/// Represents Pokemon natures
/// </summary>
public enum Nature
{
    Adamant,
    Bashful,
    Bold,
    Brave,
    Calm,
    Careful,
    Docile,
    Gentle,
    Hardy,
    Hasty,
    Impish,
    Jolly,
    Lax,
    Lonely,
    Mild,
    Modest,
    Naive,
    Naughty,
    Quiet,
    Quirky,
    Rash,
    Relaxed,
    Sassy,
    Serious,
    Timid
}

/// <summary>
/// Represents type effectiveness values
/// </summary>
public enum TypeEffectiveness
{
    NoEffect = 0,
    NotVeryEffective = 1,
    Normal = 2,
    SuperEffective = 4
}