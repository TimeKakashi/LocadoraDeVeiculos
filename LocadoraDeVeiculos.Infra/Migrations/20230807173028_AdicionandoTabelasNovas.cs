using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelasNovas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_TBGrupoAutomovel_GrupoAutomovelId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "TBAutomovel");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_GrupoAutomovelId",
                table: "TBAutomovel",
                newName: "IX_TBAutomovel_GrupoAutomovelId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "TBAutomovel",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CapacidadeEmLitros",
                table: "TBAutomovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "TBAutomovel",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmUso",
                table: "TBAutomovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnumCombusteivel",
                table: "TBAutomovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "TBAutomovel",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "Kilometragem",
                table: "TBAutomovel",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "TBAutomovel",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "TBAutomovel",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBAutomovel",
                table: "TBAutomovel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrupoAutomovel",
                table: "TBAutomovel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBAutomovel",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "CapacidadeEmLitros",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "EmUso",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "EnumCombusteivel",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Kilometragem",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "TBAutomovel");

            migrationBuilder.RenameTable(
                name: "TBAutomovel",
                newName: "Veiculo");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomovel_GrupoAutomovelId",
                table: "Veiculo",
                newName: "IX_Veiculo_GrupoAutomovelId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_TBGrupoAutomovel_GrupoAutomovelId",
                table: "Veiculo",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
