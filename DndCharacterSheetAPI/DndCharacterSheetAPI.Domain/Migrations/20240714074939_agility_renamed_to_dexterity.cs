using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndCharacterSheetAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class agility_renamed_to_dexterity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Agility",
                table: "Characters",
                newName: "Dexterity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dexterity",
                table: "Characters",
                newName: "Agility");
        }
    }
}
