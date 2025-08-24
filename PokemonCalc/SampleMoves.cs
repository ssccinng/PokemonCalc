namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Sample moves data for testing
/// </summary>
public static class SampleMoves
{
    public static readonly Move Thunderbolt = new(
        Name: "Thunderbolt",
        Type: PokemonType.Electric,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "A strong electric blast that may also leave the foe paralyzed."
    );

    public static readonly Move Flamethrower = new(
        Name: "Flamethrower",
        Type: PokemonType.Fire,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "The target is scorched with an intense blast of fire."
    );

    public static readonly Move Surf = new(
        Name: "Surf",
        Type: PokemonType.Water,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "The user attacks everything around it by swamping its surroundings with a giant wave."
    );

    public static readonly Move Earthquake = new(
        Name: "Earthquake",
        Type: PokemonType.Ground,
        Category: MoveCategory.Physical,
        BasePower: 100,
        Accuracy: 100,
        PP: 10,
        Description: "The user sets off an earthquake that strikes every Pokémon around it."
    );

    public static readonly Move DragonClaw = new(
        Name: "Dragon Claw",
        Type: PokemonType.Dragon,
        Category: MoveCategory.Physical,
        BasePower: 80,
        Accuracy: 100,
        PP: 15,
        Description: "The user slashes the target with huge, sharp claws.",
        MakesContact: true
    );

    public static readonly Move MetalClaw = new(
        Name: "Metal Claw",
        Type: PokemonType.Steel,
        Category: MoveCategory.Physical,
        BasePower: 50,
        Accuracy: 95,
        PP: 35,
        Description: "The target is raked with steel claws.",
        MakesContact: true
    );

    public static readonly Move QuickAttack = new(
        Name: "Quick Attack",
        Type: PokemonType.Normal,
        Category: MoveCategory.Physical,
        BasePower: 40,
        Accuracy: 100,
        PP: 30,
        Description: "The user lunges at the target at a speed that makes it almost invisible.",
        Priority: 1,
        MakesContact: true
    );

    public static readonly Move Psychic = new(
        Name: "Psychic",
        Type: PokemonType.Psychic,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 10,
        Description: "The target is hit by a strong telekinetic force."
    );

    private static readonly Dictionary<string, Move> _movesLookup = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Thunderbolt", Thunderbolt },
        { "Flamethrower", Flamethrower },
        { "Surf", Surf },
        { "Earthquake", Earthquake },
        { "Dragon Claw", DragonClaw },
        { "Metal Claw", MetalClaw },
        { "Quick Attack", QuickAttack },
        { "Psychic", Psychic }
    };

    public static Move? GetByName(string name) => 
        _movesLookup.TryGetValue(name, out var move) ? move : null;

    public static IEnumerable<Move> GetAll() => _movesLookup.Values;
}