using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotAddQuantityIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_RetainerID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_RetainerID",
                table: "InventorySlots");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_CharaID_Quantity",
                table: "InventorySlots",
                columns: new[] { "ItemCategory", "ItemID", "CharaID", "Quantity" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_RetainerID_Quantity",
                table: "InventorySlots",
                columns: new[] { "ItemCategory", "ItemID", "RetainerID", "Quantity" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_CharaID_Quantity",
                table: "InventorySlots",
                columns: new[] { "ItemID", "CharaID", "Quantity" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_RetainerID_Quantity",
                table: "InventorySlots",
                columns: new[] { "ItemID", "RetainerID", "Quantity" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_CharaID_Quantity",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_RetainerID_Quantity",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_CharaID_Quantity",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_RetainerID_Quantity",
                table: "InventorySlots");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_CharaID",
                table: "InventorySlots",
                columns: new[] { "ItemCategory", "ItemID", "CharaID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemCategory_ItemID_RetainerID",
                table: "InventorySlots",
                columns: new[] { "ItemCategory", "ItemID", "RetainerID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_CharaID",
                table: "InventorySlots",
                columns: new[] { "ItemID", "CharaID" });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_ItemID_RetainerID",
                table: "InventorySlots",
                columns: new[] { "ItemID", "RetainerID" });
        }
    }
}
