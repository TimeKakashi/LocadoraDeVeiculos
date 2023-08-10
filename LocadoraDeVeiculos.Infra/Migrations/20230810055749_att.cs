using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCupom_TBParceiro",
                table: "TBCupom");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoAutomovel",
                table: "TBPlanoCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCupom_TBParceiro",
                table: "TBCupom",
                column: "ParceiroId",
                principalTable: "TBParceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoAutomovel",
                table: "TBPlanoCobranca",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCupom_TBParceiro",
                table: "TBCupom");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoAutomovel",
                table: "TBPlanoCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCupom_TBParceiro",
                table: "TBCupom",
                column: "ParceiroId",
                principalTable: "TBParceiro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoAutomovel",
                table: "TBPlanoCobranca",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
