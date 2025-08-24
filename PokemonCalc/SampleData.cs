namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Sample Pokemon species data for testing
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

    private static readonly Dictionary<string, PokemonSpecies> _speciesLookup = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Pikachu", Pikachu },
        { "Charizard", Charizard },
        { "Blastoise", Blastoise },
        { "Venusaur", Venusaur },
        { "Garchomp", Garchomp },
        { "Metagross", Metagross }
    };

    public static PokemonSpecies? GetByName(string name) => 
        _speciesLookup.TryGetValue(name, out var species) ? species : null;

    public static IEnumerable<PokemonSpecies> GetAll() => _speciesLookup.Values;
}