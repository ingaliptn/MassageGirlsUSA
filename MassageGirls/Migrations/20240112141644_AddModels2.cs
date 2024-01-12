using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GirlProfiles_MassageTypes_MassageTypeID",
                table: "GirlProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GirlProfiles",
                table: "GirlProfiles");

            migrationBuilder.RenameTable(
                name: "MassageTypes",
                newName: "MassageType");

            migrationBuilder.RenameTable(
                name: "GirlProfiles",
                newName: "GirlProfile");

            migrationBuilder.RenameIndex(
                name: "IX_GirlProfiles_MassageTypeID",
                table: "GirlProfile",
                newName: "IX_GirlProfile_MassageTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MassageType",
                table: "MassageType",
                column: "MassageTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GirlProfile",
                table: "GirlProfile",
                column: "GirlId");

            migrationBuilder.AddForeignKey(
                name: "FK_GirlProfile_MassageType_MassageTypeID",
                table: "GirlProfile",
                column: "MassageTypeID",
                principalTable: "MassageType",
                principalColumn: "MassageTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GirlProfile_MassageType_MassageTypeID",
                table: "GirlProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MassageType",
                table: "MassageType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GirlProfile",
                table: "GirlProfile");

            migrationBuilder.RenameTable(
                name: "MassageType",
                newName: "MassageTypes");

            migrationBuilder.RenameTable(
                name: "GirlProfile",
                newName: "GirlProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_GirlProfile_MassageTypeID",
                table: "GirlProfiles",
                newName: "IX_GirlProfiles_MassageTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes",
                column: "MassageTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GirlProfiles",
                table: "GirlProfiles",
                column: "GirlId");

            migrationBuilder.AddForeignKey(
                name: "FK_GirlProfiles_MassageTypes_MassageTypeID",
                table: "GirlProfiles",
                column: "MassageTypeID",
                principalTable: "MassageTypes",
                principalColumn: "MassageTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
