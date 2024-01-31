using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberToCitiesTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNuberInt",
                table: "Town");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberCall",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberCall",
                table: "Town");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNuberInt",
                table: "Town",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
