using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthdayAndDeity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "BirthDay",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "BirthMonth",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "GuardianDeity",
                table: "Charas",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "BirthMonth",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "GuardianDeity",
                table: "Charas");
        }
    }
}
