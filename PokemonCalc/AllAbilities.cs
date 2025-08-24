namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Complete abilities database based on smogon/damage-calc reference
/// </summary>
public static class AllAbilities
{
    private static readonly Dictionary<string, Ability> _abilitiesLookup = new(StringComparer.OrdinalIgnoreCase);
    
    static AllAbilities()
    {
        InitializeAbilities();
    }
    
    public static Ability? GetByName(string name) => 
        _abilitiesLookup.TryGetValue(name, out var ability) ? ability : null;

    public static IEnumerable<Ability> GetAll() => _abilitiesLookup.Values;
    
    private static void InitializeAbilities()
    {
        // Generation 3 abilities (ADV)
        AddAbility("Air Lock", "Eliminates the effects of weather.");
        AddAbility("Arena Trap", "Prevents the target from fleeing.");
        AddAbility("Battle Armor", "The Pokémon is protected against critical hits.");
        AddAbility("Blaze", "Powers up Fire-type moves when the Pokémon's HP is low.");
        AddAbility("Chlorophyll", "Boosts the Pokémon's Speed stat in harsh sunlight.");
        AddAbility("Clear Body", "Prevents other Pokémon from lowering its stats.");
        AddAbility("Cloud Nine", "Eliminates the effects of weather.");
        AddAbility("Color Change", "The Pokémon's type becomes the type of the move used on it.");
        AddAbility("Compound Eyes", "The Pokémon's compound eyes boost its accuracy.");
        AddAbility("Cute Charm", "Contact with the Pokémon may cause infatuation.");
        AddAbility("Damp", "Prevents the use of explosive moves such as Self-Destruct.");
        AddAbility("Drizzle", "The Pokémon makes it rain when it enters a battle.");
        AddAbility("Drought", "Turns the sunlight harsh when the Pokémon enters a battle.");
        AddAbility("Early Bird", "The Pokémon awakens from sleep twice as fast as other Pokémon.");
        AddAbility("Effect Spore", "Contact with the Pokémon may inflict poison, sleep, or paralysis on its attacker.");
        AddAbility("Flame Body", "Contact with the Pokémon may burn the attacker.");
        AddAbility("Flash Fire", "It powers up Fire-type moves if it's hit by one.");
        AddAbility("Forecast", "The Pokémon transforms with the weather.");
        AddAbility("Guts", "It's so gutsy that having a status condition boosts the Attack stat.");
        AddAbility("Huge Power", "Doubles the Pokémon's Attack stat.");
        AddAbility("Hustle", "Boosts the Attack stat, but lowers accuracy.");
        AddAbility("Hyper Cutter", "The Pokémon's proud of its powerful pincers. They prevent other Pokémon from lowering its Attack stat.");
        AddAbility("Illuminate", "Raises the likelihood of meeting wild Pokémon by illuminating the surroundings.");
        AddAbility("Immunity", "The immune system of the Pokémon prevents it from getting poisoned.");
        AddAbility("Inner Focus", "The Pokémon's intense focus prevents it from flinching.");
        AddAbility("Insomnia", "The Pokémon is suffering from insomnia and cannot fall asleep.");
        AddAbility("Intimidate", "The Pokémon intimidates opposing Pokémon upon entering battle, lowering their Attack stat.");
        AddAbility("Keen Eye", "Keen eyes prevent other Pokémon from lowering this Pokémon's accuracy.");
        AddAbility("Levitate", "By floating in the air, the Pokémon receives full immunity to all Ground-type moves.");
        AddAbility("Lightning Rod", "The Pokémon draws in all Electric-type moves. Instead of being hit by Electric-type moves, it boosts its Sp. Atk.");
        AddAbility("Limber", "Its limber body protects the Pokémon from paralysis.");
        AddAbility("Liquid Ooze", "The oozed liquid has a strong stench, which damages attackers using any draining move.");
        AddAbility("Magma Armor", "The Pokémon is covered with hot magma, which prevents the Pokémon from becoming frozen.");
        AddAbility("Magnet Pull", "Prevents Steel-type Pokémon from fleeing by pulling them in with magnetism.");
        AddAbility("Marvel Scale", "The Pokémon's marvelous scales boost the Defense stat if it has a status condition.");
        AddAbility("Minus", "Boosts the Sp. Atk stat when another Pokémon with Plus or Minus is present.");
        AddAbility("Natural Cure", "All status conditions heal when the Pokémon switches out.");
        AddAbility("Oblivious", "The Pokémon is oblivious, and that keeps it from being infatuated or falling for taunts.");
        AddAbility("Overgrow", "Powers up Grass-type moves when the Pokémon's HP is low.");
        AddAbility("Own Tempo", "This Pokémon has its own tempo, and that prevents it from becoming confused.");
        AddAbility("Pickup", "The Pokémon may pick up the item an opposing Pokémon used during a battle.");
        AddAbility("Plus", "Boosts the Sp. Atk stat when another Pokémon with Plus or Minus is present.");
        AddAbility("Poison Point", "Contact with the Pokémon may poison the attacker.");
        AddAbility("Pressure", "By putting pressure on the opposing Pokémon, it raises their PP usage.");
        AddAbility("Pure Power", "Using its pure power, the Pokémon doubles its Attack stat.");
        AddAbility("Rain Dish", "The Pokémon gradually regains HP in rain.");
        AddAbility("Rock Head", "Protects the Pokémon from recoil damage.");
        AddAbility("Rough Skin", "This Pokémon inflicts damage with its rough skin to the attacker on contact.");
        AddAbility("Run Away", "Enables a sure getaway from wild Pokémon.");
        AddAbility("Sand Stream", "The Pokémon summons a sandstorm when it enters a battle.");
        AddAbility("Sand Veil", "Boosts the Pokémon's evasiveness in a sandstorm.");
        AddAbility("Serene Grace", "Boosts the likelihood of additional effects occurring when attacking.");
        AddAbility("Shadow Tag", "This Pokémon steps on the opposing Pokémon's shadow to prevent them from fleeing.");
        AddAbility("Shed Skin", "The Pokémon may heal its own status conditions by shedding its skin.");
        AddAbility("Shell Armor", "A hard shell protects the Pokémon from critical hits.");
        AddAbility("Shield Dust", "This Pokémon's dust blocks the additional effects of attacks taken.");
        AddAbility("Soundproof", "Soundproofing of the Pokémon itself gives it immunity to all sound-based moves.");
        AddAbility("Speed Boost", "Its Speed stat is boosted every turn.");
        AddAbility("Static", "The Pokémon is charged with static electricity, so contact with it may cause paralysis.");
        AddAbility("Stench", "The stench may cause the target to flinch.");
        AddAbility("Sticky Hold", "Items held by the Pokémon are stuck fast and cannot be removed by other Pokémon.");
        AddAbility("Sturdy", "It cannot be knocked out with one hit. One-hit KO moves cannot knock it out, either.");
        AddAbility("Suction Cups", "This Pokémon uses suction cups to stay in one spot to negate all moves and items that force switching out.");
        AddAbility("Swarm", "Powers up Bug-type moves when the Pokémon's HP is low.");
        AddAbility("Swift Swim", "Boosts the Pokémon's Speed stat in rain.");
        AddAbility("Synchronize", "The attacker will receive the same status condition if it inflicts a burn, poison, or paralysis to the Pokémon.");
        AddAbility("Thick Fat", "The Pokémon is protected by a layer of thick fat, which halves the damage taken from Fire- and Ice-type moves.");
        AddAbility("Torrent", "Powers up Water-type moves when the Pokémon's HP is low.");
        AddAbility("Trace", "When it enters a battle, the Pokémon copies an opposing Pokémon's Ability.");
        AddAbility("Truant", "The Pokémon can't use a move if it had used a move on the previous turn.");
        AddAbility("Vital Spirit", "The Pokémon is full of vitality, and that prevents it from falling asleep.");
        AddAbility("Volt Absorb", "Restores HP if hit by an Electric-type move instead of taking damage.");
        AddAbility("Water Absorb", "Restores HP if hit by a Water-type move instead of taking damage.");
        AddAbility("Water Veil", "The Pokémon is covered with a water veil, which prevents the Pokémon from getting a burn.");
        AddAbility("White Smoke", "The Pokémon is protected by its white smoke, which prevents other Pokémon from lowering its stats.");
        AddAbility("Wonder Guard", "Its mysterious power only lets supereffective moves hit the Pokémon.");

        // Generation 4 abilities (DPP)
        AddAbility("Adaptability", "Powers up moves of the same type as the Pokémon.");
        AddAbility("Aftermath", "Damages the attacker if it contacts the Pokémon with a finishing hit.");
        AddAbility("Anger Point", "The Pokémon is angered when it takes a critical hit, and that maxes its Attack stat.");
        AddAbility("Anticipation", "The Pokémon can sense an opposing Pokémon's dangerous moves.");
        AddAbility("Bad Dreams", "Reduces the HP of sleeping opposing Pokémon.");
        AddAbility("Download", "Compares an opposing Pokémon's Defense and Sp. Def stats before raising its own Attack or Sp. Atk stat—whichever will be more effective.");
        AddAbility("Dry Skin", "Restores HP in rain or when hit by Water-type moves. Reduces HP in harsh sunlight, and increases the damage received from Fire-type moves.");
        AddAbility("Filter", "Reduces the power of supereffective attacks taken.");
        AddAbility("Flower Gift", "Boosts the Attack and Sp. Def stats of itself and allies when the weather is sunny.");
        AddAbility("Forewarn", "When it enters a battle, the Pokémon can tell one of the moves an opposing Pokémon has.");
        AddAbility("Frisk", "When it enters a battle, the Pokémon can check an opposing Pokémon's held item.");
        AddAbility("Gluttony", "Makes the Pokémon eat a held Berry when its HP drops to half or less, which is sooner than usual.");
        AddAbility("Heatproof", "The heatproof body of the Pokémon halves the damage from Fire-type moves that hit it.");
        AddAbility("Honey Gather", "The Pokémon may gather Honey after a battle.");
        AddAbility("Hydration", "Heals status conditions if it's raining.");
        AddAbility("Ice Body", "The Pokémon gradually regains HP in hail.");
        AddAbility("Iron Fist", "Powers up punching moves.");
        AddAbility("Klutz", "The Pokémon can't use any held items.");
        AddAbility("Leaf Guard", "Prevents status conditions in harsh sunlight.");
        AddAbility("Magic Guard", "The Pokémon only takes damage from attacks.");
        AddAbility("Mold Breaker", "Moves can be used on the target regardless of its Abilities.");
        AddAbility("Motor Drive", "Boosts its Speed stat if hit by an Electric-type move instead of taking damage.");
        AddAbility("Multitype", "Changes the Pokémon's type to match the Plate or Z-Crystal it holds.");
        AddAbility("No Guard", "The Pokémon employs no-guard tactics to ensure incoming and outgoing attacks always land.");
        AddAbility("Normalize", "All the Pokémon's moves become Normal type. The power of those moves is boosted a little.");
        AddAbility("Poison Heal", "Restores HP if the Pokémon is poisoned instead of losing HP.");
        AddAbility("Quick Feet", "Boosts the Speed stat if the Pokémon has a status condition.");
        AddAbility("Reckless", "Powers up moves that have recoil damage.");
        AddAbility("Rivalry", "Deals more damage to Pokémon of the same gender.");
        AddAbility("Scrappy", "The Pokémon can hit Ghost-type Pokémon with Normal- and Fighting-type moves.");
        AddAbility("Simple", "The stat changes the Pokémon receives are doubled.");
        AddAbility("Skill Link", "Maximizes the number of times multistrike moves hit.");
        AddAbility("Slow Start", "For five turns, the Pokémon's Attack and Speed stats are halved.");
        AddAbility("Sniper", "Powers up moves if they become critical hits when attacking.");
        AddAbility("Snow Cloak", "Boosts evasiveness in hail.");
        AddAbility("Snow Warning", "The Pokémon summons a hailstorm when it enters a battle.");
        AddAbility("Solar Power", "Boosts the Sp. Atk stat in harsh sunlight, but HP decreases every turn.");
        AddAbility("Solid Rock", "Reduces the power of supereffective attacks taken.");
        AddAbility("Stall", "The Pokémon moves after all other Pokémon do.");
        AddAbility("Steadfast", "The Pokémon's determination boosts the Speed stat each time the Pokémon flinches.");
        AddAbility("Storm Drain", "Draws in all Water-type moves. Instead of being hit by Water-type moves, it boosts its Sp. Atk.");
        AddAbility("Super Luck", "The Pokémon is so lucky that the critical-hit ratios of its moves are boosted.");
        AddAbility("Tangled Feet", "Raises evasiveness if the Pokémon is confused.");
        AddAbility("Technician", "Powers up the Pokémon's weaker moves.");
        AddAbility("Tinted Lens", "The Pokémon can use \"not very effective\" moves to deal regular damage.");
        AddAbility("Unaware", "When attacking, the Pokémon ignores the target's stat changes.");
        AddAbility("Unburden", "Boosts the Speed stat if the Pokémon's held item is used or lost.");

        // Generation 5 abilities (BW)
        AddAbility("Analytic", "Boosts the power of the Pokémon's move if it is the last to act that turn.");
        AddAbility("Big Pecks", "Protects the Pokémon from Defense-lowering effects.");
        AddAbility("Contrary", "Makes stat changes have an opposite effect.");
        AddAbility("Cursed Body", "May disable a move used on the Pokémon.");
        AddAbility("Defeatist", "Halves the Pokémon's Attack and Sp. Atk stats when its HP becomes half or less.");
        AddAbility("Defiant", "Boosts the Attack stat sharply when the Pokémon's stats are lowered.");
        AddAbility("Flare Boost", "Powers up special moves when the Pokémon is burned.");
        AddAbility("Friend Guard", "Reduces damage done to allies.");
        AddAbility("Harvest", "May create another Berry after one is used.");
        AddAbility("Healer", "Sometimes heals an ally's status condition.");
        AddAbility("Heavy Metal", "Doubles the Pokémon's weight.");
        AddAbility("Illusion", "Comes out disguised as the Pokémon in the party's last spot.");
        AddAbility("Imposter", "The Pokémon transforms itself into the Pokémon it's facing.");
        AddAbility("Infiltrator", "Passes through the opposing Pokémon's barrier, substitute, and the like and strikes.");
        AddAbility("Iron Barbs", "Inflicts damage on the attacker upon contact with iron barbs.");
        AddAbility("Justified", "Being hit by a Dark-type move boosts the Attack stat of the Pokémon, for justice.");
        AddAbility("Light Metal", "Halves the Pokémon's weight.");
        AddAbility("Magic Bounce", "Reflects status moves instead of getting hit by them.");
        AddAbility("Moody", "Raises one stat sharply and lowers another every turn.");
        AddAbility("Moxie", "The Pokémon shows moxie, and that boosts the Attack stat after knocking out any Pokémon.");
        AddAbility("Multiscale", "Reduces the amount of damage the Pokémon takes while its HP is full.");
        AddAbility("Mummy", "Contact with the Pokémon changes the attacker's Ability to Mummy.");
        AddAbility("Overcoat", "Protects the Pokémon from things like sand, hail, and powder.");
        AddAbility("Pickpocket", "Steals an item from an attacker that made direct contact.");
        AddAbility("Poison Touch", "May poison a target when the Pokémon makes contact.");
        AddAbility("Prankster", "Gives priority to status moves.");
        AddAbility("Rattled", "Some move types scare it and boost its Speed stat.");
        AddAbility("Regenerator", "Restores a little HP when withdrawn from battle.");
        AddAbility("Sand Force", "Boosts the power of Rock-, Ground-, and Steel-type moves in a sandstorm.");
        AddAbility("Sand Rush", "Boosts the Pokémon's Speed stat in a sandstorm.");
        AddAbility("Sap Sipper", "Boosts the Attack stat if hit by a Grass-type move instead of taking damage.");
        AddAbility("Sheer Force", "Removes additional effects to increase the power of moves when attacking.");
        AddAbility("Telepathy", "Anticipates an ally's attack and dodges it.");
        AddAbility("Teravolt", "Moves can be used on the target regardless of its Abilities.");
        AddAbility("Toxic Boost", "Powers up physical moves when the Pokémon is poisoned.");
        AddAbility("Turboblaze", "Moves can be used on the target regardless of its Abilities.");
        AddAbility("Unnerve", "Unnerves opposing Pokémon and makes them unable to eat Berries.");
        AddAbility("Victory Star", "Boosts the accuracy of its allies and itself.");
        AddAbility("Weak Armor", "Physical attacks to the Pokémon lower its Defense stat but sharply raise its Speed stat.");
        AddAbility("Wonder Skin", "Makes status moves more likely to miss.");
        AddAbility("Zen Mode", "Changes the Pokémon's shape when HP is half or less.");

        // Generation 6 abilities (XY)
        AddAbility("Aerilate", "Normal-type moves become Flying-type moves. The power of those moves is boosted a little.");
        AddAbility("Aroma Veil", "Protects itself and its allies from attacks that limit their move choices.");
        AddAbility("Aura Break", "The effects of \"Aura\" Abilities are reversed to lower the power of affected moves.");
        AddAbility("Bulletproof", "Protects the Pokémon from some ball and bomb moves.");
        AddAbility("Cheek Pouch", "Restores HP as well when the Pokémon eats a Berry.");
        AddAbility("Competitive", "Boosts the Sp. Atk stat sharply when the Pokémon's stats are lowered.");
        AddAbility("Dark Aura", "Powers up each Pokémon's Dark-type moves.");
        AddAbility("Delta Stream", "The Pokémon changes the weather to eliminate all of the Flying type's weaknesses.");
        AddAbility("Desolate Land", "The Pokémon changes the weather to nullify Water-type attacks.");
        AddAbility("Fairy Aura", "Powers up each Pokémon's Fairy-type moves.");
        AddAbility("Flower Veil", "Ally Grass-type Pokémon are protected from status conditions and the lowering of their stats.");
        AddAbility("Fur Coat", "Halves the damage from physical moves.");
        AddAbility("Gale Wings", "Gives priority to Flying-type moves when the Pokémon's HP is full.");
        AddAbility("Gooey", "Contact with the Pokémon lowers the attacker's Speed stat.");
        AddAbility("Grass Pelt", "Boosts the Pokémon's Defense stat on Grassy Terrain.");
        AddAbility("Magician", "The Pokémon steals the held item of a Pokémon it hits with a move.");
        AddAbility("Mega Launcher", "Powers up aura and pulse moves.");
        AddAbility("Parental Bond", "Parent and child each attacks.");
        AddAbility("Pixilate", "Normal-type moves become Fairy-type moves. The power of those moves is boosted a little.");
        AddAbility("Primordial Sea", "The Pokémon changes the weather to nullify Fire-type attacks.");
        AddAbility("Protean", "Changes the Pokémon's type to the type of the move it's about to use.");
        AddAbility("Refrigerate", "Normal-type moves become Ice-type moves. The power of those moves is boosted a little.");
        AddAbility("Stance Change", "The Pokémon changes its form to Blade Forme when it uses an attack move and changes to Shield Forme when it uses King's Shield.");
        AddAbility("Strong Jaw", "The Pokémon's strong jaw boosts the power of biting moves.");
        AddAbility("Sweet Veil", "Prevents itself and ally Pokémon from falling asleep.");
        AddAbility("Symbiosis", "The Pokémon passes its item to an ally that has used up an item.");
        AddAbility("Tough Claws", "Powers up moves that make direct contact.");

        // Generation 7 abilities (SM)
        AddAbility("Battery", "Powers up ally Pokémon's special moves.");
        AddAbility("Battle Bond", "Defeating an opposing Pokémon strengthens the Pokémon's bond with its Trainer, and it becomes Ash-Greninja. Water Shuriken gets more powerful.");
        AddAbility("Beast Boost", "The Pokémon boosts its most proficient stat each time it knocks out a Pokémon.");
        AddAbility("Berserk", "Boosts the Pokémon's Sp. Atk stat when it takes a hit that causes its HP to become half or less.");
        AddAbility("Comatose", "It's always drowsing and will never wake up. It can attack without waking up.");
        AddAbility("Corrosion", "The Pokémon can poison the target even if it's a Steel or Poison type.");
        AddAbility("Dancer", "When another Pokémon uses a dance move, it can use a dance move following it regardless of its Speed.");
        AddAbility("Dazzling", "Surprises the opposing Pokémon, making it unable to attack using priority moves.");
        AddAbility("Disguise", "Once per battle, the shroud that covers the Pokémon can protect it from an attack.");
        AddAbility("Electric Surge", "Turns the ground into Electric Terrain when the Pokémon enters a battle.");
        AddAbility("Emergency Exit", "The Pokémon, sensing danger, switches out when its HP becomes half or less.");
        AddAbility("Fluffy", "Halves the damage taken from moves that make direct contact, but doubles that of Fire-type moves.");
        AddAbility("Full Metal Body", "Prevents other Pokémon from lowering its stats with moves or Abilities.");
        AddAbility("Galvanize", "Normal-type moves become Electric-type moves. The power of those moves is boosted a little.");
        AddAbility("Grassy Surge", "Turns the ground into Grassy Terrain when the Pokémon enters a battle.");
        AddAbility("Innards Out", "Damages the attacker landing the finishing hit by the amount equal to its last HP.");
        AddAbility("Liquid Voice", "All sound-based moves become Water-type moves.");
        AddAbility("Long Reach", "The Pokémon uses its moves without making contact with the target.");
        AddAbility("Merciless", "The Pokémon's attacks become critical hits if the target is poisoned.");
        AddAbility("Misty Surge", "Turns the ground into Misty Terrain when the Pokémon enters a battle.");
        AddAbility("Neuroforce", "Powers up moves that are super effective.");
        AddAbility("Power Construct", "Other Cells gather to aid when its HP becomes half or less. Then the Pokémon changes its form to Complete Forme.");
        AddAbility("Power of Alchemy", "The Pokémon copies the Ability of a defeated ally.");
        AddAbility("Prism Armor", "Reduces the power of supereffective attacks taken.");
        AddAbility("Psychic Surge", "Turns the ground into Psychic Terrain when the Pokémon enters a battle.");
        AddAbility("Queenly Majesty", "Its majesty pressures the opposing Pokémon, making it unable to attack using priority moves.");
        AddAbility("Receiver", "The Pokémon copies the Ability of a defeated ally.");
        AddAbility("RKS System", "Changes the Pokémon's type to match the memory disc it holds.");
        AddAbility("Schooling", "When it has a lot of HP, the Pokémon forms a powerful school. It stops schooling when its HP is low.");
        AddAbility("Shadow Shield", "Reduces the amount of damage the Pokémon takes while its HP is full.");
        AddAbility("Shields Down", "When its HP becomes half or less, the Pokémon's shell breaks and it becomes aggressive.");
        AddAbility("Slush Rush", "Boosts the Pokémon's Speed stat in hail.");
        AddAbility("Soul-Heart", "Boosts its Sp. Atk stat every time another Pokémon faints.");
        AddAbility("Stakeout", "Doubles the damage dealt to the target's replacement if the target switches out.");
        AddAbility("Stamina", "Boosts the Defense stat when hit by an attack.");
        AddAbility("Steelworker", "Powers up Steel-type moves.");
        AddAbility("Surge Surfer", "Doubles the Pokémon's Speed stat on Electric Terrain.");
        AddAbility("Tangling Hair", "Contact with the Pokémon lowers the attacker's Speed stat.");
        AddAbility("Triage", "Gives priority to healing moves.");
        AddAbility("Water Bubble", "Lowers the power of Fire-type moves done to the Pokémon and prevents the Pokémon from getting a burn.");
        AddAbility("Water Compaction", "Boosts the Pokémon's Defense stat sharply when hit by a Water-type move.");
        AddAbility("Wimp Out", "The Pokémon cowardly switches out when its HP becomes half or less.");

        // Generation 8 abilities (SS)
        AddAbility("As One (Glastrier)", "This Ability combines the effects of both Calyrex's Unnerve Ability and Glastrier's Chilling Neigh Ability.");
        AddAbility("As One (Spectrier)", "This Ability combines the effects of both Calyrex's Unnerve Ability and Spectrier's Grim Neigh Ability.");
        AddAbility("Ball Fetch", "If the Pokémon is not holding an item, it will fetch the Poké Ball from the first failed throw of the battle.");
        AddAbility("Chilling Neigh", "When the Pokémon knocks out a target, it utters a chilling neigh, which boosts its Attack stat.");
        AddAbility("Cotton Down", "When the Pokémon is hit by an attack, it scatters cotton fluff around and lowers the Speed stat of all Pokémon except itself.");
        AddAbility("Curious Medicine", "When the Pokémon enters a battle, it scatters medicine from its shell, which removes all stat changes from allies.");
        AddAbility("Dauntless Shield", "Boosts the Pokémon's Defense stat when the Pokémon enters a battle.");
        AddAbility("Dragon's Maw", "Powers up Dragon-type moves.");
        AddAbility("Gorilla Tactics", "Boosts the Pokémon's Attack stat but only allows the use of the first selected move.");
        AddAbility("Grim Neigh", "When the Pokémon knocks out a target, it utters a terrifying neigh, which boosts its Sp. Atk stat.");
        AddAbility("Gulp Missile", "When the Pokémon uses Surf or Dive, it will come back with prey. When it takes damage, it will spit out the prey to attack.");
        AddAbility("Hunger Switch", "The Pokémon changes its form, alternating between its Full Belly Mode and Hangry Mode after the end of each turn.");
        AddAbility("Ice Face", "The Pokémon's ice head can take a physical attack as a substitute, but the attack also changes the Pokémon's appearance.");
        AddAbility("Ice Scales", "The Pokémon is protected by ice scales, which halve the damage taken from special moves.");
        AddAbility("Intrepid Sword", "Boosts the Pokémon's Attack stat when the Pokémon enters a battle.");
        AddAbility("Libero", "Changes the Pokémon's type to the type of the move it's about to use.");
        AddAbility("Mimicry", "Changes the Pokémon's type depending on the terrain.");
        AddAbility("Mirror Armor", "Bounces back only the stat-lowering effects that the Pokémon receives.");
        AddAbility("Neutralizing Gas", "If the Pokémon with Neutralizing Gas is in the battle, the effects of all Pokémon's Abilities will be nullified or will not be triggered.");
        AddAbility("Pastel Veil", "Protects the Pokémon and its ally Pokémon from being poisoned.");
        AddAbility("Perish Body", "When hit by a move that makes direct contact, the Pokémon and the attacker will faint after three turns unless they switch out of battle.");
        AddAbility("Power Spot", "Just being next to the Pokémon powers up moves.");
        AddAbility("Propeller Tail", "Ignores the effects of opposing Pokémon's Abilities and moves that draw in moves.");
        AddAbility("Punk Rock", "Boosts the power of sound-based moves. The Pokémon also takes half the damage from sound-based moves.");
        AddAbility("Quick Draw", "Enables the Pokémon to move first occasionally.");
        AddAbility("Ripen", "Ripens Berries and doubles their effect.");
        AddAbility("Sand Spit", "The Pokémon creates a sandstorm when it's hit by an attack.");
        AddAbility("Screen Cleaner", "When the Pokémon enters a battle, the effects of Light Screen, Reflect, and Aurora Veil are nullified for both opposing and ally Pokémon.");
        AddAbility("Stalwart", "Ignores the effects of opposing Pokémon's Abilities and moves that draw in moves.");
        AddAbility("Steam Engine", "Boosts the Pokémon's Speed stat drastically if hit by a Fire- or Water-type move.");
        AddAbility("Steely Spirit", "Powers up ally Pokémon's Steel-type moves.");
        AddAbility("Transistor", "Powers up Electric-type moves.");
        AddAbility("Unseen Fist", "If the Pokémon uses moves that make direct contact, it can attack the target even if the target protects itself.");
        AddAbility("Wandering Spirit", "The Pokémon exchanges Abilities with a Pokémon that hits it with a move that makes direct contact.");

        // Generation 9 abilities (SV)
        AddAbility("Anger Shell", "When an attack causes its HP to drop to half or less, the Pokémon gets angry. This lowers its Defense and Sp. Def stats but boosts its Attack, Sp. Atk, and Speed stats.");
        AddAbility("Armor Tail", "The mysterious tail covering the Pokémon's head makes opponents unable to use priority moves against the Pokémon or its allies.");
        AddAbility("Beads of Ruin", "The power of the Pokémon's ruinous beads lowers the Sp. Def stats of all Pokémon except itself.");
        AddAbility("Commander", "When the Pokémon enters a battle, it goes inside the mouth of an ally Dondozo if one is on the field. The Pokémon then issues commands from there.");
        AddAbility("Costar", "When the Pokémon enters a battle, it copies an ally's stat changes.");
        AddAbility("Cud Chew", "When the Pokémon eats a Berry, it will regurgitate that Berry at the end of the next turn and eat it one more time.");
        AddAbility("Earth Eater", "If hit by a Ground-type move, the Pokémon has its HP restored instead of taking damage.");
        AddAbility("Electromorphosis", "The Pokémon becomes charged when it takes damage, boosting the power of the next Electric-type move the Pokémon uses.");
        AddAbility("Embody Aspect (Cornerstone)", "The Pokémon's heart fills with memories, causing the Cornerstone Mask to shine and the Pokémon's Defense stat to be boosted.");
        AddAbility("Embody Aspect (Hearthflame)", "The Pokémon's heart fills with memories, causing the Hearthflame Mask to shine and the Pokémon's Attack stat to be boosted.");
        AddAbility("Embody Aspect (Teal)", "The Pokémon's heart fills with memories, causing the Teal Mask to shine and the Pokémon's Speed stat to be boosted.");
        AddAbility("Embody Aspect (Wellspring)", "The Pokémon's heart fills with memories, causing the Wellspring Mask to shine and the Pokémon's Sp. Atk stat to be boosted.");
        AddAbility("Good as Gold", "A body of pure, solid gold gives the Pokémon full immunity to other Pokémon's status moves.");
        AddAbility("Guard Dog", "Boosts the Pokémon's Attack stat if intimidated. Moves and items that would force the Pokémon to switch out also fail to work.");
        AddAbility("Hadron Engine", "Turns the ground into Electric Terrain when the Pokémon enters a battle. The terrain does not wear off until the Pokémon leaves the field.");
        AddAbility("Hospitality", "When the Pokémon enters a battle, it showers its ally with hospitality, restoring a small amount of the ally's HP.");
        AddAbility("Lingering Aroma", "Contact with the Pokémon changes the attacker's Ability to Lingering Aroma.");
        AddAbility("Mind's Eye", "The Pokémon ignores changes to opponents' evasiveness, its accuracy can't be lowered, and it can hit Ghost types with Normal- and Fighting-type moves.");
        AddAbility("Mycelium Might", "The Pokémon will always act more slowly when using status moves, but these moves will be unimpeded by the Ability of the target.");
        AddAbility("Opportunist", "If an opponent's stat is boosted, the Pokémon seizes the opportunity to boost the same stat for itself.");
        AddAbility("Orichalcum Pulse", "Turns the sunlight harsh when the Pokémon enters a battle. The harsh sunlight does not wear off until the Pokémon leaves the field.");
        AddAbility("Poison Puppeteer", "Pokémon poisoned by Pecharunt's moves will also become confused.");
        AddAbility("Protosynthesis", "Boosts the Pokémon's most proficient stat in harsh sunlight or if the Pokémon is holding Booster Energy.");
        AddAbility("Purifying Salt", "The Pokémon's pure salt protects it from status conditions and halves the damage taken from Ghost-type moves.");
        AddAbility("Quark Drive", "Boosts the Pokémon's most proficient stat on Electric Terrain or if the Pokémon is holding Booster Energy.");
        AddAbility("Rocky Payload", "Powers up Rock-type moves.");
        AddAbility("Seed Sower", "Turns the ground into Grassy Terrain when the Pokémon takes damage.");
        AddAbility("Sharpness", "Powers up slicing moves.");
        AddAbility("Supersweet Syrup", "A sickly sweet scent spreads across the field the first time the Pokémon enters a battle, lowering the evasiveness of opposing Pokémon.");
        AddAbility("Supreme Overlord", "When the Pokémon enters a battle, its Attack and Sp. Atk stats are slightly boosted for each of the allies in its party that have already been defeated.");
        AddAbility("Sword of Ruin", "The power of the Pokémon's ruinous sword lowers the Defense stats of all Pokémon except itself.");
        AddAbility("Tablets of Ruin", "The power of the Pokémon's ruinous wooden tablets lowers the Attack stats of all Pokémon except itself.");
        AddAbility("Tera Shell", "The Pokémon's shell contains the powers of each type. All damage-dealing moves that hit the Pokémon when its HP is full will not be very effective.");
        AddAbility("Tera Shift", "When the Pokémon enters a battle, it absorbs the energy around itself and transforms into its Terastal Form.");
        AddAbility("Teraform Zero", "When Terapagos changes into its Stellar Form, it uses its hidden power to eliminate all effects of weather and terrain.");
        AddAbility("Thermal Exchange", "Boosts the Attack stat when the Pokémon is hit by a Fire-type move. The Pokémon also cannot be burned.");
        AddAbility("Toxic Chain", "The power of the Pokémon's toxic chain may badly poison any target the Pokémon hits with a move.");
        AddAbility("Toxic Debris", "Scatters poison spikes at the feet of the opposing team when the Pokémon takes damage from physical moves.");
        AddAbility("Vessel of Ruin", "The power of the Pokémon's ruinous vessel lowers the Sp. Atk stats of all Pokémon except itself.");
        AddAbility("Well-Baked Body", "The Pokémon takes no damage when hit by Fire-type moves. Instead, its Defense stat is sharply boosted.");
        AddAbility("Wind Power", "The Pokémon becomes charged when it is hit by a wind move, boosting the power of the next Electric-type move the Pokémon uses.");
        AddAbility("Wind Rider", "Boosts the Pokémon's Attack stat if Tailwind takes effect or if the Pokémon is hit by a wind move. The Pokémon also takes no damage from wind moves.");
        AddAbility("Zero to Hero", "The Pokémon transforms into its Hero Form when it switches out.");
    }

    private static void AddAbility(string name, string description)
    {
        var ability = new Ability(name, description);
        _abilitiesLookup[name] = ability;
    }
}