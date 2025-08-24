namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Sample Pokemon species data for testing
/// </summary>
public static class SampleSpecies
{
    public static readonly PokemonSpecies Pikachu = new(
        Name: "皮卡丘",
        Type1: PokemonType.Electric,
        Type2: null,
        BaseStats: new StatsTable(35, 55, 40, 50, 50, 90),
        WeightKg: 6.0,
        Abilities: new[] { "静电", "避雷针" }
    );

    public static readonly PokemonSpecies Charizard = new(
        Name: "喷火龙", 
        Type1: PokemonType.Fire,
        Type2: PokemonType.Flying,
        BaseStats: new StatsTable(78, 84, 78, 109, 85, 100),
        WeightKg: 90.5,
        Abilities: new[] { "猛火", "太阳之力" }
    );

    public static readonly PokemonSpecies Blastoise = new(
        Name: "水箭龟",
        Type1: PokemonType.Water,
        Type2: null,
        BaseStats: new StatsTable(79, 83, 100, 85, 105, 78),
        WeightKg: 85.5,
        Abilities: new[] { "激流", "雨盘" }
    );

    public static readonly PokemonSpecies Venusaur = new(
        Name: "妙蛙花",
        Type1: PokemonType.Grass,
        Type2: PokemonType.Poison,
        BaseStats: new StatsTable(80, 82, 83, 100, 100, 80),
        WeightKg: 100.0,
        Abilities: new[] { "茂盛", "叶绿素" }
    );

    public static readonly PokemonSpecies Garchomp = new(
        Name: "烈咬陆鲨",
        Type1: PokemonType.Dragon,
        Type2: PokemonType.Ground,
        BaseStats: new StatsTable(108, 130, 95, 80, 85, 102),
        WeightKg: 95.0,
        Abilities: new[] { "沙隐", "粗糙皮肤" }
    );

    public static readonly PokemonSpecies Metagross = new(
        Name: "巨金怪",
        Type1: PokemonType.Steel,
        Type2: PokemonType.Psychic,
        BaseStats: new StatsTable(80, 135, 130, 95, 90, 70),
        WeightKg: 550.0,
        Abilities: new[] { "恒净之躯", "轻金属" }
    );

    private static readonly Dictionary<string, PokemonSpecies> _speciesLookup = new(StringComparer.OrdinalIgnoreCase)
    {
        { "皮卡丘", Pikachu },
        { "喷火龙", Charizard },
        { "水箭龟", Blastoise },
        { "妙蛙花", Venusaur },
        { "烈咬陆鲨", Garchomp },
        { "巨金怪", Metagross }
    };

    public static PokemonSpecies? GetByName(string name) => 
        _speciesLookup.TryGetValue(name, out var species) ? species : null;

    public static IEnumerable<PokemonSpecies> GetAll() => _speciesLookup.Values;
}