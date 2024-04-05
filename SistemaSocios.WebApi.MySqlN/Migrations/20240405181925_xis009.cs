using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class xis009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Entidades_Usuario_Id",
            //    table: "Entidades");

            migrationBuilder.DropForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoMensalidades_Usuario_Id",
                table: "HistoricoMensalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_JurosMensalidade_Usuario_Id",
                table: "JurosMensalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_Usuario_Id",
                table: "RedeSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_TelefoneUsuario_Usuario_TipoTelefoneUsuarioId",
                table: "TelefoneUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ValorMensalidade_Usuario_UsuarioId",
                table: "ValorMensalidade");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ValorMensalidade",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_ValorMensalidade_UsuarioId",
                table: "ValorMensalidade",
                newName: "IX_ValorMensalidade_UsuarioID");

            migrationBuilder.AddColumn<Guid>(
                name: "ValorMensalidadeModelId",
                table: "ValorMensalidade",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EscolaridadeId",
                table: "Usuario",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TelefoneUsuarioModelId",
                table: "TelefoneUsuario",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "RedeSocialModelId",
                table: "RedeSocial",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "JurosMensalidadeModelId",
                table: "JurosMensalidade",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "HistoricoMensalidadesModelId",
                table: "HistoricoMensalidades",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoUsuarioModelId",
                table: "EnderecoUsuario",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "StatusMensalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HistoricoMensalidadesModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMensalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusMensalidade_HistoricoMensalidades_HistoricoMensalidade~",
                        column: x => x.HistoricoMensalidadesModelId,
                        principalTable: "HistoricoMensalidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ValorMensalidade_ValorMensalidadeModelId",
                table: "ValorMensalidade",
                column: "ValorMensalidadeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EntidadeId",
                table: "Usuario",
                column: "EntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EscolaridadeId",
                table: "Usuario",
                column: "EscolaridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneUsuario_TelefoneUsuarioModelId",
                table: "TelefoneUsuario",
                column: "TelefoneUsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneUsuario_UsuarioID",
                table: "TelefoneUsuario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocial_RedeSocialModelId",
                table: "RedeSocial",
                column: "RedeSocialModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocial_UsuarioID",
                table: "RedeSocial",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_JurosMensalidade_JurosMensalidadeModelId",
                table: "JurosMensalidade",
                column: "JurosMensalidadeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_JurosMensalidade_UsuarioID",
                table: "JurosMensalidade",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMensalidades_HistoricoMensalidadesModelId",
                table: "HistoricoMensalidades",
                column: "HistoricoMensalidadesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUsuario_EnderecoUsuarioModelId",
                table: "EnderecoUsuario",
                column: "EnderecoUsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusMensalidade_HistoricoMensalidadesModelId",
                table: "StatusMensalidade",
                column: "HistoricoMensalidadesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoUsuario_EnderecoUsuario_EnderecoUsuarioModelId",
                table: "EnderecoUsuario",
                column: "EnderecoUsuarioModelId",
                principalTable: "EnderecoUsuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoMensalidades_HistoricoMensalidades_HistoricoMensali~",
                table: "HistoricoMensalidades",
                column: "HistoricoMensalidadesModelId",
                principalTable: "HistoricoMensalidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JurosMensalidade_JurosMensalidade_JurosMensalidadeModelId",
                table: "JurosMensalidade",
                column: "JurosMensalidadeModelId",
                principalTable: "JurosMensalidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JurosMensalidade_Usuario_UsuarioID",
                table: "JurosMensalidade",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_RedeSocial_RedeSocialModelId",
                table: "RedeSocial",
                column: "RedeSocialModelId",
                principalTable: "RedeSocial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_Usuario_UsuarioID",
                table: "RedeSocial",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TelefoneUsuario_TelefoneUsuario_TelefoneUsuarioModelId",
                table: "TelefoneUsuario",
                column: "TelefoneUsuarioModelId",
                principalTable: "TelefoneUsuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TelefoneUsuario_Usuario_UsuarioID",
                table: "TelefoneUsuario",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Entidades_EntidadeId",
                table: "Usuario",
                column: "EntidadeId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_EscolaridadeUsuario_EscolaridadeId",
                table: "Usuario",
                column: "EscolaridadeId",
                principalTable: "EscolaridadeUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValorMensalidade_Usuario_UsuarioID",
                table: "ValorMensalidade",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValorMensalidade_ValorMensalidade_ValorMensalidadeModelId",
                table: "ValorMensalidade",
                column: "ValorMensalidadeModelId",
                principalTable: "ValorMensalidade",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoUsuario_EnderecoUsuario_EnderecoUsuarioModelId",
                table: "EnderecoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoMensalidades_HistoricoMensalidades_HistoricoMensali~",
                table: "HistoricoMensalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_JurosMensalidade_JurosMensalidade_JurosMensalidadeModelId",
                table: "JurosMensalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_JurosMensalidade_Usuario_UsuarioID",
                table: "JurosMensalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_RedeSocial_RedeSocialModelId",
                table: "RedeSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_Usuario_UsuarioID",
                table: "RedeSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_TelefoneUsuario_TelefoneUsuario_TelefoneUsuarioModelId",
                table: "TelefoneUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_TelefoneUsuario_Usuario_UsuarioID",
                table: "TelefoneUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Entidades_EntidadeId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_EscolaridadeUsuario_EscolaridadeId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ValorMensalidade_Usuario_UsuarioID",
                table: "ValorMensalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_ValorMensalidade_ValorMensalidade_ValorMensalidadeModelId",
                table: "ValorMensalidade");

            migrationBuilder.DropTable(
                name: "StatusMensalidade");

            migrationBuilder.DropIndex(
                name: "IX_ValorMensalidade_ValorMensalidadeModelId",
                table: "ValorMensalidade");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EntidadeId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EscolaridadeId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_TelefoneUsuario_TelefoneUsuarioModelId",
                table: "TelefoneUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TelefoneUsuario_UsuarioID",
                table: "TelefoneUsuario");

            migrationBuilder.DropIndex(
                name: "IX_RedeSocial_RedeSocialModelId",
                table: "RedeSocial");

            migrationBuilder.DropIndex(
                name: "IX_RedeSocial_UsuarioID",
                table: "RedeSocial");

            migrationBuilder.DropIndex(
                name: "IX_JurosMensalidade_JurosMensalidadeModelId",
                table: "JurosMensalidade");

            migrationBuilder.DropIndex(
                name: "IX_JurosMensalidade_UsuarioID",
                table: "JurosMensalidade");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoMensalidades_HistoricoMensalidadesModelId",
                table: "HistoricoMensalidades");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoUsuario_EnderecoUsuarioModelId",
                table: "EnderecoUsuario");

            migrationBuilder.DropColumn(
                name: "ValorMensalidadeModelId",
                table: "ValorMensalidade");

            migrationBuilder.DropColumn(
                name: "EscolaridadeId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TelefoneUsuarioModelId",
                table: "TelefoneUsuario");

            migrationBuilder.DropColumn(
                name: "RedeSocialModelId",
                table: "RedeSocial");

            migrationBuilder.DropColumn(
                name: "JurosMensalidadeModelId",
                table: "JurosMensalidade");

            migrationBuilder.DropColumn(
                name: "HistoricoMensalidadesModelId",
                table: "HistoricoMensalidades");

            migrationBuilder.DropColumn(
                name: "EnderecoUsuarioModelId",
                table: "EnderecoUsuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "ValorMensalidade",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ValorMensalidade_UsuarioID",
                table: "ValorMensalidade",
                newName: "IX_ValorMensalidade_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_Usuario_Id",
                table: "Entidades",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EscolaridadeUsuario_Usuario_Id",
                table: "EscolaridadeUsuario",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoMensalidades_Usuario_Id",
                table: "HistoricoMensalidades",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JurosMensalidade_Usuario_Id",
                table: "JurosMensalidade",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_Usuario_Id",
                table: "RedeSocial",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TelefoneUsuario_Usuario_TipoTelefoneUsuarioId",
                table: "TelefoneUsuario",
                column: "TipoTelefoneUsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfis_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValorMensalidade_Usuario_UsuarioId",
                table: "ValorMensalidade",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
