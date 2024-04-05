using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscolaridadeId",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EscolaridadeId",
                table: "Usuario",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }
    }
}
