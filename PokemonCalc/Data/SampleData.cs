using PokemonCalc.Data;
using PokemonCalc.Models;
using PokemonCalc.Utilities;

namespace PokemonCalc.Data;

/// <summary>
/// Sample data repository containing basic Pokemon data
/// </summary>
public static class SampleData
{
    /// <summary>
    /// Basic type effectiveness chart (simplified)
    /// </summary>
    public static readonly IReadOnlyDictionary<TypeName, IReadOnlyDictionary<TypeName, TypeEffectiveness>> TypeChart =
        new Dictionary<TypeName, IReadOnlyDictionary<TypeName, TypeEffectiveness>>
        {
            [TypeName.Fire] = new Dictionary<TypeName, TypeEffectiveness>
            {
                [TypeName.Grass] = TypeEffectiveness.SuperEffective,
                [TypeName.Ice] = TypeEffectiveness.SuperEffective,
                [TypeName.Bug] = TypeEffectiveness.SuperEffective,
                [TypeName.Steel] = TypeEffectiveness.SuperEffective,
                [TypeName.Fire] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Water] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Rock] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Dragon] = TypeEffectiveness.NotVeryEffective
            },
            [TypeName.Water] = new Dictionary<TypeName, TypeEffectiveness>
            {
                [TypeName.Fire] = TypeEffectiveness.SuperEffective,
                [TypeName.Ground] = TypeEffectiveness.SuperEffective,
                [TypeName.Rock] = TypeEffectiveness.SuperEffective,
                [TypeName.Water] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Grass] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Dragon] = TypeEffectiveness.NotVeryEffective
            },
            [TypeName.Grass] = new Dictionary<TypeName, TypeEffectiveness>
            {
                [TypeName.Water] = TypeEffectiveness.SuperEffective,
                [TypeName.Ground] = TypeEffectiveness.SuperEffective,
                [TypeName.Rock] = TypeEffectiveness.SuperEffective,
                [TypeName.Fire] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Grass] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Poison] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Flying] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Bug] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Dragon] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Steel] = TypeEffectiveness.NotVeryEffective
            },
            [TypeName.Electric] = new Dictionary<TypeName, TypeEffectiveness>
            {
                [TypeName.Water] = TypeEffectiveness.SuperEffective,
                [TypeName.Flying] = TypeEffectiveness.SuperEffective,
                [TypeName.Electric] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Grass] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Dragon] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Ground] = TypeEffectiveness.NoEffect
            },
            [TypeName.Fighting] = new Dictionary<TypeName, TypeEffectiveness>
            {
                [TypeName.Normal] = TypeEffectiveness.SuperEffective,
                [TypeName.Ice] = TypeEffectiveness.SuperEffective,
                [TypeName.Rock] = TypeEffectiveness.SuperEffective,
                [TypeName.Dark] = TypeEffectiveness.SuperEffective,
                [TypeName.Steel] = TypeEffectiveness.SuperEffective,
                [TypeName.Poison] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Flying] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Psychic] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Bug] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Fairy] = TypeEffectiveness.NotVeryEffective,
                [TypeName.Ghost] = TypeEffectiveness.NoEffect
            }
        };

    /// <summary>
    /// Sample Pokemon species
    /// </summary>
    public static readonly IReadOnlyDictionary<ID, Species> Species = new Dictionary<ID, Species>
    {
        [IDUtils.ToID("Pikachu")] = new Species(
            IDUtils.ToID("Pikachu"),
            "Pikachu",
            TypeName.Electric,
            null,
            new StatsTable(35, 55, 40, 50, 50, 90),
            6.0,
            Abilities: new[] { "Static", "Lightning Rod" }
        ),
        [IDUtils.ToID("Charizard")] = new Species(
            IDUtils.ToID("Charizard"),
            "Charizard",
            TypeName.Fire,
            TypeName.Flying,
            new StatsTable(78, 84, 78, 109, 85, 100),
            90.5,
            Abilities: new[] { "Blaze", "Solar Power" }
        ),
        [IDUtils.ToID("Blastoise")] = new Species(
            IDUtils.ToID("Blastoise"),
            "Blastoise",
            TypeName.Water,
            null,
            new StatsTable(79, 83, 100, 85, 105, 78),
            85.5,
            Abilities: new[] { "Torrent", "Rain Dish" }
        ),
        [IDUtils.ToID("Venusaur")] = new Species(
            IDUtils.ToID("Venusaur"),
            "Venusaur",
            TypeName.Grass,
            TypeName.Poison,
            new StatsTable(80, 82, 83, 100, 100, 80),
            100.0,
            Abilities: new[] { "Overgrow", "Chlorophyll" }
        ),
        [IDUtils.ToID("Garchomp")] = new Species(
            IDUtils.ToID("Garchomp"),
            "Garchomp",
            TypeName.Dragon,
            TypeName.Ground,
            new StatsTable(108, 130, 95, 80, 85, 102),
            95.0,
            Abilities: new[] { "Sand Veil", "Rough Skin" }
        )
    };

    /// <summary>
    /// Sample moves
    /// </summary>
    public static readonly IReadOnlyDictionary<ID, Move> Moves = new Dictionary<ID, Move>
    {
        [IDUtils.ToID("Thunderbolt")] = new Move(
            IDUtils.ToID("Thunderbolt"),
            "Thunderbolt",
            TypeName.Electric,
            MoveCategory.Special,
            90
        ),
        [IDUtils.ToID("Earthquake")] = new Move(
            IDUtils.ToID("Earthquake"),
            "Earthquake",
            TypeName.Ground,
            MoveCategory.Physical,
            100
        ),
        [IDUtils.ToID("Flamethrower")] = new Move(
            IDUtils.ToID("Flamethrower"),
            "Flamethrower",
            TypeName.Fire,
            MoveCategory.Special,
            90
        ),
        [IDUtils.ToID("Hydro Pump")] = new Move(
            IDUtils.ToID("Hydro Pump"),
            "Hydro Pump",
            TypeName.Water,
            MoveCategory.Special,
            110
        ),
        [IDUtils.ToID("Solar Beam")] = new Move(
            IDUtils.ToID("Solar Beam"),
            "Solar Beam",
            TypeName.Grass,
            MoveCategory.Special,
            120
        ),
        [IDUtils.ToID("Close Combat")] = new Move(
            IDUtils.ToID("Close Combat"),
            "Close Combat",
            TypeName.Fighting,
            MoveCategory.Physical,
            120,
            IsContact: true
        ),
        [IDUtils.ToID("Thunder Wave")] = new Move(
            IDUtils.ToID("Thunder Wave"),
            "Thunder Wave",
            TypeName.Electric,
            MoveCategory.Status,
            0
        )
    };

    /// <summary>
    /// Sample abilities
    /// </summary>
    public static readonly IReadOnlyDictionary<ID, Ability> Abilities = new Dictionary<ID, Ability>
    {
        [IDUtils.ToID("Static")] = new Ability(
            IDUtils.ToID("Static"),
            "Static",
            "Contact with the Pokémon may cause paralysis."
        ),
        [IDUtils.ToID("Blaze")] = new Ability(
            IDUtils.ToID("Blaze"),
            "Blaze",
            "Powers up Fire-type moves when the Pokémon's HP is low."
        ),
        [IDUtils.ToID("Torrent")] = new Ability(
            IDUtils.ToID("Torrent"),
            "Torrent",
            "Powers up Water-type moves when the Pokémon's HP is low."
        ),
        [IDUtils.ToID("Overgrow")] = new Ability(
            IDUtils.ToID("Overgrow"),
            "Overgrow",
            "Powers up Grass-type moves when the Pokémon's HP is low."
        ),
        [IDUtils.ToID("Sand Veil")] = new Ability(
            IDUtils.ToID("Sand Veil"),
            "Sand Veil",
            "Boosts the Pokémon's evasiveness in a sandstorm."
        )
    };

    /// <summary>
    /// Sample items
    /// </summary>
    public static readonly IReadOnlyDictionary<ID, Item> Items = new Dictionary<ID, Item>
    {
        [IDUtils.ToID("Leftovers")] = new Item(
            IDUtils.ToID("Leftovers"),
            "Leftovers",
            Description: "Restores a little HP each turn."
        ),
        [IDUtils.ToID("Choice Band")] = new Item(
            IDUtils.ToID("Choice Band"),
            "Choice Band",
            Description: "Boosts Attack, but allows the use of only one move."
        ),
        [IDUtils.ToID("Life Orb")] = new Item(
            IDUtils.ToID("Life Orb"),
            "Life Orb",
            Description: "Boosts the power of moves, but at the cost of some HP on each hit."
        ),
        [IDUtils.ToID("Charizardite X")] = new Item(
            IDUtils.ToID("Charizardite X"),
            "Charizardite X",
            IsMegaStone: true,
            MegaEvolves: "Charizard",
            Description: "Allows Charizard to Mega Evolve into Mega Charizard X."
        )
    };

    /// <summary>
    /// Sample natures
    /// </summary>
    public static readonly IReadOnlyDictionary<ID, Nature> Natures = new Dictionary<ID, Nature>
    {
        [IDUtils.ToID("Adamant")] = new Nature(
            IDUtils.ToID("Adamant"),
            "Adamant",
            StatIDExceptHP.ATK,
            StatIDExceptHP.SPA
        ),
        [IDUtils.ToID("Modest")] = new Nature(
            IDUtils.ToID("Modest"),
            "Modest",
            StatIDExceptHP.SPA,
            StatIDExceptHP.ATK
        ),
        [IDUtils.ToID("Jolly")] = new Nature(
            IDUtils.ToID("Jolly"),
            "Jolly",
            StatIDExceptHP.SPE,
            StatIDExceptHP.SPA
        ),
        [IDUtils.ToID("Timid")] = new Nature(
            IDUtils.ToID("Timid"),
            "Timid",
            StatIDExceptHP.SPE,
            StatIDExceptHP.ATK
        ),
        [IDUtils.ToID("Serious")] = new Nature(
            IDUtils.ToID("Serious"),
            "Serious"
        )
    };

    /// <summary>
    /// Get a species by name
    /// </summary>
    public static Species? GetSpecies(string name) =>
        Species.TryGetValue(IDUtils.ToID(name), out var species) ? species : null;

    /// <summary>
    /// Get a move by name
    /// </summary>
    public static Move? GetMove(string name) =>
        Moves.TryGetValue(IDUtils.ToID(name), out var move) ? move : null;

    /// <summary>
    /// Get an ability by name
    /// </summary>
    public static Ability? GetAbility(string name) =>
        Abilities.TryGetValue(IDUtils.ToID(name), out var ability) ? ability : null;

    /// <summary>
    /// Get an item by name
    /// </summary>
    public static Item? GetItem(string name) =>
        Items.TryGetValue(IDUtils.ToID(name), out var item) ? item : null;

    /// <summary>
    /// Get a nature by name
    /// </summary>
    public static Nature? GetNature(string name) =>
        Natures.TryGetValue(IDUtils.ToID(name), out var nature) ? nature : null;
}