using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSocios.WebApi.MySqlN.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoEnderecoUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnderecoUsuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoTelefoneUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefoneUsuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TelefoneId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Profissao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EscolaridadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RedeSocialId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataIniciacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUltimaObrigacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    JurosMensalidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorMensalidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MensalidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EntidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PerfilId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnderecoUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoEnderecoUsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoUsuario_TipoEnderecoUsuario_TipoEnderecoId",
                        column: x => x.TipoEnderecoUsuarioId,
                        principalTable: "TipoEnderecoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoUsuario_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoEntidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entidades_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EscolaridadeUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoEscolaridade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusEscolaridade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolaridadeUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscolaridadeUsuario_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistoricoMensalidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MesReferencia = table.Column<int>(type: "int", nullable: false),
                    AnoReferencia = table.Column<int>(type: "int", nullable: false),
                    StatusMensalidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoMensalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoMensalidades_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoMensalidades_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JurosMensalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    valorJuros = table.Column<int>(type: "int", nullable: false),
                    DataVigenciaJuros = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    statusValorJuros = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurosMensalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JurosMensalidade_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoPerfil = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfis_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RedeSocial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoRedeSocialUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlRedeSocial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedeSocial_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TelefoneUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DddTelefoneUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroTelefoneUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoTelefoneUsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefoneUsuario_TipoTelefoneUsuario_TipoTelefoneUsuarioId",
                        column: x => x.TipoTelefoneUsuarioId,
                        principalTable: "TipoTelefoneUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelefoneUsuario_Usuario_TipoTelefoneUsuarioId",
                        column: x => x.TipoTelefoneUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ValorMensalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VigenciaMensalidade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    statusValorMensalidade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorMensalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorMensalidade_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUsuario_TipoEnderecoUsuarioId",
                table: "EnderecoUsuario",
                column: "TipoEnderecoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUsuario_UsuarioID",
                table: "EnderecoUsuario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMensalidades_UsuarioID",
                table: "HistoricoMensalidades",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneUsuario_TipoTelefoneUsuarioId",
                table: "TelefoneUsuario",
                column: "TipoTelefoneUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorMensalidade_UsuarioId",
                table: "ValorMensalidade",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoUsuario");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "EscolaridadeUsuario");

            migrationBuilder.DropTable(
                name: "HistoricoMensalidades");

            migrationBuilder.DropTable(
                name: "JurosMensalidade");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "RedeSocial");

            migrationBuilder.DropTable(
                name: "TelefoneUsuario");

            migrationBuilder.DropTable(
                name: "ValorMensalidade");

            migrationBuilder.DropTable(
                name: "TipoEnderecoUsuario");

            migrationBuilder.DropTable(
                name: "TipoTelefoneUsuario");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
