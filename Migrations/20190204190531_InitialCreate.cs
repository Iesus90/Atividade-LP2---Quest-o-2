using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atividade1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    IdBanco = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    IdAgencia = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BancoIdBanco = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.IdAgencia);
                    table.ForeignKey(
                        name: "FK_Agencias_Bancos_BancoIdBanco",
                        column: x => x.BancoIdBanco,
                        principalTable: "Bancos",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Saldo = table.Column<decimal>(nullable: false),
                    Titular = table.Column<string>(nullable: true),
                    AgenciaIdAgencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Agencias_AgenciaIdAgencia",
                        column: x => x.AgenciaIdAgencia,
                        principalTable: "Agencias",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContasPoupanca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Juros = table.Column<decimal>(nullable: false),
                    DataAniversario = table.Column<DateTime>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    Titular = table.Column<string>(nullable: true),
                    AgenciaIdAgencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPoupanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasPoupanca_Agencias_AgenciaIdAgencia",
                        column: x => x.AgenciaIdAgencia,
                        principalTable: "Agencias",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    IdSolicitacao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgenciaIdAgencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.IdSolicitacao);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Agencias_AgenciaIdAgencia",
                        column: x => x.AgenciaIdAgencia,
                        principalTable: "Agencias",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_BancoIdBanco",
                table: "Agencias",
                column: "BancoIdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_AgenciaIdAgencia",
                table: "ContasCorrentes",
                column: "AgenciaIdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPoupanca_AgenciaIdAgencia",
                table: "ContasPoupanca",
                column: "AgenciaIdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_AgenciaIdAgencia",
                table: "Solicitacoes",
                column: "AgenciaIdAgencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");

            migrationBuilder.DropTable(
                name: "ContasPoupanca");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
