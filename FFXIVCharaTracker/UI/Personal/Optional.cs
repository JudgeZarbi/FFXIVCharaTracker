using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawOptionalContentSection(Chara charaData)
        {
            if (ImGui.TreeNode("Optional Content"))
            {
                if (ImGui.TreeNode("General"))
                {
                    if (ImGui.BeginTable("optionalGeneral", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Mist", charaData.IsQuestComplete(66750));
                        DrawTableRowText("Lavender Beds", charaData.IsQuestComplete(66748));
                        DrawTableRowText("The Goblet", charaData.IsQuestComplete(66749));
                        DrawTableRowText("Shirogane", charaData.IsQuestComplete(68167));
                        DrawTableRowText("Empyreum", charaData.IsQuestComplete(69708));
                        DrawTableRowText("Dyeing", charaData.IsQuestComplete(66235));
                        DrawTableRowText("Glamours", charaData.IsQuestComplete(68553));
                        DrawTableRowText("Gold Saucer", charaData.IsQuestComplete(65970));
                        DrawTableRowText("Challenge Log", charaData.IsQuestComplete(66967));
                        DrawTableRowText("Aesthetician", charaData.IsQuestComplete(66746));
                        DrawTableRowText("Crystalline Conflict", charaData.IsQuestComplete(66640) || charaData.IsQuestComplete(66640) || charaData.IsQuestComplete(66640));
                        DrawTableRowText("Frontlines", charaData.IsQuestComplete(67063) || charaData.IsQuestComplete(67064) || charaData.IsQuestComplete(67065));
                        DrawTableRowText("Rival Wings", charaData.IsQuestComplete(68583));
                        DrawTableRowText("Wondrous Tails", charaData.IsQuestComplete(67928));
                        DrawTableRowText("Faux Hollows", charaData.IsQuestComplete(69501));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("A Realm Reborn"))
                {
                    if (ImGui.TreeNode("Dungeons"))
                    {
                        if (ImGui.BeginTable("DungeonsArr", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Halatali", charaData.IsInstanceUnlocked(7));
                            DrawTableRowText("The Sunken Temple of Qarn", charaData.IsInstanceUnlocked(9));
                            DrawTableRowText("Cutter's Cry", charaData.IsInstanceUnlocked(12));
                            DrawTableRowText("Dzemael Darkhold", charaData.IsInstanceUnlocked(13));
                            DrawTableRowText("The Aurum Vale", charaData.IsInstanceUnlocked(5));
                            DrawTableRowText("Amdapor Keep", charaData.IsInstanceUnlocked(14));
                            DrawTableRowText("The Wanderer's Palace", charaData.IsInstanceUnlocked(7));
                            DrawTableRowText("Copperbell Mines (Hard)", charaData.IsInstanceUnlocked(18));
                            DrawTableRowText("Haukke Manor (Hard)", charaData.IsInstanceUnlocked(19));
                            DrawTableRowText("Pharos Sirius", charaData.IsInstanceUnlocked(17));
                            DrawTableRowText("Brayflox's Longstop (Hard)", charaData.IsInstanceUnlocked(20));
                            DrawTableRowText("Halatali (Hard)", charaData.IsInstanceUnlocked(21));
                            DrawTableRowText("The Lost City of Amdapor (Hard)", charaData.IsInstanceUnlocked(22));
                            DrawTableRowText("Hullbreaker Isle", charaData.IsInstanceUnlocked(23));
                            DrawTableRowText("The Stone Vigil (Hard)", charaData.IsInstanceUnlocked(25));
                            DrawTableRowText("The Tam-Tara Deepcroft (Hard)", charaData.IsInstanceUnlocked(24));
                            DrawTableRowText("Sastasha (Hard)", charaData.IsInstanceUnlocked(28));
                            DrawTableRowText("The Sunken Temple of Qarn (Hard)", charaData.IsInstanceUnlocked(26));
                            DrawTableRowText("Amdapor Keep (Hard)", charaData.IsInstanceUnlocked(29));
                            DrawTableRowText("The Wanderer's Palace (Hard)", charaData.IsInstanceUnlocked(30));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Trials"))
                    {
                        if (ImGui.BeginTable("TrialsArr", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Battle on the Big Bridge", charaData.IsInstanceUnlocked(20021));
                            DrawTableRowText("A Relic Reborn: The Chimera", charaData.IsInstanceUnlocked(20019));
                            DrawTableRowText("A Relic Reborn: The Hydra", charaData.IsInstanceUnlocked(20020));
                            DrawTableRowText("The Minstrel's Ballad: Ultima's Bane", charaData.IsInstanceUnlocked(20013));
                            DrawTableRowText("The Howling Eye (Extreme)", charaData.IsInstanceUnlocked(20010));
                            DrawTableRowText("The Navel (Extreme)", charaData.IsInstanceUnlocked(20009));
                            DrawTableRowText("The Bowl of Embers (Extreme)", charaData.IsInstanceUnlocked(20008));
                            DrawTableRowText("The Dragon's Neck", charaData.IsInstanceUnlocked(20026));
                            DrawTableRowText("The Whorleater (Extreme)", charaData.IsInstanceUnlocked(20018));
                            DrawTableRowText("Thornmarch (Extreme)", charaData.IsInstanceUnlocked(20012));
                            DrawTableRowText("The Striking Tree (Extreme)", charaData.IsInstanceUnlocked(20023));
                            DrawTableRowText("Battle in the Big Keep", charaData.IsInstanceUnlocked(20030));
                            DrawTableRowText("Akh Afah Amphitheatre (Extreme)", charaData.IsInstanceUnlocked(20025));
                            DrawTableRowText("Urth's Fount", charaData.IsInstanceUnlocked(20027));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Raids"))
                    {
                        if (ImGui.BeginTable("RaidsArr", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Binding Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30002));
                            DrawTableRowText("The Binding Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30003));
                            DrawTableRowText("The Binding Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30004));
                            DrawTableRowText("The Binding Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30005));
                            DrawTableRowText("The Binding Coil of Bahamut - Turn 5", charaData.IsInstanceUnlocked(30006));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30007));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30008));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30009));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30010));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 1 (Savage)", charaData.IsInstanceUnlocked(30012));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 2 (Savage)", charaData.IsInstanceUnlocked(30013));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 3 (Savage)", charaData.IsInstanceUnlocked(30014));
                            DrawTableRowText("The Second Coil of Bahamut - Turn 4 (Savage)", charaData.IsInstanceUnlocked(30015));
                            DrawTableRowText("The Final Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30016));
                            DrawTableRowText("The Final Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30017));
                            DrawTableRowText("The Final Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30018));
                            DrawTableRowText("The Final Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30019));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Heavensward"))
                {
                    if (ImGui.TreeNode("Dungeons"))
                    {
                        if (ImGui.BeginTable("DungeonsHw", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Dusk Vigil", charaData.IsInstanceUnlocked(36));
                            DrawTableRowText("Neverreap", charaData.IsInstanceUnlocked(33));
                            DrawTableRowText("The Fractal Continuum", charaData.IsInstanceUnlocked(35));
                            DrawTableRowText("Saint Mocianne's Arboretum", charaData.IsInstanceUnlocked(41));
                            DrawTableRowText("Pharos Sirius (Hard)", charaData.IsInstanceUnlocked(40));
                            DrawTableRowText("The Lost City of Amdapor (Hard)", charaData.IsInstanceUnlocked(42));
                            DrawTableRowText("Hullbreaker Isle (Hard)", charaData.IsInstanceUnlocked(45));
                            DrawTableRowText("The Great Gubal Library (Hard)", charaData.IsInstanceUnlocked(47));
                            DrawTableRowText("Sohm Al (Hard)", charaData.IsInstanceUnlocked(49));
                            DrawTableRowText("The Palace of the Dead", charaData.IsQuestComplete(67092));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Trials"))
                    {
                        if (ImGui.BeginTable("TrialsHw", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Limitless Blue (Extreme)", charaData.IsInstanceUnlocked(20034));
                            DrawTableRowText("Thok ast Thok (Extreme)", charaData.IsInstanceUnlocked(20032));
                            DrawTableRowText("Containment Bay S1T7", charaData.IsInstanceUnlocked(20037));
                            DrawTableRowText("The Minstrel's Ballad: Thordan's Reign", charaData.IsInstanceUnlocked(20036));
                            DrawTableRowText("Containment Bay S1T7 (Extreme)", charaData.IsInstanceUnlocked(20038));
                            DrawTableRowText("Containment Bay P1T6", charaData.IsInstanceUnlocked(20041));
                            DrawTableRowText("The Minstrel's Ballad: Nidhogg's Rage", charaData.IsInstanceUnlocked(20040));
                            DrawTableRowText("Containment Bay P1T6 (Extreme)", charaData.IsInstanceUnlocked(20042));
                            DrawTableRowText("Containment Bay Z1T9", charaData.IsInstanceUnlocked(20043));
                            DrawTableRowText("Containment Bay Z1T9 (Extreme)", charaData.IsInstanceUnlocked(20044));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Raids"))
                    {
                        if (ImGui.TreeNode("Normal Raids"))
                        {
                            if (ImGui.BeginTable("NormalRaidsHw", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("Alexander - The Fist of the Father", charaData.IsInstanceUnlocked(30021));
                                DrawTableRowText("Alexander - The Cuff of the Father", charaData.IsInstanceUnlocked(30022));
                                DrawTableRowText("Alexander - The Arm of the Father", charaData.IsInstanceUnlocked(30023));
                                DrawTableRowText("Alexander - The Burden of the Father", charaData.IsInstanceUnlocked(30024));
                                DrawTableRowText("Alexander - The Fist of the Father (Savage)", charaData.IsInstanceUnlocked(30025));
                                DrawTableRowText("Alexander - The Cuff of the Father (Savage)", charaData.IsInstanceUnlocked(30026));
                                DrawTableRowText("Alexander - The Arm of the Father (Savage)", charaData.IsInstanceUnlocked(30027));
                                DrawTableRowText("Alexander - The Burden of the Father (Savage)", charaData.IsInstanceUnlocked(30028));
                                DrawTableRowText("Alexander - The Fist of the Son", charaData.IsInstanceUnlocked(30030));
                                DrawTableRowText("Alexander - The Cuff of the Son", charaData.IsInstanceUnlocked(30031));
                                DrawTableRowText("Alexander - The Arm of the Son", charaData.IsInstanceUnlocked(30032));
                                DrawTableRowText("Alexander - The Burden of the Son (Savage)", charaData.IsInstanceUnlocked(30033));
                                DrawTableRowText("Alexander - The Fist of the Son (Savage)", charaData.IsInstanceUnlocked(30034));
                                DrawTableRowText("Alexander - The Cuff of the Son (Savage)", charaData.IsInstanceUnlocked(30035));
                                DrawTableRowText("Alexander - The Arm of the Son (Savage)", charaData.IsInstanceUnlocked(30036));
                                DrawTableRowText("Alexander - The Burden of the Son (Savage)", charaData.IsInstanceUnlocked(30037));
                                DrawTableRowText("Alexander - The Eyes of the Creator", charaData.IsInstanceUnlocked(30039));
                                DrawTableRowText("Alexander - The Breath of the Creator", charaData.IsInstanceUnlocked(30040));
                                DrawTableRowText("Alexander - The Heart of the Creator", charaData.IsInstanceUnlocked(30041));
                                DrawTableRowText("Alexander - The Soul of the Creator", charaData.IsInstanceUnlocked(30042));
                                DrawTableRowText("Alexander - The Eyes of the Creator (Savage)", charaData.IsInstanceUnlocked(30043));
                                DrawTableRowText("Alexander - The Breath of the Creator (Savage)", charaData.IsInstanceUnlocked(30044));
                                DrawTableRowText("Alexander - The Heart of the Creator (Savage)", charaData.IsInstanceUnlocked(30045));
                                DrawTableRowText("Alexander - The Soul of the Creator (Savage)", charaData.IsInstanceUnlocked(30046));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Alliance Raids"))
                        {
                            if (ImGui.BeginTable("AllianceRaidsHw", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("The Void Ark", charaData.IsInstanceUnlocked(30029));
                                DrawTableRowText("The Weeping City of Mhach", charaData.IsInstanceUnlocked(30038));
                                DrawTableRowText("Dun Scaith", charaData.IsInstanceUnlocked(30047));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Stormblood"))
                {
                    if (ImGui.TreeNode("Dungeons"))
                    {
                        if (ImGui.BeginTable("DungeonsSb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Shisui of the Violet Tides", charaData.IsInstanceUnlocked(50));
                            DrawTableRowText("Kugane Castle", charaData.IsInstanceUnlocked(57));
                            DrawTableRowText("The Temple of the Fist", charaData.IsInstanceUnlocked(51));
                            DrawTableRowText("Hell's Lid", charaData.IsInstanceUnlocked(59));
                            DrawTableRowText("The Fractal Continuum (Hard)", charaData.IsInstanceUnlocked(60));
                            DrawTableRowText("The Swallow's Compass", charaData.IsInstanceUnlocked(61));
                            DrawTableRowText("Saint Mocianne's Arboretum (Hard)", charaData.IsInstanceUnlocked(62));
                            DrawTableRowText("Heaven-on-High", charaData.IsQuestComplete(68667));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Trials"))
                    {
                        if (ImGui.BeginTable("TrialsSb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Emanation (Extreme)", charaData.IsInstanceUnlocked(20049));
                            DrawTableRowText("The Pool of Tribute (Extreme)", charaData.IsInstanceUnlocked(20047));
                            DrawTableRowText("The Great Hunt", charaData.IsInstanceUnlocked(20053));
                            DrawTableRowText("The Minstrel's Ballad: Shinryu's Domain", charaData.IsInstanceUnlocked(20050));
                            DrawTableRowText("The Jade Stoa", charaData.IsInstanceUnlocked(20051));
                            DrawTableRowText("The Jade Stoa (Extreme)", charaData.IsInstanceUnlocked(20052));
                            DrawTableRowText("The Great Hunt (Extreme)", charaData.IsInstanceUnlocked(20054));
                            DrawTableRowText("The Minstrel's Ballad: Tsukuyomi's Pain", charaData.IsInstanceUnlocked(20056));
                            DrawTableRowText("Hells' Kier", charaData.IsInstanceUnlocked(20057));
                            DrawTableRowText("Kugane Ohashi", charaData.IsInstanceUnlocked(20059));
                            DrawTableRowText("The Wreath of Snakes", charaData.IsInstanceUnlocked(20060));
                            DrawTableRowText("Hells' Kier (Extreme)", charaData.IsInstanceUnlocked(20058));
                            DrawTableRowText("The Wreath of Snakes (Extreme)", charaData.IsInstanceUnlocked(20061));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Raids"))
                    {
                        if (ImGui.TreeNode("Normal Raids"))
                        {
                            if (ImGui.BeginTable("NormalRaidsSb", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("Deltascape V1.0", charaData.IsInstanceUnlocked(30049));
                                DrawTableRowText("Deltascape V2.0", charaData.IsInstanceUnlocked(30050));
                                DrawTableRowText("Deltascape V3.0", charaData.IsInstanceUnlocked(30051));
                                DrawTableRowText("Deltascape V4.0", charaData.IsInstanceUnlocked(30052));
                                DrawTableRowText("Deltascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30053));
                                DrawTableRowText("Deltascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30054));
                                DrawTableRowText("Deltascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30055));
                                DrawTableRowText("Deltascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30056));
                                DrawTableRowText("Sigmascape V1.0", charaData.IsInstanceUnlocked(30059));
                                DrawTableRowText("Sigmascape V2.0", charaData.IsInstanceUnlocked(30060));
                                DrawTableRowText("Sigmascape V3.0", charaData.IsInstanceUnlocked(30061));
                                DrawTableRowText("Sigmascape V4.0", charaData.IsInstanceUnlocked(30062));
                                DrawTableRowText("Sigmascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30063));
                                DrawTableRowText("Sigmascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30064));
                                DrawTableRowText("Sigmascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30065));
                                DrawTableRowText("Sigmascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30066));
                                DrawTableRowText("Alphascape V1.0", charaData.IsInstanceUnlocked(30069));
                                DrawTableRowText("Alphascape V2.0", charaData.IsInstanceUnlocked(30070));
                                DrawTableRowText("Alphascape V3.0", charaData.IsInstanceUnlocked(30071));
                                DrawTableRowText("Alphascape V4.0", charaData.IsInstanceUnlocked(30072));
                                DrawTableRowText("Alphascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30073));
                                DrawTableRowText("Alphascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30074));
                                DrawTableRowText("Alphascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30075));
                                DrawTableRowText("Alphascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30076));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Alliance Raids"))
                        {
                            if (ImGui.BeginTable("AllianceRaidsSb", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("The Royal City of Rabanastre", charaData.IsInstanceUnlocked(30058));
                                DrawTableRowText("The Ridorana Lighthouse", charaData.IsInstanceUnlocked(30068));
                                DrawTableRowText("The Orbonne Monastery", charaData.IsInstanceUnlocked(30077));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Eureka"))
                    {
                        if (ImGui.BeginTable("EurekaSb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Forbidden Land, Eureka Anemos", charaData.IsQuestComplete(68614));
                            DrawTableRowText("The Forbidden Land, Eureka Pagos", charaData.IsQuestComplete(68478));
                            DrawTableRowText("The Forbidden Land, Eureka Pyros", charaData.IsQuestComplete(68148));
                            DrawTableRowText("The Forbidden Land, Eureka Hydatos", charaData.IsQuestComplete(68149));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shadowbringers"))
                {
                    if (ImGui.TreeNode("Dungeons"))
                    {
                        if (ImGui.BeginTable("DungeonsShb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Akadaemia Anyder", charaData.IsInstanceUnlocked(71));
                            DrawTableRowText("The Twinning", charaData.IsInstanceUnlocked(20013));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Trials"))
                    {
                        if (ImGui.BeginTable("TrialsShb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Crown of the Immaculate (Extreme)", charaData.IsInstanceUnlocked(20065));
                            DrawTableRowText("The Minstrel's Ballad: Hades' Elegy", charaData.IsInstanceUnlocked(20067));
                            DrawTableRowText("Cinder Drift", charaData.IsInstanceUnlocked(20068));
                            DrawTableRowText("Cinder Drift (Extreme)", charaData.IsInstanceUnlocked(20069));
                            DrawTableRowText("Memoria Misera (Extreme)", charaData.IsInstanceUnlocked(20070));
                            DrawTableRowText("The Seat of Sacrifice (Extreme)", charaData.IsInstanceUnlocked(20072));
                            DrawTableRowText("Castrum Marinum", charaData.IsInstanceUnlocked(20073));
                            DrawTableRowText("The Cloud Deck", charaData.IsInstanceUnlocked(20075));
                            DrawTableRowText("Castrum Marinum (Extreme)", charaData.IsInstanceUnlocked(20074));
                            DrawTableRowText("The Cloud Deck (Extreme)", charaData.IsInstanceUnlocked(20076));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Raids"))
                    {
                        if (ImGui.TreeNode("Normal Raids"))
                        {
                            if (ImGui.BeginTable("NormalRaidsShb", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("Eden's Gate: Resurrection", charaData.IsInstanceUnlocked(30078));
                                DrawTableRowText("Eden's Gate: Descent", charaData.IsInstanceUnlocked(30082));
                                DrawTableRowText("Eden's Gate: Inundation", charaData.IsInstanceUnlocked(30080));
                                DrawTableRowText("Eden's Gate: Sepulture", charaData.IsInstanceUnlocked(30084));
                                DrawTableRowText("Eden's Gate: Resurrection (Savage)", charaData.IsInstanceUnlocked(30079));
                                DrawTableRowText("Eden's Gate: Descent (Savage)", charaData.IsInstanceUnlocked(30083));
                                DrawTableRowText("Eden's Gate: Inundation (Savage)", charaData.IsInstanceUnlocked(30081));
                                DrawTableRowText("Eden's Gate: Sepulture (Savage)", charaData.IsInstanceUnlocked(30085));
                                DrawTableRowText("Eden's Verse: Fulmination", charaData.IsInstanceUnlocked(30088));
                                DrawTableRowText("Eden's Verse: Furor", charaData.IsInstanceUnlocked(30090));
                                DrawTableRowText("Eden's Verse: Iconoclasm", charaData.IsInstanceUnlocked(30092));
                                DrawTableRowText("Eden's Verse: Refulgence", charaData.IsInstanceUnlocked(30094));
                                DrawTableRowText("Eden's Verse: Fulmination (Savage)", charaData.IsInstanceUnlocked(30089));
                                DrawTableRowText("Eden's Verse: Furor (Savage)", charaData.IsInstanceUnlocked(30091));
                                DrawTableRowText("Eden's Verse: Iconoclasm (Savage)", charaData.IsInstanceUnlocked(30093));
                                DrawTableRowText("Eden's Verse: Refulgence (Savage)", charaData.IsInstanceUnlocked(30095));
                                DrawTableRowText("Eden's Promise: Umbra", charaData.IsInstanceUnlocked(30097));
                                DrawTableRowText("Eden's Promise: Litany", charaData.IsInstanceUnlocked(30099));
                                DrawTableRowText("Eden's Promise: Anamorphosis", charaData.IsInstanceUnlocked(30101));
                                DrawTableRowText("Eden's Promise: Eternity", charaData.IsInstanceUnlocked(30103));
                                DrawTableRowText("Eden's Promise: Umbra (Savage)", charaData.IsInstanceUnlocked(30098));
                                DrawTableRowText("Eden's Promise: Litany (Savage)", charaData.IsInstanceUnlocked(30100));
                                DrawTableRowText("Eden's Promise: Anamorphosis (Savage)", charaData.IsInstanceUnlocked(30102));
                                DrawTableRowText("Eden's Promise: Eternity (Savage)", charaData.IsInstanceUnlocked(30104));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Alliance Raids"))
                        {
                            if (ImGui.BeginTable("AllianceRaidsShb", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("The Copied Factory", charaData.IsInstanceUnlocked(30087));
                                DrawTableRowText("The Puppets' Bunker", charaData.IsInstanceUnlocked(30096));
                                DrawTableRowText("The Tower at Paradigm's Breach", charaData.IsInstanceUnlocked(30105));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Bozja"))
                    {
                        if (ImGui.BeginTable("BozjaShb", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Bozjan Southern Front", charaData.IsQuestComplete(69477));
                            DrawTableRowText("Castrum Lacus Litore", charaData.IsQuestComplete(69487) || QuestManager.GetQuestSequence(69487) > 0);
                            DrawTableRowText("Delubrum Reginae", charaData.IsQuestComplete(69562) || QuestManager.GetQuestSequence(69562) > 0);
                            DrawTableRowText("Zadnor", charaData.IsQuestComplete(69620));
                            DrawTableRowText("The Dalriada", charaData.IsQuestComplete(69624) || QuestManager.GetQuestSequence(69624) > 0);
                            DrawTableRowText("Bozja complete", charaData.IsQuestComplete(69624));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Endwalker"))
                {
                    if (ImGui.TreeNode("Dungeons"))
                    {
                        if (ImGui.BeginTable("DungeonsEw", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Smileton", charaData.IsInstanceUnlocked(20030));
                            DrawTableRowText("The Stigma Dreamscape", charaData.IsInstanceUnlocked(79));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Trials"))
                    {
                        if (ImGui.BeginTable("TrialsEw", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("The Minstrel's Ballad: Hydaelyn's Call", charaData.IsInstanceUnlocked(20078));
                            DrawTableRowText("The Minstrel's Ballad: Zodiark's Fall", charaData.IsInstanceUnlocked(20081));
                            DrawTableRowText("The Minstrel's Ballad: Endsinger's Aria", charaData.IsInstanceUnlocked(20083));
                            DrawTableRowText("Storm's Crown (Extreme)", charaData.IsInstanceUnlocked(20085));
                            DrawTableRowText("Mount Ordeals (Extreme)", charaData.IsInstanceUnlocked(20087));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Raids"))
                    {
                        if (ImGui.TreeNode("Normal Raids"))
                        {
                            if (ImGui.BeginTable("NormalRaidsEw", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("Asphodelos: The First Circle", charaData.IsInstanceUnlocked(30111));
                                DrawTableRowText("Asphodelos: The Second Circle", charaData.IsInstanceUnlocked(30113));
                                DrawTableRowText("Asphodelos: The Third Circle", charaData.IsInstanceUnlocked(30109));
                                DrawTableRowText("Asphodelos: The Fourth Circle", charaData.IsInstanceUnlocked(30107));
                                DrawTableRowText("Asphodelos: The First Circle (Savage)", charaData.IsInstanceUnlocked(30112));
                                DrawTableRowText("Asphodelos: The Second Circle (Savage)", charaData.IsInstanceUnlocked(30114));
                                DrawTableRowText("Asphodelos: The Third Circle (Savage)", charaData.IsInstanceUnlocked(30110));
                                DrawTableRowText("Asphodelos: The Fourth Circle (Savage)", charaData.IsInstanceUnlocked(30108));
                                DrawTableRowText("Abyssos: The Fifth Circle", charaData.IsInstanceUnlocked(30116));
                                DrawTableRowText("Abyssos: The Sixth Circle", charaData.IsInstanceUnlocked(30120));
                                DrawTableRowText("Abyssos: The Seventh Circle", charaData.IsInstanceUnlocked(30118));
                                DrawTableRowText("Abyssos: The Eighth Circle", charaData.IsInstanceUnlocked(30122));
                                DrawTableRowText("Abyssos: The Fifth Circle (Savage)", charaData.IsInstanceUnlocked(30117));
                                DrawTableRowText("Abyssos: The Sixth Circle (Savage)", charaData.IsInstanceUnlocked(30121));
                                DrawTableRowText("Abyssos: The Seventh Circle (Savage)", charaData.IsInstanceUnlocked(30119));
                                DrawTableRowText("Abyssos: The Eighth Circle (Savage)", charaData.IsInstanceUnlocked(30123));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Alliance Raids"))
                        {
                            if (ImGui.BeginTable("AllianceRaidsEw", 2))
                            {
                                SetUpTableColumns();

                                DrawTableRowText("Aglaia", charaData.IsInstanceUnlocked(30115));
                                DrawTableRowText("Euphrosyne", charaData.IsInstanceUnlocked(30125));

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }

}
