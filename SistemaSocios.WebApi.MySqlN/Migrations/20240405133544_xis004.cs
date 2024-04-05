using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Perfis",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "HistoricoMensalidades",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Perfis",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "HistoricoMensalidades",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
