namespace PokemonCalc;

using PokemonCalc.Core;
using PokemonCalc.Tests;

/// <summary>
/// Example usage of the Pokemon damage calculation library
/// </summary>
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Pokemon Damage Calculator - C# Edition");
        Console.WriteLine("=====================================");
        Console.WriteLine();

        // Run tests first
        SimpleTests.RunAllTests();
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine("=========");

        // Example 1: Simple calculation
        Console.WriteLine("Example 1: Basic damage calculation");
        var result1 = PokemonCalculator.CalculateDamage(
            attackerSpecies: "Pikachu",
            defenderSpecies: "Charizard", 
            moveName: "Thunderbolt"
        );
        
        PrintDamageResult(result1);
        Console.WriteLine();

        // Example 2: With custom settings
        Console.WriteLine("Example 2: With custom Pokemon settings");
        var attackerSettings = new PokemonSettings(
            Level: 50,
            Nature: Nature.Modest,
            EVs: new StatsTable(0, 0, 0, 252, 4, 252),
            Item: "Magnet"
        );

        var defenderSettings = new PokemonSettings(
            Level: 50,
            Nature: Nature.Bold,
            EVs: new StatsTable(248, 0, 252, 0, 8, 0)
        );

        var result2 = PokemonCalculator.CalculateDamage(
            attackerSpecies: "Pikachu",
            defenderSpecies: "Blastoise",
            moveName: "Thunderbolt",
            attackerSettings: attackerSettings,
            defenderSettings: defenderSettings
        );

        PrintDamageResult(result2);
        Console.WriteLine();

        // Example 3: Weather effects
        Console.WriteLine("Example 3: With weather effects");
        var battleSettings = new BattleSettings(
            Weather: WeatherType.Rain,
            IsCriticalHit: false
        );

        var result3 = PokemonCalculator.CalculateDamage(
            attackerSpecies: "Blastoise",
            defenderSpecies: "Charizard",
            moveName: "Surf",
            battleSettings: battleSettings
        );

        PrintDamageResult(result3);
        Console.WriteLine();

        // Example 4: Using the builder pattern
        Console.WriteLine("Example 4: Using Pokemon builder");
        var attacker = PokemonCalculator.CreatePokemon()
            .WithSpecies("Garchomp")
            .WithLevel(100)
            .WithNature(Nature.Jolly)
            .WithEVs(attack: 252, speed: 252, hp: 4)
            .WithAbility("Rough Skin")
            .WithItem("Choice Band")
            .Build();

        var defender = PokemonCalculator.CreatePokemon()
            .WithSpecies("Metagross")
            .WithLevel(100)
            .WithNature(Nature.Adamant)
            .WithEVs(hp: 252, attack: 252, defense: 4)
            .WithAbility("Clear Body")
            .Build();

        var result4 = PokemonCalculator.CalculateDamage(
            attacker: attacker,
            defender: defender,
            moveName: "Earthquake"
        );

        PrintDamageResult(result4);
        Console.WriteLine();

        // Show available data
        Console.WriteLine("Available Pokemon:");
        foreach (var species in PokemonCalculator.GetAvailableSpecies())
        {
            Console.WriteLine($"  - {species}");
        }

        Console.WriteLine();
        Console.WriteLine("Available Moves:");
        foreach (var move in PokemonCalculator.GetAvailableMoves())
        {
            Console.WriteLine($"  - {move}");
        }
    }

    private static void PrintDamageResult(DamageResult result)
    {
        Console.WriteLine($"Calculation: {result.Description}");
        Console.WriteLine($"Damage Range: {result.MinDamage} - {result.MaxDamage}");
        Console.WriteLine($"Average Damage: {result.AverageDamage:F1}");
        
        if (result.TypeEffectiveness != 1.0)
        {
            Console.WriteLine($"Type Effectiveness: {result.TypeEffectiveness}x");
        }
        
        if (result.IsCriticalHit)
        {
            Console.WriteLine("Critical Hit Applied!");
        }
    }
}
