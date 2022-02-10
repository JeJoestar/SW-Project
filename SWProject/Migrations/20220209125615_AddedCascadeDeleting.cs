using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.DAL.Migrations
{
    public partial class AddedCascadeDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Fleets_FleetId",
                table: "Starships");

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Fleets_FleetId",
                table: "Starships",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Fleets_FleetId",
                table: "Starships");

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Fleets_FleetId",
                table: "Starships",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
