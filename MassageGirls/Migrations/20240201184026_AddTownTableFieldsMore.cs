using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddTownTableFieldsMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Town",
                newName: "TitleTantra");

            migrationBuilder.AddColumn<string>(
                name: "TitleAsian",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleBody",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleCouples",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleErotic",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleHappyEnding",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleNuru",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleSensual",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleAsian",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleBody",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleCouples",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleErotic",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleHappyEnding",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleNuru",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TitleSensual",
                table: "Town");

            migrationBuilder.RenameColumn(
                name: "TitleTantra",
                table: "Town",
                newName: "Title");
        }
    }
}
