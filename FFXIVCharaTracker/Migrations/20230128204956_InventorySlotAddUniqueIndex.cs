#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotAddUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventorySlots_CharaID_RetainerID_Inventory_Slot",
                table: "InventorySlots",
                columns: new[] { "CharaID", "RetainerID", "Inventory", "Slot" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_CharaID_RetainerID_Inventory_Slot",
                table: "InventorySlots");
        }
    }
}
