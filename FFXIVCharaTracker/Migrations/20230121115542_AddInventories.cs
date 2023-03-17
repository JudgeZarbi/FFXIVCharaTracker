
#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddInventories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearRetainer1",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "GearRetainer2",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "LevelRetainer1",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "LevelRetainer2",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "RetainerClass",
                table: "Charas");

            migrationBuilder.CreateTable(
                name: "Retainers",
                columns: table => new
                {
                    RetainerID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassID = table.Column<uint>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Gear = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerCharaID = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retainers", x => x.RetainerID);
                    table.ForeignKey(
                        name: "FK_Retainers_Charas_OwnerCharaID",
                        column: x => x.OwnerCharaID,
                        principalTable: "Charas",
                        principalColumn: "CharaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventorySlots",
                columns: table => new
                {
                    InventorySlotID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<uint>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false),
                    Inventory = table.Column<uint>(type: "INTEGER", nullable: false),
                    Slot = table.Column<int>(type: "INTEGER", nullable: false),
                    RetainerID = table.Column<ulong>(type: "INTEGER", nullable: true),
                    CharaID = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySlots", x => x.InventorySlotID);
                    table.ForeignKey(
                        name: "FK_InventorySlots_Charas_CharaID",
                        column: x => x.CharaID,
                        principalTable: "Charas",
                        principalColumn: "CharaID");
                    table.ForeignKey(
                        name: "FK_InventorySlots_Retainers_RetainerID",
                        column: x => x.RetainerID,
                        principalTable: "Retainers",
                        principalColumn: "RetainerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_CharaID_Inventory_Slot",
                table: "InventorySlots",
                columns: new[] { "CharaID", "Inventory", "Slot" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_CharaID",
                table: "InventorySlots",
                columns: new[] { "ItemID", "CharaID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_RetainerID",
                table: "InventorySlots",
                columns: new[] { "ItemID", "RetainerID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_RetainerID_Inventory_Slot",
                table: "InventorySlots",
                columns: new[] { "RetainerID", "Inventory", "Slot" });

            migrationBuilder.CreateIndex(
                name: "IX_Retainers_OwnerCharaID",
                table: "Retainers",
                column: "OwnerCharaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventorySlots");

            migrationBuilder.DropTable(
                name: "Retainers");

            migrationBuilder.AddColumn<bool>(
                name: "GearRetainer1",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GearRetainer2",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LevelRetainer1",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelRetainer2",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<uint>(
                name: "RetainerClass",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);
        }
    }
}
