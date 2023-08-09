using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoCupom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CupomCliente",
                columns: table => new
                {
                    ClientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuponsUsadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupomCliente", x => new { x.ClientesId, x.CuponsUsadosId });
                    table.ForeignKey(
                        name: "FK_CupomCliente_TBCliente_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CupomCliente_TBCupom_CuponsUsadosId",
                        column: x => x.CuponsUsadosId,
                        principalTable: "TBCupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CupomCliente_CuponsUsadosId",
                table: "CupomCliente",
                column: "CuponsUsadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CupomCliente");
        }
    }
}
