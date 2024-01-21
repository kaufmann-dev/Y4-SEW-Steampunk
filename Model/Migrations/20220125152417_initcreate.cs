using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class initcreate : Migration
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
                name: "WEAPONS_ST",
                columns: table => new
                {
                    WEAPON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ATTACK_VALUE = table.Column<int>(type: "int", nullable: false),
                    AMMONITION_CAPACITY = table.Column<int>(type: "int", nullable: false),
                    RANGE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WEAPON_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEAPONS_ST", x => x.WEAPON_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AIRSHIP_HAS_ENGINES_JT",
                columns: table => new
                {
                    ENGINE_ID = table.Column<int>(type: "int", nullable: false),
                    AIRSHIP_ID = table.Column<int>(type: "int", nullable: false),
                    POSITION = table.Column<int>(type: "int", nullable: false),
                    DAMAGE_STATE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRSHIP_HAS_ENGINES_JT", x => new { x.ENGINE_ID, x.AIRSHIP_ID, x.POSITION });
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

            migrationBuilder.CreateTable(
                name: "SHIP_HAS_WEAPONS_JT",
                columns: table => new
                {
                    WEAPON_ID = table.Column<int>(type: "int", nullable: false),
                    SHIP_ID = table.Column<int>(type: "int", nullable: false),
                    POSITION = table.Column<int>(type: "int", nullable: false),
                    DAMAGE_STATE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIP_HAS_WEAPONS_JT", x => new { x.WEAPON_ID, x.SHIP_ID, x.POSITION });
                    table.ForeignKey(
                        name: "FK_SHIP_HAS_WEAPONS_JT_AIRSHIPS_SHIP_ID",
                        column: x => x.SHIP_ID,
                        principalTable: "AIRSHIPS",
                        principalColumn: "AIRSHIP_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHIP_HAS_WEAPONS_JT_WEAPONS_ST_WEAPON_ID",
                        column: x => x.WEAPON_ID,
                        principalTable: "WEAPONS_ST",
                        principalColumn: "WEAPON_ID",
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

            migrationBuilder.CreateIndex(
                name: "IX_SHIP_HAS_WEAPONS_JT_SHIP_ID",
                table: "SHIP_HAS_WEAPONS_JT",
                column: "SHIP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIRSHIP_HAS_ENGINES_JT");

            migrationBuilder.DropTable(
                name: "SHIP_HAS_WEAPONS_JT");

            migrationBuilder.DropTable(
                name: "ENGINES_ST");

            migrationBuilder.DropTable(
                name: "AIRSHIPS");

            migrationBuilder.DropTable(
                name: "WEAPONS_ST");
        }
    }
}
