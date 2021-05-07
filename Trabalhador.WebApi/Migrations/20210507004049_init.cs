using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalhador.WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trabalhador",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValeTransporte = table.Column<float>(type: "real", nullable: false),
                    CargaDeTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustoTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabalhador", x => x.Nome);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trabalhador");
        }
    }
}
