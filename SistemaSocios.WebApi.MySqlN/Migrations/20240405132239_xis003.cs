using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
