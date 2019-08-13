using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoDeProjetos.Infra.Data.Migrations
{
    public partial class CampoFuncao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Pessoa",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Pessoa");
        }
    }
}
