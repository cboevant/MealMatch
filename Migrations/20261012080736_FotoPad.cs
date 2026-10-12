using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealMatch.Migrations
{
    /// <inheritdoc />
    public partial class FotoPad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPad",
                table: "Recepten",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPad",
                table: "Recepten");
        }
    }
}
