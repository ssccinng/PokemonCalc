using PokemonCalc.Data;

namespace PokemonCalc;

// Sample data provider for testing and basic functionality
public static class SampleData
{
    /// <summary>
    /// Create a basic Generation 9 with minimal sample data
    /// </summary>
    public static IGeneration CreateGen9()
    {
        return new BasicGeneration(
            GenerationNum.Gen9,
            CreateSampleAbilities(),
            CreateSampleItems(),
            CreateSampleMoves(),
            CreateSampleSpecies(),
            CreateSampleTypes(),
            CreateSampleNatures()
        );
    }

    /// <summary>
    /// Create sample abilities
    /// </summary>
    private static IAbilities CreateSampleAbilities()
    {
        var abilities = new[]
        {
            new BasicAbility("overgrow", "Overgrow"),
            new BasicAbility("blaze", "Blaze"),
            new BasicAbility("torrent", "Torrent"),
            new BasicAbility("swarm", "Swarm"),
            new BasicAbility("guts", "Guts"),
            new BasicAbility("adaptability", "Adaptability"),
            new BasicAbility("technician", "Technician"),
            new BasicAbility("pressure", "Pressure"),
            new BasicAbility("levitate", "Levitate"),
            new BasicAbility("sturdy", "Sturdy")
        };

        return new BasicAbilities(abilities);
    }

    /// <summary>
    /// Create sample items
    /// </summary>
    private static IItems CreateSampleItems()
    {
        var items = new[]
        {
            new BasicItem("choiceband", "Choice Band"),
            new BasicItem("choicespecs", "Choice Specs"),
            new BasicItem("choicescarf", "Choice Scarf"),
            new BasicItem("lifeorb", "Life Orb"),
            new BasicItem("leftovers", "Leftovers"),
            new BasicItem("focussash", "Focus Sash"),
            new BasicItem("expertbelt", "Expert Belt"),
            new BasicItem("muscleband", "Muscle Band"),
            new BasicItem("wiseglasses", "Wise Glasses"),
            new BasicItem("charcoal", "Charcoal")
        };

        return new BasicItems(items);
    }

    /// <summary>
    /// Create sample moves
    /// </summary>
    private static IMoves CreateSampleMoves()
    {
        var moves = new[]
        {
            new BasicMove("tackle", "Tackle", 40, TypeName.Normal, MoveCategory.Physical, new MoveFlags(Contact: true)),
            new BasicMove("scratch", "Scratch", 40, TypeName.Normal, MoveCategory.Physical, new MoveFlags(Contact: true)),
            new BasicMove("earthquake", "Earthquake", 100, TypeName.Ground, MoveCategory.Physical, new MoveFlags()),
            new BasicMove("surf", "Surf", 90, TypeName.Water, MoveCategory.Special, new MoveFlags()),
            new BasicMove("flamethrower", "Flamethrower", 90, TypeName.Fire, MoveCategory.Special, new MoveFlags()),
            new BasicMove("thunderbolt", "Thunderbolt", 90, TypeName.Electric, MoveCategory.Special, new MoveFlags()),
            new BasicMove("icebeam", "Ice Beam", 90, TypeName.Ice, MoveCategory.Special, new MoveFlags()),
            new BasicMove("psychic", "Psychic", 90, TypeName.Psychic, MoveCategory.Special, new MoveFlags()),
            new BasicMove("shadowball", "Shadow Ball", 80, TypeName.Ghost, MoveCategory.Special, new MoveFlags()),
            new BasicMove("energyball", "Energy Ball", 90, TypeName.Grass, MoveCategory.Special, new MoveFlags()),
            new BasicMove("closecombat", "Close Combat", 120, TypeName.Fighting, MoveCategory.Physical, new MoveFlags(Contact: true)),
            new BasicMove("stoneedge", "Stone Edge", 100, TypeName.Rock, MoveCategory.Physical, new MoveFlags(), WillCrit: true)
        };

        return new BasicMoves(moves);
    }

    /// <summary>
    /// Create sample Pokemon species
    /// </summary>
    private static ISpecies CreateSampleSpecies()
    {
        var species = new[]
        {
            new BasicSpecie("bulbasaur", "Bulbasaur", [TypeName.Grass, TypeName.Poison],
                new StatsTable(45, 49, 49, 65, 65, 45), 6.9, true, null, null, null, "overgrow"),
            new BasicSpecie("ivysaur", "Ivysaur", [TypeName.Grass, TypeName.Poison],
                new StatsTable(60, 62, 63, 80, 80, 60), 13.0, true, null, null, null, "overgrow"),
            new BasicSpecie("venusaur", "Venusaur", [TypeName.Grass, TypeName.Poison],
                new StatsTable(80, 82, 83, 100, 100, 80), 100.0, false, null, null, null, "overgrow"),

            new BasicSpecie("charmander", "Charmander", [TypeName.Fire],
                new StatsTable(39, 52, 43, 60, 50, 65), 8.5, true, null, null, null, "blaze"),
            new BasicSpecie("charmeleon", "Charmeleon", [TypeName.Fire],
                new StatsTable(58, 64, 58, 80, 65, 80), 19.0, true, null, null, null, "blaze"),
            new BasicSpecie("charizard", "Charizard", [TypeName.Fire, TypeName.Flying],
                new StatsTable(78, 84, 78, 109, 85, 100), 90.5, false, null, null, null, "blaze"),

            new BasicSpecie("squirtle", "Squirtle", [TypeName.Water],
                new StatsTable(44, 48, 65, 50, 64, 43), 9.0, true, null, null, null, "torrent"),
            new BasicSpecie("wartortle", "Wartortle", [TypeName.Water],
                new StatsTable(59, 63, 80, 65, 80, 58), 22.5, true, null, null, null, "torrent"),
            new BasicSpecie("blastoise", "Blastoise", [TypeName.Water],
                new StatsTable(79, 83, 100, 85, 105, 78), 85.5, false, null, null, null, "torrent"),

            new BasicSpecie("pikachu", "Pikachu", [TypeName.Electric],
                new StatsTable(35, 55, 40, 50, 50, 90), 6.0, true, null, null, null, "pressure"),
            new BasicSpecie("raichu", "Raichu", [TypeName.Electric],
                new StatsTable(60, 90, 55, 90, 80, 110), 30.0, false, null, null, null, "pressure"),

            new BasicSpecie("garchomp", "Garchomp", [TypeName.Dragon, TypeName.Ground],
                new StatsTable(108, 130, 95, 80, 85, 102), 95.0, false, null, null, null, "pressure"),
            new BasicSpecie("mewtwo", "Mewtwo", [TypeName.Psychic],
                new StatsTable(106, 110, 90, 154, 90, 130), 122.0, false, null, null, null, "pressure"),
        };

        return new BasicSpecies(species);
    }

    /// <summary>
    /// Create type effectiveness chart
    /// </summary>
    private static ITypes CreateSampleTypes()
    {
        var types = new[]
        {
            CreateType(TypeName.Normal, new Dictionary<TypeName, double>
            {
                [TypeName.Rock] = 0.5,
                [TypeName.Ghost] = 0,
                [TypeName.Steel] = 0.5
            }),
            CreateType(TypeName.Fire, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Water] = 0.5,
                [TypeName.Grass] = 2,
                [TypeName.Ice] = 2,
                [TypeName.Bug] = 2,
                [TypeName.Rock] = 0.5,
                [TypeName.Dragon] = 0.5,
                [TypeName.Steel] = 2
            }),
            CreateType(TypeName.Water, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 2,
                [TypeName.Water] = 0.5,
                [TypeName.Grass] = 0.5,
                [TypeName.Ground] = 2,
                [TypeName.Rock] = 2,
                [TypeName.Dragon] = 0.5
            }),
            CreateType(TypeName.Electric, new Dictionary<TypeName, double>
            {
                [TypeName.Water] = 2,
                [TypeName.Electric] = 0.5,
                [TypeName.Grass] = 0.5,
                [TypeName.Ground] = 0,
                [TypeName.Flying] = 2,
                [TypeName.Dragon] = 0.5
            }),
            CreateType(TypeName.Grass, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Water] = 2,
                [TypeName.Grass] = 0.5,
                [TypeName.Poison] = 0.5,
                [TypeName.Ground] = 2,
                [TypeName.Rock] = 2,
                [TypeName.Bug] = 0.5,
                [TypeName.Dragon] = 0.5,
                [TypeName.Steel] = 0.5,
                [TypeName.Flying] = 0.5
            }),
            CreateType(TypeName.Ice, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Water] = 0.5,
                [TypeName.Grass] = 2,
                [TypeName.Ice] = 0.5,
                [TypeName.Ground] = 2,
                [TypeName.Flying] = 2,
                [TypeName.Dragon] = 2,
                [TypeName.Steel] = 0.5
            }),
            CreateType(TypeName.Fighting, new Dictionary<TypeName, double>
            {
                [TypeName.Normal] = 2,
                [TypeName.Ice] = 2,
                [TypeName.Poison] = 0.5,
                [TypeName.Flying] = 0.5,
                [TypeName.Psychic] = 0.5,
                [TypeName.Bug] = 0.5,
                [TypeName.Rock] = 2,
                [TypeName.Ghost] = 0,
                [TypeName.Dark] = 2,
                [TypeName.Steel] = 2,
                [TypeName.Fairy] = 0.5
            }),
            CreateType(TypeName.Poison, new Dictionary<TypeName, double>
            {
                [TypeName.Grass] = 2,
                [TypeName.Poison] = 0.5,
                [TypeName.Ground] = 0.5,
                [TypeName.Rock] = 0.5,
                [TypeName.Ghost] = 0.5,
                [TypeName.Steel] = 0,
                [TypeName.Fairy] = 2
            }),
            CreateType(TypeName.Ground, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 2,
                [TypeName.Electric] = 2,
                [TypeName.Grass] = 0.5,
                [TypeName.Poison] = 2,
                [TypeName.Flying] = 0,
                [TypeName.Bug] = 0.5,
                [TypeName.Rock] = 2,
                [TypeName.Steel] = 2
            }),
            CreateType(TypeName.Flying, new Dictionary<TypeName, double>
            {
                [TypeName.Electric] = 0.5,
                [TypeName.Grass] = 2,
                [TypeName.Fighting] = 2,
                [TypeName.Bug] = 2,
                [TypeName.Rock] = 0.5,
                [TypeName.Steel] = 0.5
            }),
            CreateType(TypeName.Psychic, new Dictionary<TypeName, double>
            {
                [TypeName.Fighting] = 2,
                [TypeName.Poison] = 2,
                [TypeName.Psychic] = 0.5,
                [TypeName.Dark] = 0,
                [TypeName.Steel] = 0.5
            }),
            CreateType(TypeName.Bug, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Grass] = 2,
                [TypeName.Fighting] = 0.5,
                [TypeName.Poison] = 0.5,
                [TypeName.Flying] = 0.5,
                [TypeName.Psychic] = 2,
                [TypeName.Ghost] = 0.5,
                [TypeName.Dark] = 2,
                [TypeName.Steel] = 0.5,
                [TypeName.Fairy] = 0.5
            }),
            CreateType(TypeName.Rock, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 2,
                [TypeName.Ice] = 2,
                [TypeName.Fighting] = 0.5,
                [TypeName.Ground] = 0.5,
                [TypeName.Flying] = 2,
                [TypeName.Bug] = 2,
                [TypeName.Steel] = 0.5
            }),
            CreateType(TypeName.Ghost, new Dictionary<TypeName, double>
            {
                [TypeName.Normal] = 0,
                [TypeName.Psychic] = 2,
                [TypeName.Ghost] = 2,
                [TypeName.Dark] = 0.5
            }),
            CreateType(TypeName.Dragon, new Dictionary<TypeName, double>
            {
                [TypeName.Dragon] = 2,
                [TypeName.Steel] = 0.5,
                [TypeName.Fairy] = 0
            }),
            CreateType(TypeName.Dark, new Dictionary<TypeName, double>
            {
                [TypeName.Fighting] = 0.5,
                [TypeName.Psychic] = 2,
                [TypeName.Ghost] = 2,
                [TypeName.Dark] = 0.5,
                [TypeName.Fairy] = 0.5
            }),
            CreateType(TypeName.Steel, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Water] = 0.5,
                [TypeName.Electric] = 0.5,
                [TypeName.Ice] = 2,
                [TypeName.Rock] = 2,
                [TypeName.Steel] = 0.5,
                [TypeName.Fairy] = 2
            }),
            CreateType(TypeName.Fairy, new Dictionary<TypeName, double>
            {
                [TypeName.Fire] = 0.5,
                [TypeName.Fighting] = 2,
                [TypeName.Poison] = 0.5,
                [TypeName.Dragon] = 2,
                [TypeName.Dark] = 2,
                [TypeName.Steel] = 0.5
            })
        };

        return new BasicTypes(types);
    }

    private static BasicType CreateType(TypeName name, Dictionary<TypeName, double> effectiveness)
    {
        return new BasicType(name.ToString().ToLowerInvariant(), name, effectiveness);
    }

    /// <summary>
    /// Create sample natures
    /// </summary>
    private static INatures CreateSampleNatures()
    {
        var natures = new[]
        {
            new BasicNature("hardy", NatureName.Hardy),
            new BasicNature("lonely", NatureName.Lonely, StatId.Attack, StatId.Defense),
            new BasicNature("brave", NatureName.Brave, StatId.Attack, StatId.Speed),
            new BasicNature("adamant", NatureName.Adamant, StatId.Attack, StatId.SpecialAttack),
            new BasicNature("naughty", NatureName.Naughty, StatId.Attack, StatId.SpecialDefense),
            new BasicNature("bold", NatureName.Bold, StatId.Defense, StatId.Attack),
            new BasicNature("docile", NatureName.Docile),
            new BasicNature("relaxed", NatureName.Relaxed, StatId.Defense, StatId.Speed),
            new BasicNature("impish", NatureName.Impish, StatId.Defense, StatId.SpecialAttack),
            new BasicNature("lax", NatureName.Lax, StatId.Defense, StatId.SpecialDefense),
            new BasicNature("timid", NatureName.Timid, StatId.Speed, StatId.Attack),
            new BasicNature("hasty", NatureName.Hasty, StatId.Speed, StatId.Defense),
            new BasicNature("serious", NatureName.Serious),
            new BasicNature("jolly", NatureName.Jolly, StatId.Speed, StatId.SpecialAttack),
            new BasicNature("naive", NatureName.Naive, StatId.Speed, StatId.SpecialDefense),
            new BasicNature("modest", NatureName.Modest, StatId.SpecialAttack, StatId.Attack),
            new BasicNature("mild", NatureName.Mild, StatId.SpecialAttack, StatId.Defense),
            new BasicNature("quiet", NatureName.Quiet, StatId.SpecialAttack, StatId.Speed),
            new BasicNature("bashful", NatureName.Bashful),
            new BasicNature("rash", NatureName.Rash, StatId.SpecialAttack, StatId.SpecialDefense),
            new BasicNature("calm", NatureName.Calm, StatId.SpecialDefense, StatId.Attack),
            new BasicNature("gentle", NatureName.Gentle, StatId.SpecialDefense, StatId.Defense),
            new BasicNature("sassy", NatureName.Sassy, StatId.SpecialDefense, StatId.Speed),
            new BasicNature("careful", NatureName.Careful, StatId.SpecialDefense, StatId.SpecialAttack),
            new BasicNature("quirky", NatureName.Quirky)
        };

        return new BasicNatures(natures);
    }
}