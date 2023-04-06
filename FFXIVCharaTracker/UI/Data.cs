using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal readonly Dictionary<int, string> GCRankToString =
            new()
            {
                        { 0, "Start" },
                        { 1, "Private Third Class" },
                        { 2, "Private Second Class" },
                        { 3, "Private First Class" },
                        { 4, "Corporal" },
                        { 5, "Sergeant Third Class" },
                        { 6, "Sergeant Second Class" },
                        { 7, "Sergeant First Class" },
                        { 8, "Chief Sergeant" },
                        { 9, "Second Lieutenant" },
                        { 10, "First Lieutenant" },
                        { 11, "Captain" },
            };

        private readonly Vector4 Red = new(1, 0, 0, 1);
        private readonly Vector4 Green = new(0, 1, 0, 1);
        private readonly Vector4 Blue = new(0, 0, 1, 1);
        private readonly Vector4 Yellow = new(1, 1, 0, 1);
        private readonly Vector4 White = new(1, 1, 1, 1);
        private readonly Vector4 Black = new(0, 0, 0, 1);

        internal static readonly Dictionary<uint, uint> DropdownToClassID =
            new()
            {
                        { 0, 33 },
                        { 1, 25 },
                        { 2, 23 },
                        { 3, 38 },
                        { 4, 22 },
                        { 5, 32 },
                        { 6, 37 },
                        { 7, 31 },
                        { 8, 20 },
                        { 9, 30 },
                        { 10, 19 },
                        { 11, 35 },
                        { 12, 39 },
                        { 13, 34 },
                        { 14, 28 },
                        { 15, 40 },
                        { 16, 27 },
                        { 17, 21 },
                        { 18, 24 },
                        { 33, 0 }
            };

        internal static readonly Dictionary<uint, uint> ClassIDToDropdown =
            DropdownToClassID.ToDictionary(i => i.Value, i => i.Key);

        internal readonly Dictionary<int, string> StoryProgressToString =
            new()
            {
                { 0, "Start" },
                { Data.QuestCompleteOrigin, "Origin" },
                { Data.QuestCompleteRetainer, "Origin" },
                { Data.QuestComplete20, "2.0" },
                { Data.QuestComplete21, "2.1" },
                { Data.QuestComplete22, "2.2" },
                { Data.QuestComplete23, "2.3" },
                { Data.QuestComplete24, "2.4" },
                { Data.QuestComplete255, "2.55" },
                { Data.QuestComplete30, "3.0" },
                { Data.QuestComplete31, "3.1" },
                { Data.QuestComplete32, "3.2" },
                { Data.QuestComplete33, "3.3" },
                { Data.QuestComplete34, "3.4" },
                { Data.QuestComplete355, "3.55" },
                { Data.QuestComplete40, "4.0" },
                { Data.QuestComplete41, "4.1" },
                { Data.QuestComplete42, "4.2" },
                { Data.QuestComplete43, "4.3" },
                { Data.QuestComplete44, "4.4" },
                { Data.QuestComplete455, "4.55" },
                { Data.QuestComplete50, "5.0" },
                { Data.QuestComplete51, "5.1" },
                { Data.QuestComplete52, "5.2" },
                { Data.QuestComplete53, "5.3" },
                { Data.QuestComplete54, "5.4" },
                { Data.QuestComplete555, "5.55" },
                { Data.QuestComplete60, "6.0" },
                { Data.QuestComplete61, "6.1" },
                { Data.QuestComplete62, "6.2" },
                { Data.QuestComplete63, "6.3" },
            };

        public static readonly Dictionary<uint, string> GuardianDeities = new()
        {
            { 0, "" },
            { 1, "Halone, the Fury" },
            { 2, "Menphina, the Lover" },
            { 3, "Thaliak, the Scholar" },
            { 4, "Nymeia, the Spinner" },
            { 5, "Llymlaen, the Navigator" },
            { 6, "Oschon, the Wanderer" },
            { 7, "Byregot, the Builder" },
            { 8, "Rhalgr, the Destroyer" },
            { 9, "Azeyma, the Warden" },
            { 10, "Nald'thal, the Traders" },
            { 11, "Nophica, the Matron" },
            { 12, "Althyk, the Keeper" }
        };

        public static readonly Dictionary<uint, string> SubRaces = new()
        {
            { 0, "" },
            { 1, "Hyur - Midlander" },
            { 2, "Hyur - Highlander" },
            { 3, "Elezen - Wildwood" },
            { 4, "Elezen - Duskwight" },
            { 5, "Lalafell - Plainsfolk" },
            { 6, "Lalafell - Dunesfolk" },
            { 7, "Miqo'te - Seeker of the Sun" },
            { 8, "Miqo'te - Keeper of the Moon" },
            { 9, "Roegadyn - Sea Wolf" },
            { 10, "Roegadyn - Hellsguard" },
            { 11, "Au ra - Raen" },
            { 12, "Au ra - Xaela" },
            { 13, "Hrothgar - Helions" },
            { 14, "Hrothgar - The Lost" },
            { 15, "Viera - Rava" },
            { 16, "Viera - Veena" }
        };

        // String lists for the squad listings

        public static readonly string[] SquadDoWDoMStrings = 
            { "Class", "Level", "Story completion", "Low level gear", "Current level gear" };

        public static readonly string[] SquadEmoteSidequestStrings =
            { "Throw", "Step Dance", "Harvest Dance", "Ball Dance", "Manderville Dance", "Most Gentlemanly", "Spectacles", "Manderville Mambo", "Lali-ho" };

        public static readonly string[] SquadEmoteTribeStrings =
            { "Sundrop Dance", "Moogle Dance", "Moonlift Dance", "Ritual Prayer", "Charmed", "Yol Dance", "Gratuity", "Lali Hop" };

        public static readonly string[] SquadEmoteSaucerStrings =
            { "Thavnairian Dance", "Gold Dance", "Aback", "Big Grin", "Bee's Knees", "Sheathe Weapon", "Draw Weapon" };

        public static readonly string[] SquadEmoteSquadronStrings =
            { "Squats", "Push-ups", "Sit-ups", "Breath Control" };

        public static readonly string[] SquadEmoteGCStrings =
            { "Squats", "Push-ups", "Sit-ups", "Breath Control" };

        public static readonly string[] SquadEmoteHuntStrings =
            { "Winded", "Tremble" };

        public static readonly string[] SquadEmotePvPStrings =
            { "Elucidate", "Reprimand" };

        public static readonly string[] SquadEmoteDeepDungeonStrings =
            { "Sweat", "Wow" };

        public static readonly string[] SquadEmoteEurekaStrings =
            { "Shiver", "Scheme", "Fist Pump" };

        public static readonly string[] SquadEmoteBozjaStrings =
            { "Guard", "Malevolence", "Wring Hands" };

        public static readonly string[] SquadEmoteTreasureStrings =
            { "Confirm", "Paint it Black", "Paint it Red", "Paint it Yellow", "Paint it Blue" };

        public static readonly string[] SquadEmoteRestoStrings =
            { "Lean", "Insist", "Break Fast", "Read", "High Five", "Eat Rice Ball", "Eat Apple", "Sweep Up" };

        public static readonly string[] SquadEmoteMogStrings =
            { "Bomb Dance", "Huzzah", "Eureka", "Black Ranger Pose A", "Black Ranger Pose B", "Yellow Ranger Pose A", "Yellow Ranger Pose B", "Red Ranger Pose A", "Red Ranger Pose B", "Eastern Greeting", "Dote", "Songbird", "Play Dead", "Eastern Stretch", "Eastern Dance", "Pretty Please", "Power Up", "Cheer On", "Cheer Wave", "Cheer Jump", "Megaflare", "Splash", "Crimson Lotus", "Box Step", "Side Step", "Senor Sabotender", "Get Fantasy", "Popoto Step", "Toast", "Heel Toe", "Goobbue Do", "Consider", "Flame Dance", "Wasshoi", "Flower Shower", "Pantomime", "Vexed", "Drink Tea", "Deride" };

        public static readonly string[] SquadEmoteOtherStrings =
            { "Headache", "Embrace" };

        public static readonly string[] SquadHairstyleSaucerStrings =
            { "Great Lengths", "Lexen-tails", "Styled for Hire", "Fashionably Feathered", "Rainmaker", "Curls", "Adventure", "Ponytails" };

        public static readonly string[] SquadHairstyleEurekaStrings =
            { "Form and Function" };

        public static readonly string[] SquadHairstyleBozjaStrings =
            { "Both Ways", "Early to Rise", "Wind Caller" };

        public static readonly string[] SquadHairstyleDeepDungeonStrings =
            { "Gyr Abanian Plait", "Samsonian Locks" };

        public static readonly string[] SquadHairstyleRestoStrings =
            { "Saintly Style", "Controlled Chaos", "Modern Legend" };

        public static readonly string[] SquadHairstyleAllianceStrings =
            { "Scanning for Style", "Battle-ready Bobs" };

        public static readonly string[] SquadHairstyleSanctuaryStrings =
            { "Practical Ponytails", "Tall Tails" };

        public static readonly string[] SquadHairstyleMogStrings =
            { "Sharlayan Rebellion", "Sharlayan Studies", "Master & Commander", "Scion Special Issue", "Scion Special Issue II", "Scion Special Issue III", "Pulse", "Liberating Locks", "Clowning Around", "A Wicked Wake" };

        public static readonly string[] squadMinionsAchievementStrings =
            { "Black Chocobo Chick", "Beady Eye", "Wind-up Cursor", "Wind-up Leader", "Minion of Light", "Wind-up Odin", "Wind-up Warrior of Light ", "Wind-up Goblin", "Wind-up Gilgamesh", "Wind-up Nanamo", "Wind-up Firion", "Komainu", "Mammet #003L", "Mammet #003G", "Mammet #003U", "Princely Hatchling", "Fledgling Apkallu", "Wind-up Louisoix", "Shalloweye", "Clockwork Twintania", "Penguin Prince", "Hellpup", "Faepup", "The Major-General", "Malone", "Laladile", "Much-coveted Mora", "Dolphin Calf", "Gull" };
        public static readonly string[] squadMinionsTribeStrings =
            { "Wind-up Sylph", "Wind-up Violet", "Wind-up Amalj'aa", "Wind-up Founder", "Wind-up Kobold", "Wind-up Kobolder", "Wind-up Sahagin", "Wind-up Sea Devil", "Wind-up Dezul Qualan", "Wind-up Ixal", "Wind-up Gundu Warrior", "Wind-up Zundu Warrior", "Wind-up Vath", "Wind-up Gnath", "Wind-up Dragonet", "Wind-up Ohl Deeh", "Wind-up Kojin", "Wind-up Redback", "Zephyrous Zabuton", "Wind-up Ananta", "Wind-up Qalyana", "Attendee #777", "Wind-up Pixie", "The Behelmeted Serpent of Ronka", "The Behatted Serpent of Ronka", "Lalinator 5.H0", "Wind-up Arkasodara", "Lumini" };
        public static readonly string[] squadMinionsBozjaStrings =
            { "Mameshiba", "Koala Joey", "Salt & Pepper Seal", "Axolotl Eft", "Wind-up Ravana", "Wind-up Shinryu", "Tengu Doll", "White Whittret", "Aurelia Polyp", "Byakko Cub", "Private Moai", "Monkey King", "Mudpie (Southern Front Lockbox, Zadnor Lockbox, Saint Mocianne's Arboretum", "Scarlet Peacock", "Abroader Otter", "Seitei", "Wind-up Weapon", "Chameleon", "Sharksucker-class Insubmersible", "Magitek Helldiver F1", "DÃ¡insleif F1", "Save the Princess (Delubrum Reginae", "Wind-up Gunnhildr" };
        public static readonly string[] squadMinionsCraftedStrings =
            { "Magic Broom", "Clockwork Barrow", "Model Magitek Bit", "Private Moai", "Wind-up Dullahan", "Steam-powered Gobwalker G-VII", "Bantam Train", "Gravel Golem", "Model Vanguard", "Wind-up Aldgoat", "Wind-up Qiqirn", "Plush Cushion", "Nana Bear", "Wind-up Illuminatus", "Wind-up Chimera", "Wind-up Sadu", "Wind-up Magnai", "Adventurer's Basket", "Wind-up Ifrit", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Wind-up Shinryu", "Byakko Cub", "Scarlet Peacock", "Seitei", "Atrophied Atomos", "Wanderer's Campfire" };
        public static readonly string[] squadMinionsDeepStrings =
            { "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Miniature Minecart", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Gestahl", "Owlet", "Ugly Duckling", "Paissa Brat", "Korpokkur Kid", "Hunting Hawk", "Wind-up Ifrit", "Morpho", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Dwarf Rabbit", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Sasquatch", "Hecteye", "Shaggy Shoat", "Wind-up Edda", "Baby Brachiosaur", "Castaway Chocobo Chick", "Tiny Tatsunoko", "Bombfish", "Bom Boko", "Odder Otter", "Ghido", "Road Sparrow", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Frilled Dragon" };
        public static readonly string[] squadMinionsDungeonStrings =
            { "Morbol Seedling", "Bite-sized Pudding", "Demon Brick", "Slime Puddle", "Baby Opo-opo", "Naughty Nanka", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Korpokkur Kid", "Calca", "Brina", "Morpho", "Calamari", "Shaggy Shoat", "Bullpup", "Bombfish", "Ivon Coeurlfist Doll", "Ghido", "Road Sparrow", "Dress-up Yugiri", "Mock-up Grynewaht", "Magitek Avenger F1", "Salt & Pepper Seal", "White Whittret", "Monkey King", "Mudpie", "Wind-up Weapon", "Armadillo Bowler", "Clionid Larva", "Tiny Echevore", "Forgiven Hate", "Black Hayate", "Chameleon", "Shoebill", "Little Leannan", "Ancient One", "Ephemeral Necromancer", "Drippy", "Magitek Predator F1", "Prince Lunatender", "Tiny Troll", "Wind-up Magus Sisters", "Wind-up Anima", "Hippo Calf", "Caduceus", "Starbird", "Optimus Omicron", "Teacup Kapikulu", "Wind-up Scarmiglione", "Sponge Silkie", "Sewer Skink", "Wind-up Cagnazzo" };
        public static readonly string[] squadMinionsEurekaStrings =
            { "Calca", "Wind-up Fafnir", "The Prince Of Anemos", "Wind-up Mithra", "Copycat Bulb", "Wind-up Tarutaru", "Dhalmel Calf", "Wind-up Elvaan", "Conditional Virtue", "Yukinko Snowflake" };
        public static readonly string[] squadMinionsFateStrings =
            { "Baby Bun", "Infant Imp", "Pudgy Puk", "Smallshell", "Gold Rush Minecart", "Fox Kit", "Wind-up Ixion", "Micro Gigantender", "Butterfly Effect", "Ironfrog Ambler", "Tinker's Bell", "Little Leafman", "Amaro Hatchling", "Wee Ea", "Wind-up Daivadipa" };
        public static readonly string[] squadMinionsGatherStrings =
            { "Tiny Tortoise", "Gigantpole", "Kidragora", "Coblyn Larva", "Magic Bucket", "Castaway Chocobo Chick", "Tiny Tatsunoko" };
        public static readonly string[] squadMinionsMogStrings =
            { "Baby Behemoth", "Tender Lamb", "Wind-up Edvya", "Wind-up Shantotto", "Wind-up Moogle", "Wind-up Minfilia", "Wind-up Thancred", "Wind-up Y'shtola", "Wind-up Yda", "Wind-up Papalymo", "Wind-up Urianger", "Hoary The Snowman", "Wind-up Kain", "Wind-up Alisaie", "Wind-up Tataru", "Wind-up Iceheart", "Pumpkin Butler", "Wind-up Yugiri", "Panda Cub", "Doman Magpie", "Dress-up Y'shtola", "Wind-up Krile", "Continental Eye", "Wind-up Rikku", "Wind-up Lulu", "Angel Of Mercy", "Wind-up Yuna", "Wind-up Bartz", "Wind-up Lyse", "Wind-up Gosetsu", "Motley Egg", "Wind-up Cirina", "Little Yin", "Little Yang", "Wind-up Tifa", "Wind-up Cloud", "Wind-up Aerith", "Wind-up Fran", "Brave New Y'shtola", "Wind-up Ardbert", "Wind-up Edge", "Wind-up Rydia", "Wind-up Rosa", "Wind-up Rudy", "Squirrel Emperor", "Wind-up Porom" };
        public static readonly string[] squadMinionsPvpStrings =
            { "Fenrir Pup", "Wind-up Cheerleader", "Clockwork Lantern", "Minitek Conveyor", "Protonaught" };
        public static readonly string[] squadMinionsQuestStrings =
            { "Chigoe Larva", "Cactuar Cutting", "Goobbue Sproutling", "Coeurl Kitten", "Wolf Pup", "Mini Mole", "Wind-up Gentleman", "Accompaniment Node", "Gigi", "Anima", "Palico", "Wind-up Alpha", "The Great Serpent Of Ronka", "Golden Dhyata" };
        public static readonly string[] squadMinionsRaidStrings =
            { "Wind-up Onion Knight", "Puff Of Darkness", "Wind-up Echidna", "Faustlet", "Wind-up Calofisteri", "Toy Alexander", "Wind-up Scathach", "Wind-up Exdeath", "Wind-up Kefka", "Construct 8", "OMG", "Wind-up Ramza", "Eden Minor", "Pod 054", "Pod 316", "Wind-up Ryne", "2B Automaton", "2P Automaton", "Wind-up Gaia", "Smaller Stubby", "9S Automaton", "Nosferatu", "Wind-up Azeyma", "Wind-up Erichthonios", "Wind-up Halone" };
        public static readonly string[] squadMinionsSkybuilderStrings =
            { "Plush Cushion", "Nutkin", "Atrophied Atomos", "Gaelikitten", "Owlet", "Ugly Duckling", "Clockwork Barrow", "Paissa Brat", "Hunting Hawk", "Morpho", "Calamari", "Dwarf Rabbit", "Shaggy Shoat", "Bullpup", "Baby Brachiosaur", "Pegasus Colt", "Miniature White Knight", "Dress-up Estinien", "Paissa Patissier", "Paissa Threadpuller", "Cerberpup", "Weatherproof Gaelicat", "Petit Pteranodon", "Trike" };
        public static readonly string[] squadMinionsTreasureStrings =
            { "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Paissa Brat", "Dwarf Rabbit", "Wind-up Namazu", "Wind-up Matanga", "The Gold Whisker", "Capybara Pup", "Hedgehoglet", "Wind-up Fuath", "Sungold Talos", "Golden Beaver", "Royal Lunatender", "Wind-up Aidoneus", "Wind-up Philos" };
        public static readonly string[] squadMinionsTrialStrings =
            { "Wind-up Ultros", "Enkidu", "Poogie", "Giant Beaver" };
        public static readonly string[] squadMinionsVentureStrings =
            { "Minute Mindflayer", "Tiny Tapir", "Miniature Minecart", "Littlefoot", "Fat Cat", "Gestahl", "Bom Boko", "Odder Otter", "Mameshiba", "Koala Joey", "Axolotl Eft", "Tengu Doll", "Bacon Bits", "Mystic Weapon", "Domakin", "Wind-up Hobgoblin", "Allagan Melon", "Greener Gleaner", "Flag", "Crabe De La Crabe", "Wind-up Grebuloff", "Wind-up Kangaroo", "Chewy", "Blue-footed Booby", "Clockwork Novus D" };
        public static readonly string[] squadMinionsVoyageStrings =
            { "Aurelia Polyp", "Abroader Otter", "Sharksucker-class Insubmersible", "Meerkat", "Silver Dasher", "Syldrion-class Insubmersible", "Benben Stone", "Suzusaurus" };
        public static readonly string[] squadMinionsTailsStrings =
            { "Dress-up Thancred", "Dress-up Alisaie", "Wind-up Estinien", "Wind-up Khloe", "Wind-up Hien", "Wind-up Zhloe", "Wind-up Omega-M", "Wind-up Omega-F", "Sand Fox", "Anteater", "Brave New Urianger", "Pterosquirrel", "Corgi" };
        public static readonly string[] squadMinionsGilStrings =
            { "Wayward Hatchling", "Cherry Bomb", "Tiny Rat", "Baby Raptor", "Baby Bat", "Mammet #001" };
        public static readonly string[] squadMinionsSaucerStrings =
            { "Zu Hatchling", "Heavy Hatchling", "Black Coeurl", "Water Imp", "Wind-up Nero Tol Scaeva", "Piggy", "Wind-up Daivadipa", "Mama Automaton" };
        public static readonly string[] squadMinionsPoeticsStrings =
            { "Wide-eyed Fawn", "Dust Bunny", "Fledgling Dodo" };
        public static readonly string[] squadMinionsHuntsStrings =
            { "Wind-up Succubus", "Treasure Box", "Behemoth Heir", "Griffin Hatchling", "Tora-jiro", "Wind-up Meateater", "Bitty Duckbill", "Cute Justice", "Nagxian Cat", "Wind-up Nu Mou" };
        public static readonly string[] squadMinionsGcStrings =
            { "Storm Hatchling", "Serpent Hatchling", "Flame Hatchling" };
        public static readonly string[] squadMinionsSanctuaryStrings =
            { "Felicitous Fuzzball", "Sky Blue Back" };
        public static readonly string[] squadMinionsOtherStrings =
            { "Wind-up Sun", "Wind-up Moon" };

        public static readonly string[] squadMountsAchievementStrings =
            { "Ahriman", "Behemoth", "Gilded Magitek Armor", "Warlion", "Warbear", "Storm Warsteed", "Serpent Warsteed", "Flame Warsteed", "Parade Chocobo", "Logistics System", "War Panther", "Gloria-class Airship", "Astrope", "Aerodynamics System", "Goten", "Ginga", "Raigo", "Battle Lion", "Battle Bear", "Battle Panther", "Centurio Tiger", "Magitek Avenger", "Magitek Death Claw", "Safeguard System", "Juedi", "Magitek Avenger A1", "Demi-Ozma", "War Tiger", "Triceratops", "Amaro", "Battle Tiger", "Morbol", "Construct VII", "Hybodus", "Pteranodon", "Cerberus", "Al-iklil", "Victor", "Silkie" };
        public static readonly string[] squadMountsTribeStrings =
            { "Cavalry Drake", "Laurel Goobbue", "Cavalry Elbst", "Bomb Palanquin", "Direwolf", "Sanuwa", "Kongamato", "Cloud Mallow", "Striped Ray", "Marid", "True Griffin", "Mikoshi", "Portly Porxie", "Great Vessel Of Ronka", "Rolling Tankard", "Hippo Cart", "Miw Miisv" };
        public static readonly string[] squadMountsBozjaStrings =
            { "Construct 14", "Gabriel Î‘", "Gabriel Mark III", "Deinonychus" };
        public static readonly string[] squadMountsCraftedStrings =
            { "Flying Chair", "Magicked Bed" };
        public static readonly string[] squadMountsDeepStrings =
            { "Disembodied Head", "Black Pegasus", "Dodo", "Sil'dihn Throne" };
        public static readonly string[] squadMountsDungeonStrings =
            { "Magitek Predator" };
        public static readonly string[] squadMountsEurekaStrings =
            { "Tyrannosaur", "Eldthurs", "Eurekan Petrel" };
        public static readonly string[] squadMountsFateStrings =
            { "Ixion", "Ironfrog Mover", "Level Checker", "Wivre" };
        public static readonly string[] squadMountsMogStrings =
            { "Coeurl", "Fat Chocobo", "Draught Chocobo", "Sleipnir", "Ceremony Chocobo", "Griffin", "Amber Draught Chocobo", "Twintania", "Witch's Broom", "White Devil", "Red Baron", "Original Fat Chocobo", "Bennu", "Fat Moogle", "Eggshilaration System", "Syldra", "Managarm", "Mystic Panda", "Starlight Bear", "Aquamarine Carbuncle", "Citrine Carbuncle", "Nezha Chariot", "Broken Heart", "Broken Heart", "Red Hare", "Indigo Whale", "SDS Fenrir", "Fatter Cat", "Fat Black Chocobo", "Magicked Carpet", "Grani", "Circus Ahriman", "Sunspun Cumulus", "Spriggan Stonecarrier", "Kingly Peacock", "Rubellite Carbuncle", "Chocobo Carriage", "Snowman", "Lunar Whale", "Polar Bear", "Cruise Chaser", "Arion", "Papa Paissa", "Megashiba", "Mechanical Lotus", "Magicked Umbrella", "Magicked Parasol", "Set Of Ceruleum Balloons" };
        public static readonly string[] squadMountsPvpStrings =
            { "Magitek Sky Armor" };
        public static readonly string[] squadMountsRaidStrings =
            { "Gobwalker", "Arrhidaeus", "Alte Roite", "Air Force", "Model O", "Skyslipper", "Ramuh", "Eden", "Demi-Phoinix", "Sunforged" };
        public static readonly string[] squadMountsSkybuilderStrings =
            { "Pegasus", "Ufiti", "Dhalmel", "Albino Karakul", "Megalotragus", "Big Shell", "Antelope Doe", "Antelope Stag" };
        public static readonly string[] squadMountsTreasureStrings =
            { "Alkonost", "Phaethon", "Pinky" };
        public static readonly string[] squadMountsTrialStrings =
            { "Nightmare", "Aithon", "Xanthos", "Gullfaxi", "Enbarr", "Markab", "Boreas", "White Lanner", "Rose Lanner", "Round Lanner", "Warring Lanner", "Dark Lanner", "Sophic Lanner", "Demonic Lanner", "Blissful Kamuy", "Reveling Kamuy", "Legendary Kamuy", "Auspicious Kamuy", "Lunar Kamuy", "Rathalos", "Euphonious Kamuy", "Hallowed Kamuy", "Fae Gwiber", "Innocent Gwiber", "Shadow Gwiber", "Ruby Gwiber", "Gwiber Of Light", "Emerald Gwiber", "Diamond Gwiber", "Lynx Of Eternal Darkness", "Lynx Of Divine Light", "Bluefeather Lynx", "Lynx Of Imperious Wind", "Lynx Of Righteous Fire" };
        public static readonly string[] squadMountsVoyageStrings =
            { "Zu" };
        public static readonly string[] squadMountsTailsStrings =
            { "Ixion", "Incitatus", "Construct VI-S", "Calydontis", "Troll", "Wondrous Lanner" };
        public static readonly string[] squadMountsGilStrings =
            { "Gilded Mikoshi", "Resplendent Vessel Of Ronka", "Magitek Avenger G1", "Chrysomallos" };
        public static readonly string[] squadMountsSaucerStrings =
            { "Adamantoise", "Fenrir", "Archon Throne", "Korpokkur Kolossus", "Typhon", "Sabotender Emperador", "Pod 602", "Blackjack" };
        public static readonly string[] squadMountsHuntsStrings =
            { "Wyvern", "Forgiven Reticence", "Vinegaroon" };
        public static readonly string[] squadMountsSanctuaryStrings =
            { "Garlond GL-II", "Island Mandragora", "Island Onion Prince", "Island Eggplant Knight", "Island Alligator" };
    }
}
