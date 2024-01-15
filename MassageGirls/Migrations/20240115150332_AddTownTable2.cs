using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageGirls.Migrations
{
    /// <inheritdoc />
    public partial class AddTownTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MassageType",
                columns: table => new
                {
                    MassageTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassageType", x => x.MassageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownID);
                });

            migrationBuilder.CreateTable(
                name: "GirlProfile",
                columns: table => new
                {
                    GirlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GirlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownID = table.Column<int>(type: "int", nullable: false),
                    MassageTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirlProfile", x => x.GirlId);
                    table.ForeignKey(
                        name: "FK_GirlProfile_MassageType_MassageTypeID",
                        column: x => x.MassageTypeID,
                        principalTable: "MassageType",
                        principalColumn: "MassageTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GirlProfile_Town_TownID",
                        column: x => x.TownID,
                        principalTable: "Town",
                        principalColumn: "TownID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GirlProfile_MassageTypeID",
                table: "GirlProfile",
                column: "MassageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GirlProfile_TownID",
                table: "GirlProfile",
                column: "TownID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirlProfile");

            migrationBuilder.DropTable(
                name: "MassageType");

            migrationBuilder.DropTable(
                name: "Town");
        }
    }
}
