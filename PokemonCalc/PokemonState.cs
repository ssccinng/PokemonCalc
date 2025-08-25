namespace PokemonCalc;

// Pokemon state representation - immutable functional style
public record PokemonState(
    IGeneration Generation,
    string Name,
    string? Ability = null,
    string? Item = null,
    NatureName Nature = NatureName.Hardy,
    GenderName Gender = GenderName.N,
    int Level = 100,
    StatsTable? IVs = null,
    StatsTable? EVs = null,
    PartialStatsTable? Boosts = null,
    StatusName? Status = null,
    int? CurrentHP = null,
    bool IsDynamaxed = false,
    string[]? Moves = null,
    int TeraType = -1 // -1 means no Tera type
)
{
    public StatsTable GetIVs() => IVs ?? new StatsTable(31, 31, 31, 31, 31, 31);
    public StatsTable GetEVs() => EVs ?? new StatsTable();
    public PartialStatsTable GetBoosts() => Boosts ?? new PartialStatsTable();

    public ISpecie? Species => Generation.Species.Get(Utils.ToId(Name));
}

// Move state representation  
public record MoveState(
    IGeneration Generation,
    string Name,
    int? BasePower = null,
    TypeName? Type = null,
    MoveCategory? Category = null,
    int? PP = null,
    bool IsCrit = false,
    int? Hits = null,
    bool IsSpread = false,
    int? ZPower = null,
    int? MaxPower = null,
    string? OverrideBasePower = null
)
{
    public IMove? Move => Generation.Moves.Get(Utils.ToId(Name));
}

// Field conditions state
public record FieldState(
    GameType GameType = GameType.Singles,
    Weather? Weather = null,
    Terrain? Terrain = null,
    bool IsGravity = false,
    bool IsMagicRoom = false,
    bool IsWonderRoom = false,
    bool IsCriticalHit = false,
    SideState? AttackerSide = null,
    SideState? DefenderSide = null
)
{
    public SideState GetAttackerSide() => AttackerSide ?? new SideState();
    public SideState GetDefenderSide() => DefenderSide ?? new SideState();
}

// Side conditions
public record SideState(
    bool IsReflect = false,
    bool IsLightScreen = false,
    bool IsAuroraVeil = false,
    bool IsProtected = false,
    bool IsSeeded = false,
    bool IsForesight = false,
    bool IsHelpingHand = false,
    bool IsFriendGuard = false,
    int Spikes = 0,
    int ToxicSpikes = 0,
    bool IsSteelsurge = false,
    bool IsStickyWeb = false,
    bool IsTailwind = false,
    bool IsBattery = false,
    bool IsPowerSpot = false
);

// Utility functions
public static class Utils
{
    public static string ToId(string name) =>
        name.ToLowerInvariant()
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("'", "")
            .Replace(".", "")
            .Replace("%", "");

    public static int GetStatValue(StatsTable stats, StatId stat) => stat switch
    {
        StatId.HP => stats.HP,
        StatId.Attack => stats.Attack,
        StatId.Defense => stats.Defense,
        StatId.SpecialAttack => stats.SpecialAttack,
        StatId.SpecialDefense => stats.SpecialDefense,
        StatId.Speed => stats.Speed,
        _ => throw new ArgumentException($"Invalid stat: {stat}")
    };

    public static int? GetPartialStatValue(PartialStatsTable stats, StatId stat) => stat switch
    {
        StatId.HP => stats.HP,
        StatId.Attack => stats.Attack,
        StatId.Defense => stats.Defense,
        StatId.SpecialAttack => stats.SpecialAttack,
        StatId.SpecialDefense => stats.SpecialDefense,
        StatId.Speed => stats.Speed,
        _ => throw new ArgumentException($"Invalid stat: {stat}")
    };
}