using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersStatistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPlayerColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number identificator.")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "Players");
        }
    }
}
