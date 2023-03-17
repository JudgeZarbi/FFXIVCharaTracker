
#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddCascade2 : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Dps1",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Dps2",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Healer",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Tank",
                table: "Teams");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Dps1",
                table: "Teams",
                column: "Dps1",
                principalTable: "Charas",
                principalColumn: "CharaID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Dps2",
                table: "Teams",
                column: "Dps2",
                principalTable: "Charas",
                principalColumn: "CharaID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Healer",
                table: "Teams",
                column: "Healer",
                principalTable: "Charas",
                principalColumn: "CharaID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Tank",
                table: "Teams",
                column: "Tank",
                principalTable: "Charas",
                principalColumn: "CharaID",
                onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Dps1",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Dps2",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Healer",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Charas_Tank",
                table: "Teams");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Dps1",
                table: "Teams",
                column: "Dps1",
                principalTable: "Charas",
                principalColumn: "CharaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Dps2",
                table: "Teams",
                column: "Dps2",
                principalTable: "Charas",
                principalColumn: "CharaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Healer",
                table: "Teams",
                column: "Healer",
                principalTable: "Charas",
                principalColumn: "CharaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Charas_Tank",
                table: "Teams",
                column: "Tank",
                principalTable: "Charas",
                principalColumn: "CharaID");
        }
    }
}
