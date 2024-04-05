using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoUsuario_TipoEnderecoUsuario_TipoEnderecoId",
                table: "EnderecoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoUsuario_TipoEnderecoUsuario_TipoEnderecoUsuarioId",
                table: "EnderecoUsuario",
                column: "TipoEnderecoUsuarioId",
                principalTable: "TipoEnderecoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoUsuario_TipoEnderecoUsuario_TipoEnderecoUsuarioId",
                table: "EnderecoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoUsuario_TipoEnderecoUsuario_TipoEnderecoId",
                table: "EnderecoUsuario",
                column: "TipoEnderecoUsuarioId",
                principalTable: "TipoEnderecoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
