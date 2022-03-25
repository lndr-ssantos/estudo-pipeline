using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoRestaurante.Infra.Migrations
{
    public partial class AtualizandoTabelaPedidoAdicionandoMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mesa",
                table: "Pedidos",
                type: "varchar(2)",
                maxLength: 2,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mesa",
                table: "Pedidos");
        }
    }
}
