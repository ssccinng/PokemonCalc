using PokemonCalc.Data;
using PokemonCalc.Models;
using PokemonCalc.Calculations;
using PokemonCalc.Utilities;

namespace PokemonCalc;

/// <summary>
/// Main API for Pokemon damage calculations using functional programming principles
/// </summary>
public static class PokemonCalculator
{
    /// <summary>
    /// Calculate damage between two Pokemon with a specific move
    /// </summary>
    /// <param name="attackerSpecies">Name of the attacking Pokemon species</param>
    /// <param name="defenderSpecies">Name of the defending Pokemon species</param>
    /// <param name="moveName">Name of the move being used</param>
    /// <param name="attackerLevel">Level of the attacking Pokemon (default 100)</param>
    /// <param name="defenderLevel">Level of the defending Pokemon (default 100)</param>
    /// <param name="field">Battle field conditions</param>
    /// <param name="generation">Pokemon generation for mechanics (default Gen 9)</param>
    /// <returns>Damage calculation result</returns>
    public static DamageResult CalculateDamage(
        string attackerSpecies,
        string defenderSpecies,
        string moveName,
        int attackerLevel = 100,
        int defenderLevel = 100,
        Field field = default,
        GenerationNum generation = default)
    {
        var species1 = SampleData.GetSpecies(attackerSpecies);
        var species2 = SampleData.GetSpecies(defenderSpecies);
        var move = SampleData.GetMove(moveName);

        if (!species1.HasValue)
            throw new ArgumentException($"Unknown Pokemon species: {attackerSpecies}", nameof(attackerSpecies));
        if (!species2.HasValue)
            throw new ArgumentException($"Unknown Pokemon species: {defenderSpecies}", nameof(defenderSpecies));
        if (!move.HasValue)
            throw new ArgumentException($"Unknown move: {moveName}", nameof(moveName));

        var attacker = CreateDefaultPokemon(species1.Value, attackerLevel);
        var defender = CreateDefaultPokemon(species2.Value, defenderLevel);

        return DamageCalculator.Calculate(
            attacker,
            defender,
            move.Value,
            field,
            generation == 0 ? GenerationNum.Gen9 : generation,
            SampleData.TypeChart);
    }

    /// <summary>
    /// Create a Pokemon with custom configuration
    /// </summary>
    /// <param name="speciesName">Pokemon species name</param>
    /// <param name="level">Pokemon level</param>
    /// <param name="natureName">Nature name (optional)</param>
    /// <param name="abilityName">Ability name (optional)</param>
    /// <param name="itemName">Item name (optional)</param>
    /// <param name="ivs">Individual Values (optional, defaults to max)</param>
    /// <param name="evs">Effort Values (optional, defaults to none)</param>
    /// <returns>Configured Pokemon</returns>
    public static Pokemon CreatePokemon(
        string speciesName,
        int level = 100,
        string? natureName = null,
        string? abilityName = null,
        string? itemName = null,
        StatsTable? ivs = null,
        StatsTable? evs = null)
    {
        var species = SampleData.GetSpecies(speciesName);
        if (!species.HasValue)
            throw new ArgumentException($"Unknown Pokemon species: {speciesName}", nameof(speciesName));

        var nature = natureName != null ?
            SampleData.GetNature(natureName) ?? throw new ArgumentException($"Unknown nature: {natureName}", nameof(natureName)) :
            SampleData.GetNature("Serious")!.Value;

        var ability = abilityName != null ?
            SampleData.GetAbility(abilityName) ?? throw new ArgumentException($"Unknown ability: {abilityName}", nameof(abilityName)) :
            Ability.None;

        var item = itemName != null ?
            SampleData.GetItem(itemName) ?? throw new ArgumentException($"Unknown item: {itemName}", nameof(itemName)) :
            Item.None;

        return new Pokemon(
            species.Value,
            level,
            nature,
            ability,
            item,
            ivs ?? new StatsTable(31, 31, 31, 31, 31, 31), // Max IVs by default
            evs ?? new StatsTable(0, 0, 0, 0, 0, 0)        // No EVs by default
        );
    }

    /// <summary>
    /// Get all available Pokemon species names
    /// </summary>
    public static IEnumerable<string> GetAvailableSpecies() =>
        SampleData.Species.Values.Select(s => s.Name);

    /// <summary>
    /// Get all available move names
    /// </summary>
    public static IEnumerable<string> GetAvailableMoves() =>
        SampleData.Moves.Values.Select(m => m.Name);

    /// <summary>
    /// Get all available ability names
    /// </summary>
    public static IEnumerable<string> GetAvailableAbilities() =>
        SampleData.Abilities.Values.Select(a => a.Name);

    /// <summary>
    /// Get all available item names
    /// </summary>
    public static IEnumerable<string> GetAvailableItems() =>
        SampleData.Items.Values.Select(i => i.Name);

    /// <summary>
    /// Get all available nature names
    /// </summary>
    public static IEnumerable<string> GetAvailableNatures() =>
        SampleData.Natures.Values.Select(n => n.Name);

    /// <summary>
    /// Calculate type effectiveness between attack type and defender types
    /// </summary>
    /// <param name="attackType">The attacking move's type</param>
    /// <param name="defenderTypes">The defending Pokemon's types</param>
    /// <returns>Type effectiveness multiplier</returns>
    public static double CalculateTypeEffectiveness(TypeName attackType, params TypeName[] defenderTypes) =>
        TypeUtils.CalculateEffectiveness(attackType, defenderTypes, SampleData.TypeChart);

    /// <summary>
    /// Calculate stat with level, IVs, EVs, and nature
    /// </summary>
    /// <param name="stat">The stat to calculate</param>
    /// <param name="baseStat">Base stat value</param>
    /// <param name="level">Pokemon level</param>
    /// <param name="iv">Individual Value</param>
    /// <param name="ev">Effort Value</param>
    /// <param name="nature">Pokemon nature</param>
    /// <returns>Calculated stat value</returns>
    public static int CalculateStat(
        StatID stat,
        int baseStat,
        int level,
        int iv = 31,
        int ev = 0,
        Nature? nature = null)
    {
        var natureValue = nature ?? SampleData.GetNature("Serious")!.Value;
        return StatUtils.CalculateStat(stat, baseStat, iv, ev, level, natureValue);
    }

    /// <summary>
    /// Create a default Pokemon with optimal stats
    /// </summary>
    private static Pokemon CreateDefaultPokemon(Species species, int level)
    {
        var nature = SampleData.GetNature("Serious")!.Value;
        var ability = species.Abilities?.FirstOrDefault() != null
            ? SampleData.GetAbility(species.Abilities.First()) ?? Ability.None
            : Ability.None;

        return new Pokemon(
            species,
            level,
            nature,
            ability,
            Item.None,
            new StatsTable(31, 31, 31, 31, 31, 31), // Max IVs
            new StatsTable(0, 0, 0, 0, 0, 0)        // No EVs
        );
    }
}