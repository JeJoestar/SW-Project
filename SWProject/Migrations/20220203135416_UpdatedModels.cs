using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWProject.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Base_Fleets_AttachedFleetId",
                table: "Base");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_AssaultShipes_AssaultShipId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Legions_LegionId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_StarDestroyers_StarDestroyerId1",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Droid_AssaultShipes_AssaultShipId",
                table: "Droid");

            migrationBuilder.DropForeignKey(
                name: "FK_Droid_StarDestroyers_StarDestroyerId1",
                table: "Droid");

            migrationBuilder.DropTable(
                name: "AssaultShipes");

            migrationBuilder.DropIndex(
                name: "IX_Droid_AssaultShipId",
                table: "Droid");

            migrationBuilder.DropIndex(
                name: "IX_Droid_StarDestroyerId1",
                table: "Droid");

            migrationBuilder.DropIndex(
                name: "IX_Clones_AssaultShipId",
                table: "Clones");

            migrationBuilder.DropIndex(
                name: "IX_Clones_StarDestroyerId1",
                table: "Clones");

            migrationBuilder.DropColumn(
                name: "AssaultShipId",
                table: "Droid");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Droid");

            migrationBuilder.DropColumn(
                name: "StarDestroyerId1",
                table: "Droid");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Droid");

            migrationBuilder.DropColumn(
                name: "AssaultShipId",
                table: "Clones");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Clones");

            migrationBuilder.DropColumn(
                name: "StarDestroyerId1",
                table: "Clones");

            migrationBuilder.AddColumn<int>(
                name: "BaseFleetId",
                table: "StarDestroyers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StarDestroyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LegionId",
                table: "Clones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttachedFleetId",
                table: "Base",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StarDestroyers_BaseFleetId",
                table: "StarDestroyers",
                column: "BaseFleetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Base_Fleets_AttachedFleetId",
                table: "Base",
                column: "AttachedFleetId",
                principalTable: "Fleets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Legions_LegionId",
                table: "Clones",
                column: "LegionId",
                principalTable: "Legions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StarDestroyers_Fleets_BaseFleetId",
                table: "StarDestroyers",
                column: "BaseFleetId",
                principalTable: "Fleets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Base_Fleets_AttachedFleetId",
                table: "Base");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Legions_LegionId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_StarDestroyers_Fleets_BaseFleetId",
                table: "StarDestroyers");

            migrationBuilder.DropIndex(
                name: "IX_StarDestroyers_BaseFleetId",
                table: "StarDestroyers");

            migrationBuilder.DropColumn(
                name: "BaseFleetId",
                table: "StarDestroyers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StarDestroyers");

            migrationBuilder.AddColumn<int>(
                name: "AssaultShipId",
                table: "Droid",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Droid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StarDestroyerId1",
                table: "Droid",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Droid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LegionId",
                table: "Clones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssaultShipId",
                table: "Clones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Clones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StarDestroyerId1",
                table: "Clones",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttachedFleetId",
                table: "Base",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssaultShipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponryId = table.Column<int>(type: "int", nullable: true),
                    BaseFleetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssaultShipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssaultShipes_Fleets_BaseFleetId",
                        column: x => x.BaseFleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssaultShipes_StarshipWeaponries_WeaponryId",
                        column: x => x.WeaponryId,
                        principalTable: "StarshipWeaponries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Droid_AssaultShipId",
                table: "Droid",
                column: "AssaultShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Droid_StarDestroyerId1",
                table: "Droid",
                column: "StarDestroyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clones_AssaultShipId",
                table: "Clones",
                column: "AssaultShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Clones_StarDestroyerId1",
                table: "Clones",
                column: "StarDestroyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssaultShipes_BaseFleetId",
                table: "AssaultShipes",
                column: "BaseFleetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssaultShipes_WeaponryId",
                table: "AssaultShipes",
                column: "WeaponryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Base_Fleets_AttachedFleetId",
                table: "Base",
                column: "AttachedFleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_AssaultShipes_AssaultShipId",
                table: "Clones",
                column: "AssaultShipId",
                principalTable: "AssaultShipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Legions_LegionId",
                table: "Clones",
                column: "LegionId",
                principalTable: "Legions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_StarDestroyers_StarDestroyerId1",
                table: "Clones",
                column: "StarDestroyerId1",
                principalTable: "StarDestroyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Droid_AssaultShipes_AssaultShipId",
                table: "Droid",
                column: "AssaultShipId",
                principalTable: "AssaultShipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Droid_StarDestroyers_StarDestroyerId1",
                table: "Droid",
                column: "StarDestroyerId1",
                principalTable: "StarDestroyers",
                principalColumn: "Id");
        }
    }
}
