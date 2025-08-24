namespace PokemonCalc.Core;

/// <summary>
/// Battle field conditions
/// </summary>
public readonly record struct Field(
    WeatherType Weather = WeatherType.None,
    TerrainType Terrain = TerrainType.None,
    bool TrickRoom = false,
    bool GravityActive = false,
    int WeatherTurns = 0,
    int TerrainTurns = 0
);

/// <summary>
/// Result of a damage calculation
/// </summary>
public readonly record struct DamageResult(
    IReadOnlyList<int> DamageRolls,
    string Description,
    bool IsCriticalHit = false,
    double TypeEffectiveness = 1.0
)
{
    public int MinDamage => DamageRolls.Min();
    public int MaxDamage => DamageRolls.Max();
    public double AverageDamage => DamageRolls.Average();
    
    public (double min, double max) DamagePercentage(int targetMaxHP) => 
        (MinDamage * 100.0 / targetMaxHP, MaxDamage * 100.0 / targetMaxHP);
}