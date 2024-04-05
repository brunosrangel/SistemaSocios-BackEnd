using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado",
                table: "EnderecoUsuario",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "EnderecoUsuario",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "EnderecoUsuario",
                newName: "Cidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "EnderecoUsuario",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "EnderecoUsuario",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "EnderecoUsuario",
                newName: "cidade");
        }
    }
}
