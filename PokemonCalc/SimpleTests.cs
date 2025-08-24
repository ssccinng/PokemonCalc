namespace PokemonCalc.Tests;

using PokemonCalc.Core;

/// <summary>
/// Simple tests to validate the Pokemon calculator functionality
/// </summary>
public static class SimpleTests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Running Pokemon Calculator Tests...");
        Console.WriteLine("==================================");
        
        TestStatCalculations();
        TestTypeEffectiveness();
        TestDamageCalculation();
        TestCriticalHits();
        TestWeatherEffects();
        
        Console.WriteLine("All tests completed!");
    }

    private static void TestStatCalculations()
    {
        Console.WriteLine("\n1. Testing stat calculations...");
        
        // Test Garchomp at level 100 with 31 IVs and no EVs
        var baseStats = new StatsTable(108, 130, 95, 80, 85, 102);
        var ivs = StatsTable.WithDefault(31);
        var evs = StatsTable.WithDefault(0);
        
        var stats = Core.Stats.CalculateStats(baseStats, ivs, evs, 100, Nature.Serious);
        
        Console.WriteLine($"烈咬陆鲨种族值 (Garchomp Level 100 stats) (严肃性格, 31个体值, 0努力值):");
        Console.WriteLine($"HP: {stats.HP} (expected ~291)");
        Console.WriteLine($"Attack: {stats.Attack} (expected ~317)");
        Console.WriteLine($"Defense: {stats.Defense} (expected ~216)");
        
        // Test with nature modifiers
        var jollyStats = Core.Stats.CalculateStats(baseStats, ivs, evs, 100, Nature.Jolly);
        Console.WriteLine($"爽朗烈咬陆鲨速度: {jollyStats.Speed} (expected ~367, +10% from 334)");
        Console.WriteLine($"爽朗烈咬陆鲨特攻: {jollyStats.SpecialAttack} (expected ~176, -10% from 196)");
    }

    private static void TestTypeEffectiveness()
    {
        Console.WriteLine("\n2. Testing type effectiveness...");
        
        // Electric vs Flying (2x)
        var effectiveness1 = TypeChart.GetEffectiveness(PokemonType.Electric, PokemonType.Flying);
        Console.WriteLine($"Electric vs Flying: {effectiveness1}x (expected 2x)");
        
        // Water vs Fire (2x)
        var effectiveness2 = TypeChart.GetEffectiveness(PokemonType.Water, PokemonType.Fire);
        Console.WriteLine($"Water vs Fire: {effectiveness2}x (expected 2x)");
        
        // Normal vs Ghost (0x)
        var effectiveness3 = TypeChart.GetEffectiveness(PokemonType.Normal, PokemonType.Ghost);
        Console.WriteLine($"Normal vs Ghost: {effectiveness3}x (expected 0x)");
        
        // Fire vs Water (0.5x)
        var effectiveness4 = TypeChart.GetEffectiveness(PokemonType.Fire, PokemonType.Water);
        Console.WriteLine($"Fire vs Water: {effectiveness4}x (expected 0.5x)");
        
        // Dual type test: Water vs Fire/Flying (2x * 1x = 2x)
        var dualTypes = new[] { PokemonType.Fire, PokemonType.Flying };
        var totalEffectiveness = TypeChart.GetTotalEffectiveness(PokemonType.Water, dualTypes);
        Console.WriteLine($"Water vs Fire/Flying: {totalEffectiveness}x (expected 2x)");
    }

    private static void TestDamageCalculation()
    {
        Console.WriteLine("\n3. Testing damage calculation...");
        
        var result = PokemonCalculator.CalculateDamage(
            attackerSpecies: "烈咬陆鲨",
            defenderSpecies: "喷火龙",
            moveName: "地震"
        );
        
        Console.WriteLine($"烈咬陆鲨地震 vs 喷火龙:");
        Console.WriteLine($"Damage: {result.MinDamage}-{result.MaxDamage} (avg: {result.AverageDamage:F1})");
        Console.WriteLine($"Type effectiveness: {result.TypeEffectiveness}x");
        
        var (minPercent, maxPercent) = result.DamagePercentage(331); // Charizard's HP
        Console.WriteLine($"Damage %: {minPercent:F1}%-{maxPercent:F1}%");
    }

    private static void TestCriticalHits()
    {
        Console.WriteLine("\n4. Testing critical hits...");
        
        var normalResult = PokemonCalculator.CalculateDamage(
            attackerSpecies: "皮卡丘",
            defenderSpecies: "喷火龙",
            moveName: "十万伏特",
            battleSettings: new BattleSettings(IsCriticalHit: false)
        );
        
        var critResult = PokemonCalculator.CalculateDamage(
            attackerSpecies: "皮卡丘",
            defenderSpecies: "喷火龙",
            moveName: "十万伏特", 
            battleSettings: new BattleSettings(IsCriticalHit: true)
        );
        
        Console.WriteLine($"Normal hit: {normalResult.MinDamage}-{normalResult.MaxDamage}");
        Console.WriteLine($"Critical hit: {critResult.MinDamage}-{critResult.MaxDamage}");
        Console.WriteLine($"Crit multiplier: {(double)critResult.MinDamage / normalResult.MinDamage:F2}x (expected ~1.5x)");
    }

    private static void TestWeatherEffects()
    {
        Console.WriteLine("\n5. Testing weather effects...");
        
        var normalResult = PokemonCalculator.CalculateDamage(
            attackerSpecies: "喷火龙",
            defenderSpecies: "妙蛙花",
            moveName: "喷射火焰"
        );
        
        var sunResult = PokemonCalculator.CalculateDamage(
            attackerSpecies: "喷火龙",
            defenderSpecies: "妙蛙花",
            moveName: "喷射火焰",
            battleSettings: new BattleSettings(Weather: WeatherType.Sun)
        );
        
        var rainResult = PokemonCalculator.CalculateDamage(
            attackerSpecies: "喷火龙",
            defenderSpecies: "妙蛙花",
            moveName: "喷射火焰",
            battleSettings: new BattleSettings(Weather: WeatherType.Rain)
        );
        
        Console.WriteLine($"Normal weather: {normalResult.MinDamage}-{normalResult.MaxDamage}");
        Console.WriteLine($"Sun: {sunResult.MinDamage}-{sunResult.MaxDamage} (1.5x expected)");
        Console.WriteLine($"Rain: {rainResult.MinDamage}-{rainResult.MaxDamage} (0.5x expected)");
    }
}