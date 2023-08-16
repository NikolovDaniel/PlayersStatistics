using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersStatistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnsToPlayersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Place of birth.");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Description of the player.");

            migrationBuilder.AddColumn<string>(
                name: "Hand",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "The hand with which the player plays.");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Height of the player.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Hand",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");
        }
    }
}
