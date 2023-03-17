#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeLists",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SubcategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    ListData = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLists", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLists_SubcategoryName_Name_ListData",
                table: "RecipeLists",
                columns: new[] { "SubcategoryName", "Name", "ListData" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeLists");
        }
    }
}
