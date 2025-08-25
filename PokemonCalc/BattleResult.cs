namespace PokemonCalc;

// Damage calculation result - immutable functional style
public record DamageResult(
    int[] Damage,
    double Percentage,
    double MinPercentage,
    double MaxPercentage,
    string Description = ""
)
{
    public int MinDamage => Damage.Min();
    public int MaxDamage => Damage.Max();
    public double AverageDamage => Damage.Average();

    public bool IsGuaranteedKO => MinPercentage >= 100.0;
    public bool IsPossibleKO => MaxPercentage >= 100.0;

    public double KOChance(int targetHP)
    {
        if (targetHP <= 0) return 1.0;

        var koHits = Damage.Count(d => d >= targetHP);
        return (double)koHits / Damage.Length;
    }

    public string GetDamageRange() => $"{MinDamage}-{MaxDamage}";

    public string GetPercentageRange() => $"{MinPercentage:F1}%-{MaxPercentage:F1}%";
}

// Move effectiveness calculation result
public record EffectivenessResult(
    double Multiplier,
    string Description = ""
)
{
    public bool IsNotVeryEffective => Multiplier < 1.0;
    public bool IsSuperEffective => Multiplier > 1.0;
    public bool IsNormalEffective => Math.Abs(Multiplier - 1.0) < 0.001;
    public bool IsNoEffect => Math.Abs(Multiplier) < 0.001;
}

// Comprehensive battle calculation result
public record BattleResult(
    DamageResult Damage,
    EffectivenessResult Effectiveness,
    PokemonState Attacker,
    PokemonState Defender,
    MoveState Move,
    FieldState Field,
    string Description = ""
)
{
    public bool IsCriticalHit => Description.Contains("critical hit", StringComparison.OrdinalIgnoreCase);
    public bool HasWeatherBoost => Description.Contains("weather", StringComparison.OrdinalIgnoreCase);
    public bool HasAbilityEffect => Description.Contains("ability", StringComparison.OrdinalIgnoreCase);
    public bool HasItemEffect => Description.Contains("item", StringComparison.OrdinalIgnoreCase);
}