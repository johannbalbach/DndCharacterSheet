using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndCharacterSheetAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class classlevelbonus_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HitPointsBonus",
                table: "ClassLevelBonuses",
                newName: "ProficiencyBonusValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProficiencyBonusValue",
                table: "ClassLevelBonuses",
                newName: "HitPointsBonus");
        }
    }
}
