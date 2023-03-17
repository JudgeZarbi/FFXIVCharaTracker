
#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventorySlots_Charas_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropForeignKey(
                name: "FK_InventorySlots_Retainers_RetainerID",
                table: "InventorySlots");

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySlots_Charas_CharaID",
                table: "InventorySlots",
                column: "CharaID",
                principalTable: "Charas",
                principalColumn: "CharaID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySlots_Retainers_RetainerID",
                table: "InventorySlots",
                column: "RetainerID",
                principalTable: "Retainers",
                principalColumn: "RetainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventorySlots_Charas_CharaID",
                table: "InventorySlots");

            migrationBuilder.DropForeignKey(
                name: "FK_InventorySlots_Retainers_RetainerID",
                table: "InventorySlots");

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySlots_Charas_CharaID",
                table: "InventorySlots",
                column: "CharaID",
                principalTable: "Charas",
                principalColumn: "CharaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySlots_Retainers_RetainerID",
                table: "InventorySlots",
                column: "RetainerID",
                principalTable: "Retainers",
                principalColumn: "RetainerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
