using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.DAL.Migrations
{
    public partial class RemovedAgeFRomJedi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Jedies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Jedies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
