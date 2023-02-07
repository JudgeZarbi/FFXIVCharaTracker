using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "ItemCategory",
                table: "InventorySlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "SortCategory",
                table: "InventorySlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_SortCategory_ItemCategory_ItemID_CharaID",
                table: "InventorySlots",
                columns: new[] { "SortCategory", "ItemCategory", "ItemID", "CharaID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_SortCategory_ItemCategory_ItemID_RetainerID",
                table: "InventorySlots",
                columns: new[] { "SortCategory", "ItemCategory", "ItemID", "RetainerID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_SortCategory_ItemID_CharaID",
                table: "InventorySlots",
                columns: new[] { "SortCategory", "ItemID", "CharaID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_SortCategory_ItemID_RetainerID",
                table: "InventorySlots",
                columns: new[] { "SortCategory", "ItemID", "RetainerID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_SortCategory_ItemCategory_ItemID_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_SortCategory_ItemCategory_ItemID_RetainerID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_SortCategory_ItemID_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_SortCategory_ItemID_RetainerID",
                table: "InventorySlots");

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "InventorySlots");

            migrationBuilder.DropColumn(
                name: "SortCategory",
                table: "InventorySlots");
        }
    }
}
