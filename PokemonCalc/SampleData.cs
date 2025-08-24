namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Extended Pokemon species data based on smogon/damage-calc reference
/// </summary>
public static class SampleSpecies
{
    public static readonly PokemonSpecies Pikachu = new(
        Name: "Pikachu",
        Type1: PokemonType.Electric,
        Type2: null,
        BaseStats: new StatsTable(35, 55, 40, 50, 50, 90),
        WeightKg: 6.0,
        Abilities: new[] { "Static", "Lightning Rod" }
    );

    public static readonly PokemonSpecies Charizard = new(
        Name: "Charizard",
        Type1: PokemonType.Fire,
        Type2: PokemonType.Flying,
        BaseStats: new StatsTable(78, 84, 78, 109, 85, 100),
        WeightKg: 90.5,
        Abilities: new[] { "Blaze", "Solar Power" }
    );

    public static readonly PokemonSpecies Blastoise = new(
        Name: "Blastoise",
        Type1: PokemonType.Water,
        Type2: null,
        BaseStats: new StatsTable(79, 83, 100, 85, 105, 78),
        WeightKg: 85.5,
        Abilities: new[] { "Torrent", "Rain Dish" }
    );

    public static readonly PokemonSpecies Venusaur = new(
        Name: "Venusaur",
        Type1: PokemonType.Grass,
        Type2: PokemonType.Poison,
        BaseStats: new StatsTable(80, 82, 83, 100, 100, 80),
        WeightKg: 100.0,
        Abilities: new[] { "Overgrow", "Chlorophyll" }
    );

    public static readonly PokemonSpecies Garchomp = new(
        Name: "Garchomp",
        Type1: PokemonType.Dragon,
        Type2: PokemonType.Ground,
        BaseStats: new StatsTable(108, 130, 95, 80, 85, 102),
        WeightKg: 95.0,
        Abilities: new[] { "Sand Veil", "Rough Skin" }
    );

    public static readonly PokemonSpecies Metagross = new(
        Name: "Metagross",
        Type1: PokemonType.Steel,
        Type2: PokemonType.Psychic,
        BaseStats: new StatsTable(80, 135, 130, 95, 90, 70),
        WeightKg: 550.0,
        Abilities: new[] { "Clear Body", "Light Metal" }
    );

    public static readonly PokemonSpecies Alakazam = new(
        Name: "Alakazam",
        Type1: PokemonType.Psychic,
        Type2: null,
        BaseStats: new StatsTable(55, 50, 45, 135, 95, 120),
        WeightKg: 48.0,
        Abilities: new[] { "Synchronize", "Inner Focus", "Magic Guard" }
    );

    public static readonly PokemonSpecies Gengar = new(
        Name: "Gengar",
        Type1: PokemonType.Ghost,
        Type2: PokemonType.Poison,
        BaseStats: new StatsTable(60, 65, 60, 130, 75, 110),
        WeightKg: 40.5,
        Abilities: new[] { "Levitate" }
    );

    public static readonly PokemonSpecies Machamp = new(
        Name: "Machamp",
        Type1: PokemonType.Fighting,
        Type2: null,
        BaseStats: new StatsTable(90, 130, 80, 65, 85, 55),
        WeightKg: 130.0,
        Abilities: new[] { "Guts", "No Guard", "Steadfast" }
    );

    public static readonly PokemonSpecies Dragonite = new(
        Name: "Dragonite",
        Type1: PokemonType.Dragon,
        Type2: PokemonType.Flying,
        BaseStats: new StatsTable(91, 134, 95, 100, 100, 80),
        WeightKg: 210.0,
        Abilities: new[] { "Inner Focus", "Multiscale" }
    );

    public static readonly PokemonSpecies Tyranitar = new(
        Name: "Tyranitar",
        Type1: PokemonType.Rock,
        Type2: PokemonType.Dark,
        BaseStats: new StatsTable(100, 134, 110, 95, 100, 61),
        WeightKg: 202.0,
        Abilities: new[] { "Sand Stream", "Unnerve" }
    );

    public static readonly PokemonSpecies Blaziken = new(
        Name: "Blaziken",
        Type1: PokemonType.Fire,
        Type2: PokemonType.Fighting,
        BaseStats: new StatsTable(80, 120, 70, 110, 70, 80),
        WeightKg: 52.0,
        Abilities: new[] { "Blaze", "Speed Boost" }
    );

    public static readonly PokemonSpecies Swampert = new(
        Name: "Swampert",
        Type1: PokemonType.Water,
        Type2: PokemonType.Ground,
        BaseStats: new StatsTable(100, 110, 90, 85, 90, 60),
        WeightKg: 81.9,
        Abilities: new[] { "Torrent", "Damp" }
    );

    public static readonly PokemonSpecies Sceptile = new(
        Name: "Sceptile",
        Type1: PokemonType.Grass,
        Type2: null,
        BaseStats: new StatsTable(70, 85, 65, 105, 85, 120),
        WeightKg: 52.2,
        Abilities: new[] { "Overgrow", "Unburden" }
    );

    public static readonly PokemonSpecies Lucario = new(
        Name: "Lucario",
        Type1: PokemonType.Fighting,
        Type2: PokemonType.Steel,
        BaseStats: new StatsTable(70, 110, 70, 115, 70, 90),
        WeightKg: 54.0,
        Abilities: new[] { "Steadfast", "Inner Focus", "Justified" }
    );

    public static readonly PokemonSpecies Scizor = new(
        Name: "Scizor",
        Type1: PokemonType.Bug,
        Type2: PokemonType.Steel,
        BaseStats: new StatsTable(70, 130, 100, 55, 80, 65),
        WeightKg: 118.0,
        Abilities: new[] { "Swarm", "Technician", "Light Metal" }
    );

    public static readonly PokemonSpecies Rotom = new(
        Name: "Rotom",
        Type1: PokemonType.Electric,
        Type2: PokemonType.Ghost,
        BaseStats: new StatsTable(50, 50, 77, 95, 77, 91),
        WeightKg: 0.3,
        Abilities: new[] { "Levitate" }
    );

    public static readonly PokemonSpecies Rayquaza = new(
        Name: "Rayquaza",
        Type1: PokemonType.Dragon,
        Type2: PokemonType.Flying,
        BaseStats: new StatsTable(105, 150, 90, 150, 90, 95),
        WeightKg: 206.5,
        Abilities: new[] { "Air Lock" }
    );

    public static readonly PokemonSpecies Kyogre = new(
        Name: "Kyogre",
        Type1: PokemonType.Water,
        Type2: null,
        BaseStats: new StatsTable(100, 100, 90, 150, 140, 90),
        WeightKg: 352.0,
        Abilities: new[] { "Drizzle" }
    );

    public static readonly PokemonSpecies Groudon = new(
        Name: "Groudon",
        Type1: PokemonType.Ground,
        Type2: null,
        BaseStats: new StatsTable(100, 150, 140, 100, 90, 90),
        WeightKg: 950.0,
        Abilities: new[] { "Drought" }
    );

    private static readonly Dictionary<string, PokemonSpecies> _speciesLookup = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Pikachu", Pikachu },
        { "Charizard", Charizard },
        { "Blastoise", Blastoise },
        { "Venusaur", Venusaur },
        { "Garchomp", Garchomp },
        { "Metagross", Metagross },
        { "Alakazam", Alakazam },
        { "Gengar", Gengar },
        { "Machamp", Machamp },
        { "Dragonite", Dragonite },
        { "Tyranitar", Tyranitar },
        { "Blaziken", Blaziken },
        { "Swampert", Swampert },
        { "Sceptile", Sceptile },
        { "Lucario", Lucario },
        { "Scizor", Scizor },
        { "Rotom", Rotom },
        { "Rayquaza", Rayquaza },
        { "Kyogre", Kyogre },
        { "Groudon", Groudon }
    };

    public static PokemonSpecies? GetByName(string name) => 
        _speciesLookup.TryGetValue(name, out var species) ? species : null;

    public static IEnumerable<PokemonSpecies> GetAll() => _speciesLookup.Values;
}