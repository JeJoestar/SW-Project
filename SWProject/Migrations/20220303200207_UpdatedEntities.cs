using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.DAL.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Supplies_AmmoSupplyId",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Bases_BaseId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Starships_StarshipId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Droids_Bases_BaseId",
                table: "Droids");

            migrationBuilder.DropForeignKey(
                name: "FK_Droids_Starships_StarshipId",
                table: "Droids");

            migrationBuilder.AddColumn<int>(
                name: "SupplyId",
                table: "Starships",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StarshipId",
                table: "Droids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "Droids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StarshipId",
                table: "Clones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "Clones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AmmoSupplyId",
                table: "Bases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_SupplyId",
                table: "Starships",
                column: "SupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Supplies_AmmoSupplyId",
                table: "Bases",
                column: "AmmoSupplyId",
                principalTable: "Supplies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Bases_BaseId",
                table: "Clones",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Starships_StarshipId",
                table: "Clones",
                column: "StarshipId",
                principalTable: "Starships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Droids_Bases_BaseId",
                table: "Droids",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Droids_Starships_StarshipId",
                table: "Droids",
                column: "StarshipId",
                principalTable: "Starships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Supplies_SupplyId",
                table: "Starships",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Supplies_AmmoSupplyId",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Bases_BaseId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Clones_Starships_StarshipId",
                table: "Clones");

            migrationBuilder.DropForeignKey(
                name: "FK_Droids_Bases_BaseId",
                table: "Droids");

            migrationBuilder.DropForeignKey(
                name: "FK_Droids_Starships_StarshipId",
                table: "Droids");

            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Supplies_SupplyId",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Starships_SupplyId",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "Starships");

            migrationBuilder.AlterColumn<int>(
                name: "StarshipId",
                table: "Droids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "Droids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StarshipId",
                table: "Clones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseId",
                table: "Clones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmmoSupplyId",
                table: "Bases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Supplies_AmmoSupplyId",
                table: "Bases",
                column: "AmmoSupplyId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Bases_BaseId",
                table: "Clones",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clones_Starships_StarshipId",
                table: "Clones",
                column: "StarshipId",
                principalTable: "Starships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Droids_Bases_BaseId",
                table: "Droids",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Droids_Starships_StarshipId",
                table: "Droids",
                column: "StarshipId",
                principalTable: "Starships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
