using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealMatch.Migrations
{
    /// <inheritdoc />
    public partial class Koppeltabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredienten_Recepten_ReceptID",
                table: "Ingredienten");

            migrationBuilder.DropIndex(
                name: "IX_Ingredienten_ReceptID",
                table: "Ingredienten");

            migrationBuilder.CreateTable(
                name: "ReceptIngredienten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Hoeveelheid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptIngredienten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptIngredienten_Ingredienten_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredienten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceptIngredienten_Recepten_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceptIngredienten_IngredientId",
                table: "ReceptIngredienten",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptIngredienten_ReceptId",
                table: "ReceptIngredienten",
                column: "ReceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceptIngredienten");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_ReceptID",
                table: "Ingredienten",
                column: "ReceptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredienten_Recepten_ReceptID",
                table: "Ingredienten",
                column: "ReceptID",
                principalTable: "Recepten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
