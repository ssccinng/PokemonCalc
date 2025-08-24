# Pokemon Damage Calculator - C# Edition

A comprehensive Pokemon damage calculation library implemented in C# using functional programming principles. This library is based on the reference implementation from [smogon/damage-calc](https://github.com/smogon/damage-calc).

## Features

- **Functional Programming Style**: Immutable data structures, pure functions, and minimal side effects
- **Complete Damage Calculation**: Implements modern Pokemon damage formulas (Gen 3+)
- **Type Effectiveness**: Full type chart with dual-type support
- **Stat Calculations**: IV/EV/Nature-based stat calculations
- **Battle Conditions**: Weather, terrain, and field effects
- **Item & Ability Effects**: Support for damage-modifying items and abilities
- **Builder Pattern**: Fluent API for creating Pokemon instances
- **Extensible**: Easy to add new Pokemon, moves, abilities, and items

## Quick Start

### Basic Usage

```csharp
using PokemonCalc.Core;

// Simple damage calculation
var result = PokemonCalculator.CalculateDamage(
    attackerSpecies: "皮卡丘",
    defenderSpecies: "喷火龙",
    moveName: "十万伏特"
);

Console.WriteLine($"Damage: {result.MinDamage}-{result.MaxDamage}");
Console.WriteLine($"Type effectiveness: {result.TypeEffectiveness}x");
```

### Advanced Usage with Custom Settings

```csharp
// Custom Pokemon settings
var attackerSettings = new PokemonSettings(
    Level: 50,
    Nature: Nature.Modest,
    EVs: new StatsTable(0, 0, 0, 252, 4, 252),
    Item: "Magnet"
);

var result = PokemonCalculator.CalculateDamage(
    attackerSpecies: "皮卡丘",
    defenderSpecies: "水箭龟",
    moveName: "十万伏特",
    attackerSettings: attackerSettings
);
```

### Using the Builder Pattern

```csharp
var garchomp = PokemonCalculator.CreatePokemon()
    .WithSpecies("烈咬陆鲨")
    .WithLevel(100)
    .WithNature(Nature.Jolly)
    .WithEVs(attack: 252, speed: 252, hp: 4)
    .WithAbility("粗糙皮肤")
    .WithItem("Choice Band")
    .Build();

var result = PokemonCalculator.CalculateDamage(
    attacker: garchomp,
    defender: metagross,
    moveName: "地震"
);
```

### Battle Conditions

```csharp
var battleSettings = new BattleSettings(
    Weather: WeatherType.Rain,
    Terrain: TerrainType.Electric,
    IsCriticalHit: true
);

var result = PokemonCalculator.CalculateDamage(
    attackerSpecies: "水箭龟",
    defenderSpecies: "喷火龙", 
    moveName: "冲浪",
    battleSettings: battleSettings
);
```

## Architecture

### Core Components

- **Types.cs**: Enums for Pokemon types, stats, status conditions, etc.
- **Stats.cs**: Stat calculation functions following functional programming principles
- **Pokemon.cs**: Immutable Pokemon data structures
- **TypeChart.cs**: Type effectiveness calculations
- **DamageCalculator.cs**: Main damage calculation engine
- **PokemonCalculator.cs**: High-level API and builder patterns

### Data

- **SampleData.cs**: Sample Pokemon species for testing
- **SampleMoves.cs**: Sample moves for testing

### Functional Programming Features

1. **Immutable Data Structures**: All core types are `readonly record struct`
2. **Pure Functions**: No side effects in calculation functions
3. **Function Composition**: Damage modifiers are applied through function composition
4. **Builder Pattern**: Fluent interface for object construction
5. **Option Types**: Nullable value types for optional parameters

## Implemented Features

### Generation Support
- ✅ Gen 3+ damage formulas
- ❌ Gen 1-2 formulas (not yet implemented)

### Battle Mechanics
- ✅ Type effectiveness (full chart)
- ✅ STAB (Same Type Attack Bonus)
- ✅ Critical hits
- ✅ Weather effects (Rain, Sun, Sand, etc.)
- ✅ Terrain effects (Electric, Grassy, Psychic, Misty)
- ✅ Stat stages and boosts
- ✅ Nature modifiers

### Items & Abilities
- ✅ Type-boosting items (Charcoal, Mystic Water, etc.)
- ✅ Basic ability effects (Huge Power, Thick Fat, etc.)
- ❌ Complex ability interactions (planned)
- ❌ Z-moves and Dynamax (planned)

### Sample Data
- ✅ 6 Pokemon species (皮卡丘, 喷火龙, 水箭龟, 妙蛙花, 烈咬陆鲨, 巨金怪)
- ✅ 8 moves covering different types and categories
- ❌ Full Pokedex (would require extensive data import)

## Extending the Library

### Adding New Pokemon

```csharp
public static readonly PokemonSpecies NewPokemon = new(
    Name: "NewPokemon",
    Type1: PokemonType.Fire,
    Type2: PokemonType.Flying,
    BaseStats: new StatsTable(78, 84, 78, 109, 85, 100),
    WeightKg: 90.5,
    Abilities: new[] { "Ability1", "Ability2" }
);
```

### Adding New Moves

```csharp
public static readonly Move NewMove = new(
    Name: "New Move",
    Type: PokemonType.Fire,
    Category: MoveCategory.Special,
    BasePower: 90,
    Accuracy: 100,
    PP: 15,
    Description: "A powerful fire attack."
);
```

## Testing

The library includes comprehensive tests covering:
- Stat calculations with different natures and EVs
- Type effectiveness calculations
- Damage formulas and modifiers
- Critical hit mechanics
- Weather and terrain effects

Run tests with:
```bash
dotnet run
```

## API Reference

### Main Classes

- `PokemonCalculator`: High-level API for damage calculations
- `DamageCalculator`: Core damage calculation engine
- `Stats`: Stat calculation utilities
- `TypeChart`: Type effectiveness lookups
- `PokemonBuilder`: Fluent Pokemon creation interface

### Key Types

- `Pokemon`: Immutable Pokemon instance
- `PokemonSpecies`: Species data (base stats, types, etc.)
- `Move`: Move data (power, type, effects)
- `StatsTable`: Six Pokemon stats (HP, Atk, Def, SpA, SpD, Spe)
- `DamageResult`: Calculation results with damage range

## Future Improvements

1. **Complete Data Import**: Import full Pokemon, move, ability, and item databases
2. **Advanced Mechanics**: Z-moves, Dynamax, Tera types
3. **Complex Abilities**: Multi-turn effects, weather setting, etc.
4. **Battle Simulation**: Turn-by-turn battle calculation
5. **Performance**: Optimize for high-throughput calculations
6. **Validation**: Input validation and error handling
7. **Serialization**: JSON import/export for Pokemon teams

## Contributing

This library follows functional programming principles:
- Prefer immutable data structures
- Use pure functions without side effects
- Leverage C# record types and pattern matching
- Minimize object mutation and state changes

## License

This project is inspired by and based on the [smogon/damage-calc](https://github.com/smogon/damage-calc) TypeScript implementation.