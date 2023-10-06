using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveXpress.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "Pedidos",
                newName: "NomeCliente");

            migrationBuilder.AddColumn<int>(
                name: "RestauranteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "NomeCliente",
                table: "Pedidos",
                newName: "NomeUsuario");
        }
    }
}
