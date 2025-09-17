# PokemonCalc .NET Class Library

PokemonCalc is a .NET 9.0 class library project containing Pokemon calculation functionality. The codebase is built using modern .NET SDK tools and follows standard C# library patterns.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Domain Context & Purpose

This library is designed to provide Pokemon battle calculation functionality, similar to Smogon's damage calculator. Core areas include:

- **Damage Calculations**: Physical/Special attack damage with modifiers (STAB, type effectiveness, weather, abilities, items)
- **Pokemon Data Models**: Species stats, types, abilities, moves, natures, items
- **Battle Mechanics**: Status effects, boosts, field conditions, generation-specific mechanics
- **Stat Calculations**: Base stats + IVs/EVs + nature + level → final stats

Reference implementation patterns from: https://github.com/smogon/damage-calc/tree/master/calc/src

### Key Pokemon Concepts to Model
- **Pokemon**: Species, level, nature, ability, item, stats (HP/Atk/Def/SpA/SpD/Spe), IVs, EVs, status
- **Moves**: Base power, type, category (Physical/Special/Status), accuracy, effects
- **Battle Context**: Weather, terrain, field effects, generation rules
- **Type System**: 18 types with effectiveness multipliers (0x, 0.5x, 1x, 2x)

## Working Effectively

### Prerequisites and Environment Setup
- Ensure .NET 9.0 SDK is installed: `dotnet --list-sdks` should show 9.0.x
- If only .NET 8.0 is available, temporarily modify `PokemonCalc/PokemonCalc.csproj` to target `net8.0` instead of `net9.0`
- The project requires no additional dependencies beyond the .NET SDK

### Building the Project
- Clean build artifacts: `dotnet clean` -- takes < 1 second. NEVER CANCEL.
- Build Debug configuration: `dotnet build` -- takes 10 seconds. NEVER CANCEL. Set timeout to 30+ seconds.
- Build Release configuration: `dotnet build --configuration Release` -- takes 2 seconds. NEVER CANCEL. Set timeout to 15+ seconds.
- **CRITICAL TIMING**: Build commands typically complete in under 15 seconds, but ALWAYS set timeouts to 30+ seconds to account for network delays during package restore.

### Code Quality and Formatting
- Format code: `dotnet format --verbosity normal` -- takes 8 seconds. NEVER CANCEL. Set timeout to 30+ seconds.
- Verify no formatting changes needed: `dotnet format --verify-no-changes`
- Always run `dotnet format` before committing changes to ensure consistent code style.

### Testing
- Run tests: `dotnet test --verbosity normal` -- takes < 1 second (no tests currently defined). NEVER CANCEL. Set timeout to 15+ seconds.
- Currently no unit tests are defined in the project. The project builds successfully but contains only a placeholder `Class1` class.

### Packaging
- Create NuGet package: `dotnet pack --verbosity normal` -- takes 3 seconds. NEVER CANCEL. Set timeout to 15+ seconds.
- Packages are created in `PokemonCalc/bin/Release/` directory as `.nupkg` files.
- Warning: Package will show missing README warning - this is expected for the current state.

## Validation and Testing

### Manual Validation Requirements
After making any changes to the library:

1. **Build Validation**: 
   - Run `dotnet clean && dotnet build` to ensure clean compilation
   - Verify both Debug and Release configurations build successfully

2. **Library Usage Test**:
   - Create a test console application: `dotnet new console --name TestApp --framework net8.0` (or net9.0 if available)
   - Add reference: `dotnet add TestApp reference path/to/PokemonCalc.csproj`
   - Test instantiation: Create and use instances of PokemonCalc classes in the test app
   - Run test app: `dotnet run --project TestApp` -- takes 2-3 seconds. NEVER CANCEL.

3. **Code Quality Check**:
   - Always run `dotnet format` before committing
   - Verify no formatting changes are needed with `dotnet format --verify-no-changes`

### Framework Compatibility Notes
- **CRITICAL**: Project targets .NET 9.0 but may need to run on .NET 8.0 in CI/CD environments
- If build fails with "does not support targeting .NET 9.0", temporarily change target framework:
  - Edit `PokemonCalc/PokemonCalc.csproj`
  - Change `<TargetFramework>net9.0</TargetFramework>` to `<TargetFramework>net8.0</TargetFramework>`
  - Remember to revert this change before final commit if working with .NET 9.0 environment

## Repository Structure

### Project Layout
```
PokemonCalc/
├── .git/
├── .gitattributes          # Git configuration for line endings and file handling
├── .gitignore             # Standard Visual Studio .gitignore
├── PokemonCalc.sln        # Solution file (Visual Studio 2017+ format)
└── PokemonCalc/
    ├── Class1.cs          # Main library class (currently placeholder)
    └── PokemonCalc.csproj # Project file targeting .NET 9.0
```

### Key Files
- **PokemonCalc.sln**: Visual Studio solution file containing project references
- **PokemonCalc/PokemonCalc.csproj**: Main project file with .NET 9.0 target, nullable enabled, implicit usings enabled
- **PokemonCalc/Class1.cs**: Currently contains empty `Class1` placeholder - this is where main functionality should be implemented

## Common Workflows

### Development Cycle
1. Make code changes to `.cs` files in `PokemonCalc/` directory
2. Run `dotnet build` to verify compilation (10 seconds)
3. Run `dotnet format` to ensure code style compliance (8 seconds)
4. Test changes with a simple console application that references the library
5. Run full validation: `dotnet clean && dotnet build --configuration Release && dotnet pack`

### Before Committing
- Always run `dotnet format` to ensure consistent formatting
- Verify build succeeds in both Debug and Release configurations
- If working with .NET 8.0 environment, test with target framework temporarily changed to `net8.0`
- Ensure any new public APIs are properly documented with XML comments
- **Pokemon-specific**: Validate calculations against known expected results when possible
- **API Design**: Follow C# naming conventions (PascalCase for public members, camelCase for parameters)

## API Design Guidelines

### Pokemon-Specific Patterns
- Use `enum` for fixed sets like `PokemonType`, `Nature`, `StatusCondition`
- Use `readonly struct` for value types like `Stats`, `Individual Values (IVs)`, `Effort Values (EVs)`
- Use `class` for complex entities like `Pokemon`, `Move`, `BattleContext`
- Implement `IEquatable<T>` for value types that need comparison
- Use nullable reference types (`string?`, `Pokemon?`) for optional properties

### Naming Conventions
- **Classes**: `Pokemon`, `DamageCalculator`, `BattleField`, `TypeEffectiveness`
- **Properties**: `BaseAttack`, `CurrentHP`, `IsShiny`, `HasStatusCondition`
- **Methods**: `CalculateDamage()`, `ApplyStatusEffect()`, `GetTypeEffectiveness()`
- **Events**: `StatsChanged`, `HPUpdated`, `StatusApplied`

### Input Validation
- Always validate Pokemon level (1-100), stats (0-65535), IVs (0-31), EVs (0-252, max 510 total)
- Throw `ArgumentOutOfRangeException` for invalid ranges
- Throw `ArgumentException` for invalid combinations (e.g., incompatible ability + species)
- Use `ArgumentNullException.ThrowIfNull()` for required reference parameters

### Calculation Accuracy
- Use `decimal` for precise calculations where accuracy matters
- Use `int` for discrete values (level, base power, stats)
- Round damage calculations using standard Pokemon rounding rules (floor for most cases)
- Document any approximations or generation-specific differences

## Pokemon Calculation Examples

### Basic Stat Calculation
```csharp
public static int CalculateStat(StatType statType, int baseValue, int iv, int ev, 
    int level, Nature nature)
{
    // HP has different formula than other stats
    if (statType == StatType.HP)
        return (2 * baseValue + iv + ev / 4) * level / 100 + level + 10;
    
    var baseStat = (2 * baseValue + iv + ev / 4) * level / 100 + 5;
    var natureMultiplier = nature.GetMultiplier(statType);
    return (int)(baseStat * natureMultiplier);
}
```

### Type Effectiveness
```csharp
public decimal GetEffectiveness(PokemonType attackType, PokemonType defenseType1, 
    PokemonType? defenseType2 = null)
{
    var effectiveness = TypeChart[attackType][defenseType1];
    if (defenseType2.HasValue)
        effectiveness *= TypeChart[attackType][defenseType2.Value];
    return effectiveness;
}
```

### Troubleshooting
- **Build fails with .NET version error**: Modify target framework to match available SDK version
- **Format takes longer than expected**: This is normal for first run, subsequent runs are faster
- **Missing package references**: Run `dotnet restore` explicitly if needed
- **Clean build issues**: Ensure no files are locked by IDE or other processes

## Build Time Expectations
- **Clean**: < 1 second
- **Build (Debug)**: ~10 seconds first time, 1-2 seconds incremental
- **Build (Release)**: ~2 seconds
- **Format**: ~8 seconds first time, faster subsequent runs
- **Pack**: ~3 seconds
- **Test**: < 1 second (no tests currently)

**NEVER CANCEL** any of these operations. Always set timeouts to at least double the expected time to account for network operations and system load.

## Testing & Validation Guidelines

### Unit Testing Standards
When adding tests (currently none exist):
- Use xUnit as the testing framework: `dotnet add package Microsoft.NET.Test.Sdk xunit xunit.runner.visualstudio`
- Test Pokemon calculations against known correct values from Smogon or Pokemon Showdown
- Use `Theory` and `InlineData` for testing multiple scenarios efficiently
- Group tests by functionality: `StatCalculationTests`, `DamageCalculationTests`, `TypeEffectivenessTests`

### Validation Examples
```csharp
[Theory]
[InlineData(100, 31, 252, 50, Nature.Adamant, StatType.Attack, 183)] // Adamant 50 ATK
[InlineData(100, 31, 0, 50, Nature.Modest, StatType.Attack, 122)]   // Modest 50 ATK
public void CalculateStat_ReturnsExpectedValue(int baseAttack, int iv, int ev, 
    int level, Nature nature, StatType statType, int expected)
{
    var result = StatCalculator.CalculateStat(statType, baseAttack, iv, ev, level, nature);
    Assert.Equal(expected, result);
}
```

### Manual Verification Process
1. **Compare with Reference**: Cross-check calculations with Pokemon Showdown or Smogon calculator
2. **Edge Cases**: Test level 1, level 100, 0 IVs, 31 IVs, no EVs, max EVs combinations  
3. **Type Interactions**: Verify dual-type effectiveness (e.g., Flying/Fire vs Rock = 2x × 2x = 4x)
4. **Generation Differences**: Document which generation's mechanics are implemented

## Tool Integration

### Using These Instructions Effectively
- **Context Matters**: When asking for Pokemon calculation help, mention the generation and specific mechanic
- **Code Examples**: Prefer showing working code over abstract descriptions
- **Reference Patterns**: Point to similar implementations in the Smogon damage-calc repository
- **Incremental Development**: Build one calculation type at a time (stats → damage → advanced mechanics)

### Common Development Tasks
- **Adding Pokemon Data**: Create strongly-typed models with validation
- **Implementing Calculations**: Start with basic formulas, add modifiers incrementally  
- **Battle Mechanics**: Model field effects, abilities, and items as separate concerns
- **Performance**: Use value types and avoid unnecessary allocations in hot paths