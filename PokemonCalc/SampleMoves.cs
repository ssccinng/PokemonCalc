namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Sample moves data for testing
/// </summary>
public static class SampleMoves
{
    public static readonly Move Thunderbolt = new(
        Name: "十万伏特",
        Type: PokemonType.Electric,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "向对手发出强力的电击。有时会让对手陷入麻痹状态。"
    );

    public static readonly Move Flamethrower = new(
        Name: "喷射火焰",
        Type: PokemonType.Fire,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "向对手喷射烈焰进行攻击。有时会让对手陷入灼伤状态。"
    );

    public static readonly Move Surf = new(
        Name: "冲浪",
        Type: PokemonType.Water,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 15,
        Description: "利用大浪攻击自己周围所有的宝可梦。"
    );

    public static readonly Move Earthquake = new(
        Name: "地震",
        Type: PokemonType.Ground,
        Category: MoveCategory.Physical,
        BasePower: 100,
        Accuracy: 100,
        PP: 10,
        Description: "引发地震，攻击自己周围所有的宝可梦。"
    );

    public static readonly Move DragonClaw = new(
        Name: "龙爪",
        Type: PokemonType.Dragon,
        Category: MoveCategory.Physical,
        BasePower: 80,
        Accuracy: 100,
        PP: 15,
        Description: "用尖锐的巨爪撕裂对手进行攻击。",
        MakesContact: true
    );

    public static readonly Move MetalClaw = new(
        Name: "金属爪",
        Type: PokemonType.Steel,
        Category: MoveCategory.Physical,
        BasePower: 50,
        Accuracy: 95,
        PP: 35,
        Description: "用钢铁之爪进行攻击。有时会提高自己的攻击。",
        MakesContact: true
    );

    public static readonly Move QuickAttack = new(
        Name: "电光一闪",
        Type: PokemonType.Normal,
        Category: MoveCategory.Physical,
        BasePower: 40,
        Accuracy: 100,
        PP: 30,
        Description: "以迅雷不及掩耳之势扑向对手。必定能够先制攻击。",
        Priority: 1,
        MakesContact: true
    );

    public static readonly Move Psychic = new(
        Name: "精神强念",
        Type: PokemonType.Psychic,
        Category: MoveCategory.Special,
        BasePower: 90,
        Accuracy: 100,
        PP: 10,
        Description: "向对手发出强大的念力进行攻击。有时会降低对手的特防。"
    );

    private static readonly Dictionary<string, Move> _movesLookup = new(StringComparer.OrdinalIgnoreCase)
    {
        { "十万伏特", Thunderbolt },
        { "喷射火焰", Flamethrower },
        { "冲浪", Surf },
        { "地震", Earthquake },
        { "龙爪", DragonClaw },
        { "金属爪", MetalClaw },
        { "电光一闪", QuickAttack },
        { "精神强念", Psychic }
    };

    public static Move? GetByName(string name) => 
        _movesLookup.TryGetValue(name, out var move) ? move : null;

    public static IEnumerable<Move> GetAll() => _movesLookup.Values;
}