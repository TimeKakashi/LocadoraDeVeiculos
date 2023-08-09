using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TbCondutir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.AddColumn<bool>(
                name: "ClienteEhCondutor",
                table: "TBCondutor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Condutor_TBCliente",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condutor_TBCliente",
                table: "TBCondutor");

            migrationBuilder.DropColumn(
                name: "ClienteEhCondutor",
                table: "TBCondutor");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
