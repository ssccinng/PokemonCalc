# PokemonCalc .NET Class Library

PokemonCalc is a .NET 9.0 class library project containing Pokemon calculation functionality. The codebase is built using modern .NET SDK tools and follows standard C# library patterns.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

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