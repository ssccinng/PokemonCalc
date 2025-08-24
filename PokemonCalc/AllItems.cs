namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Complete items database based on smogon/damage-calc reference
/// </summary>
public static class AllItems
{
    private static readonly Dictionary<string, Item> _itemsLookup = new(StringComparer.OrdinalIgnoreCase);
    
    static AllItems()
    {
        InitializeItems();
    }
    
    public static Item? GetByName(string name) => 
        _itemsLookup.TryGetValue(name, out var item) ? item : null;

    public static IEnumerable<Item> GetAll() => _itemsLookup.Values;
    
    private static void InitializeItems()
    {
        // Generation 2 (GSC) items
        AddItem("Berry Juice", "A 100% pure juice made of Berries. When consumed, it restores 20 HP to an injured Pokémon.");
        AddItem("Berry", "A Pecha Berry. If held by a Pokémon, it recovers from paralysis.");
        AddItem("Berserk Gene", "An item that boosts Attack but causes confusion. It can't be removed until the Pokémon switches out.");
        AddItem("Bitter Berry", "A hold item that heals confusion. Single use.");
        AddItem("Black Belt", "An item to be held by a Pokémon. It's a belt that boosts determination and Fighting-type moves.");
        AddItem("Black Glasses", "An item to be held by a Pokémon. These thick glasses boost Dark-type moves.");
        AddItem("Bright Powder", "An item to be held by a Pokémon. It casts a tricky glare that lowers the opponent's accuracy.");
        AddItem("Burnt Berry", "A hold item that heals freeze. Single use.");
        AddItem("Charcoal", "An item to be held by a Pokémon. It's a combustible fuel that boosts Fire-type moves.");
        AddItem("Dragon Fang", "An item to be held by a Pokémon. This hard and sharp fang boosts Dragon-type moves.");
        AddItem("Dragon Scale", "A thick and durable scale. Dragon-type Pokémon may be holding this item when caught.");
        AddItem("Fast Ball", "A Poké Ball that makes it easier to catch Pokémon which are quick to run away.");
        AddItem("Fire Stone", "A peculiar stone that can make certain species of Pokémon evolve. It burns as red as a flame.");
        AddItem("Focus Band", "An item to be held by a Pokémon. The holder may endure a potential KO attack, leaving it with just 1 HP.");
        AddItem("Friend Ball", "A Poké Ball that makes caught Pokémon more friendly.");
        AddItem("Gold Berry", "A hold item that restores 30 HP. Single use.");
        AddItem("Great Ball", "A good, high-performance Poké Ball that provides a higher success rate for catching Pokémon than a standard Poké Ball.");
        AddItem("Hard Stone", "An item to be held by a Pokémon. It's an unbreakable stone that boosts Rock-type moves.");
        AddItem("Heavy Ball", "A Poké Ball for catching very heavy Pokémon.");
        AddItem("Ice Berry", "A hold item that heals burn. Single use.");
        AddItem("King's Rock", "An item to be held by a Pokémon. When the holder successfully inflicts damage, the target may also flinch.");
        AddItem("Leaf Stone", "A peculiar stone that can make certain species of Pokémon evolve. It has an unmistakable leaf pattern.");
        AddItem("Leftovers", "An item to be held by a Pokémon. The holder's HP is slowly but steadily restored throughout every battle.");
        AddItem("Level Ball", "A Poké Ball for catching Pokémon that are a lower level than your own.");
        AddItem("Light Ball", "An item to be held by Pikachu. It's a mysterious orb that boosts its Attack and Sp. Atk stats.");
        AddItem("Love Ball", "A Poké Ball for catching Pokémon that are the opposite gender of your Pokémon.");
        AddItem("Lucky Punch", "An item to be held by Chansey. It's a glove that boosts Chansey's critical-hit ratio.");
        AddItem("Lure Ball", "A Poké Ball for catching Pokémon hooked by a Rod when fishing.");
        AddItem("Magnet", "An item to be held by a Pokémon. It's a powerful magnet that boosts Electric-type moves.");
        AddItem("Mail", "A Poké Ball for catching Pokémon in your Safari Zone.");
        AddItem("Master Ball", "The best Poké Ball with the ultimate level of performance. With it, you will catch any wild Pokémon without fail.");
        AddItem("Metal Coat", "An item to be held by a Pokémon. It's a special metallic film that can boost the power of Steel-type moves.");
        AddItem("Metal Powder", "An item to be held by Ditto. Extremely fine yet hard, this odd powder boosts the Defense stat.");
        AddItem("Mint Berry", "A hold item that heals sleep. Single use.");
        AddItem("Miracle Berry", "A hold item that heals all status problems. Single use.");
        AddItem("Miracle Seed", "An item to be held by a Pokémon. It's a life-force seed that boosts Grass-type moves.");
        AddItem("Moon Ball", "A Poké Ball for catching Pokémon that evolve using the Moon Stone.");
        AddItem("Moon Stone", "A peculiar stone that can make certain species of Pokémon evolve. It's as black as the night sky.");
        AddItem("Mystery Berry", "A hold item that restores 5 PP. Single use.");
        AddItem("Mystic Water", "An item to be held by a Pokémon. This teardrop-shaped gem boosts Water-type moves.");
        AddItem("Never-Melt Ice", "An item to be held by a Pokémon. It's a piece of ice that repels heat and boosts Ice-type moves.");
        AddItem("Pink Bow", "An item to be held by a Pokémon. It's a cute bow that boosts Normal-type moves.");
        AddItem("Poison Barb", "An item to be held by a Pokémon. This small, poisonous barb boosts Poison-type moves.");
        AddItem("Poke Ball", "A device for catching wild Pokémon. It's thrown like a ball at a Pokémon, comfortably encapsulating its target.");
        AddItem("Polkadot Bow", "An item to be held by a Pokémon. It's a cute bow that boosts Normal-type moves.");
        AddItem("PRZ Cure Berry", "A hold item that heals paralysis. Single use.");
        AddItem("PSN Cure Berry", "A hold item that heals poison. Single use.");
        AddItem("Quick Claw", "An item to be held by a Pokémon. A light and sharp claw. The holder may be able to strike first.");
        AddItem("Safari Ball", "A special Poké Ball that is used only in the Safari Zone and Great Marsh.");
        AddItem("Scope Lens", "An item to be held by a Pokémon. It's a lens for scoping out weak points. It boosts the holder's critical-hit ratio.");
        AddItem("Sharp Beak", "An item to be held by a Pokémon. It's a long, sharp beak that boosts Flying-type moves.");
        AddItem("Silver Powder", "An item to be held by a Pokémon. It's a shiny silver powder that boosts Bug-type moves.");
        AddItem("Soft Sand", "An item to be held by a Pokémon. It's a loose, silky sand that boosts Ground-type moves.");
        AddItem("Spell Tag", "An item to be held by a Pokémon. It's a sinister, eerie tag that boosts Ghost-type moves.");
        AddItem("Sport Ball", "A special Poké Ball for the Bug-Catching Contest.");
        AddItem("Stick", "An item to be held by Farfetch'd. It's a very long and stiff stalk of leek that boosts Farfetch'd's critical-hit ratio.");
        AddItem("Sun Stone", "A peculiar stone that can make certain species of Pokémon evolve. It burns as red as the evening sun.");
        AddItem("Thick Club", "An item to be held by Cubone or Marowak. It's a hard bone of some sort that boosts the Attack stat.");
        AddItem("Thunder Stone", "A peculiar stone that can make certain species of Pokémon evolve. It has a distinct thunderbolt pattern.");
        AddItem("Twisted Spoon", "An item to be held by a Pokémon. It's a spoon imbued with telekinetic power that boosts Psychic-type moves.");
        AddItem("Ultra Ball", "An ultra-high-performance Poké Ball that provides a higher success rate for catching Pokémon than a Great Ball.");
        AddItem("Up-Grade", "A transparent device overflowing with dubious data. Its producer is unknown.");
        AddItem("Water Stone", "A peculiar stone that can make certain species of Pokémon evolve. It's a clear light blue.");

        // Generation 3 (ADV) items
        AddItem("Aguav Berry", "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.");
        AddItem("Apicot Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Sp. Def stat will increase when it's in a pinch.");
        AddItem("Aspear Berry", "If held by a Pokémon, it recovers from being frozen.");
        AddItem("Belue Berry", "Used to make Pokéblocks that will enhance your Beauty, this Berry is rare in every region.");
        AddItem("Bluk Berry", "Used to make Pokéblocks that will enhance your Beauty. Its blue color is generally popular for this purpose.");
        AddItem("Cheri Berry", "If held by a Pokémon, it recovers from paralysis.");
        AddItem("Chesto Berry", "If held by a Pokémon, it recovers from sleep.");
        AddItem("Choice Band", "An item to be held by a Pokémon. This curious headband boosts Attack but only allows the use of one move.");
        AddItem("Claw Fossil", "A fossil from a prehistoric Pokémon that lived on the land. It appears to be a claw.");
        AddItem("Cornn Berry", "Used to make Pokéblocks that will enhance your Beauty. Its dryness makes it unsuitable for rookies.");
        AddItem("Deep Sea Scale", "An item to be held by Clamperl. A scale that shines with a faint pink light. It raises the Sp. Def stat.");
        AddItem("Deep Sea Tooth", "An item to be held by Clamperl. A fang that gleams with a sharp luster. It raises the Sp. Atk stat.");
        AddItem("Dive Ball", "A somewhat different Poké Ball that works especially well when catching Pokémon that live underwater.");
        AddItem("Dome Fossil", "A fossil from a prehistoric Pokémon that lived in the sea. It could be a shell or carapace.");
        AddItem("Durin Berry", "Used to make Pokéblocks that will enhance your Smartness. Its large size makes it cumbersome to eat.");
        AddItem("Enigma Berry", "A completely enigmatic Berry. It apparently has the power of the stars that fill the night sky.");
        AddItem("Figy Berry", "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates spicy food.");
        AddItem("Ganlon Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Defense stat will increase when it's in a pinch.");
        AddItem("Grepa Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base Sp. Def stat.");
        AddItem("Helix Fossil", "A fossil from a prehistoric Pokémon that lived in the sea. It might be a piece of a seashell.");
        AddItem("Hondew Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base Sp. Atk stat.");
        AddItem("Iapapa Berry", "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates sour food.");
        AddItem("Kelpsy Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base Attack stat.");
        AddItem("Lansat Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its critical-hit ratio will increase when it's in a pinch.");
        AddItem("Lax Incense", "An item to be held by a Pokémon. The beguiling aroma of this incense may cause attacks to miss the holder.");
        AddItem("Leppa Berry", "If held by a Pokémon, it restores a move's PP by 10.");
        AddItem("Liechi Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Attack stat will increase when it's in a pinch.");
        AddItem("Lum Berry", "If held by a Pokémon, it recovers from any status condition.");
        AddItem("Luxury Ball", "A comfortable Poké Ball that makes a caught wild Pokémon quickly grow friendlier.");
        AddItem("Macho Brace", "An item to be held by a Pokémon. It's a stiff and heavy brace that promotes strong growth but lowers Speed.");
        AddItem("Mago Berry", "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates sweet food.");
        AddItem("Magost Berry", "Used to make Pokéblocks that will enhance your Cuteness. Its red color makes it unsuitable for beginners.");
        AddItem("Mental Herb", "An item to be held by a Pokémon. The holder shrugs off move-binding effects to move freely.");
        AddItem("Nanab Berry", "Used to make Pokéblocks that will enhance your Cuteness. Its pink color is popular among young people.");
        AddItem("Nest Ball", "A somewhat different Poké Ball that has a more successful catch rate if used on a weaker Pokémon.");
        AddItem("Net Ball", "A somewhat different Poké Ball that is more effective when attempting to catch Water- or Bug-type Pokémon.");
        AddItem("Nomel Berry", "Used to make Pokéblocks that will enhance your Toughness. It's considered highly nutritious.");
        AddItem("Old Amber", "A piece of amber that contains the genetic material of an ancient Pokémon. It's clear with a tawny, golden coloration.");
        AddItem("Oran Berry", "If held by a Pokémon, it heals the user by just 10 HP.");
        AddItem("Pamtre Berry", "Used to make Pokéblocks that will enhance your Beauty. It's said that this Berry grew lumps to help store water.");
        AddItem("Pecha Berry", "If held by a Pokémon, it recovers from poison.");
        AddItem("Persim Berry", "If held by a Pokémon, it recovers from confusion.");
        AddItem("Petaya Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Sp. Atk stat will increase when it's in a pinch.");
        AddItem("Pinap Berry", "Used to make Pokéblocks that will enhance your Toughness. It lives for a long time, so it can be eaten fresh year-round.");
        AddItem("Pomeg Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base HP stat.");
        AddItem("Premier Ball", "A somewhat rare Poké Ball that was made as a commemorative item.");
        AddItem("Qualot Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base Defense stat.");
        AddItem("Rabuta Berry", "Used to make Pokéblocks that will enhance your Smartness. It makes fruits ripen faster when buried in soil.");
        AddItem("Rawst Berry", "If held by a Pokémon, it recovers from a burn.");
        AddItem("Razz Berry", "Used to make Pokéblocks that will enhance your Coolness. Its red color and spicy flavor are equally attractive.");
        AddItem("Repeat Ball", "A somewhat different Poké Ball that works especially well on Pokémon species that were previously caught.");
        AddItem("Root Fossil", "A fossil from a prehistoric Pokémon that lived on the land. It looks like the root of a tree.");
        AddItem("Salac Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Speed stat will increase when it's in a pinch.");
        AddItem("Sea Incense", "An item to be held by a Pokémon. It slightly boosts the power of Water-type moves.");
        AddItem("Shell Bell", "An item to be held by a Pokémon. The holder's HP is restored a little every time it inflicts damage.");
        AddItem("Silk Scarf", "An item to be held by a Pokémon. It's a sumptuous scarf that boosts Normal-type moves.");
        AddItem("Sitrus Berry", "If held by a Pokémon, it heals the user's HP a little.");
        AddItem("Soul Dew", "A wondrous orb to be held by Latios or Latias. It boosts the power of Psychic- and Dragon-type moves.");
        AddItem("Spelon Berry", "Used to make Pokéblocks that will enhance your Cuteness. Its flesh is sweet, but its skin is very spicy.");
        AddItem("Starf Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, one of its stats will be greatly boosted when it's in a pinch.");
        AddItem("Tamato Berry", "Using it on a Pokémon makes it more friendly, but it also lowers its base Speed stat.");
        AddItem("Timer Ball", "A somewhat different Poké Ball that becomes more effective the more turns there are in a battle.");
        AddItem("Watmel Berry", "Used to make Pokéblocks that will enhance your Smartness. It's popular with Pokémon that love to eat a lot.");
        AddItem("Wepear Berry", "Used to make Pokéblocks that will enhance your Coolness. It makes other food eaten at the same time taste sweet.");
        AddItem("White Herb", "An item to be held by a Pokémon. It will restore any lowered stat in battle. It can be used only once.");
        AddItem("Wiki Berry", "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates dry food.");

        // Generation 4 (DPP) items
        AddItem("Adamant Orb", "A brightly gleaming orb to be held by Dialga. It boosts the power of Dragon- and Steel-type moves when they are used by Dialga.");
        AddItem("Armor Fossil", "A fossil from a prehistoric Pokémon that lived on the land. It appears as though it could be part of a collar.");
        AddItem("Babiri Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Steel-type attack.");
        AddItem("Big Root", "An item to be held by a Pokémon. It boosts the power of HP-stealing moves to let the holder recover more HP.");
        AddItem("Black Sludge", "An item to be held by a Pokémon. It gradually restores the HP of Poison-type Pokémon. It damages other types.");
        AddItem("Charti Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Rock-type attack.");
        AddItem("Cherish Ball", "A quite rare Poké Ball that has been specially crafted to commemorate an occasion of some sort.");
        AddItem("Chilan Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one Normal-type attack.");
        AddItem("Choice Scarf", "An item to be held by a Pokémon. This curious scarf boosts Speed but only allows the use of one move.");
        AddItem("Choice Specs", "An item to be held by a Pokémon. These curious glasses boost Sp. Atk but only allow the use of one move.");
        AddItem("Chople Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Fighting-type attack.");
        AddItem("Coba Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Flying-type attack.");
        AddItem("Colbur Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Dark-type attack.");
        AddItem("Custap Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, it will be able to move first just once when it's in a pinch.");
        AddItem("Damp Rock", "An item to be held by a Pokémon. It extends the duration of the move Rain Dance when used by the holder.");
        AddItem("Dawn Stone", "A peculiar stone that can make certain species of Pokémon evolve. It sparkles like a glittering eye.");
        AddItem("Destiny Knot", "An item to be held by a Pokémon. If the holder becomes infatuated, the opposing Pokémon will be, too.");
        AddItem("Draco Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Dragon-type moves.");
        AddItem("Dread Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Dark-type moves.");
        AddItem("Dubious Disc", "A transparent device overflowing with dubious data. Its producer is unknown.");
        AddItem("Dusk Ball", "A somewhat different Poké Ball that makes it easier to catch wild Pokémon at night or in dark places such as caves.");
        AddItem("Dusk Stone", "A peculiar stone that can make certain species of Pokémon evolve. It holds shadows as dark as can be.");
        AddItem("Earth Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Ground-type moves.");
        AddItem("Electirizer", "A box packed with a tremendous amount of electric energy. It's loved by a certain Pokémon.");
        AddItem("Expert Belt", "An item to be held by a Pokémon. It's a well-worn belt that boosts the power of supereffective moves.");
        AddItem("Fist Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Fighting-type moves.");
        AddItem("Flame Orb", "An item to be held by a Pokémon. It's a heated orb that burns the holder every turn.");
        AddItem("Flame Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Fire-type moves.");
        AddItem("Focus Sash", "An item to be held by a Pokémon. If it has full HP, the holder will endure one potential KO attack, leaving 1 HP.");
        AddItem("Full Incense", "An item to be held by a Pokémon. This exotic incense makes the holder bloated and slow moving.");
        AddItem("Grip Claw", "An item to be held by a Pokémon. It extends the duration of multiturn attack moves such as Bind and Wrap.");
        AddItem("Griseous Orb", "A glowing orb to be held by Giratina. It boosts the power of Dragon- and Ghost-type moves when they are used by Giratina.");
        AddItem("Haban Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Dragon-type attack.");
        AddItem("Heal Ball", "A remedial Poké Ball that restores the caught Pokémon's HP and status problem.");
        AddItem("Heat Rock", "An item to be held by a Pokémon. It extends the duration of the move Sunny Day when used by the holder.");
        AddItem("Icicle Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Ice-type moves.");
        AddItem("Icy Rock", "An item to be held by a Pokémon. It extends the duration of the move Hail when used by the holder.");
        AddItem("Insect Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Bug-type moves.");
        AddItem("Iron Ball", "An item to be held by a Pokémon. It lowers Speed and allows Ground-type moves to hit Flying-type Pokémon.");
        AddItem("Iron Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Steel-type moves.");
        AddItem("Jaboca Berry", "If held by a Pokémon and a physical attack does damage to it, the attacker will also be damaged upon contact.");
        AddItem("Kasib Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Ghost-type attack.");
        AddItem("Kebia Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Poison-type attack.");
        AddItem("Lagging Tail", "An item to be held by a Pokémon. It is tremendously heavy and makes the holder move slower than usual.");
        AddItem("Life Orb", "An item to be held by a Pokémon. It boosts the power of moves, but at the cost of some HP on each use.");
        AddItem("Light Clay", "An item to be held by a Pokémon. It extends the duration of barrier moves such as Light Screen and Reflect used by the holder.");
        AddItem("Lustrous Orb", "A beautifully glowing orb to be held by Palkia. It boosts the power of Dragon- and Water-type moves when they are used by Palkia.");
        AddItem("Magmarizer", "A box packed with a tremendous amount of magma energy. It's loved by a certain Pokémon.");
        AddItem("Meadow Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Grass-type moves.");
        AddItem("Metronome", "An item to be held by a Pokémon. It boosts moves used consecutively, but only until a different move is used.");
        AddItem("Micle Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its accuracy will increase just once when it's in a pinch.");
        AddItem("Mind Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Psychic-type moves.");
        AddItem("Muscle Band", "An item to be held by a Pokémon. It's a headband that slightly boosts the power of physical moves.");
        AddItem("Occa Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Fire-type attack.");
        AddItem("Odd Incense", "An item to be held by a Pokémon. This exotic incense boosts the power of Psychic-type moves.");
        AddItem("Oval Stone", "A peculiar stone that can make certain species of Pokémon evolve. It's as round as a Pokémon Egg.");
        AddItem("Park Ball", "A special Poké Ball for the Pal Park.");
        AddItem("Passho Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Water-type attack.");
        AddItem("Payapa Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Psychic-type attack.");
        AddItem("Power Anklet", "An item to be held by a Pokémon. It's a stiff and heavy anklet that promotes strong growth but lowers Speed.");
        AddItem("Power Band", "An item to be held by a Pokémon. It's a stiff and heavy band that promotes strong growth but lowers Speed.");
        AddItem("Power Belt", "An item to be held by a Pokémon. It's a stiff and heavy belt that promotes strong growth but lowers Speed.");
        AddItem("Power Bracer", "An item to be held by a Pokémon. It's a stiff and heavy bracer that promotes strong growth but lowers Speed.");
        AddItem("Power Herb", "An item to be held by a Pokémon. It allows the immediate use of a move that charges on the first turn.");
        AddItem("Power Lens", "An item to be held by a Pokémon. It's a stiff and heavy lens that promotes strong growth but lowers Speed.");
        AddItem("Power Weight", "An item to be held by a Pokémon. It's a stiff and heavy weight that promotes strong growth but lowers Speed.");
        AddItem("Protector", "A protective item of some sort. It is extremely stiff and heavy. It's loved by a certain Pokémon.");
        AddItem("Quick Ball", "A somewhat different Poké Ball that provides a better catch rate if it's used at the start of a wild encounter.");
        AddItem("Quick Powder", "An item to be held by Ditto. Extremely fine yet hard, this odd powder boosts the Speed stat.");
        AddItem("Rare Bone", "A bone that is extremely valuable for Pokémon archeology. It can be sold for a high price to shops.");
        AddItem("Razor Claw", "An item to be held by a Pokémon. It's a sharp claw that boosts the holder's critical-hit ratio.");
        AddItem("Razor Fang", "An item to be held by a Pokémon. It may make foes flinch when the holder inflicts damage.");
        AddItem("Reaper Cloth", "A cloth imbued with horrifyingly strong spiritual energy. It's loved by a certain Pokémon.");
        AddItem("Rindo Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Grass-type attack.");
        AddItem("Rock Incense", "An item to be held by a Pokémon. This exotic incense boosts the power of Rock-type moves.");
        AddItem("Rose Incense", "An item to be held by a Pokémon. This exotic incense boosts the power of Grass-type moves.");
        AddItem("Rowap Berry", "If held by a Pokémon and a special attack does damage to it, the attacker will also be damaged upon contact.");
        AddItem("Shed Shell", "An item to be held by a Pokémon. The holder may switch out of battle whether or not it is trapped by a move.");
        AddItem("Shiny Stone", "A peculiar stone that can make certain species of Pokémon evolve. It shines with a dazzling light.");
        AddItem("Shuca Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Ground-type attack.");
        AddItem("Skull Fossil", "A fossil from a prehistoric Pokémon that lived on the land. It appears as though it could be part of a collar.");
        AddItem("Sky Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Flying-type moves.");
        AddItem("Smooth Rock", "An item to be held by a Pokémon. It extends the duration of the move Sandstorm when used by the holder.");
        AddItem("Splash Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Water-type moves.");
        AddItem("Spooky Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Ghost-type moves.");
        AddItem("Sticky Barb", "An item to be held by a Pokémon. It damages the holder every turn and may latch on to Pokémon that touch the holder.");
        AddItem("Stone Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Rock-type moves.");
        AddItem("Tanga Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Bug-type attack.");
        AddItem("Toxic Orb", "An item to be held by a Pokémon. It's a bizarre orb that badly poisons the holder in battle.");
        AddItem("Toxic Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Poison-type moves.");
        AddItem("Wacan Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Electric-type attack.");
        AddItem("Wave Incense", "An item to be held by a Pokémon. This exotic incense boosts the power of Water-type moves.");
        AddItem("Wide Lens", "An item to be held by a Pokémon. It's a magnifying lens that slightly boosts the accuracy of moves.");
        AddItem("Wise Glasses", "An item to be held by a Pokémon. It's a thick pair of glasses that slightly boosts the power of special moves.");
        AddItem("Yache Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Ice-type attack.");
        AddItem("Zap Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Electric-type moves.");
        AddItem("Zoom Lens", "An item to be held by a Pokémon. If the holder moves after its target, its accuracy will be boosted.");

        // Generation 5 (BW) items
        AddItem("Absorb Bulb", "An item to be held by a Pokémon. It boosts Sp. Atk if the holder is hit by a Water-type move. It can only be used once.");
        AddItem("Air Balloon", "An item to be held by a Pokémon. The holder will float in the air until hit. Once hit, this item will burst.");
        AddItem("Binding Band", "An item to be held by a Pokémon. It's a band that increases the power of binding moves when held.");
        AddItem("Bug Gem", "A gem with an essence of Bug. When held, it strengthens the power of a Bug-type move one time.");
        AddItem("Burn Drive", "A cassette to be held by Genesect. It changes Genesect's Techno Blast move so it becomes Fire type.");
        AddItem("Cell Battery", "An item to be held by a Pokémon. It boosts Attack if the holder is hit by an Electric-type move. It can only be used once.");
        AddItem("Chill Drive", "A cassette to be held by Genesect. It changes Genesect's Techno Blast move so it becomes Ice type.");
        AddItem("Cover Fossil", "A fossil from a prehistoric Pokémon that lived on the land. It appears as though it could be part of a collar.");
        AddItem("Dark Gem", "A gem with an essence of Dark. When held, it strengthens the power of a Dark-type move one time.");
        AddItem("Douse Drive", "A cassette to be held by Genesect. It changes Genesect's Techno Blast move so it becomes Water type.");
        AddItem("Dragon Gem", "A gem with an essence of Dragon. When held, it strengthens the power of a Dragon-type move one time.");
        AddItem("Dream Ball", "A Poké Ball that makes it easier to catch wild Pokémon while they're asleep.");
        AddItem("Eject Button", "An item to be held by a Pokémon. If the holder is hit by an attack, it will be switched out of battle.");
        AddItem("Electric Gem", "A gem with an essence of Electric. When held, it strengthens the power of an Electric-type move one time.");
        AddItem("Eviolite", "An item to be held by a Pokémon that can still evolve. It may evolve into a stronger form.");
        AddItem("Fighting Gem", "A gem with an essence of Fighting. When held, it strengthens the power of a Fighting-type move one time.");
        AddItem("Fire Gem", "A gem with an essence of Fire. When held, it strengthens the power of a Fire-type move one time.");
        AddItem("Float Stone", "An item to be held by a Pokémon. It's a very light stone that reduces the weight of a Pokémon when held.");
        AddItem("Flying Gem", "A gem with an essence of Flying. When held, it strengthens the power of a Flying-type move one time.");
        AddItem("Ghost Gem", "A gem with an essence of Ghost. When held, it strengthens the power of a Ghost-type move one time.");
        AddItem("Grass Gem", "A gem with an essence of Grass. When held, it strengthens the power of a Grass-type move one time.");
        AddItem("Ground Gem", "A gem with an essence of Ground. When held, it strengthens the power of a Ground-type move one time.");
        AddItem("Ice Gem", "A gem with an essence of Ice. When held, it strengthens the power of an Ice-type move one time.");
        AddItem("Normal Gem", "A gem with an essence of Normal. When held, it strengthens the power of a Normal-type move one time.");
        AddItem("Plume Fossil", "A fossil from a prehistoric Pokémon that lived in the sky. It looks like the wing bone of a bird.");
        AddItem("Poison Gem", "A gem with an essence of Poison. When held, it strengthens the power of a Poison-type move one time.");
        AddItem("Prism Scale", "A mysterious scale that causes a certain Pokémon to evolve. It shines in rainbow colors.");
        AddItem("Psychic Gem", "A gem with an essence of Psychic. When held, it strengthens the power of a Psychic-type move one time.");
        AddItem("Red Card", "An item to be held by a Pokémon. When the holder is struck by a move, the attacker is removed from battle.");
        AddItem("Ring Target", "An item to be held by a Pokémon. Moves that normally have no effect will land on the Pokémon that holds it.", true);
        AddItem("Rock Gem", "A gem with an essence of Rock. When held, it strengthens the power of a Rock-type move one time.");
        AddItem("Rocky Helmet", "An item to be held by a Pokémon. If the holder is hit by a move that makes direct contact, the attacker will also be damaged.");
        AddItem("Shock Drive", "A cassette to be held by Genesect. It changes Genesect's Techno Blast move so it becomes Electric type.");
        AddItem("Steel Gem", "A gem with an essence of Steel. When held, it strengthens the power of a Steel-type move one time.");
        AddItem("Water Gem", "A gem with an essence of Water. When held, it strengthens the power of a Water-type move one time.");

        // Mega Stones (Generation 6)
        AddItem("Absolite", "One variety of the mysterious Mega Stones. Have Absol hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Absol");
        AddItem("Abomasite", "One variety of the mysterious Mega Stones. Have Abomasnow hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Abomasnow");
        AddItem("Aerodactylite", "One variety of the mysterious Mega Stones. Have Aerodactyl hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Aerodactyl");
        AddItem("Aggronite", "One variety of the mysterious Mega Stones. Have Aggron hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Aggron");
        AddItem("Alakazite", "One variety of the mysterious Mega Stones. Have Alakazam hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Alakazam");
        AddItem("Altarianite", "One variety of the mysterious Mega Stones. Have Altaria hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Altaria");
        AddItem("Ampharosite", "One variety of the mysterious Mega Stones. Have Ampharos hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Ampharos");
        AddItem("Banettite", "One variety of the mysterious Mega Stones. Have Banette hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Banette");
        AddItem("Beedrillite", "One variety of the mysterious Mega Stones. Have Beedrill hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Beedrill");
        AddItem("Blastoisinite", "One variety of the mysterious Mega Stones. Have Blastoise hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Blastoise");
        AddItem("Blazikenite", "One variety of the mysterious Mega Stones. Have Blaziken hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Blaziken");
        AddItem("Cameruptite", "One variety of the mysterious Mega Stones. Have Camerupt hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Camerupt");
        AddItem("Charizardite X", "One variety of the mysterious Mega Stones. Have Charizard hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Charizard");
        AddItem("Charizardite Y", "One variety of the mysterious Mega Stones. Have Charizard hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Charizard");
        AddItem("Diancite", "One variety of the mysterious Mega Stones. Have Diancie hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Diancie");
        AddItem("Galladite", "One variety of the mysterious Mega Stones. Have Gallade hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Gallade");
        AddItem("Garchompite", "One variety of the mysterious Mega Stones. Have Garchomp hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Garchomp");
        AddItem("Gardevoirite", "One variety of the mysterious Mega Stones. Have Gardevoir hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Gardevoir");
        AddItem("Gengarite", "One variety of the mysterious Mega Stones. Have Gengar hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Gengar");
        AddItem("Glalitite", "One variety of the mysterious Mega Stones. Have Glalie hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Glalie");
        AddItem("Gyaradosite", "One variety of the mysterious Mega Stones. Have Gyarados hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Gyarados");
        AddItem("Heracronite", "One variety of the mysterious Mega Stones. Have Heracross hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Heracross");
        AddItem("Houndoominite", "One variety of the mysterious Mega Stones. Have Houndoom hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Houndoom");
        AddItem("Kangaskhanite", "One variety of the mysterious Mega Stones. Have Kangaskhan hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Kangaskhan");
        AddItem("Latiasite", "One variety of the mysterious Mega Stones. Have Latias hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Latias");
        AddItem("Latiosite", "One variety of the mysterious Mega Stones. Have Latios hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Latios");
        AddItem("Lopunnite", "One variety of the mysterious Mega Stones. Have Lopunny hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Lopunny");
        AddItem("Lucarionite", "One variety of the mysterious Mega Stones. Have Lucario hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Lucario");
        AddItem("Manectite", "One variety of the mysterious Mega Stones. Have Manectric hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Manectric");
        AddItem("Mawilite", "One variety of the mysterious Mega Stones. Have Mawile hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Mawile");
        AddItem("Medichamite", "One variety of the mysterious Mega Stones. Have Medicham hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Medicham");
        AddItem("Metagrossite", "One variety of the mysterious Mega Stones. Have Metagross hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Metagross");
        AddItem("Mewtwonite X", "One variety of the mysterious Mega Stones. Have Mewtwo hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Mewtwo");
        AddItem("Mewtwonite Y", "One variety of the mysterious Mega Stones. Have Mewtwo hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Mewtwo");
        AddItem("Pidgeotite", "One variety of the mysterious Mega Stones. Have Pidgeot hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Pidgeot");
        AddItem("Pinsirite", "One variety of the mysterious Mega Stones. Have Pinsir hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Pinsir");
        AddItem("Sablenite", "One variety of the mysterious Mega Stones. Have Sableye hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Sableye");
        AddItem("Salamencite", "One variety of the mysterious Mega Stones. Have Salamence hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Salamence");
        AddItem("Sceptilite", "One variety of the mysterious Mega Stones. Have Sceptile hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Sceptile");
        AddItem("Scizorite", "One variety of the mysterious Mega Stones. Have Scizor hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Scizor");
        AddItem("Sharpedonite", "One variety of the mysterious Mega Stones. Have Sharpedo hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Sharpedo");
        AddItem("Slowbronite", "One variety of the mysterious Mega Stones. Have Slowbro hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Slowbro");
        AddItem("Steelixite", "One variety of the mysterious Mega Stones. Have Steelix hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Steelix");
        AddItem("Swampertite", "One variety of the mysterious Mega Stones. Have Swampert hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Swampert");
        AddItem("Tyranitarite", "One variety of the mysterious Mega Stones. Have Tyranitar hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Tyranitar");
        AddItem("Venusaurite", "One variety of the mysterious Mega Stones. Have Venusaur hold it, and this stone will enable it to Mega Evolve during battle.", megaEvolves: "Venusaur");

        // Generation 6 (XY) additional items
        AddItem("Assault Vest", "An item to be held by a Pokémon. This offensive vest raises Sp. Def but prevents the use of status moves.");
        AddItem("Kee Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Defense stat will increase when it's hit by a physical attack.");
        AddItem("Luminous Moss", "An item to be held by a Pokémon. It boosts Sp. Def if the holder is hit by a Water-type move. It can only be used once.");
        AddItem("Maranga Berry", "A Berry to be consumed by Pokémon. If a Pokémon holds one, its Sp. Def stat will increase when it's hit by a special attack.");
        AddItem("Pixie Plate", "An item to be held by a Pokémon. It's a stone tablet that boosts the power of Fairy-type moves.");
        AddItem("Roseli Berry", "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Fairy-type attack.");
        AddItem("Safety Goggles", "An item to be held by a Pokémon. These goggles protect the holder from both weather-related damage and powder.");
        AddItem("Snowball", "An item to be held by a Pokémon. It boosts Attack if the holder is hit by an Ice-type move. It can only be used once.");
        AddItem("Weakness Policy", "An item to be held by a Pokémon. Attack and Sp. Atk sharply increase if the holder is hit by a move it's weak to.");

        // Generation 7 (SM) items
        AddItem("Electric Seed", "An item to be held by a Pokémon. It boosts Defense on Electric Terrain. It can only be used once.");
        AddItem("Grassy Seed", "An item to be held by a Pokémon. It boosts Defense on Grassy Terrain. It can only be used once.");
        AddItem("Ice Stone", "A peculiar stone that can make certain species of Pokémon evolve. It has an unmistakable snowflake pattern.");
        AddItem("Misty Seed", "An item to be held by a Pokémon. It boosts Sp. Def on Misty Terrain. It can only be used once.");
        AddItem("Protective Pads", "An item to be held by a Pokémon. These pads protect the holder from effects caused by making direct contact with the target.");
        AddItem("Psychic Seed", "An item to be held by a Pokémon. It boosts Sp. Def on Psychic Terrain. It can only be used once.");
        AddItem("Terrain Extender", "An item to be held by a Pokémon. It extends the duration of the terrain caused by the holder's move or Ability.");

        // Generation 8 (SS) items
        AddItem("Heavy-Duty Boots", "These boots prevent the effects of traps set on the battlefield.");
        AddItem("Room Service", "An item to be held by a Pokémon. Lowers Speed when Trick Room takes effect.");
        AddItem("Throat Spray", "An item to be held by a Pokémon. It boosts Sp. Atk if the holder uses a sound-based move.");
        AddItem("Utility Umbrella", "An item to be held by a Pokémon. This sturdy umbrella protects the holder from the effects of weather.");

        // Generation 9 (SV) items
        AddItem("Ability Shield", "An item to be held by a Pokémon. This cute shield protects the holder from having its Ability changed by others.");
        AddItem("Booster Energy", "An item to be held by a Pokémon. It activates the Quark Drive and Protosynthesis Abilities.");
        AddItem("Clear Amulet", "An item to be held by a Pokémon. This clear amulet protects the holder from having its stats lowered by moves used against it.");
        AddItem("Covert Cloak", "An item to be held by a Pokémon. This hooded cloak conceals the holder, protecting it from the additional effects of moves.");
        AddItem("Loaded Dice", "An item to be held by a Pokémon. This loaded dice always rolls a high number, causing multistrike moves to hit more times.");
        AddItem("Mirror Herb", "An item to be held by a Pokémon. This herb will allow the holder to mirror an opponent's stat increases to boost its own stats.");
        AddItem("Punching Glove", "An item to be held by a Pokémon. This protective glove boosts the power of punching moves and prevents direct contact.");
    }

    private static void AddItem(string name, string description, bool isBerry = false, string? megaEvolves = null)
    {
        var item = new Item(name, description, isBerry, megaEvolves);
        _itemsLookup[name] = item;
    }
}