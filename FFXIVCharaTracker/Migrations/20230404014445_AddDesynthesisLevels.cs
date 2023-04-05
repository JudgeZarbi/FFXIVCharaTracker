using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddDesynthesisLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelAlc",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelArm",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelBsm",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelCrp",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelCul",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelGsm",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelLtw",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DesynthesisLevelWvr",
                table: "Charas",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesynthesisLevelAlc",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelArm",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelBsm",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelCrp",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelCul",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelGsm",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelLtw",
                table: "Charas");

            migrationBuilder.DropColumn(
                name: "DesynthesisLevelWvr",
                table: "Charas");
        }
    }
}
