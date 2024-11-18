using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ingrEZ.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreperationTime",
                table: "Recipe",
                newName: "PreparationTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreparationTime",
                table: "Recipe",
                newName: "PreperationTime");
        }
    }
}
