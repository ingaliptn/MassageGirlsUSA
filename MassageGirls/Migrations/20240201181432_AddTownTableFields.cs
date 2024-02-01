using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddTownTableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TownUrl",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TownUrl",
                table: "Town");
        }
    }
}
