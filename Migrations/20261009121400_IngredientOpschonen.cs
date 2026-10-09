using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealMatch.Migrations
{
    /// <inheritdoc />
    public partial class IngredientOpschonen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                table: "Ingredienten");

            migrationBuilder.DropColumn(
                name: "ReceptID",
                table: "Ingredienten");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hoeveelheid",
                table: "Ingredienten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReceptID",
                table: "Ingredienten",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
