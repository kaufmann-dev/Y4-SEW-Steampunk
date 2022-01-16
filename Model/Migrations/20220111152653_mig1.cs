using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AIRSHIPS",
                columns: table => new
                {
                    AIRSHIP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AIRSHIP_SPEED = table.Column<int>(type: "int", nullable: false),
                    HULL_POINTS = table.Column<int>(type: "int", nullable: false),
                    ARMOR_VALUE = table.Column<int>(type: "int", nullable: false),
                    DAMAGE_STATE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRSHIPS", x => x.AIRSHIP_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ENGINES_ST",
                columns: table => new
                {
                    ENGINE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ENGINE_LABEL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POWER_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENGINE_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENGINES_ST", x => x.ENGINE_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AIRSHIP_HAS_ENGINES_JT",
                columns: table => new
                {
                    ENGINE_ID = table.Column<int>(type: "int", nullable: false),
                    AIRSHIP_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRSHIP_HAS_ENGINES_JT", x => new { x.ENGINE_ID, x.AIRSHIP_ID });
                    table.ForeignKey(
                        name: "FK_AIRSHIP_HAS_ENGINES_JT_AIRSHIPS_AIRSHIP_ID",
                        column: x => x.AIRSHIP_ID,
                        principalTable: "AIRSHIPS",
                        principalColumn: "AIRSHIP_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIRSHIP_HAS_ENGINES_JT_ENGINES_ST_ENGINE_ID",
                        column: x => x.ENGINE_ID,
                        principalTable: "ENGINES_ST",
                        principalColumn: "ENGINE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AIRSHIP_HAS_ENGINES_JT_AIRSHIP_ID",
                table: "AIRSHIP_HAS_ENGINES_JT",
                column: "AIRSHIP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AIRSHIPS_NAME",
                table: "AIRSHIPS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENGINES_ST_ENGINE_LABEL",
                table: "ENGINES_ST",
                column: "ENGINE_LABEL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIRSHIP_HAS_ENGINES_JT");

            migrationBuilder.DropTable(
                name: "AIRSHIPS");

            migrationBuilder.DropTable(
                name: "ENGINES_ST");
        }
    }
}
