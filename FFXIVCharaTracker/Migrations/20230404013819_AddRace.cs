using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Race",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Race",
                table: "Charas");
        }
    }
}
