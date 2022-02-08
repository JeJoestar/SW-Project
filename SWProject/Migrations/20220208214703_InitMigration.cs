using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.DAL.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fleets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jedies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PadawanId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    LegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jedies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jedies_Jedies_PadawanId",
                        column: x => x.PadawanId,
                        principalTable: "Jedies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StarshipWeaponries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaserTurretCnt = table.Column<int>(type: "int", nullable: false),
                    LaserDoubleCannonCnt = table.Column<int>(type: "int", nullable: false),
                    LaserTargetDefenseCannonCnt = table.Column<int>(type: "int", nullable: false),
                    ProtonTorpedoLauncherCnt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipWeaponries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartridgesCnt = table.Column<int>(type: "int", nullable: false),
                    GrenadesCnt = table.Column<int>(type: "int", nullable: false),
                    FuelCnt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralJediId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legions_Jedies_GeneralJediId",
                        column: x => x.GeneralJediId,
                        principalTable: "Jedies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponryId = table.Column<int>(type: "int", nullable: true),
                    FleetId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Starships_Fleets_FleetId",
                        column: x => x.FleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Starships_StarshipWeaponries_WeaponryId",
                        column: x => x.WeaponryId,
                        principalTable: "StarshipWeaponries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachedFleetId = table.Column<int>(type: "int", nullable: true),
                    AmmoSupplyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Base_Fleets_AttachedFleetId",
                        column: x => x.AttachedFleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Supplies_AmmoSupplyId",
                        column: x => x.AmmoSupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegionId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: true),
                    StarshipId = table.Column<int>(type: "int", nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clones_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clones_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clones_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Droid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: true),
                    StarshipId = table.Column<int>(type: "int", nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Droid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Droid_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Droid_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Base_AmmoSupplyId",
                table: "Base",
                column: "AmmoSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_AttachedFleetId",
                table: "Base",
                column: "AttachedFleetId");

            migrationBuilder.CreateIndex(
                name: "IX_Clones_BaseId",
                table: "Clones",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clones_LegionId",
                table: "Clones",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clones_StarshipId",
                table: "Clones",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Droid_BaseId",
                table: "Droid",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Droid_StarshipId",
                table: "Droid",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Jedies_PadawanId",
                table: "Jedies",
                column: "PadawanId",
                unique: true,
                filter: "[PadawanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_GeneralJediId",
                table: "Legions",
                column: "GeneralJediId",
                unique: true,
                filter: "[GeneralJediId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_FleetId",
                table: "Starships",
                column: "FleetId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_WeaponryId",
                table: "Starships",
                column: "WeaponryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clones");

            migrationBuilder.DropTable(
                name: "Droid");

            migrationBuilder.DropTable(
                name: "Legions");

            migrationBuilder.DropTable(
                name: "Base");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Jedies");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Fleets");

            migrationBuilder.DropTable(
                name: "StarshipWeaponries");
        }
    }
}
