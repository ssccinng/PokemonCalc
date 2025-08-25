namespace PokemonCalc.Data;

// Basic data implementations using functional programming patterns
public record BasicAbility(string Id, string Name) : IAbility
{
    public DataKind Kind => DataKind.Ability;
}

public record BasicItem(string Id, string Name, string? MegaEvolves = null, bool IsBerry = false, (int BasePower, TypeName Type)? NaturalGift = null) : IItem
{
    public DataKind Kind => DataKind.Item;
}

public record BasicMove(
    string Id,
    string Name,
    int BasePower,
    TypeName Type,
    MoveCategory Category,
    MoveFlags Flags,
    MoveTarget Target = MoveTarget.Normal,
    (int, int)? Recoil = null,
    bool HasCrashDamage = false,
    bool WillCrit = false,
    (int, int)? Drain = null,
    int Priority = 0,
    bool IgnoreDefensive = false,
    StatId? OverrideOffensiveStat = null,
    StatId? OverrideDefensiveStat = null,
    bool BreaksProtect = false,
    bool IsZ = false,
    bool IsMax = false,
    int[]? Multihit = null
) : IMove
{
    public DataKind Kind => DataKind.Move;
}

public record BasicSpecie(
    string Id,
    string Name,
    TypeName[] Types,
    StatsTable BaseStats,
    double WeightKg,
    bool IsNfe = false,
    GenderName? Gender = null,
    string[]? OtherFormes = null,
    string? BaseSpecies = null,
    string? PrimaryAbility = null
) : ISpecie
{
    public DataKind Kind => DataKind.Species;
}

public record BasicType(string Id, TypeName Name, IReadOnlyDictionary<TypeName, double> Effectiveness) : IType
{
    public DataKind Kind => DataKind.Type;
}

public record BasicNature(string Id, NatureName Name, StatId? Plus = null, StatId? Minus = null) : INature
{
    public DataKind Kind => DataKind.Nature;
}

// Collection implementations
public class BasicAbilities : IAbilities
{
    private readonly Dictionary<string, IAbility> _abilities = new();

    public BasicAbilities(IEnumerable<IAbility> abilities)
    {
        foreach (var ability in abilities)
        {
            _abilities[ability.Id] = ability;
        }
    }

    public IAbility? Get(string id) => _abilities.TryGetValue(id, out var ability) ? ability : null;

    public IEnumerator<IAbility> GetEnumerator() => _abilities.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public class BasicItems : IItems
{
    private readonly Dictionary<string, IItem> _items = new();

    public BasicItems(IEnumerable<IItem> items)
    {
        foreach (var item in items)
        {
            _items[item.Id] = item;
        }
    }

    public IItem? Get(string id) => _items.TryGetValue(id, out var item) ? item : null;

    public IEnumerator<IItem> GetEnumerator() => _items.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public class BasicMoves : IMoves
{
    private readonly Dictionary<string, IMove> _moves = new();

    public BasicMoves(IEnumerable<IMove> moves)
    {
        foreach (var move in moves)
        {
            _moves[move.Id] = move;
        }
    }

    public IMove? Get(string id) => _moves.TryGetValue(id, out var move) ? move : null;

    public IEnumerator<IMove> GetEnumerator() => _moves.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public class BasicSpecies : ISpecies
{
    private readonly Dictionary<string, ISpecie> _species = new();

    public BasicSpecies(IEnumerable<ISpecie> species)
    {
        foreach (var specie in species)
        {
            _species[specie.Id] = specie;
        }
    }

    public ISpecie? Get(string id) => _species.TryGetValue(id, out var specie) ? specie : null;

    public IEnumerator<ISpecie> GetEnumerator() => _species.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public class BasicTypes : ITypes
{
    private readonly Dictionary<string, IType> _types = new();

    public BasicTypes(IEnumerable<IType> types)
    {
        foreach (var type in types)
        {
            _types[type.Id] = type;
        }
    }

    public IType? Get(string id) => _types.TryGetValue(id, out var type) ? type : null;

    public IEnumerator<IType> GetEnumerator() => _types.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public class BasicNatures : INatures
{
    private readonly Dictionary<string, INature> _natures = new();

    public BasicNatures(IEnumerable<INature> natures)
    {
        foreach (var nature in natures)
        {
            _natures[nature.Id] = nature;
        }
    }

    public INature? Get(string id) => _natures.TryGetValue(id, out var nature) ? nature : null;

    public IEnumerator<INature> GetEnumerator() => _natures.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

// Generation implementation
public record BasicGeneration(
    GenerationNum Num,
    IAbilities Abilities,
    IItems Items,
    IMoves Moves,
    ISpecies Species,
    ITypes Types,
    INatures Natures
) : IGeneration;