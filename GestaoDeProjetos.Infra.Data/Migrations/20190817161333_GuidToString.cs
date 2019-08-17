using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoDeProjetos.Infra.Data.Migrations
{
    public partial class GuidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Funcao = table.Column<string>(maxLength: 1000, nullable: false),
                    Setor = table.Column<string>(maxLength: 100, nullable: false),
                    Contato = table.Column<string>(maxLength: 50, nullable: false),
                    Empresa = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    CoordenadorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipe_Pessoa_CoordenadorId",
                        column: x => x.CoordenadorId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEquipe",
                columns: table => new
                {
                    Id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    DataAlocacao = table.Column<DateTime>(nullable: false),
                    PessoaId = table.Column<string>(nullable: false),
                    EquipeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEquipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaEquipe_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEquipe_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    Prioridade = table.Column<string>(maxLength: 100, nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    Relatorio = table.Column<string>(maxLength: 10000, nullable: false),
                    Progresso = table.Column<int>(nullable: false),
                    CoordenadorId = table.Column<string>(nullable: false),
                    EquipeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_Pessoa_CoordenadorId",
                        column: x => x.CoordenadorId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projeto_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    ResponsavelId = table.Column<string>(nullable: false),
                    ProjetoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefa_Pessoa_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_CoordenadorId",
                table: "Equipe",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEquipe_EquipeId",
                table: "PessoaEquipe",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEquipe_PessoaId",
                table: "PessoaEquipe",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_CoordenadorId",
                table: "Projeto",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_EquipeId",
                table: "Projeto",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ResponsavelId",
                table: "Tarefa",
                column: "ResponsavelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaEquipe");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
