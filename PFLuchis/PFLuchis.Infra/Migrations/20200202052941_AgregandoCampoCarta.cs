using Microsoft.EntityFrameworkCore.Migrations;

namespace PFLuchis.Infra.Migrations
{
    public partial class AgregandoCampoCarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cartas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cartas");
        }
    }
}
