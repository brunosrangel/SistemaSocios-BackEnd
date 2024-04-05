using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusEscolaridade",
                table: "EscolaridadeUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusEscolaridade",
                table: "EscolaridadeUsuario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
