#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotAddIslandSanctuary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IslandSanctuaryLevel",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IslandSanctuaryLevel",
                table: "Charas");
        }
    }
}
