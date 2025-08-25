namespace PokemonCalc;

/// <summary>
/// Main entry point for the PokemonCalc library - provides a simplified API
/// </summary>
public static class PokemonCalc
{
    /// <summary>
    /// Calculate damage between two Pokemon
    /// </summary>
    public static BattleResult Calculate(
        GenerationNum generation,
        string attackerName,
        string defenderName,
        string moveName,
        PokemonOptions? attackerOptions = null,
        PokemonOptions? defenderOptions = null,
        FieldOptions? fieldOptions = null)
    {
        var gen = GetGeneration(generation);

        var attacker = CreatePokemon(gen, attackerName, attackerOptions ?? new());
        var defender = CreatePokemon(gen, defenderName, defenderOptions ?? new());
        var move = CreateMove(gen, moveName);
        var field = CreateField(fieldOptions ?? new());

        return DamageCalculator.Calculate(gen, attacker, defender, move, field);
    }

    /// <summary>
    /// Calculate damage with full Pokemon state objects
    /// </summary>
    public static BattleResult Calculate(
        GenerationNum generation,
        PokemonState attacker,
        PokemonState defender,
        MoveState move,
        FieldState? field = null)
    {
        var gen = GetGeneration(generation);
        return DamageCalculator.Calculate(gen, attacker, defender, move, field);
    }

    /// <summary>
    /// Get a generation's data
    /// </summary>
    public static IGeneration GetGeneration(GenerationNum generation) => generation switch
    {
        GenerationNum.Gen9 => SampleData.CreateGen9(),
        // For now, all generations use Gen 9 data - in a full implementation,
        // each would have its own data set
        _ => SampleData.CreateGen9()
    };

    /// <summary>
    /// Create a Pokemon with the specified options
    /// </summary>
    public static PokemonState CreatePokemon(IGeneration generation, string name, PokemonOptions options)
    {
        return new PokemonState(
            generation,
            name,
            options.Ability,
            options.Item,
            options.Nature,
            options.Gender,
            options.Level,
            options.IVs,
            options.EVs,
            options.Boosts,
            options.Status,
            options.CurrentHP,
            options.IsDynamaxed,
            options.Moves,
            options.TeraType
        );
    }

    /// <summary>
    /// Create a move with default options
    /// </summary>
    public static MoveState CreateMove(IGeneration generation, string name, MoveOptions? options = null)
    {
        options ??= new();
        return new MoveState(
            generation,
            name,
            options.BasePower,
            options.Type,
            options.Category,
            options.PP,
            options.IsCrit,
            options.Hits,
            options.IsSpread,
            options.ZPower,
            options.MaxPower,
            options.OverrideBasePower
        );
    }

    /// <summary>
    /// Create a field with the specified options
    /// </summary>
    public static FieldState CreateField(FieldOptions options)
    {
        return new FieldState(
            options.GameType,
            options.Weather,
            options.Terrain,
            options.IsGravity,
            options.IsMagicRoom,
            options.IsWonderRoom,
            options.IsCriticalHit,
            options.AttackerSide,
            options.DefenderSide
        );
    }
}

/// <summary>
/// Options for creating a Pokemon
/// </summary>
public record PokemonOptions(
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
    int TeraType = -1
);

/// <summary>
/// Options for creating a move
/// </summary>
public record MoveOptions(
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
);

/// <summary>
/// Options for creating a field
/// </summary>
public record FieldOptions(
    GameType GameType = GameType.Singles,
    Weather? Weather = null,
    Terrain? Terrain = null,
    bool IsGravity = false,
    bool IsMagicRoom = false,
    bool IsWonderRoom = false,
    bool IsCriticalHit = false,
    SideState? AttackerSide = null,
    SideState? DefenderSide = null
);