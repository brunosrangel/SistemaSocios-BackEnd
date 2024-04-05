using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Usuario_Id",
                table: "Perfis");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Usuario_Id",
                table: "Perfis",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
