using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PrecoKm = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    KmDisponivel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBGrupoAutomovel_TBPlanoCobranca",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_TBGrupoAutomovel_GrupoAutomovelId",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBGrupoAutomovel_PlanoCobrancaId",
                table: "TBGrupoAutomovel",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_GrupoAutomovelId",
                table: "Veiculo",
                column: "GrupoAutomovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomovel");

            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
