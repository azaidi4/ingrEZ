using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ingrEZ.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealPlanRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanRecipe_MealPlan_MealPlanId",
                table: "MealPlanRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "MealPlanId",
                table: "MealPlanRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanRecipe_MealPlan_MealPlanId",
                table: "MealPlanRecipe",
                column: "MealPlanId",
                principalTable: "MealPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanRecipe_MealPlan_MealPlanId",
                table: "MealPlanRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "MealPlanId",
                table: "MealPlanRecipe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanRecipe_MealPlan_MealPlanId",
                table: "MealPlanRecipe",
                column: "MealPlanId",
                principalTable: "MealPlan",
                principalColumn: "Id");
        }
    }
}
