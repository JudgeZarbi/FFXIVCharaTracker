#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charas",
                columns: table => new
                {
                    CharaID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorldID = table.Column<uint>(type: "INTEGER", nullable: false),
                    Account = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassID = table.Column<uint>(type: "INTEGER", nullable: false),
                    Forename = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    ClassLevel = table.Column<short>(type: "INTEGER", nullable: false),
                    LowGear = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurGear = table.Column<bool>(type: "INTEGER", nullable: false),
                    LevelCrp = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelBsm = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelArm = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelGsm = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelLtw = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelWvr = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelAlc = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelCul = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelMin = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelBtn = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelFsh = table.Column<int>(type: "INTEGER", nullable: false),
                    GatherGear = table.Column<bool>(type: "INTEGER", nullable: false),
                    IncompleteFolkloreBooks = table.Column<string>(type: "TEXT", nullable: false),
                    IncompleteSecretRecipeBooks = table.Column<string>(type: "TEXT", nullable: false),
                    UnobtainedHairstyles = table.Column<string>(type: "TEXT", nullable: false),
                    UnobtainedEmotes = table.Column<string>(type: "TEXT", nullable: false),
                    RetainersStoringDescription = table.Column<string>(type: "TEXT", nullable: false),
                    RetainerClass = table.Column<uint>(type: "INTEGER", nullable: false),
                    LevelRetainer1 = table.Column<int>(type: "INTEGER", nullable: false),
                    GearRetainer1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    LevelRetainer2 = table.Column<int>(type: "INTEGER", nullable: false),
                    GearRetainer2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    GCRank = table.Column<int>(type: "INTEGER", nullable: false),
                    LockedDuties = table.Column<string>(type: "TEXT", nullable: false),
                    LockedCustomDeliveries = table.Column<string>(type: "TEXT", nullable: false),
                    ChocoboLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    IncompleteQuests = table.Column<string>(type: "TEXT", nullable: false),
                    CustomDeliveryRanks = table.Column<string>(type: "TEXT", nullable: false),
                    UnobtainedMinions = table.Column<string>(type: "TEXT", nullable: false),
                    UnobtainedMounts = table.Column<string>(type: "TEXT", nullable: false),
                    PluginDataVersion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Charas", x => x.CharaID));

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tank = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Dps1 = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Dps2 = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Healer = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Charas_Dps1",
                        column: x => x.Dps1,
                        principalTable: "Charas",
                        principalColumn: "CharaID");
                    table.ForeignKey(
                        name: "FK_Teams_Charas_Dps2",
                        column: x => x.Dps2,
                        principalTable: "Charas",
                        principalColumn: "CharaID");
                    table.ForeignKey(
                        name: "FK_Teams_Charas_Healer",
                        column: x => x.Healer,
                        principalTable: "Charas",
                        principalColumn: "CharaID");
                    table.ForeignKey(
                        name: "FK_Teams_Charas_Tank",
                        column: x => x.Tank,
                        principalTable: "Charas",
                        principalColumn: "CharaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Dps1",
                table: "Teams",
                column: "Dps1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Dps2",
                table: "Teams",
                column: "Dps2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Healer",
                table: "Teams",
                column: "Healer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Tank",
                table: "Teams",
                column: "Tank",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Charas");
        }
    }
}
