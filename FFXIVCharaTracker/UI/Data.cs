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

        public static readonly string[] SquadMinionAchievementStrings =
                    { "Black Chocobo Chick", "Beady Eye", "Mammet #003L", "Mammet #003G", "Mammet #003U", "Wind-up Cursor", "Princely Hatchling", "Wind-up Leader", "Minion Of Light", "Wind-up Odin", "Wind-up Warrior Of Light", "Fledgling Apkallu", "Wind-up Goblin", "Wind-up Gilgamesh", "Wind-up Louisoix", "Wind-up Nanamo", "Wind-up Firion", "Shalloweye", "Clockwork Twintania", "Penguin Prince", "Hellpup", "Faepup", "Komainu", "The Major-General", "Malone", "Laladile", "Much-coveted Mora", "Dolphin Calf", "Gull", };

        public static readonly string[] SquadMinionBozjaStrings =
                    { "Mameshiba", "Koala Joey", "Salt & Pepper Seal", "Axolotl Eft", "Wind-up Ravana", "Wind-up Shinryu", "Tengu Doll", "White Whittret", "Aurelia Polyp", "Byakko Cub", "Private Moai", "Monkey King", "Mudpie", "Scarlet Peacock", "Abroader Otter", "Seitei", "Wind-up Weapon", "Chameleon", "Sharksucker-class Insubmersible", "Magitek Helldiver F1", "Dáinsleif F1", "Save The Princess", "Wind-up Gunnhildr", };

        public static readonly string[] SquadMinionCraftedStrings =
                    { "Gravel Golem", "Wind-up Dullahan", "Wind-up Aldgoat", "Wind-up Qiqirn", "Model Vanguard", "Plush Cushion", "Magic Broom", "Nana Bear", "Model Magitek Bit", "Atrophied Atomos", "Iron Dwarf", "Clockwork Barrow", "Steam-powered Gobwalker G-VII", "Wind-up Illuminatus", "Wind-up Ifrit", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Chimera", "Wind-up Ravana", "Wind-up Shinryu", "Byakko Cub", "Private Moai", "Wind-up Magnai", "Wind-up Sadu", "Scarlet Peacock", "Seitei", "Wanderer's Campfire", "Adventure Basket", "Bantam Train", };

        public static readonly string[] SquadMinionDeepStrings =
                    { "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Miniature Minecart", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Gestahl", "Owlet", "Ugly Duckling", "Paissa Brat", "Korpokkur Kid", "Hunting Hawk", "Wind-up Ifrit", "Morpho", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Dwarf Rabbit", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Sasquatch", "Hecteye", "Shaggy Shoat", "Wind-up Edda", "Baby Brachiosaur", "Castaway Chocobo Chick", "Tiny Tatsunoko", "Bombfish", "Bom Boko", "Odder Otter", "Ghido", "Road Sparrow", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Salt & Pepper Seal", "White Whittret", "Monkey King", "Frilled Dragon", "Mudpie", "Wind-up Weapon", "Armadillo Bowler", "Clionid Larva", "Tiny Echevore", "Black Hayate", "Chameleon", "Shoebill", "Bacon Bits", "Mystic Weapon", "Little Leannan", "Meerkat", "Magitek Predator F1", "Prince Lunatender", "Hippo Calf", "Optimus Omicron", "Private Pachypodium", };

        public static readonly string[] SquadMinionDungeonStrings =
                    { "Morbol Seedling", "Bite-sized Pudding", "Demon Brick", "Slime Puddle", "Baby Opo-opo", "Naughty Nanka", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Korpokkur Kid", "Calca", "Brina", "Morpho", "Calamari", "Shaggy Shoat", "Bullpup", "Bombfish", "Ivon Coeurlfist Doll", "Ghido", "Road Sparrow", "Dress-up Yugiri", "Mock-up Grynewaht", "Magitek Avenger F1", "Salt & Pepper Seal", "White Whittret", "Monkey King", "Mudpie", "Wind-up Weapon", "Armadillo Bowler", "Clionid Larva", "Tiny Echevore", "Forgiven Hate", "Black Hayate", "Chameleon", "Shoebill", "Little Leannan", "Ancient One", "Ephemeral Necromancer", "Drippy", "Magitek Predator F1", "Prince Lunatender", "Tiny Troll", "Wind-up Magus Sisters", "Wind-up Anima", "Hippo Calf", "Caduceus", "Starbird", "Optimus Omicron", "Teacup Kapikulu", "Wind-up Scarmiglione", "Wind-up Cagnazzo", };

        public static readonly string[] SquadMinionEurekaStrings =
                    { "Calca", "Wind-up Fafnir", "The Prince Of Anemos", "Wind-up Mithra", "Copycat Bulb", "Wind-up Tarutaru", "Dhalmel Calf", "Wind-up Elvaan", "Conditional Virtue", "Yukinko Snowflake", };

        public static readonly string[] SquadMinionFateStrings =
                    { "Baby Bun", "Infant Imp", "Pudgy Puk", "Smallshell", "Gold Rush Minecart", "Fox Kit", "Wind-up Ixion", "Micro Gigantender", "Butterfly Effect", "Ironfrog Ambler", "Tinker's Bell", "Little Leafman", "Amaro Hatchling", "Wee Ea", "Wind-up Daivadipa", };

        public static readonly string[] SquadMinionGatherStrings =
                    { "Tiny Tortoise", "Gigantpole", "Kidragora", "Coblyn Larva", "Magic Bucket", "Castaway Chocobo Chick", "Tiny Tatsunoko", };

        public static readonly string[] SquadMinionSaucerStrings =
                    { "Zu Hatchling", "Heavy Hatchling", "Black Coeurl", "Water Imp", "Wind-up Nero Tol Scaeva", "Piggy", "Unlucky Rabbit", "Mama Automaton", };

        public static readonly string[] SquadMinionHuntStrings =
                    { "Wind-up Succubus", "Treasure Box", "Behemoth Heir", "Griffin Hatchling", "Tora-jiro", "Wind-up Meateater", "Bitty Duckbill", "Wind-up Nu Mou", "Cute Justice", "Nagxian Cat", };

        public static readonly string[] SquadMinionSanctuaryStrings =
                    { "Felicitous Fuzzball", "Sky Blue Back", };

        public static readonly string[] SquadMinionOtherStrings =
                    { "Wind-up Sun", "Onion Prince", "Eggplant Knight", "Garlic Jester", "Tomato King", "Mandragora Queen", "Assassin Fry", "Demon Box", "Wind-up Moon", "Allagan Melon", };

        public static readonly string[] SquadMinionMogStrings =
                    { "Baby Behemoth", "Tender Lamb", "Wind-up Edvya", "Wind-up Shantotto", "Wind-up Moogle", "Wind-up Minfilia", "Wind-up Thancred", "Wind-up Y'shtola", "Wind-up Yda", "Wind-up Papalymo", "Wind-up Urianger", "Hoary The Snowman", "Wind-up Kain", "Wind-up Alisaie", "Wind-up Tataru", "Wind-up Iceheart", "Pumpkin Butler", "Wind-up Yugiri", "Panda Cub", "Doman Magpie", "Dress-up Y'shtola", "Wind-up Krile", "Continental Eye", "Wind-up Rikku", "Wind-up Lulu", "Angel Of Mercy", "Wind-up Yuna", "Wind-up Bartz", "Wind-up Lyse", "Wind-up Gosetsu", "Motley Egg", "Wind-up Cirina", "Bridesmoogle", "Little Yin", "Little Yang", "Wind-up Tifa", "Wind-up Cloud", "Wind-up Aerith", "Wind-up Fran", "Brave New Y'shtola", "Wind-up Ardbert", "Wind-up Edge", "Wind-up Rydia", "Wind-up Rosa", "Wind-up Rudy", "Squirrel Emperor", "Wind-up Porom", "Hatching Bunny", };

        public static readonly string[] SquadMinionShopStrings =
                    { "Wayward Hatchling", "Storm Hatchling", "Serpent Hatchling", "Flame Hatchling", "Cherry Bomb", "Tiny Rat", "Wide-eyed Fawn", "Baby Raptor", "Baby Bat", "Dust Bunny", "Fledgling Dodo", "Mammet #001", };

        public static readonly string[] SquadMinionPvPStrings =
                    { "Fenrir Pup", "Wind-up Cheerleader", "Clockwork Lantern", "Minitek Conveyor", "Protonaught", };

        public static readonly string[] SquadMinionSidequestStrings =
                    { "Chigoe Larva", "Cactuar Cutting", "Goobbue Sproutling", "Wind-up Airship", "Coeurl Kitten", "Buffalo Calf", "Wolf Pup", "Mini Mole", "Wind-up Gentleman", "Midgardsormr", "Wind-up Alphinaud", "Wind-up Cid", "Accompaniment Node", "Wind-up Haurchefant", "Poro Roggo", "Wind-up Aymeric", "Wind-up Moenbryda", "Gigi", "Anima", "Dress-up Raubahn", "Palico", "Wind-up Alpha", "The Great Serpent Of Ronka", "Wind-up G'raha Tia", "Wind-up Mystel", "Wind-up Herois", "Golden Dhyata", };

        public static readonly string[] SquadMinionRaidStrings =
                    { "Wind-up Onion Knight", "Puff Of Darkness", "Wind-up Echidna", "Faustlet", "Wind-up Calofisteri", "Toy Alexander", "Wind-up Scathach", "Wind-up Exdeath", "Wind-up Kefka", "Construct 8", "OMG", "Wind-up Ramza", "Eden Minor", "Pod 054", "Pod 316", "Wind-up Ryne", "2B Automaton", "2P Automaton", "Wind-up Gaia", "Smaller Stubby", "9S Automaton", "Nosferatu", "Wind-up Azeyma", "Wind-up Erichthonios", "Wind-up Halone", };

        public static readonly string[] SquadMinionRestoStrings =
                    { "Plush Cushion", "Magic Broom", "Nutkin", "Atrophied Atomos", "Gaelikitten", "Owlet", "Ugly Duckling", "Clockwork Barrow", "Paissa Brat", "Hunting Hawk", "Morpho", "Calamari", "Dwarf Rabbit", "Shaggy Shoat", "Bullpup", "Baby Brachiosaur", "Pegasus Colt", "Miniature White Knight", "Dress-up Estinien", "Paissa Patissier", "Paissa Threadpuller", "Cerberpup", "Weatherproof Gaelicat", "Petit Pteranodon", "Trike", };

        public static readonly string[] SquadMinionTreasureStrings =
                    { "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Paissa Brat", "Dwarf Rabbit", "Wind-up Namazu", "Wind-up Matanga", "The Gold Whisker", "Capybara Pup", "Hedgehoglet", "Wind-up Fuath", "Sungold Talos", "Golden Beaver", "Royal Lunatender", "Wind-up Aidoneus", "Wind-up Philos", };

        public static readonly string[] SquadMinionTrialStrings =
                    { "Wind-up Ultros", "Enkidu", "Poogie", "Giant Beaver", };

        public static readonly string[] SquadMinionTribeStrings =
                    { "Wind-up Sylph", "Wind-up Amalj'aa", "Wind-up Kobold", "Wind-up Sahagin", "Wind-up Violet", "Wind-up Founder", "Wind-up Dezul Qualan", "Wind-up Ixal", "Wind-up Kobolder", "Wind-up Sea Devil", "Wind-up Gundu Warrior", "Wind-up Zundu Warrior", "Wind-up Vath", "Wind-up Gnath", "Wind-up Dragonet", "Wind-up Ohl Deeh", "Wind-up Kojin", "Wind-up Ananta", "Attendee #777", "Wind-up Redback", "Wind-up Qalyana", "Zephyrous Zabuton", "Wind-up Pixie", "The Behelmeted Serpent Of Ronka", "The Behatted Serpent Of Ronka", "Lalinator 5.H0", "Wind-up Arkasodara", "Lumini", "Findingway", };

        public static readonly string[] SquadMinionVandCStrings =
                    { "Sponge Silkie", "Sewer Skink", };

        public static readonly string[] SquadMinionVentureStrings =
                    { "Minute Mindflayer", "Tiny Tapir", "Miniature Minecart", "Littlefoot", "Fat Cat", "Gestahl", "Bom Boko", "Odder Otter", "Mameshiba", "Koala Joey", "Axolotl Eft", "Tengu Doll", "Bacon Bits", "Mystic Weapon", "Domakin", "Wind-up Hobgoblin", "Allagan Melon", "Greener Gleaner", "Flag", "Crabe De La Crabe", "Wind-up Grebuloff", "Wind-up Kangaroo", "Chewy", "Blue-footed Booby", "Clockwork Novus D", };

        public static readonly string[] SquadMinionVoyageStrings =
                    { "Aurelia Polyp", "Abroader Otter", "Sharksucker-class Insubmersible", "Meerkat", "Silver Dasher", "Syldrion-class Insubmersible", "Benben Stone", "Suzusaurus", };

        public static readonly string[] SquadMinionTailsStrings =
                    { "Dress-up Thancred", "Dress-up Alisaie", "Wind-up Estinien", "Wind-up Khloe", "Wind-up Hien", "Wind-up Zhloe", "Wind-up Omega-M", "Wind-up Omega-F", "Sand Fox", "Anteater", "Brave New Urianger", "Pterosquirrel", "Corgi", };

        public static readonly string[] SquadMountAchievementStrings =
                    { "Ahriman", "Behemoth", "Gilded Magitek Armor", "Warlion", "Warbear", "Storm Warsteed", "Serpent Warsteed", "Flame Warsteed", "Parade Chocobo", "Logistics System", "War Panther", "Gloria-class Airship", "Astrope", "Aerodynamics System", "Goten", "Ginga", "Raigo", "Battle Lion", "Battle Bear", "Battle Panther", "Centurio Tiger", "Magitek Avenger", "Magitek Death Claw", "Safeguard System", "Juedi", "Magitek Avenger A1", "Demi-Ozma", "War Tiger", "Triceratops", "Amaro", "Battle Tiger", "Morbol", "Construct VII", "Hybodus", "Pteranodon", "Cerberus", "Al-iklil", "Victor", "Silkie", "Aeturna", };

        public static readonly string[] SquadMountBozjaStrings =
                    { "Construct 14", "Gabriel Α", "Gabriel Mark III", "Deinonychus", };

        public static readonly string[] SquadMountCraftedStrings =
                    { "Flying Chair", "Magicked Bed", };

        public static readonly string[] SquadMountDeepStrings =
                    { "Disembodied Head", "Black Pegasus", "Dodo", "Orthos Craklaw", };

        public static readonly string[] SquadMountDungeonStrings =
                    { "Magitek Predator", };

        public static readonly string[] SquadMountEurekaStrings =
                    { "Tyrannosaur", "Eldthurs", "Eurekan Petrel", };

        public static readonly string[] SquadMountFateStrings =
                    { "Ixion", "Ironfrog Mover", "Level Checker", "Wivre", };

        public static readonly string[] SquadMountSaucerStrings =
                    { "Adamantoise", "Fenrir", "Archon Throne", "Korpokkur Kolossus", "Typhon", "Sabotender Emperador", "Pod 602", "Blackjack", };

        public static readonly string[] SquadMountHuntStrings =
                    { "Wyvern", "Forgiven Reticence", "Vinegaroon", };

        public static readonly string[] SquadMountSanctuaryStrings =
                    { "Garlond GL-II", "Island Mandragora", "Island Onion Prince", "Island Eggplant Knight", "Island Alligator", };

        public static readonly string[] SquadMountMogStrings =
                    { "Coeurl", "Fat Chocobo", "Draught Chocobo", "Sleipnir", "Ceremony Chocobo", "Griffin", "Amber Draught Chocobo", "Twintania", "Witch's Broom", "White Devil", "Red Baron", "Original Fat Chocobo", "Bennu", "Fat Moogle", "Eggshilaration System", "Syldra", "Managarm", "Mystic Panda", "Starlight Bear", "Aquamarine Carbuncle", "Citrine Carbuncle", "Nezha Chariot", "Broken Heart (Right)", "Broken Heart (Left)", "Red Hare", "Indigo Whale", "SDS Fenrir", "Fatter Cat", "Fat Black Chocobo", "Magicked Carpet", "Grani", "Circus Ahriman", "Sunspun Cumulus", "Spriggan Stonecarrier", "Kingly Peacock", "Rubellite Carbuncle", "Chocobo Carriage", "Snowman", "Lunar Whale", "Polar Bear", "Cruise Chaser", "Arion", "Papa Paissa", "Megashiba", "Mechanical Lotus", "Magicked Umbrella", "Magicked Parasol", "Set Of Ceruleum Balloons", };

        public static readonly string[] SquadMountShopStrings =
                    { "Gilded Mikoshi", "Resplendent Vessel Of Ronka", "Magitek Avenger G1", "Chrysomallos", };

        public static readonly string[] SquadMountPvPStrings =
                    { "Magitek Sky Armor", };

        public static readonly string[] SquadMountSidequestStrings =
                    { "Company Chocobo", "Magitek Armor", "Unicorn", "Kirin", "Midgardsormr", "Manacutter", "Black Chocobo", "Firebird", "Yol", "Kamuy Of The Nine Tails", "Ehll Tou", "Landerwaffe", "Magicked Card", "Argos", "Anden III", };

        public static readonly string[] SquadMountRaidStrings =
                    { "Gobwalker", "Arrhidaeus", "Alte Roite", "Air Force", "Model O", "Skyslipper", "Ramuh", "Eden", "Demi-Phoinix", "Sunforged", };

        public static readonly string[] SquadMountRestoStrings =
                    { "Pegasus", "Ufiti", "Dhalmel", "Albino Karakul", "Megalotragus", "Big Shell", "Antelope Doe", "Antelope Stag", };

        public static readonly string[] SquadMountTreasureStrings =
                    { "Alkonost", "Phaethon", "Pinky", };

        public static readonly string[] SquadMountTrialStrings =
                    { "Nightmare", "Aithon", "Xanthos", "Gullfaxi", "Enbarr", "Markab", "Boreas", "White Lanner", "Rose Lanner", "Round Lanner", "Warring Lanner", "Dark Lanner", "Sophic Lanner", "Demonic Lanner", "Blissful Kamuy", "Reveling Kamuy", "Legendary Kamuy", "Auspicious Kamuy", "Lunar Kamuy", "Rathalos", "Euphonious Kamuy", "Hallowed Kamuy", "Fae Gwiber", "Innocent Gwiber", "Shadow Gwiber", "Ruby Gwiber", "Gwiber Of Light", "Emerald Gwiber", "Diamond Gwiber", "Lynx Of Eternal Darkness", "Lynx Of Divine Light", "Bluefeather Lynx", "Lynx Of Imperious Wind", "Lynx Of Righteous Fire", };

        public static readonly string[] SquadMountTribeStrings =
                    { "Cavalry Drake", "Laurel Goobbue", "Cavalry Elbst", "Bomb Palanquin", "Direwolf", "Sanuwa", "Kongamato", "Cloud Mallow", "Striped Ray", "Marid", "True Griffin", "Mikoshi", "Portly Porxie", "Great Vessel Of Ronka", "Rolling Tankard", "Hippo Cart", "Miw Miisv", "Moon-hopper", };

        public static readonly string[] SquadMountVandCStrings =
                    { "Sil'dihn Throne", };

        public static readonly string[] SquadMountVoyageStrings =
                    { "Zu", };

        public static readonly string[] SquadBardingAchievementStrings =
                    { "Black Mage Barding", "Sovereign Barding", "Barding Of Light", "Plumed Barding", "Flyer Shaffron", "Wild Rose Barding", "Race Barding", };

        public static readonly string[] SquadBardingBozjaStrings =
                    { "Expanse Barding", "Hive Barding", "Sephirotic Barding", "Horde Barding", "Sophic Barding", "Zurvanite Barding", "Reveler's Barding", "Shinryu Barding", "Byakko Barding", "Lunar Barding", "Suzaku Barding", "Seiryu Barding", "Queen's Guard Barding", "Bozjan Barding", };

        public static readonly string[] SquadBardingCraftedStrings =
                    { "Tidal Barding", "Levin Barding", "Ice Barding", "Orthodox Barding", "Highland Barding", "Expanse Barding", "Hive Barding", "Sephirotic Barding", "Horde Barding", "Sophic Barding", "Zurvanite Barding", "Reveler's Barding", "Blissful Barding", "Shinryu Barding", "Byakko Barding", "Lunar Barding", "Suzaku Barding", "Seiryu Barding", "Titania Barding", "Innocence Barding", "Hades Barding", "Ruby Barding", "True Barding Of Light", "Emerald Barding", "Diamond Barding", "Barding Of Eternal Darkness", "Barding Of Divine Light", "Bluefeather Barding", "Windswept Barding", "Flamecloaked Barding", };

        public static readonly string[] SquadBardingDeepStrings =
                    { "Tidal Barding", "Levin Barding", "Ice Barding", "Expanse Barding", "Hive Barding", "Sephirotic Barding", "Horde Barding", "Abigail Barding", "Sophic Barding", "Zurvanite Barding", "Reveler's Barding", "Blissful Barding", "Lunar Barding", "Suzaku Barding", "Seiryu Barding", "Titania Barding", "Innocence Barding", "Ruby Barding", "Emerald Barding", "Diamond Barding", "Barding Of Eternal Darkness", "Barding Of Divine Light", "Allagan Barding", };

        public static readonly string[] SquadBardingEurekaStrings =
                    { "Red Mage Barding", "Samurai Barding", };

        public static readonly string[] SquadBardingFateStrings =
                    { "Sleipnir Barding", "Ishgardian Half Barding", "Ala Mhigan Barding", "Ixion Barding", "Dancer Barding", "Deepshadow Barding", "Thavnairian Barding", };

        public static readonly string[] SquadBardingGatherStrings =
                    { "Chocobo Raincoat", };

        public static readonly string[] SquadBardingSaucerStrings =
                    { "Gambler Barding", "Mandervillian Barding", };

        public static readonly string[] SquadBardingHuntStrings =
                    { "Ishgardian Barding", "Hingan Barding", };

        public static readonly string[] SquadBardingSanctuaryStrings =
                    { "Isle Pioneer's Barding", };

        public static readonly string[] SquadBardingMogStrings =
                    { "Far Eastern Barding", "Butlery Barding", "Behemoth Barding", "Starlight Barding", "Egg Barding", "Eerie Barding", "Paramour Barding", "Egg Hunter Barding", "Angelic Barding", "Demonic Barding", "Oriental Barding", "Nezha Barding", "Saintly Barding", "Postmoogle Barding", };

        public static readonly string[] SquadBardingShopStrings =
                    { "Lominsan Half Barding", "Lominsan Barding", "Lominsan Crested Barding", "Gridanian Half Barding", "Gridanian Barding", "Gridanian Crested Barding", "Ul'dahn Half Barding", "Ul'dahn Barding", "Ul'dahn Crested Barding", };

        public static readonly string[] SquadBardingPvPStrings =
                    { "Wolf Barding", };

        public static readonly string[] SquadBardingRestoStrings =
                    { "Tidal Barding", "Levin Barding", "Ice Barding", "Expanse Barding", "Hive Barding", "Sephirotic Barding", "Horde Barding", "Sophic Barding", "Zurvanite Barding", "Machinist Barding", };

        public static readonly string[] SquadBardingTrialStrings =
                    { "Round Table Barding", "Yojimbo Barding", };

        public static readonly string[] SquadEmoteAchievementStrings =
                    { "Squats", "Push-ups", "Sit-ups", "Breath Control", };

        public static readonly string[] SquadEmoteBozjaStrings =
                    { "Guard", "Malevolence", "Wring Hands", };

        public static readonly string[] SquadEmoteDeepStrings =
                    { "Sweat", };

        public static readonly string[] SquadEmoteEurekaStrings =
                    { "Shiver", "Scheme", "Fist Pump", };

        public static readonly string[] SquadEmoteSaucerStrings =
                    { "Thavnairian Dance", "Gold Dance", "Aback", "Big Grin", "Bee's Knees", "Draw Weapon", "Sheathe Weapon", };

        public static readonly string[] SquadEmoteHuntStrings =
                    { "Tremble", "Winded", "Headache", };

        public static readonly string[] SquadEmoteOtherStrings =
                    { "Fist Bump", "Tomestone", };

        public static readonly string[] SquadEmoteMogStrings =
                    { "Bomb Dance", "Huzzah", "Eureka", "Red Ranger Pose A", "Red Ranger Pose B", "Black Ranger Pose A", "Black Ranger Pose B", "Yellow Ranger Pose A", "Yellow Ranger Pose B", "Eastern Greeting", "Dote", "Backflip", "Songbird", "Play Dead", "Eastern Stretch", "Eastern Dance", "Pretty Please", "Power Up", "Cheer On", "Cheer Wave", "Cheer Jump", "Megaflare", "Splash", "Crimson Lotus", "Box Step", "Side Step", "Senor Sabotender", "Get Fantasy", "Popoto Step", "Toast", "Snap", "Heel Toe", "Goobbue Do", "Consider", "Flame Dance", "Wasshoi", "Flower Shower", "Vexed", "Pantomime", "Eat Egg", "Drink Tea", "Deride", };

        public static readonly string[] SquadEmoteShopStrings =
                    { "Attention", "At Ease", "Reflect", };

        public static readonly string[] SquadEmotePvPStrings =
                    { "Elucidate", "Reprimand", };

        public static readonly string[] SquadEmoteSidequestStrings =
                    { "Imperial Salute", "Throw", "Step Dance", "Harvest Dance", "Ball Dance", "Manderville Dance", "Embrace", "Most Gentlemanly", "Sundrop Dance", "Battle Stance", "Victory", "Haurchefant", "Moogle Dance", "Spectacles", "Moonlift Dance", "Eastern Bow", "Water Flip", "Box", "Greeting", "Ponder", "Hum", "Endure", "Gratuity", "Manderville Mambo", "Lali-ho", "Shush", };

        public static readonly string[] SquadEmoteRestoStrings =
                    { "Lean", "Insist", "Break Fast", "Read", "High Five", "Eat Rice Ball", "Eat Apple", "Sweep Up", };

        public static readonly string[] SquadEmoteTreasureStrings =
                    { "Confirm", "Paint It Black", "Paint It Red", "Paint It Yellow", "Paint It Blue", };

        public static readonly string[] SquadEmoteTribeStrings =
                    { "Ritual Prayer", "Charmed", "Yol Dance", "Lali Hop", "Ear Wiggle", };

        public static readonly string[] SquadEmoteVandCStrings =
                    { "Wow", };

        public static readonly string[] SquadHairstyleBozjaStrings =
                    { "Wind Caller", "Early To Rise", "Both Ways", };

        public static readonly string[] SquadHairstyleDeepStrings =
                    { "Samsonian Locks", "Gyr Abanian Plait", "A Close Shave", };

        public static readonly string[] SquadHairstyleEurekaStrings =
                    { "Form And Function", };

        public static readonly string[] SquadHairstyleSaucerStrings =
                    { "Ponytails", "Adventure", "Curls", "Rainmaker", "Lexen-tails", "Great Lengths", };

        public static readonly string[] SquadHairstyleSanctuaryStrings =
                    { "Tall Tails", "Practical Ponytails", };

        public static readonly string[] SquadHairstyleMogStrings =
                    { "A Wicked Wake", "Scion Special Issue", "Pulse", "Scion Special Issue II", "Scion Special Issue III", "Master & Commander", "Sharlayan Studies", "Clowning Around", "Liberating Locks", "Sharlayan Rebellion", };

        public static readonly string[] SquadHairstylePvPStrings =
                    { "Fashionably Feathered", "Styled For Hire", };

        public static readonly string[] SquadHairstyleRaidStrings =
                    { "Battle-ready Bobs", "Scanning For Style", };

        public static readonly string[] SquadHairstyleRestoStrings =
                    { "Modern Legend", "Controlled Chaos", "Saintly Style", };

        public static readonly string[] SquadOrchestrionAchievementStrings =
                    { "Prelude – Discoveries", "Ultima", "Defender Of The Realm", "The Seventh Sun", "Prelude - Long March Home", "Beyond Redemption", "Doman Distractions", "Shuffle Or Boogie (Shadowbringers)", };

        public static readonly string[] SquadOrchestrionBozjaStrings =
                    { "Wind On The Plains", "Blood On The Wind", "Discord: Imperial (Zodiac Age Version)", "Into The Fortress (Zodiac Age Version)", "Battle With An Esper (Zodiac Age Version)", "Life And Death (Zodiac Age Version)", "The Sochen Cave Palace (Zodiac Age Version)", "Giving Chase (Zodiac Age Version)", "The Queen Awakens", "Wrath Of The Harrier", };

        public static readonly string[] SquadOrchestrionCraftedStrings =
                    { "Hubris", "Tumbling Down", "The Maker's Ruin", "Now I Know The Truth", "Primal Judgment", "Out Of The Labyrinth", "Blood For Blood", "Fallen Angel", "Starved", "Under The Weight", "Blind To The Dark", "Heroes", "Hunger", "Fiend", "Eternal Wind", "Thunderer", "A Light In The Storm", "The Only Path", "The Dark's Embrace", "Rise Of The White Raven", "A World Apart", "The Scars Of Battle", "From The Ashes", "Answers", "Another Round", "Dark Vows", "Riptide", "Painted Foothills", "Lost In The Clouds", "Imagination", "Down The Up Staircase", "Wreck To The Seaman", "Through The Maelstrom", "Good King Moggle Mog XII", "Revenge Of The Horde", "Battle On The Big Bridge", "Engage", "Against The Wind", "Landlords", "Missing Pages", "Footsteps In The Snow", "Oblivion", "Thunder Rolls", "Equilibrium", "Close To The Heavens", "The Corpse Hall", "Limitless Blue", "Woe That Is Madness", "The Hand That Gives The Rose", "Unbending Steel", "Infinity", "Revelation", "Beauty's Wicked Wiles", "Skylords", "The Silent Regard Of Stars", "The Worm's Head", "The Worm's Tail", "On High", "Answer On High", "Amatsu Kaze", "Ambient Abyss", "Nightbloom", "Wayward Daughter", "Black And White", "Sunrise", "From The Dragon's Wake", "Afterglow", "Harmony", "What Angel Wakes Me", "Insanity", "Invincible", "Ultima (The Primals)", "To The Edge", "Eternal Wind (Shadowbringers)", "The Black Wolf Stalks Again", "In The Arms Of War", "Endcaller", "Your Answer", "The Final Day", "With Hearts Aligned", "Battle With The Four Fiends (Buried Memory)", "Forged In Crimson", };

        public static readonly string[] SquadOrchestrionDeepStrings =
                    { "A Light In The Storm", "The Scars Of Battle", "Dark Vows", "Riptide", "Down The Up Staircase", "Horizons Calling", "Ink Long Dry", "Blackbosom", "Fog Of Phantom", "Blasphemous Experiment", "Notice Of Death", "Bibliophobia", "Far From Home", "Unbreakable (Duality)", "Earth, Wind, And Water", "Far East Of Eorzea", "Parting Ways", "A Land Long Dead", "From Mud", "To Fire And Sword", "Figments", "Unwound", "Deep Down", "In The Belly Of The Beast", "Mortal Instants", "A Long Fall", "Shadows Withal", "The Grand Cosmos", "Where All Roads Lead", "Freshly Glazed Porxie", "Tower Of Zot (Endwalker)", "Garlemald Express", "As The Sky Burns", "Miracle Works", "The Aetherial Sea", "Of Countless Stars", "Carrots Of Happiness", "The Map Unfolds", "Troian Beauty (Endwalker)", "Forbidden Land (Endwalker)", "The Promise Of Plunder", "Crystal Rain", };

        public static readonly string[] SquadOrchestrionDungeonStrings =
                    { "Horizons Calling", "The Warrens", "Ink Long Dry", "Unbreakable", "Apologies", "Silver Tears", "Slumber Eternal", "Hallowed Halls", "Poison Ivy", "Bibliophobia", "The Open Box", "Most Unworthy", "Deception", "Far From Home", "Liberty Or Death", "Their Deadly Mission", "Down Where Daemons Dwell", "Unbreakable (Duality)", "The Ancient City", "Gates Of The Moon", "Earth, Wind, And Water", "Beneath Bloodied Banners", "Tricksome", "Upon The Rocks", "A Land Long Dead", "From Mud", "A Pall Most Murderous", "To Fire And Sword", "Figments", "Unwound", "Deep Down", "In The Belly Of The Beast", "Mortal Instants", "A Long Fall", "Shadows Withal", "Fury", "Alienus", "The Grand Cosmos", "The Maiden's Lament", "The Darkhold", "Floundering In The Depths", "Abomination", "A Tonberry's Tears", "Where All Roads Lead", "Below", "The Ludus", "Freshly Glazed Porxie", "Dancing Calcabrina", "Seven Flames", "From The Depths", "Tower Of Zot (Endwalker)", "Garlemald Express", "As The Sky Burns", "Miracle Works", "The Aetherial Sea", "Of Countless Stars", "Carrots Of Happiness", "Roar Of The Wyrm", "Dawnbound", "The Map Unfolds", "Aftermath", "Descent", "Like A Summer Rain", "A Thousand Screams", "Lipflaps On Longstops", "Troian Beauty (Endwalker)", "FINAL FANTASY IV: Battle 2 (Endwalker)", "Toll Of The Bells", "Stigma", "Deep Blue", "Echoes Of Ages Past", "Cold Salvation", "Miser's Folly", "Cracks In The Wall", "Forgotten By The Sun", "Holy Consult", };

        public static readonly string[] SquadOrchestrionEurekaStrings =
                    { "Wicked Winds Whisper", "No Quarter", "Gates Of Paradise - The Garden Of Ru'Hmet", "Onslaught", "Turmoil", };

        public static readonly string[] SquadOrchestrionFateStrings =
                    { "Fleeting Rays", "Beyond The Wall", "Liquid Flame", "The Dark Which Illuminates The World", "Indulgence", "The Source", "A World Divided", "Sands Of Amber", "Fierce And Free", "Civilizations", "Full Fathom Five", "Knowledge Never Sleeps", "Masquerade", "Unchanging, Everchanging", "The Quick Way", "Sands Of Blood", "The Faerie Ring", "A Hopeless Race", "Neath Dark Waters", "A Reason To Live", "No Greater Sorrow", "Bedlam's Brink", "The Ewer Brimmeth", "Twilit Terraces", "The Labyrinth", "Divine Words", "White Snow, Black Steel", "One Small Step", "Sky Unsundered", "Close In The Distance", "The Nautilus Knoweth", "The Day Will Come (Endwalker)", "Vibrant Voices", "Perfumed Eves", "Dreams Of Man", "Prayers Repeated", "Black Steel, Cold Embers", "Stars Long Dead", "Welcome To Our Town! (Endwalker)", "Home Beyond The Horizon", "The Emperor's Wont", "Penitus", };

        public static readonly string[] SquadOrchestrionGatherStrings =
                    { "Songs Of Salt And Suffering", "Hope Forgotten", "The Stone Remembers", "Old Wounds", "Freedom", };

        public static readonly string[] SquadOrchestrionSaucerStrings =
                    { "Torn From The Heavens", "Agent Of Inquiry", "Sport Of Kings", "Four-sided Circle", "A Cold Wind", "Battle To The Death - Heavensward", "Battle Theme 1.x", "Spiral", "Tempest", "Daring Dalliances", "Revenge Twofold", "Triumph", "Game Theory", "Rise Of Heroes (Chiptune Version)", "Vamo' Alla Flamenco (Shadowbringers)", "A Fine Death", "Gateway To Paradise", "Shuffle Or Boogie", };

        public static readonly string[] SquadOrchestrionHuntStrings =
                    { "Thicker Than A Knife's Blade", "Drowning In The Horizon", "Rencounter", "Nail Of The Heavens", "Imperium", "Gogo's Theme", "Unbowed", };

        public static readonly string[] SquadOrchestrionSanctuaryStrings =
                    { "A Quiet Moment", "Island Paradise", };

        public static readonly string[] SquadOrchestrionOtherStrings =
                    { "Tenacity", "When A Tree Falls", };

        public static readonly string[] SquadOrchestrionMogStrings =
                    { "Pa-Paya", "Moonfire Faire", "Heavensward", "All Saints' Wake", "Up At Dawn", "Starlight Celebration", "Heavensturn", "Borderless (Duality)", "Unbending Steel (Duality)", "The Kiss", "Hyper Rainbow Z", "Answers - Reprise", "Stormblood", "Ultima (Orchestral Version)", "Heroes (Orchestral Version)", "Starlit Gateway", "Siren Song", "Rise Of The White Raven (Orchestral Version)", "Revenge Twofold (Orchestral Version)", "Oblivion (Orchestral Version)", "Revolutions", "Starlight, Starbright", "Serenity (Orchestral Version)", "Calamity Unbound (Orchestral Version)", "Ominous Prognisticks (Orchestral Version)", "Wayward Daughter (Chiptune Version)", "The Worm's Tail (Chiptune Version)", "Rise (The Primals)", "Oblivion (GUNN Vocals)", "Painted Foothills (Orchestral Version)", "Moebius (Orchestral Version)", "The Worm's Tail (Journeys Version)", "EScape (Journeys Version)", "Starlight De Chocobo", "Tsukuyomi's Pain (Orchestral Version)", "The Worm's Tail (Orchestral Version)", "A New Hope (Piano Collections)", "Wailers And Waterwheels (Piano Collections)", "I Am The Sea (Piano Collections)", "Neath Dark Waters (Scions & Sinners)", "A Long Fall (Scions & Sinners: Band)", "Ominous Prognisticks (Piano Collections)", "Night In The Brume (Piano Collections)", "Painted Foothills (Piano Collections)", "On Westerly Winds (Piano Collections)", "Serenity (Piano Collections)", "To The Sun (Piano Collections)", "Invincible (Scions & Sinners: Piano)", "Tomorrow And Tomorrow (Scions & Sinners: Amanda Achen Vocals)", "Return To Oblivion (Scions & Sinners: Amanda Achen Vocals)", "What Angel Wakes Me (Scions & Sinners: Amanda Achen Vocals)", "A Long Fall (Scions & Sinners: Piano)", "Equilibrium (Scions & Sinners: Band)", "What Angel Wakes Me (Scions & Sinners: Band)", "Shadowbringers (Scions & Sinners: Band)", "Blinding Indigo (Scions & Sinners: Band)", "Insatiable (Scions & Sinners: Band)", "Rise (Pulse)", "Through The Maelstrom (Pulse)", "Neath Dark Waters (Pulse)", "What Angel Wakes Me (Pulse)", "Sunrise (Pulse)", "Ink Long Dry (Piano Collections)", "Heroes (Piano Collections)", "Old Wounds (Piano Collections)", "Westward Tide (Piano Collections)", "Imagination (Piano Collections)", "Crimson Sunset (Piano Collections)", "Close In The Distance (Beyond The Shadow)", "Hic Svnt Leones (Beyond The Shadow)", "To The Edge (Orchestral Version)", "Flow (Orchestral Version)", };

        public static readonly string[] SquadOrchestrionShopStrings =
                    { "Wailers And Waterwheels", "I Am The Sea", "A New Hope", "The Waking Sands", "Contention", "Solid", "A Sailor Never Sleeps", "Dance Of The Fireflies", "Sultana Dreaming", "On Westerly Winds", "Serenity", "To The Sun", "Nobility Obliges", "The Mushroomery", "Shelter", "Ominous Prognisticks", "Behind Closed Doors", "Where The Heart Is", "Reflections", "Nobility Sleeps", "Night In The Brume", "Homestead", "Canticle", "Aetherosphere", "Six Fulms Under", "Teardrops In The Rain", "A Thousand Faces", "Frontiers Within", "Saltswept", "Ambient Birdsong", "Ambient Waves", "Ambient Rainfall", "Ambient Cricketsong", "The Edge", "Ambient Insects", "Ambient Bonfire", "Ambient Kitchen", "Impact", "Babbling Brook", "Bustling Boulevard", "Temple Bell", "Chapel Bell", "Fragments Of Forever", "Westward Tide", "He Rises Above", "Ambient Wind Chime", "Victory Or Death", "Cradle", "Starlight And Sellswords", "Born To Ride", "Dewdrops & Moonbeams", "Ripples In The Sea", "The Sands' Secrets", "Silence", "Into The Adder's Den", "Maelstrom Command", "The Hall Of Flames", "Bliss", "Sacred Bonds", };

        public static readonly string[] SquadOrchestrionPvPStrings =
                    { "Birds Of Prey", "Rival Wings", "A Fierce Air Forceth", "A Fine Air Forbiddeth", "Warming Up", "Festival Of The Hunt (Endwalker)", "Run! (Endwalker)", };

        public static readonly string[] SquadOrchestrionSidequestStrings =
                    { "Dragonsong", "Sins Of The Father, Sins Of The Son", "Locus", "Metal", "Metal - Brute Justice Mode", "Exponential Entropy", "Rise", "Grounded", "Forever Lost", "Promises", "Shadow Of The Body", "Another Brick", "Quicksand", "Steel Reason", "Imperial Will", "He Who Continues The Attack", "The Measure Of His Reach", "The Measure Of Our Reach", "Protagonist's Theme", "Background Story", "Cyan's Theme", "Iroha", "World Map", "A Chapel", "A Dream In Flight", "Ending", "Deltascape", "Staff Credits", "Alma's Theme", "Shadowbringers", "Tomorrow And Tomorrow", "Significance (Nothing)", "Pain In Pleasure", "Voice Of No Return (Guitar)", "Crumbling Lies (Front)", "Blue Fields (Shadowbringers)", "Broken Heart", "Amusement Park", "New Foundations", "Voice Of No Return (Normal)", "The Color Of Depression", "Widespread Illness", "Possessed By Disease", "Faltering Prayer (Dawn Breeze)", "And Love You Shall Find", "Weight Of The World (Instrumental)", "Endwalker – Footfalls", "Flow", "Flow Together", "Somewhere In The World (Ambitions Writhe)", };

        public static readonly string[] SquadOrchestrionRaidStrings =
                    { "Moebius", "Trisection", "Precipitous Combat", "Ultima's Transformation", "Shattered", "The Mystery Of Giruvegan", "Apoplexy", "Flash Of Steel", "Omega Squared", "Decisions (Omega)", "Final, Not Final", "A Battle Decisively", "Dancing Mad - Movement I", "Dancing Mad - Movement II", "Dancing Mad - Movement III", "Dancing Mad - Movement IV", "Battle", "Primogenitor", "EScape", "Heartless", "From The Heavens", "Under The Stars", "Pressure (No. 1)", "Antipyretic", "A Man Consumed", "Ultima's Perfection", "Force Your Way (Shadowbringers)", "Blinding Indigo", "Landslide", "City Ruins (Rays Of Light)", "Alien Manifestation", "Song Of The Ancients (Atonement)", "Bipolar Nightmare", "Weight Of The World (Prelude Version)", "Twice Stricken", "Primal Angel", "Return To Oblivion", "Fortress Of Lies", "Grandma (Destruction)", "End Of The Unknown", "Torn From The Heavens／The Dark Colossus Destroys All (Medley Version)", "Don't Be Afraid (Shadowbringers)", "The Legendary Beast (Shadowbringers)", "Promises To Keep", "The Extreme (Shadowbringers)", "Mourning", "Emil (Despair)", "The Sound Of The End", "The Sound Of The End: 8bit", "Kainé (Final Fantasy Main Theme Version)", "Ancient Shackles", "Hic Svnt Leones", "Pilgrimage", "Radiance", "In The Balance", "Silent Scream", "Scream", "Embers", "White Stone Black", "Favor", "Rhythm Of The Realm", "Dedicated To Moonlight", };

        public static readonly string[] SquadOrchestrionRestoStrings =
                    { "Jewel", "Navigator's Glory - The Theme Of Limsa Lominsa", "Born Of The Boughs - The Theme Of Gridania", "The Twin Faces Of Fate - The Theme Of Ul'dah", "Tricksome", "Upon The Rocks", "Safety In Numbers", "Stone And Steel", "The Mendicant's Relish", "Order Yet Undeciphered", "Paradise Found", "Fealty", "The Heavens' Ward", "Freefall", "Hearthward", "Faith In Her Fury", "Painted Skies", "Skyrise", "What Is Love?", "Unworthy", };

        public static readonly string[] SquadOrchestrionTreasureStrings =
                    { "On Windy Meadows", "Whisper Of The Land", "Twilight Over Thanalan", "Calamity Unbound", "Unspoken", "Breaking Boundaries", "Navigator's Glory - The Theme Of Limsa Lominsa", "Born Of The Boughs - The Theme Of Gridania", "The Twin Faces Of Fate - The Theme Of Ul'dah", "Crimson Sunrise", "A Father's Pride", "Crimson Sunset", "A Mother's Pride", "Insatiable", "On Our Fates Alight", "Unmatching Pieces", "Everywhere And Nowhere", "Tomorrow And Tomorrow - Reprise", "Dangerous Words", "A Better Tomorrow", "On Blade's Edge", "Finality", "A Victory Fanfare Reborn", "Dangertek", };

        public static readonly string[] SquadOrchestrionTrialStrings =
                    { "Cornerstone Of The New World - Astera", "Savage Of The Ancient Forest", "Proof Of A Hero - Monster Hunter: World Version", };

        public static readonly string[] SquadOrchestrionTribeStrings =
                    { "Smoulder", "Coming Home", "Flibbertigibbet", "Piece Of Mind", "Indomitable", "Keepers Of The Lock", "Seven Hundred Seventy-Seven Whiskers", "The Garden's Gates", "Hopl's Dropple", "Watts's Anvil", "Hippo Ridin'", "Cradle Of Hope", "Dreamwalker", "Battle 1 From FINAL FANTASY IV", };

        public static readonly string[] SquadOrchestrionVandCStrings =
                    { "Desert Sun", };

        public static readonly string[] SquadOrchestrionVoyageStrings =
                    { "Hard To Miss", "Nemesis", "By Design", "Dreams Aloft", };

        public static readonly string[] SquadFashionAchievementStrings =
                    { "Gold Parasaucer", };

        public static readonly string[] SquadFashionBozjaStrings =
                    { "Classy Checkered Parasol", "Pleasant Dot Parasol", };

        public static readonly string[] SquadFashionDeepStrings =
                    { "Raindrop Defense System", };

        public static readonly string[] SquadFashionFateStrings =
                    { "Fallen Angel Wings", };

        public static readonly string[] SquadFashionSaucerStrings =
                    { "Gold Paper Parasol", "Angel Wings", "False Spectacles", };

        public static readonly string[] SquadFashionHuntStrings =
                    { "Diabolos Wings", };

        public static readonly string[] SquadFashionSanctuaryStrings =
                    { "Bluepowder Pixie Wings", "Felicitous Furball Umbrella", };

        public static readonly string[] SquadFashionMogStrings =
                    { "Red Moon Parasol", };

        public static readonly string[] SquadFashionShopStrings =
                    { "Vermilion Paper Parasol", "Prim Dot Parasol", };

        public static readonly string[] SquadFashionRestoStrings =
                    { "Parasol", "Sky Blue Parasol", "Calming Checkered Parasol", "Cheerful Checkered Parasol", "Pastoral Dot Parasol", };

        public static readonly string[] SquadFashionTreasureStrings =
                    { "Pixie Wings", "Archangel Wings", "White Lace Parasol", };

        public static readonly string[] SquadFashionVandCStrings =
                    { "Sabotender Parasol", };

        public static readonly string[] SquadFashionVoyageStrings =
                    { "Plum Paper Parasol", "Blue Blossom Parasol", "False Classic Spectacles", };


    }
}
