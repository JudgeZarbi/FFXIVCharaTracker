#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotRemoveIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropIndex(
                name: "IX_InventorySlots_ItemID_RetainerID",
                table: "InventorySlots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
