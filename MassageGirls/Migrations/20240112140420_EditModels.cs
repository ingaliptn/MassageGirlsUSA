using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class EditModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MassageTypes",
                columns: table => new
                {
                    MassageTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassageTypes", x => x.MassageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GirlProfiles",
                columns: table => new
                {
                    GirlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GirlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassageTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirlProfiles", x => x.GirlId);
                    table.ForeignKey(
                        name: "FK_GirlProfiles_MassageTypes_MassageTypeID",
                        column: x => x.MassageTypeID,
                        principalTable: "MassageTypes",
                        principalColumn: "MassageTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GirlProfiles_MassageTypeID",
                table: "GirlProfiles",
                column: "MassageTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirlProfiles");

            migrationBuilder.DropTable(
                name: "MassageTypes");
        }
    }
}
