using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaWebEmpleado.Migrations
{
    public partial class cambio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "legajo",
                table: "Empleado",
                newName: "Legajo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Legajo",
                table: "Empleado",
                newName: "legajo");
        }
    }
}
