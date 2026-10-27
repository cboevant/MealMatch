using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealMatch.Migrations
{
    /// <inheritdoc />
    public partial class Planning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planningen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planningen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planningen_Recepten_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planningen_ReceptId",
                table: "Planningen",
                column: "ReceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planningen");
        }
    }
}
