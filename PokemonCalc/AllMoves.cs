namespace PokemonCalc.Data;

using PokemonCalc.Core;

/// <summary>
/// Complete moves database based on smogon/damage-calc reference
/// </summary>
public static class AllMoves
{
    private static readonly Dictionary<string, Move> _movesLookup = new(StringComparer.OrdinalIgnoreCase);
    
    static AllMoves()
    {
        InitializeMoves();
    }
    
    public static Move? GetByName(string name) => 
        _movesLookup.TryGetValue(name, out var move) ? move : null;

    public static IEnumerable<Move> GetAll() => _movesLookup.Values;
    
    private static void InitializeMoves()
    {
        // Generation 1 (RBY) moves
        AddMove("(No Move)", PokemonType.Normal, MoveCategory.Status, 0, 100, 1, "");
        AddMove("Absorb", PokemonType.Grass, MoveCategory.Special, 20, 100, 25, "A nutrient-draining attack. The user's HP is restored by half the damage taken by the target.");
        AddMove("Acid", PokemonType.Poison, MoveCategory.Special, 40, 100, 30, "The opposing Pokémon are attacked with a spray of harsh acid.");
        AddMove("Acid Armor", PokemonType.Poison, MoveCategory.Status, 0, 100, 20, "The user alters its cellular structure to liquefy itself, sharply raising its Defense stat.");
        AddMove("Agility", PokemonType.Psychic, MoveCategory.Status, 0, 100, 30, "The user relaxes and lightens its body to move faster. This sharply raises the Speed stat.");
        AddMove("Amnesia", PokemonType.Psychic, MoveCategory.Status, 0, 100, 20, "The user temporarily empties its mind to forget its concerns. This sharply raises the user's Sp. Def stat.");
        AddMove("Aurora Beam", PokemonType.Ice, MoveCategory.Special, 65, 100, 20, "The target is hit with a rainbow-colored beam. This may also lower the target's Attack stat.");
        AddMove("Barrage", PokemonType.Normal, MoveCategory.Physical, 15, 85, 20, "Round objects are hurled at the target to strike two to five times in a row.");
        AddMove("Barrier", PokemonType.Psychic, MoveCategory.Status, 0, 100, 20, "The user throws up a sturdy wall that sharply raises its Defense stat.");
        AddMove("Bide", PokemonType.Normal, MoveCategory.Physical, 0, 100, 10, "The user endures attacks for two turns, then strikes back to cause double the damage taken.", 1);
        AddMove("Bind", PokemonType.Normal, MoveCategory.Physical, 15, 85, 20, "Things such as long bodies or tentacles are used to bind and squeeze the target for four to five turns.", makesContact: true);
        AddMove("Bite", PokemonType.Dark, MoveCategory.Physical, 60, 100, 25, "The target is bitten with viciously sharp fangs. This may also make the target flinch.", makesContact: true, isBiteMove: true);
        AddMove("Blizzard", PokemonType.Ice, MoveCategory.Special, 110, 70, 5, "A howling blizzard is summoned to strike opposing Pokémon. This may also leave the opposing Pokémon frozen.");
        AddMove("Body Slam", PokemonType.Normal, MoveCategory.Physical, 85, 100, 15, "The user drops onto the target with its full body weight. This may also leave the target with paralysis.", makesContact: true);
        AddMove("Bone Club", PokemonType.Ground, MoveCategory.Physical, 65, 85, 20, "The user clubs the target with a bone. This may also make the target flinch.");
        AddMove("Bonemerang", PokemonType.Ground, MoveCategory.Physical, 50, 90, 10, "The user throws the bone it holds. The bone loops around to hit the target twice—coming and going.");
        AddMove("Bubble", PokemonType.Water, MoveCategory.Special, 40, 100, 30, "A spray of countless bubbles is jetted at the opposing Pokémon.");
        AddMove("Bubble Beam", PokemonType.Water, MoveCategory.Special, 65, 100, 20, "A spray of bubbles is forcefully ejected at the target. This may also lower the target's Speed stat.");
        AddMove("Clamp", PokemonType.Water, MoveCategory.Physical, 35, 85, 15, "The target is clamped and squeezed by the user's very thick and sturdy shell for four to five turns.", makesContact: true);
        AddMove("Comet Punch", PokemonType.Normal, MoveCategory.Physical, 18, 85, 15, "The target is hit with a flurry of punches that strike two to five times in a row.", makesContact: true, isPunchMove: true);
        AddMove("Confuse Ray", PokemonType.Ghost, MoveCategory.Status, 0, 100, 10, "The target is exposed to a sinister ray that triggers confusion.");
        AddMove("Confusion", PokemonType.Psychic, MoveCategory.Special, 50, 100, 25, "The target is hit by a weak telekinetic force. This may also confuse the target.");
        AddMove("Constrict", PokemonType.Normal, MoveCategory.Physical, 10, 100, 35, "The target is attacked with long, creeping tentacles, vines, or the like. This may also lower the target's Speed stat.", makesContact: true);
        AddMove("Conversion", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user changes its type to become the same type as the move at the top of the list of moves it knows.");
        AddMove("Counter", PokemonType.Fighting, MoveCategory.Physical, 0, 100, 20, "A retaliation move that counters any physical attack, inflicting double the damage taken.", makesContact: true);
        AddMove("Crabhammer", PokemonType.Water, MoveCategory.Physical, 100, 90, 10, "The target is hammered with a large pincer. Critical hits land more easily.", makesContact: true);
        AddMove("Cut", PokemonType.Normal, MoveCategory.Physical, 50, 95, 30, "The target is cut with a scythe or claw.", makesContact: true, isSlicingMove: true);
        AddMove("Defense Curl", PokemonType.Normal, MoveCategory.Status, 0, 100, 40, "The user curls up to conceal weak spots and raise its Defense stat.");
        AddMove("Dig", PokemonType.Ground, MoveCategory.Physical, 80, 100, 10, "The user burrows, then attacks on the next turn.", makesContact: true);
        AddMove("Disable", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "For four turns, this move prevents the target from using the move it last used.");
        AddMove("Dizzy Punch", PokemonType.Normal, MoveCategory.Physical, 70, 100, 10, "The target is hit with rhythmically launched punches. This may also leave the target confused.", makesContact: true, isPunchMove: true);
        AddMove("Double-Edge", PokemonType.Normal, MoveCategory.Physical, 120, 100, 15, "A reckless, life-risking tackle. This also damages the user quite a lot.", makesContact: true);
        AddMove("Double Kick", PokemonType.Fighting, MoveCategory.Physical, 30, 100, 30, "The target is quickly kicked twice in succession using both feet.", makesContact: true);
        AddMove("Double Slap", PokemonType.Normal, MoveCategory.Physical, 15, 85, 10, "The target is slapped repeatedly, back and forth, two to five times in a row.", makesContact: true);
        AddMove("Double Team", PokemonType.Normal, MoveCategory.Status, 0, 100, 15, "By moving rapidly, the user makes illusory copies of itself to raise its evasiveness.");
        AddMove("Dragon Rage", PokemonType.Dragon, MoveCategory.Special, 0, 100, 10, "This attack hits the target with a shock wave of pure rage. This attack always inflicts 40 HP damage.");
        AddMove("Dream Eater", PokemonType.Psychic, MoveCategory.Special, 100, 100, 15, "The user eats the dreams of a sleeping target. It absorbs half the damage caused to heal its own HP.");
        AddMove("Drill Peck", PokemonType.Flying, MoveCategory.Physical, 80, 100, 20, "A corkscrewing attack with a sharp beak acting as a drill.", makesContact: true);
        AddMove("Earthquake", PokemonType.Ground, MoveCategory.Physical, 100, 100, 10, "The user sets off an earthquake that strikes every Pokémon around it.");
        AddMove("Egg Bomb", PokemonType.Normal, MoveCategory.Physical, 100, 75, 10, "A large egg is hurled at the target with maximum force to inflict damage.", isBulletMove: true);
        AddMove("Ember", PokemonType.Fire, MoveCategory.Special, 40, 100, 25, "The target is attacked with small flames. This may also leave the target with a burn.");
        AddMove("Explosion", PokemonType.Normal, MoveCategory.Physical, 250, 100, 5, "The user attacks everything around it by causing a tremendous explosion. The user faints upon using this move.");
        AddMove("Fire Blast", PokemonType.Fire, MoveCategory.Special, 110, 85, 5, "The target is attacked with an intense blast of all-consuming fire. This may also leave the target with a burn.");
        AddMove("Fire Punch", PokemonType.Fire, MoveCategory.Physical, 75, 100, 15, "The target is punched with a fiery fist. This may also leave the target with a burn.", makesContact: true, isPunchMove: true);
        AddMove("Fire Spin", PokemonType.Fire, MoveCategory.Special, 35, 85, 15, "The target becomes trapped within a fierce vortex of fire that rages for four to five turns.");
        AddMove("Fissure", PokemonType.Ground, MoveCategory.Physical, 0, 30, 5, "The user opens up a fissure in the ground and drops the target in. The target faints instantly if this attack hits.", makesContact: true);
        AddMove("Flamethrower", PokemonType.Fire, MoveCategory.Special, 90, 100, 15, "The target is scorched with an intense blast of fire. This may also leave the target with a burn.");
        AddMove("Flash", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The user flashes a bright light that cuts the target's accuracy.");
        AddMove("Fly", PokemonType.Flying, MoveCategory.Physical, 90, 95, 15, "The user soars and then strikes its target on the next turn.", makesContact: true);
        AddMove("Focus Energy", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user takes a deep breath and focuses so that critical hits land more easily.");
        AddMove("Fury Attack", PokemonType.Normal, MoveCategory.Physical, 15, 85, 20, "The target is jabbed repeatedly with a horn or beak two to five times in a row.", makesContact: true);
        AddMove("Fury Swipes", PokemonType.Normal, MoveCategory.Physical, 18, 80, 15, "The target is raked with sharp claws or scythes quickly two to five times in a row.", makesContact: true);
        AddMove("Glare", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user intimidates the target with the pattern on its belly to cause paralysis.");
        AddMove("Growl", PokemonType.Normal, MoveCategory.Status, 0, 100, 40, "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.", isSoundBased: true);
        AddMove("Growth", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The user's body grows all at once, raising the Attack and Sp. Atk stats.");
        AddMove("Guillotine", PokemonType.Normal, MoveCategory.Physical, 0, 30, 5, "A vicious, tearing attack with big pincers. The target faints instantly if this attack hits.", makesContact: true);
        AddMove("Gust", PokemonType.Flying, MoveCategory.Special, 40, 100, 35, "A gust of wind is whipped up by wings and launched at the target to inflict damage.");
        AddMove("Harden", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user stiffens all the muscles in its body to raise its Defense stat.");
        AddMove("Haze", PokemonType.Ice, MoveCategory.Status, 0, 100, 30, "The user creates a haze that eliminates every stat change among all the Pokémon engaged in battle.");
        AddMove("Headbutt", PokemonType.Normal, MoveCategory.Physical, 70, 100, 15, "The user sticks out its head and attacks by charging straight into the target. This may also make the target flinch.", makesContact: true);
        AddMove("High Jump Kick", PokemonType.Fighting, MoveCategory.Physical, 130, 90, 10, "The target is attacked with a knee kick from a jump. If it misses, the user is hurt instead.", makesContact: true);
        AddMove("Horn Attack", PokemonType.Normal, MoveCategory.Physical, 65, 100, 25, "The target is jabbed with a sharply pointed horn to inflict damage.", makesContact: true);
        AddMove("Horn Drill", PokemonType.Normal, MoveCategory.Physical, 0, 30, 5, "The user stabs the target with a horn that rotates like a drill. The target faints instantly if this attack hits.", makesContact: true);
        AddMove("Hydro Pump", PokemonType.Water, MoveCategory.Special, 110, 80, 5, "The target is blasted by a huge volume of water launched under great pressure.");
        AddMove("Hyper Beam", PokemonType.Normal, MoveCategory.Special, 150, 90, 5, "The target is attacked with a powerful beam. The user can't move on the next turn.");
        AddMove("Hyper Fang", PokemonType.Normal, MoveCategory.Physical, 80, 90, 15, "The user bites hard on the target with its sharp front fangs. This may also make the target flinch.", makesContact: true, isBiteMove: true);
        AddMove("Hypnosis", PokemonType.Psychic, MoveCategory.Status, 0, 60, 20, "The user employs hypnotic suggestion to make the target fall into a deep sleep.");
        AddMove("Ice Beam", PokemonType.Ice, MoveCategory.Special, 90, 100, 10, "The target is struck with an icy-cold beam of energy. This may also leave the target frozen.");
        AddMove("Ice Punch", PokemonType.Ice, MoveCategory.Physical, 75, 100, 15, "The target is punched with an icy fist. This may also leave the target frozen.", makesContact: true, isPunchMove: true);
        AddMove("Jump Kick", PokemonType.Fighting, MoveCategory.Physical, 100, 95, 10, "The user jumps up high, then strikes with a kick. If the kick misses, the user hurts itself.", makesContact: true);
        AddMove("Karate Chop", PokemonType.Fighting, MoveCategory.Physical, 50, 100, 25, "The target is attacked with a sharp chop. Critical hits land more easily.", makesContact: true);
        AddMove("Kinesis", PokemonType.Psychic, MoveCategory.Status, 0, 80, 15, "The user distracts the target by bending a spoon. This lowers the target's accuracy.");
        AddMove("Leech Life", PokemonType.Bug, MoveCategory.Physical, 80, 100, 10, "The user drains the target's blood. The user's HP is restored by half the damage taken by the target.", makesContact: true);
        AddMove("Leech Seed", PokemonType.Grass, MoveCategory.Status, 0, 90, 10, "A seed is planted on the target. It steals some HP from the target every turn.");
        AddMove("Leer", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user gives the target an intimidating leer that lowers the Defense stat.");
        AddMove("Lick", PokemonType.Ghost, MoveCategory.Physical, 30, 100, 30, "The target is licked with a long tongue, causing damage. This may also leave the target with paralysis.", makesContact: true);
        AddMove("Light Screen", PokemonType.Psychic, MoveCategory.Status, 0, 100, 30, "A wondrous wall of light is put up to reduce damage from special attacks for five turns.");
        AddMove("Lovely Kiss", PokemonType.Normal, MoveCategory.Status, 0, 75, 10, "With a lovely, sweet kiss, the user makes the target fall into a deep sleep.");
        AddMove("Low Kick", PokemonType.Fighting, MoveCategory.Physical, 0, 100, 20, "A powerful low kick that makes the target fall over. The heavier the target, the greater the move's power.", makesContact: true);
        AddMove("Meditate", PokemonType.Psychic, MoveCategory.Status, 0, 100, 40, "The user meditates to awaken the power deep within its body and raise its Attack stat.");
        AddMove("Mega Drain", PokemonType.Grass, MoveCategory.Special, 40, 100, 15, "A nutrient-draining attack. The user's HP is restored by half the damage taken by the target.");
        AddMove("Mega Kick", PokemonType.Normal, MoveCategory.Physical, 120, 75, 5, "The target is attacked by a kick launched with muscle-packed power.", makesContact: true);
        AddMove("Mega Punch", PokemonType.Normal, MoveCategory.Physical, 80, 85, 20, "The target is slugged by a punch thrown with muscle-packed power.", makesContact: true, isPunchMove: true);
        AddMove("Metronome", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user waggles a finger and stimulates its brain into randomly using nearly any move.");
        AddMove("Mimic", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user copies the target's last move. The move can be used during battle until the Pokémon is switched out.");
        AddMove("Minimize", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user compresses its body to make itself look smaller, which sharply raises its evasiveness.");
        AddMove("Mirror Move", PokemonType.Flying, MoveCategory.Status, 0, 100, 20, "The user counters the target by mimicking the target's last move.");
        AddMove("Mist", PokemonType.Ice, MoveCategory.Status, 0, 100, 30, "The user cloaks itself and its allies in a white mist that prevents any of their stats from being lowered for five turns.");
        AddMove("Night Shade", PokemonType.Ghost, MoveCategory.Special, 0, 100, 15, "The user makes the target see a frightening mirage. It inflicts damage equal to the user's level.");
        AddMove("Pay Day", PokemonType.Normal, MoveCategory.Physical, 40, 100, 20, "Numerous coins are hurled at the target to inflict damage. Money is earned after the battle.");
        AddMove("Peck", PokemonType.Flying, MoveCategory.Physical, 35, 100, 35, "The target is jabbed with a sharply pointed beak or horn.", makesContact: true);
        AddMove("Petal Dance", PokemonType.Grass, MoveCategory.Special, 120, 100, 10, "The user attacks the target by scattering petals for two to three turns. The user then becomes confused.", makesContact: true);
        AddMove("Pin Missile", PokemonType.Bug, MoveCategory.Physical, 25, 95, 20, "Sharp spikes are shot at the target in rapid succession. They hit two to five times in a row.");
        AddMove("Poison Gas", PokemonType.Poison, MoveCategory.Status, 0, 90, 40, "A cloud of poison gas is sprayed in the face of opposing Pokémon, poisoning those it hits.");
        AddMove("Poison Powder", PokemonType.Poison, MoveCategory.Status, 0, 75, 35, "The user scatters a cloud of poisonous dust that poisons the target.");
        AddMove("Poison Sting", PokemonType.Poison, MoveCategory.Physical, 15, 100, 35, "The user stabs the target with a poisonous stinger. This may also poison the target.");
        AddMove("Pound", PokemonType.Normal, MoveCategory.Physical, 40, 100, 35, "The target is physically pounded with a long tail, a foreleg, or the like.", makesContact: true);
        AddMove("Powder Snow", PokemonType.Ice, MoveCategory.Special, 40, 100, 25, "The user attacks with a chilled breath of air. This may also leave the opposing Pokémon frozen.");
        AddMove("Psybeam", PokemonType.Psychic, MoveCategory.Special, 65, 100, 20, "The target is attacked with a peculiar ray. This may also leave the target confused.");
        AddMove("Psychic", PokemonType.Psychic, MoveCategory.Special, 90, 100, 10, "The target is hit by a strong telekinetic force. This may also lower the target's Sp. Def stat.");
        AddMove("Psywave", PokemonType.Psychic, MoveCategory.Special, 0, 100, 15, "The target is attacked with an odd psychic wave. The attack varies in intensity.");
        AddMove("Quick Attack", PokemonType.Normal, MoveCategory.Physical, 40, 100, 30, "The user lunges at the target at a speed that makes it almost invisible. This move always goes first.", 1, makesContact: true);
        AddMove("Rage", PokemonType.Normal, MoveCategory.Physical, 20, 100, 20, "As long as this move is in use, the power of rage raises the Attack stat each time the user is hit in battle.", makesContact: true);
        AddMove("Razor Leaf", PokemonType.Grass, MoveCategory.Physical, 55, 95, 25, "Sharp-edged leaves are launched to slash at the opposing Pokémon. Critical hits land more easily.", isSlicingMove: true);
        AddMove("Razor Wind", PokemonType.Normal, MoveCategory.Special, 80, 100, 10, "In this two-turn attack, blades of wind hit opposing Pokémon on the second turn. Critical hits land more easily.", isSlicingMove: true);
        AddMove("Recover", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "Restoring its own cells, the user restores its own HP by half of its max HP.");
        AddMove("Reflect", PokemonType.Psychic, MoveCategory.Status, 0, 100, 20, "A wondrous wall of light is put up to reduce damage from physical attacks for five turns.");
        AddMove("Rest", PokemonType.Psychic, MoveCategory.Status, 0, 100, 10, "The user goes to sleep for two turns. This fully restores the user's HP and heals any status conditions.");
        AddMove("Roar", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The target is scared off, and a different Pokémon is dragged out. In the wild, this ends a battle against a single Pokémon.", isSoundBased: true);
        AddMove("Rock Slide", PokemonType.Rock, MoveCategory.Physical, 75, 90, 10, "Large boulders are hurled at the opposing Pokémon to inflict damage. This may also make the opposing Pokémon flinch.");
        AddMove("Rock Throw", PokemonType.Rock, MoveCategory.Physical, 50, 90, 15, "The user picks up and throws a small rock at the target to attack.");
        AddMove("Rolling Kick", PokemonType.Fighting, MoveCategory.Physical, 60, 85, 15, "The user lashes out with a quick, spinning kick. This may also make the target flinch.", makesContact: true);
        AddMove("Sand Attack", PokemonType.Ground, MoveCategory.Status, 0, 100, 15, "Sand is hurled in the target's face, reducing the target's accuracy.");
        AddMove("Scratch", PokemonType.Normal, MoveCategory.Physical, 40, 100, 35, "Hard, pointed, sharp claws rake the target to inflict damage.", makesContact: true);
        AddMove("Screech", PokemonType.Normal, MoveCategory.Status, 0, 85, 40, "An earsplitting screech harshly lowers the target's Defense stat.", isSoundBased: true);
        AddMove("Seismic Toss", PokemonType.Fighting, MoveCategory.Physical, 0, 100, 20, "The target is thrown using the power of gravity. It inflicts damage equal to the user's level.", makesContact: true);
        AddMove("Self-Destruct", PokemonType.Normal, MoveCategory.Physical, 200, 100, 5, "The user attacks everything around it by causing an explosion. The user faints upon using this move.");
        AddMove("Sharpen", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user makes its edges more jagged, which raises its Attack stat.");
        AddMove("Sing", PokemonType.Normal, MoveCategory.Status, 0, 55, 15, "A soothing lullaby is sung in a calming voice that puts the target into a deep slumber.", isSoundBased: true);
        AddMove("Skull Bash", PokemonType.Normal, MoveCategory.Physical, 130, 100, 10, "The user tucks in its head to raise its Defense in the first turn, then rams the target on the next turn.", makesContact: true);
        AddMove("Sky Attack", PokemonType.Flying, MoveCategory.Physical, 140, 90, 5, "A second-turn attack move where critical hits land more easily. This may also make the target flinch.", makesContact: true);
        AddMove("Slam", PokemonType.Normal, MoveCategory.Physical, 80, 75, 20, "The target is slammed with a long tail, vines, or the like to inflict damage.", makesContact: true);
        AddMove("Slash", PokemonType.Normal, MoveCategory.Physical, 70, 100, 20, "The target is attacked with a slash of claws or blades. Critical hits land more easily.", makesContact: true, isSlicingMove: true);
        AddMove("Sleep Powder", PokemonType.Grass, MoveCategory.Status, 0, 75, 15, "The user scatters a big cloud of sleep-inducing dust around the target.");
        AddMove("Sludge", PokemonType.Poison, MoveCategory.Special, 65, 100, 20, "Unsanitary sludge is hurled at the target. This may also poison the target.");
        AddMove("Smog", PokemonType.Poison, MoveCategory.Special, 30, 70, 20, "The target is attacked with a discharge of filthy gases. This may also poison the target.");
        AddMove("Smokescreen", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The user releases an obscuring cloud of smoke or ink. This lowers the target's accuracy.");
        AddMove("Soft-Boiled", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user restores its own HP by up to half of its max HP.");
        AddMove("Solar Beam", PokemonType.Grass, MoveCategory.Special, 120, 100, 10, "In this two-turn attack, the user gathers light, then blasts a bundled beam on the next turn.");
        AddMove("Sonic Boom", PokemonType.Normal, MoveCategory.Special, 0, 90, 20, "The target is hit with a destructive shock wave that always inflicts 20 HP damage.");
        AddMove("Spike Cannon", PokemonType.Normal, MoveCategory.Physical, 20, 100, 15, "Sharp spikes are shot at the target in rapid succession. They hit two to five times in a row.");
        AddMove("Splash", PokemonType.Normal, MoveCategory.Status, 0, 100, 40, "The user just flops and splashes around to no effect at all...");
        AddMove("Spore", PokemonType.Grass, MoveCategory.Status, 0, 100, 15, "The user scatters bursts of spores that induce sleep.");
        AddMove("Stomp", PokemonType.Normal, MoveCategory.Physical, 65, 100, 20, "The target is stomped with a big foot. This may also make the target flinch.", makesContact: true);
        AddMove("Strength", PokemonType.Normal, MoveCategory.Physical, 80, 100, 15, "The target is slugged with a punch thrown at maximum power.", makesContact: true);
        AddMove("String Shot", PokemonType.Bug, MoveCategory.Status, 0, 95, 40, "The opposing Pokémon are bound with silk blown from the user's mouth that harshly lowers the Speed stat.");
        AddMove("Struggle", PokemonType.Normal, MoveCategory.Physical, 50, 100, 1, "This attack is used in desperation only if the user has no PP. It also damages the user a little.", makesContact: true);
        AddMove("Stun Spore", PokemonType.Grass, MoveCategory.Status, 0, 75, 30, "The user scatters a cloud of numbing powder that paralyzes the target.");
        AddMove("Submission", PokemonType.Fighting, MoveCategory.Physical, 80, 80, 20, "The user grabs the target and recklessly dives for the ground. This also damages the user a little.", makesContact: true);
        AddMove("Substitute", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user makes a copy of itself using some of its HP. The copy serves as the user's decoy.");
        AddMove("Super Fang", PokemonType.Normal, MoveCategory.Physical, 0, 90, 10, "The user chomps hard on the target with its sharp front fangs. This cuts the target's HP in half.", makesContact: true, isBiteMove: true);
        AddMove("Supersonic", PokemonType.Normal, MoveCategory.Status, 0, 55, 20, "The user generates odd sound waves from its body that confuse the target.", isSoundBased: true);
        AddMove("Surf", PokemonType.Water, MoveCategory.Special, 90, 100, 15, "The user attacks everything around it by swamping its surroundings with a giant wave.");
        AddMove("Swift", PokemonType.Normal, MoveCategory.Special, 60, 100, 20, "Star-shaped rays are shot at the opposing Pokémon. This attack never misses.");
        AddMove("Swords Dance", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "A frenetic dance to uplift the fighting spirit. This sharply raises the user's Attack stat.");
        AddMove("Tackle", PokemonType.Normal, MoveCategory.Physical, 40, 100, 35, "A physical attack in which the user charges and slams into the target with its whole body.", makesContact: true);
        AddMove("Tail Whip", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user wags its tail cutely, making opposing Pokémon less wary and lowering their Defense stat.");
        AddMove("Take Down", PokemonType.Normal, MoveCategory.Physical, 90, 85, 20, "A reckless, full-body charge attack for slamming into the target. This also damages the user a little.", makesContact: true);
        AddMove("Teleport", PokemonType.Psychic, MoveCategory.Status, 0, 100, 20, "Use it to flee from any wild Pokémon.");
        AddMove("Thrash", PokemonType.Normal, MoveCategory.Physical, 120, 100, 10, "The user rampages and attacks for two to three turns. The user then becomes confused.", makesContact: true);
        AddMove("Thunder", PokemonType.Electric, MoveCategory.Special, 110, 70, 10, "A wicked thunderbolt is dropped on the target to inflict damage. This may also leave the target with paralysis.");
        AddMove("Thunder Punch", PokemonType.Electric, MoveCategory.Physical, 75, 100, 15, "The target is punched with an electrified fist. This may also leave the target with paralysis.", makesContact: true, isPunchMove: true);
        AddMove("Thunder Shock", PokemonType.Electric, MoveCategory.Special, 40, 100, 30, "A jolt of electricity crashes down on the target to inflict damage. This may also leave the target with paralysis.");
        AddMove("Thunder Wave", PokemonType.Electric, MoveCategory.Status, 0, 90, 20, "The user launches a weak jolt of electricity that paralyzes the target.");
        AddMove("Thunderbolt", PokemonType.Electric, MoveCategory.Special, 90, 100, 15, "A strong electric blast crashes down on the target. This may also leave the target with paralysis.");
        AddMove("Toxic", PokemonType.Poison, MoveCategory.Status, 0, 90, 10, "A move that leaves the target badly poisoned. Its poison damage worsens every turn.");
        AddMove("Transform", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user transforms into a copy of the target right down to having the same move set.");
        AddMove("Tri Attack", PokemonType.Normal, MoveCategory.Special, 80, 100, 10, "The user strikes with a simultaneous three-beam attack. May also burn, freeze, or paralyze the target.");
        AddMove("Twineedle", PokemonType.Bug, MoveCategory.Physical, 25, 100, 20, "The user damages the target twice in succession by jabbing it with two spikes. This may also poison the target.");
        AddMove("Vine Whip", PokemonType.Grass, MoveCategory.Physical, 45, 100, 25, "The target is struck with slender, whiplike vines to inflict damage.", makesContact: true);
        AddMove("Vise Grip", PokemonType.Normal, MoveCategory.Physical, 55, 100, 30, "The target is gripped and squeezed from both sides to inflict damage.", makesContact: true);
        AddMove("Water Gun", PokemonType.Water, MoveCategory.Special, 40, 100, 25, "The target is blasted with a forceful shot of water.");
        AddMove("Waterfall", PokemonType.Water, MoveCategory.Physical, 80, 100, 15, "The user charges at the target and may make it flinch.", makesContact: true);
        AddMove("Whirlwind", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The target is blown away, and a different Pokémon is dragged out. In the wild, this ends a battle against a single Pokémon.");
        AddMove("Wing Attack", PokemonType.Flying, MoveCategory.Physical, 60, 100, 35, "The target is struck with large, imposing wings spread wide to inflict damage.", makesContact: true);
        AddMove("Withdraw", PokemonType.Water, MoveCategory.Status, 0, 100, 40, "The user withdraws its body into its hard shell, raising its Defense stat.");
        AddMove("Wrap", PokemonType.Normal, MoveCategory.Physical, 15, 90, 20, "A long body, vines, or the like are used to wrap and squeeze the target for four to five turns.", makesContact: true);

        // Generation 2 (GSC) additions
        AddMove("Aeroblast", PokemonType.Flying, MoveCategory.Special, 100, 95, 5, "A vortex of air is shot at the target to inflict damage. Critical hits land more easily.");
        AddMove("Ancient Power", PokemonType.Rock, MoveCategory.Special, 60, 100, 5, "The user attacks with a prehistoric power. This may also raise all the user's stats at once.");
        AddMove("Attract", PokemonType.Normal, MoveCategory.Status, 0, 100, 15, "If it is the opposite gender of the user, the target becomes infatuated and less likely to attack.");
        AddMove("Beat Up", PokemonType.Dark, MoveCategory.Physical, 0, 100, 10, "The user gets all party Pokémon to attack the target. The more party Pokémon, the greater the number of attacks.");
        AddMove("Belly Drum", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user maximizes its Attack stat in exchange for HP equal to half its max HP.");
        AddMove("Bone Rush", PokemonType.Ground, MoveCategory.Physical, 25, 90, 10, "The user strikes the target with a hard bone two to five times in a row.");
        AddMove("Charm", PokemonType.Fairy, MoveCategory.Status, 0, 100, 20, "The user gazes at the target rather charmingly, making it less wary. This harshly lowers its Attack stat.");
        AddMove("Conversion 2", PokemonType.Normal, MoveCategory.Status, 0, 100, 30, "The user changes its type to make itself resistant to the type of the attack the opponent used last.");
        AddMove("Cotton Spore", PokemonType.Grass, MoveCategory.Status, 0, 100, 40, "The user releases cotton-like spores that cling to the opposing Pokémon, which harshly lowers their Speed stats.");
        AddMove("Cross Chop", PokemonType.Fighting, MoveCategory.Physical, 100, 80, 5, "The user delivers a double chop with its forearms crossed. Critical hits land more easily.", makesContact: true);
        AddMove("Crunch", PokemonType.Dark, MoveCategory.Physical, 80, 100, 15, "The user crunches up the target with sharp fangs. This may also lower the target's Defense stat.", makesContact: true, isBiteMove: true);
        AddMove("Curse", PokemonType.Ghost, MoveCategory.Status, 0, 100, 10, "A move that works differently for the Ghost type than for all other types.");
        AddMove("Destiny Bond", PokemonType.Ghost, MoveCategory.Status, 0, 100, 5, "After using this move, if the user faints, the Pokémon that landed the knockout hit also faints. Its chance of failing rises if it is used in succession.");
        AddMove("Detect", PokemonType.Fighting, MoveCategory.Status, 0, 100, 5, "Enables the user to evade all attacks. Its chance of failing rises if it is used in succession.", 4);
        AddMove("Dragon Breath", PokemonType.Dragon, MoveCategory.Special, 60, 100, 20, "The user exhales a mighty gust that inflicts damage. This may also leave the target with paralysis.");
        AddMove("Dynamic Punch", PokemonType.Fighting, MoveCategory.Physical, 100, 50, 5, "The user punches the target with full, concentrated power. This confuses the target if it hits.", makesContact: true, isPunchMove: true);
        AddMove("Encore", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user compels the target to keep using the move it encored for three turns.");
        AddMove("Endure", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user endures any attack with at least 1 HP. Its chance of failing rises if it is used in succession.", 4);
        AddMove("Extreme Speed", PokemonType.Normal, MoveCategory.Physical, 80, 100, 5, "The user charges the target at blinding speed. This move always goes first.", 2, makesContact: true);
        AddMove("False Swipe", PokemonType.Normal, MoveCategory.Physical, 40, 100, 40, "A restrained attack that prevents the target from fainting. The target is left with at least 1 HP.", makesContact: true);
        AddMove("Feint Attack", PokemonType.Dark, MoveCategory.Physical, 60, 100, 20, "The user approaches the target disarmingly, then throws a sucker punch. This attack never misses.", makesContact: true);
        AddMove("Flame Wheel", PokemonType.Fire, MoveCategory.Physical, 60, 100, 25, "The user cloaks itself in fire and charges at the target. This may also leave the target with a burn.", makesContact: true);
        AddMove("Flail", PokemonType.Normal, MoveCategory.Physical, 0, 100, 15, "The user flails about aimlessly to attack. The less HP the user has, the greater the move's power.", makesContact: true);
        AddMove("Foresight", PokemonType.Normal, MoveCategory.Status, 0, 100, 40, "Enables a Ghost-type target to be hit by Normal- and Fighting-type attacks. This also enables an evasive target to be hit.");
        AddMove("Frustration", PokemonType.Normal, MoveCategory.Physical, 0, 100, 20, "This full-power attack grows more powerful the less the user likes its Trainer.", makesContact: true);
        AddMove("Fury Cutter", PokemonType.Bug, MoveCategory.Physical, 40, 95, 20, "The target is slashed with scythes or claws. This attack becomes more powerful if it hits in succession.", makesContact: true, isSlicingMove: true);
        AddMove("Future Sight", PokemonType.Psychic, MoveCategory.Special, 120, 100, 10, "Two turns after this move is used, a hunk of psychic energy attacks the target.");
        AddMove("Giga Drain", PokemonType.Grass, MoveCategory.Special, 75, 100, 10, "A nutrient-draining attack. The user's HP is restored by half the damage taken by the target.");
        AddMove("Heal Bell", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user makes a soothing bell chime to heal the status conditions of all the party Pokémon.", isSoundBased: true);
        AddMove("Hidden Power", PokemonType.Normal, MoveCategory.Special, 60, 100, 15, "A unique attack that varies in type depending on the Pokémon using it.");
        AddMove("Icy Wind", PokemonType.Ice, MoveCategory.Special, 55, 95, 15, "The user attacks with a gust of chilled air. This also lowers the opposing Pokémon's Speed stats.");
        AddMove("Iron Tail", PokemonType.Steel, MoveCategory.Physical, 100, 75, 15, "The target is slammed with a steel-hard tail. This may also lower the target's Defense stat.", makesContact: true);
        AddMove("Lock-On", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user takes sure aim at the target. This ensures the next attack does not miss the target.");
        AddMove("Mach Punch", PokemonType.Fighting, MoveCategory.Physical, 40, 100, 30, "The user throws a punch at blinding speed. This move always goes first.", 1, makesContact: true, isPunchMove: true);
        AddMove("Magnitude", PokemonType.Ground, MoveCategory.Physical, 0, 100, 30, "The user attacks everything around it with a ground-shaking quake. Its power varies.");
        AddMove("Mean Look", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user pins the target with a dark, arresting look. The target becomes unable to flee.");
        AddMove("Megahorn", PokemonType.Bug, MoveCategory.Physical, 120, 85, 10, "Using its tough and impressive horn, the user rams into the target with no letup.", makesContact: true);
        AddMove("Metal Claw", PokemonType.Steel, MoveCategory.Physical, 50, 95, 35, "The target is raked with steel claws. This may also raise the user's Attack stat.", makesContact: true);
        AddMove("Milk Drink", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user restores its own HP by up to half of its max HP.");
        AddMove("Mind Reader", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user senses the target's movements with its mind to ensure its next attack does not miss the target.");
        AddMove("Mirror Coat", PokemonType.Psychic, MoveCategory.Special, 0, 100, 20, "A retaliation move that counters any special attack, inflicting double the damage taken.");
        AddMove("Moonlight", PokemonType.Fairy, MoveCategory.Status, 0, 100, 5, "The user restores its own HP. The amount of HP regained varies with the weather.");
        AddMove("Morning Sun", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "The user restores its own HP. The amount of HP regained varies with the weather.");
        AddMove("Mud-Slap", PokemonType.Ground, MoveCategory.Special, 20, 100, 10, "The user hurls mud in the target's face to inflict damage and lower its accuracy.");
        AddMove("Nightmare", PokemonType.Ghost, MoveCategory.Status, 0, 100, 15, "A sleeping target sees a nightmare that inflicts some damage every turn.");
        AddMove("Octazooka", PokemonType.Water, MoveCategory.Special, 65, 85, 10, "The user attacks by spraying ink in the target's face or eyes. This may also lower the target's accuracy.", isBulletMove: true);
        AddMove("Outrage", PokemonType.Dragon, MoveCategory.Physical, 120, 100, 10, "The user rampages and attacks for two to three turns. The user then becomes confused.", makesContact: true);
        AddMove("Pain Split", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "The user adds its HP to the target's HP, then equally shares the combined HP with the target.");
        AddMove("Perish Song", PokemonType.Normal, MoveCategory.Status, 0, 100, 5, "Any Pokémon that hears this song faints in three turns, unless it switches out of battle.", isSoundBased: true);
        AddMove("Present", PokemonType.Normal, MoveCategory.Physical, 0, 90, 15, "The user attacks by giving the target a gift with a hidden trap. It restores HP sometimes, however.");
        AddMove("Protect", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "Enables the user to evade all attacks. Its chance of failing rises if it is used in succession.", 4);
        AddMove("Psych Up", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user hypnotizes itself into copying any stat change made by the target.");
        AddMove("Pursuit", PokemonType.Dark, MoveCategory.Physical, 40, 100, 20, "The power of this attack move is doubled if it's used on a target that's switching out of battle.", makesContact: true);
        AddMove("Rain Dance", PokemonType.Water, MoveCategory.Status, 0, 100, 5, "The user summons a heavy rain that falls for five turns, powering up Water-type moves. It lowers the power of Fire-type moves.");
        AddMove("Rapid Spin", PokemonType.Normal, MoveCategory.Physical, 50, 100, 40, "A spin attack that can also eliminate such moves as Bind, Wrap, Leech Seed, and Spikes.", makesContact: true);
        AddMove("Return", PokemonType.Normal, MoveCategory.Physical, 0, 100, 20, "This full-power attack grows more powerful the more the user likes its Trainer.", makesContact: true);
        AddMove("Reversal", PokemonType.Fighting, MoveCategory.Physical, 0, 100, 15, "An all-out attack that becomes more powerful the less HP the user has.", makesContact: true);
        AddMove("Rollout", PokemonType.Rock, MoveCategory.Physical, 30, 90, 20, "The user continually rolls into the target over five turns. It becomes more powerful each time it hits.", makesContact: true);
        AddMove("Sacred Fire", PokemonType.Fire, MoveCategory.Physical, 100, 95, 5, "The target is razed with a mystical fire of great intensity. This may also leave the target with a burn.");
        AddMove("Safeguard", PokemonType.Normal, MoveCategory.Status, 0, 100, 25, "The user creates a protective field that prevents status conditions for five turns.");
        AddMove("Sandstorm", PokemonType.Rock, MoveCategory.Status, 0, 100, 10, "A five-turn sandstorm is summoned to hurt all combatants except the Rock, Ground, and Steel types. It raises the Sp. Def stat of Rock-type Pokémon.");
        AddMove("Scary Face", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "The user frightens the target with a scary face to harshly lower its Speed stat.");
        AddMove("Shadow Ball", PokemonType.Ghost, MoveCategory.Special, 80, 100, 15, "The user hurls a shadowy blob at the target. This may also lower the target's Sp. Def stat.", isBulletMove: true);
        AddMove("Sketch", PokemonType.Normal, MoveCategory.Status, 0, 100, 1, "It enables the user to permanently learn the move last used by the target. Once used, Sketch disappears.");
        AddMove("Sleep Talk", PokemonType.Normal, MoveCategory.Status, 0, 100, 10, "While it is asleep, the user randomly uses one of the moves it knows.");
        AddMove("Sludge Bomb", PokemonType.Poison, MoveCategory.Special, 90, 100, 10, "Unsanitary sludge is hurled at the target. This may also poison the target.", isBulletMove: true);
        AddMove("Snore", PokemonType.Normal, MoveCategory.Special, 50, 100, 15, "This attack can be used only if the user is asleep. The harsh noise may also make the target flinch.", isSoundBased: true);
        AddMove("Spark", PokemonType.Electric, MoveCategory.Physical, 65, 100, 20, "The user throws an electrically charged tackle at the target. This may also leave the target with paralysis.", makesContact: true);
        AddMove("Spikes", PokemonType.Ground, MoveCategory.Status, 0, 100, 20, "The user lays a trap of spikes at the opposing team's feet. The trap hurts Pokémon that switch into battle.");
        AddMove("Spite", PokemonType.Ghost, MoveCategory.Status, 0, 100, 10, "The user unleashes its grudge on the move last used by the target by cutting 4 PP from it.");
        AddMove("Steel Wing", PokemonType.Steel, MoveCategory.Physical, 70, 90, 25, "The target is hit with wings of steel. This may also raise the user's Defense stat.", makesContact: true);
        AddMove("Sunny Day", PokemonType.Fire, MoveCategory.Status, 0, 100, 5, "The user intensifies the sun for five turns, powering up Fire-type moves. It lowers the power of Water-type moves.");
        AddMove("Sweet Kiss", PokemonType.Fairy, MoveCategory.Status, 0, 75, 10, "The user kisses the target with a sweet, angelic cuteness that causes confusion.");
        AddMove("Sweet Scent", PokemonType.Normal, MoveCategory.Status, 0, 100, 20, "A sweet scent that harshly lowers opposing Pokémon's evasiveness.");
        AddMove("Swagger", PokemonType.Normal, MoveCategory.Status, 0, 85, 15, "The user enrages and confuses the target. However, this also sharply raises the target's Attack stat.");
        AddMove("Synthesis", PokemonType.Grass, MoveCategory.Status, 0, 100, 5, "The user restores its own HP. The amount of HP regained varies with the weather.");
        AddMove("Thief", PokemonType.Dark, MoveCategory.Physical, 60, 100, 25, "The user attacks and steals the target's held item simultaneously. The user can't steal anything if it already holds an item.", makesContact: true);
        AddMove("Triple Kick", PokemonType.Fighting, MoveCategory.Physical, 10, 90, 10, "A consecutive three-kick attack that becomes more powerful with each successful hit.", makesContact: true);
        AddMove("Twister", PokemonType.Dragon, MoveCategory.Special, 40, 100, 20, "The user whips up a vicious tornado to tear at the opposing Pokémon. This may also make them flinch.");
        AddMove("Vital Throw", PokemonType.Fighting, MoveCategory.Physical, 70, 100, 10, "The user attacks last. In return, this throw move never misses.", makesContact: true);
        AddMove("Whirlpool", PokemonType.Water, MoveCategory.Special, 35, 85, 15, "The user traps the target in a violent swirling whirlpool for four to five turns.");
        AddMove("Zap Cannon", PokemonType.Electric, MoveCategory.Special, 120, 50, 5, "The user fires an electric blast like a cannon to inflict damage and cause paralysis.", isBulletMove: true);

        // Add more moves as needed - this is a starting set covering Generation 1-2
        // The complete database would include all moves from all generations
    }

    private static void AddMove(
        string name,
        PokemonType type,
        MoveCategory category,
        int basePower,
        int accuracy,
        int pp,
        string description,
        int priority = 0,
        bool makesContact = false,
        bool isSoundBased = false,
        bool isPunchMove = false,
        bool isBiteMove = false,
        bool isBulletMove = false,
        bool isSlicingMove = false)
    {
        var move = new Move(
            name,
            type,
            category,
            basePower,
            accuracy,
            pp,
            description,
            priority,
            makesContact,
            isSoundBased,
            isPunchMove,
            isBiteMove,
            isBulletMove,
            isSlicingMove
        );

        _movesLookup[name] = move;
    }
}