using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndCharacterSheetAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class character_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eyes",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hair",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Notes",
                table: "Characters",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Skin",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Characters",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Eyes",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skin",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Characters");
        }
    }
}
