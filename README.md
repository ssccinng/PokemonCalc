# PokemonCalc

A functional programming-oriented Pokemon damage calculation library for .NET, inspired by the [Smogon damage calculator](https://github.com/smogon/damage-calc).

## Features

- **Functional Programming**: Immutable data structures, pure functions, and functional composition
- **Type Safety**: Strong typing with C# records and readonly structs
- **Complete Damage Calculations**: Supports all major damage mechanics including STAB, type effectiveness, critical hits, weather, and terrain
- **Generation Support**: Extensible framework for different Pokemon generation mechanics
- **Clean API**: Simple, intuitive methods for damage calculations and Pokemon creation

## Quick Start

### Basic Damage Calculation

```csharp
using PokemonCalc;

// Calculate damage from Pikachu's Thunderbolt against Charizard
var result = PokemonCalculator.CalculateDamage("Pikachu", "Charizard", "Thunderbolt");

Console.WriteLine($"Damage: {result.MinDamage}-{result.MaxDamage}");
Console.WriteLine($"Type Effectiveness: {result.TypeEffectiveness}x");
Console.WriteLine($"Description: {result.Description}");
// Output: Damage: 130-153
//         Type Effectiveness: 2x
//         Description: Pikachu Thunderbolt vs Charizard (STAB, Super Effective)
```

### Custom Pokemon Configuration

```csharp
using PokemonCalc;
using PokemonCalc.Data;

// Create a custom Garchomp with specific nature and EVs
var garchomp = PokemonCalculator.CreatePokemon(
    "Garchomp",
    level: 100,
    natureName: "Jolly",
    evs: new StatsTable(HP: 0, ATK: 252, DEF: 0, SPA: 0, SPD: 4, SPE: 252)
);

// Calculate its stats
var stats = garchomp.CalculateStats();
Console.WriteLine($"Garchomp Attack: {stats.ATK}, Speed: {stats.SPE}");
```

### Type Effectiveness

```csharp
using PokemonCalc;
using PokemonCalc.Data;

// Check type effectiveness
var effectiveness = PokemonCalculator.CalculateTypeEffectiveness(
    TypeName.Water, TypeName.Fire, TypeName.Flying);
Console.WriteLine($"Water vs Fire/Flying: {effectiveness}x"); // 2x (super effective)
```

### Battle Conditions

```csharp
using PokemonCalc;
using PokemonCalc.Models;

// Calculate damage with weather and critical hit
var field = new Field(Weather: Weather.Rain, IsCriticalHit: true);
var result = PokemonCalculator.CalculateDamage(
    "Blastoise", "Charizard", "Hydro Pump", field: field);
```

## Core Types

### Pokemon Model
```csharp
public readonly record struct Pokemon(
    Species Species,
    int Level = 100,
    Nature Nature = default,
    Ability Ability = default,
    Item Item = default,
    StatsTable IVs = default,
    StatsTable EVs = default,
    StatsTable Boosts = default,
    // ... other properties
);
```

### Damage Result
```csharp
public readonly record struct DamageResult(
    IReadOnlyList<int> DamageValues,
    double TypeEffectiveness,
    bool IsCriticalHit,
    bool HasSTAB,
    string Description = "")
{
    public int MinDamage { get; }
    public int MaxDamage { get; }
    public double AverageDamage { get; }
    
    public (double Min, double Max, double Average) GetPercentageDamage(int targetMaxHP);
}
```

## Available Data

The library includes sample data for demonstration:

### Pokemon Species
- Pikachu (Electric)
- Charizard (Fire/Flying)
- Blastoise (Water)
- Venusaur (Grass/Poison)
- Garchomp (Dragon/Ground)

### Moves
- Thunderbolt (Electric, Special, 90 BP)
- Earthquake (Ground, Physical, 100 BP)
- Flamethrower (Fire, Special, 90 BP)
- Hydro Pump (Water, Special, 110 BP)
- Solar Beam (Grass, Special, 120 BP)
- Close Combat (Fighting, Physical, 120 BP)
- Thunder Wave (Electric, Status, 0 BP)

### Other Data
- Complete type effectiveness chart
- Basic abilities, items, and natures
- Full stat calculation support

## Functional Programming Features

### Immutable Data
All core types are implemented as readonly structs or records, ensuring immutability:

```csharp
// Creating a new Pokemon with modified stats creates a new instance
var originalPokemon = PokemonCalculator.CreatePokemon("Pikachu");
var boostedPokemon = originalPokemon.WithBoost(StatID.ATK, 2);
// originalPokemon is unchanged
```

### Pure Functions
All calculations are pure functions with no side effects:

```csharp
// StatUtils.CalculateStat is a pure function
var hp = StatUtils.CalculateStat(StatID.HP, baseStat: 78, iv: 31, ev: 0, level: 100, nature);
```

### Function Composition
Complex calculations are built by composing simpler functions:

```csharp
// Damage calculation composes multiple pure functions
var damage = CalculateBaseDamage(level, basePower, attack, defense)
    .ApplySTAB(moveType, pokemonTypes)
    .ApplyTypeEffectiveness(moveType, defenderTypes)
    .ApplyCriticalHit(isCrit, generation);
```

## Architecture

The library is organized into several functional modules:

- **Data**: Type definitions, enums, and core data structures
- **Models**: Immutable Pokemon, Move, and battle state models  
- **Calculations**: Pure calculation functions and damage engine
- **Utilities**: Helper functions for stats, types, and IDs
- **PokemonCalculator**: Main API facade

## Building and Testing

```bash
# Build the library
dotnet build

# Format code
dotnet format

# Create and run a test application
dotnet new console --name TestApp
dotnet add TestApp reference path/to/PokemonCalc.csproj
dotnet run --project TestApp
```

## Requirements

- .NET 8.0 or later
- C# 12.0 features (records, readonly structs, etc.)

## License

This project is a reimplementation of Pokemon battle mechanics for educational purposes. Pokemon is a trademark of Nintendo/Game Freak.

## Contributing

This library is designed to be extended with additional Pokemon data, moves, abilities, and generation-specific mechanics. The functional architecture makes it easy to add new features without breaking existing functionality.