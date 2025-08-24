namespace PokemonCalc.Core;

using PokemonCalc.Data;

/// <summary>
/// Builder for creating Pokemon instances with a fluent interface
/// </summary>
public class PokemonBuilder
{
    private PokemonSpecies? _species;
    private int _level = 100;
    private Nature _nature = Nature.Serious;
    private StatsTable _ivs = StatsTable.WithDefault(31);
    private StatsTable _evs = StatsTable.WithDefault(0);
    private string? _ability;
    private string? _item;
    private Status _status = Status.None;
    private Gender _gender = Gender.Male;
    private PokemonType? _teraType;
    private StatsTable _statStages = StatsTable.WithDefault(0);

    public PokemonBuilder WithSpecies(string speciesName)
    {
        _species = SampleSpecies.GetByName(speciesName);
        if (_species == null)
            throw new ArgumentException($"Unknown species: {speciesName}");
        return this;
    }

    public PokemonBuilder WithLevel(int level)
    {
        _level = level;
        return this;
    }

    public PokemonBuilder WithNature(Nature nature)
    {
        _nature = nature;
        return this;
    }

    public PokemonBuilder WithIVs(int hp = 31, int attack = 31, int defense = 31, 
        int specialAttack = 31, int specialDefense = 31, int speed = 31)
    {
        _ivs = new StatsTable(hp, attack, defense, specialAttack, specialDefense, speed);
        return this;
    }

    public PokemonBuilder WithEVs(int hp = 0, int attack = 0, int defense = 0,
        int specialAttack = 0, int specialDefense = 0, int speed = 0)
    {
        _evs = new StatsTable(hp, attack, defense, specialAttack, specialDefense, speed);
        return this;
    }

    public PokemonBuilder WithAbility(string ability)
    {
        _ability = ability;
        return this;
    }

    public PokemonBuilder WithItem(string item)
    {
        _item = item;
        return this;
    }

    public PokemonBuilder WithStatus(Status status)
    {
        _status = status;
        return this;
    }

    public PokemonBuilder WithGender(Gender gender)
    {
        _gender = gender;
        return this;
    }

    public PokemonBuilder WithTeraType(PokemonType teraType)
    {
        _teraType = teraType;
        return this;
    }

    public PokemonBuilder WithStatStage(StatId stat, int stage)
    {
        _statStages = _statStages.WithStat(stat, stage);
        return this;
    }

    public Pokemon Build()
    {
        if (_species == null)
            throw new InvalidOperationException("Species must be set before building Pokemon");

        return new Pokemon(
            Species: _species.Value,
            Level: _level,
            Nature: _nature,
            IVs: _ivs,
            EVs: _evs,
            Ability: _ability,
            Item: _item,
            Status: _status,
            Gender: _gender,
            TeraType: _teraType,
            StatStages: _statStages
        );
    }
}

/// <summary>
/// Main API for Pokemon damage calculations
/// </summary>
public static class PokemonCalculator
{
    /// <summary>
    /// Create a new Pokemon builder
    /// </summary>
    public static PokemonBuilder CreatePokemon() => new();

    /// <summary>
    /// Calculate damage between two Pokemon with specified moves
    /// </summary>
    public static DamageResult CalculateDamage(
        string attackerSpecies,
        string defenderSpecies,
        string moveName,
        PokemonSettings? attackerSettings = null,
        PokemonSettings? defenderSettings = null,
        BattleSettings? battleSettings = null)
    {
        var attacker = BuildPokemon(attackerSpecies, attackerSettings);
        var defender = BuildPokemon(defenderSpecies, defenderSettings);
        var move = AllMoves.GetByName(moveName) 
            ?? throw new ArgumentException($"Unknown move: {moveName}");

        var field = new Field(
            Weather: battleSettings?.Weather ?? WeatherType.None,
            Terrain: battleSettings?.Terrain ?? TerrainType.None,
            TrickRoom: battleSettings?.TrickRoom ?? false
        );

        return DamageCalculator.CalculateDamage(
            attacker, 
            defender, 
            move, 
            field, 
            battleSettings?.IsCriticalHit ?? false,
            battleSettings?.Generation ?? GenerationNum.SV
        );
    }

    /// <summary>
    /// Calculate damage with fully configured Pokemon instances
    /// </summary>
    public static DamageResult CalculateDamage(
        Pokemon attacker,
        Pokemon defender,
        string moveName,
        BattleSettings? battleSettings = null)
    {
        var move = AllMoves.GetByName(moveName)
            ?? throw new ArgumentException($"Unknown move: {moveName}");

        var field = new Field(
            Weather: battleSettings?.Weather ?? WeatherType.None,
            Terrain: battleSettings?.Terrain ?? TerrainType.None,
            TrickRoom: battleSettings?.TrickRoom ?? false
        );

        return DamageCalculator.CalculateDamage(
            attacker,
            defender,
            move,
            field,
            battleSettings?.IsCriticalHit ?? false,
            battleSettings?.Generation ?? GenerationNum.SV
        );
    }

    private static Pokemon BuildPokemon(string speciesName, PokemonSettings? settings)
    {
        var builder = CreatePokemon().WithSpecies(speciesName);

        if (settings != null)
        {
            if (settings.Level.HasValue)
                builder = builder.WithLevel(settings.Level.Value);
            if (settings.Nature.HasValue)
                builder = builder.WithNature(settings.Nature.Value);
            if (settings.Ability != null)
                builder = builder.WithAbility(settings.Ability);
            if (settings.Item != null)
                builder = builder.WithItem(settings.Item);
            if (settings.Status.HasValue)
                builder = builder.WithStatus(settings.Status.Value);
            if (settings.TeraType.HasValue)
                builder = builder.WithTeraType(settings.TeraType.Value);

            if (settings.IVs != null)
            {
                var ivs = settings.IVs.Value;
                builder = builder.WithIVs(
                    ivs.HP, ivs.Attack, ivs.Defense,
                    ivs.SpecialAttack, ivs.SpecialDefense, ivs.Speed);
            }

            if (settings.EVs != null)
            {
                var evs = settings.EVs.Value;
                builder = builder.WithEVs(
                    evs.HP, evs.Attack, evs.Defense,
                    evs.SpecialAttack, evs.SpecialDefense, evs.Speed);
            }
        }

        return builder.Build();
    }

    /// <summary>
    /// Get available Pokemon species names
    /// </summary>
    public static IEnumerable<string> GetAvailableSpecies() => 
        SampleSpecies.GetAll().Select(s => s.Name);

    /// <summary>
    /// Get available move names
    /// </summary>
    public static IEnumerable<string> GetAvailableMoves() => 
        AllMoves.GetAll().Select(m => m.Name);

    /// <summary>
    /// Get available ability names
    /// </summary>
    public static IEnumerable<string> GetAvailableAbilities() => 
        AllAbilities.GetAll().Select(a => a.Name);

    /// <summary>
    /// Get available item names
    /// </summary>
    public static IEnumerable<string> GetAvailableItems() => 
        AllItems.GetAll().Select(i => i.Name);
}

/// <summary>
/// Settings for configuring a Pokemon
/// </summary>
public record PokemonSettings(
    int? Level = null,
    Nature? Nature = null,
    StatsTable? IVs = null,
    StatsTable? EVs = null,
    string? Ability = null,
    string? Item = null,
    Status? Status = null,
    PokemonType? TeraType = null
);

/// <summary>
/// Settings for battle conditions
/// </summary>
public record BattleSettings(
    WeatherType Weather = WeatherType.None,
    TerrainType Terrain = TerrainType.None,
    bool TrickRoom = false,
    bool IsCriticalHit = false,
    GenerationNum Generation = GenerationNum.SV
);