#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class InventorySlotAddRetainerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UncollectedBotanistItems",
                table: "Charas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UncollectedFisherItems",
                table: "Charas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UncollectedMinerItems",
                table: "Charas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UncollectedSpearfisherItems",
                table: "Charas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UncollectedBotanistItems",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "UncollectedFisherItems",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "UncollectedMinerItems",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "UncollectedSpearfisherItems",
                table: "Charas");
        }
    }
}
