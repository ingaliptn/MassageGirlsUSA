using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToTownTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AsianFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AsianHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CouplesFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CouplesHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EroticFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EroticHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HappyEndingFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HappyEndingHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NuruFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NuruHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SensualFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SensualHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TantraFooter",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TantraHeader",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsianFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "AsianHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "BodyFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "BodyHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "CouplesFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "CouplesHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "EroticFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "EroticHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "HappyEndingFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "HappyEndingHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "NuruFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "NuruHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "SensualFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "SensualHeader",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TantraFooter",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "TantraHeader",
                table: "Town");
        }
    }
}
