using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersStatistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificator for the entity."),
                    PlayerOneSets = table.Column<int>(type: "int", nullable: false, comment: "Sets won by player one."),
                    PlayerTwoSets = table.Column<int>(type: "int", nullable: false, comment: "Sets won by player two."),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Duration of the match."),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of when the match has been played."),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Location where the match has been played."),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the winner of the match."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Flag to delete the entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificator for the entity."),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the player."),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Age of the player."),
                    Wins = table.Column<int>(type: "int", nullable: false, comment: "The player's wins."),
                    Loses = table.Column<int>(type: "int", nullable: false, comment: "The player's loses."),
                    Winrate = table.Column<int>(type: "int", nullable: false, comment: "The player's total winrate."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Flag to delete the entity.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => new { x.MatchesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayersId",
                table: "MatchPlayer",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
