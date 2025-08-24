namespace PokemonCalc.Core;

/// <summary>
/// Type effectiveness chart and calculations
/// </summary>
public static class TypeChart
{
    // Using TypeEffectiveness enum values: NoEffect=0, NotVeryEffective=1, Normal=2, SuperEffective=4
    private static readonly Dictionary<(PokemonType attacking, PokemonType defending), TypeEffectiveness> _chart = 
        new()
        {
            // Normal vs all types
            [(PokemonType.Normal, PokemonType.Rock)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Normal, PokemonType.Ghost)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Normal, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Fire vs all types
            [(PokemonType.Fire, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fire, PokemonType.Water)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fire, PokemonType.Grass)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fire, PokemonType.Ice)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fire, PokemonType.Bug)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fire, PokemonType.Rock)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fire, PokemonType.Dragon)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fire, PokemonType.Steel)] = TypeEffectiveness.SuperEffective,

            // Water vs all types
            [(PokemonType.Water, PokemonType.Fire)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Water, PokemonType.Water)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Water, PokemonType.Grass)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Water, PokemonType.Ground)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Water, PokemonType.Rock)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Water, PokemonType.Dragon)] = TypeEffectiveness.NotVeryEffective,

            // Electric vs all types
            [(PokemonType.Electric, PokemonType.Water)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Electric, PokemonType.Electric)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Electric, PokemonType.Grass)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Electric, PokemonType.Ground)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Electric, PokemonType.Flying)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Electric, PokemonType.Dragon)] = TypeEffectiveness.NotVeryEffective,

            // Grass vs all types
            [(PokemonType.Grass, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Water)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Grass, PokemonType.Grass)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Poison)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Ground)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Grass, PokemonType.Flying)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Bug)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Rock)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Grass, PokemonType.Dragon)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Grass, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Ice vs all types  
            [(PokemonType.Ice, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Ice, PokemonType.Water)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Ice, PokemonType.Grass)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ice, PokemonType.Ice)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Ice, PokemonType.Ground)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ice, PokemonType.Flying)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ice, PokemonType.Dragon)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ice, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Fighting vs all types
            [(PokemonType.Fighting, PokemonType.Normal)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fighting, PokemonType.Ice)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fighting, PokemonType.Poison)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fighting, PokemonType.Flying)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fighting, PokemonType.Psychic)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fighting, PokemonType.Bug)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fighting, PokemonType.Rock)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fighting, PokemonType.Ghost)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Fighting, PokemonType.Dark)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fighting, PokemonType.Steel)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fighting, PokemonType.Fairy)] = TypeEffectiveness.NotVeryEffective,

            // Poison vs all types
            [(PokemonType.Poison, PokemonType.Grass)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Poison, PokemonType.Poison)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Poison, PokemonType.Ground)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Poison, PokemonType.Rock)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Poison, PokemonType.Ghost)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Poison, PokemonType.Steel)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Poison, PokemonType.Fairy)] = TypeEffectiveness.SuperEffective,

            // Ground vs all types
            [(PokemonType.Ground, PokemonType.Fire)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ground, PokemonType.Electric)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ground, PokemonType.Grass)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Ground, PokemonType.Poison)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ground, PokemonType.Flying)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Ground, PokemonType.Bug)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Ground, PokemonType.Rock)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ground, PokemonType.Steel)] = TypeEffectiveness.SuperEffective,

            // Flying vs all types  
            [(PokemonType.Flying, PokemonType.Electric)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Flying, PokemonType.Grass)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Flying, PokemonType.Fighting)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Flying, PokemonType.Bug)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Flying, PokemonType.Rock)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Flying, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Psychic vs all types
            [(PokemonType.Psychic, PokemonType.Fighting)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Psychic, PokemonType.Poison)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Psychic, PokemonType.Psychic)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Psychic, PokemonType.Dark)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Psychic, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Bug vs all types
            [(PokemonType.Bug, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Grass)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Bug, PokemonType.Fighting)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Poison)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Flying)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Psychic)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Bug, PokemonType.Ghost)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Dark)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Bug, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Bug, PokemonType.Fairy)] = TypeEffectiveness.NotVeryEffective,

            // Rock vs all types
            [(PokemonType.Rock, PokemonType.Fire)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Rock, PokemonType.Ice)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Rock, PokemonType.Fighting)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Rock, PokemonType.Ground)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Rock, PokemonType.Flying)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Rock, PokemonType.Bug)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Rock, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,

            // Ghost vs all types
            [(PokemonType.Ghost, PokemonType.Normal)] = TypeEffectiveness.NoEffect,
            [(PokemonType.Ghost, PokemonType.Psychic)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ghost, PokemonType.Ghost)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Ghost, PokemonType.Dark)] = TypeEffectiveness.NotVeryEffective,

            // Dragon vs all types
            [(PokemonType.Dragon, PokemonType.Dragon)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Dragon, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Dragon, PokemonType.Fairy)] = TypeEffectiveness.NoEffect,

            // Dark vs all types
            [(PokemonType.Dark, PokemonType.Fighting)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Dark, PokemonType.Psychic)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Dark, PokemonType.Ghost)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Dark, PokemonType.Dark)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Dark, PokemonType.Fairy)] = TypeEffectiveness.NotVeryEffective,

            // Steel vs all types
            [(PokemonType.Steel, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Steel, PokemonType.Water)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Steel, PokemonType.Electric)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Steel, PokemonType.Ice)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Steel, PokemonType.Rock)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Steel, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Steel, PokemonType.Fairy)] = TypeEffectiveness.SuperEffective,

            // Fairy vs all types  
            [(PokemonType.Fairy, PokemonType.Fire)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fairy, PokemonType.Fighting)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fairy, PokemonType.Poison)] = TypeEffectiveness.NotVeryEffective,
            [(PokemonType.Fairy, PokemonType.Dragon)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fairy, PokemonType.Dark)] = TypeEffectiveness.SuperEffective,
            [(PokemonType.Fairy, PokemonType.Steel)] = TypeEffectiveness.NotVeryEffective,
        };

    /// <summary>
    /// Get type effectiveness multiplier when attacking type hits defending type
    /// </summary>
    public static double GetEffectiveness(PokemonType attackingType, PokemonType defendingType)
    {
        return _chart.TryGetValue((attackingType, defendingType), out var effectiveness)
            ? (int)effectiveness / 2.0
            : 1.0; // Normal effectiveness
    }

    /// <summary>
    /// Calculate total type effectiveness for a move against a Pokemon with 1 or 2 types
    /// </summary>
    public static double GetTotalEffectiveness(PokemonType moveType, IReadOnlyList<PokemonType> targetTypes)
    {
        var effectiveness = 1.0;
        foreach (var type in targetTypes)
        {
            effectiveness *= GetEffectiveness(moveType, type);
        }
        return effectiveness;
    }

    /// <summary>
    /// Get type effectiveness as a descriptive string
    /// </summary>
    public static string GetEffectivenessDescription(double effectiveness) => effectiveness switch
    {
        0 => "No effect",
        < 1 => "Not very effective",
        1 => "",
        > 1 => "Super effective",
        _ => ""
    };
}