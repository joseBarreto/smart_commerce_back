using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartCommerce.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRECO_ESTIMADO = table.Column<double>(type: "float", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CODIGO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PRODUTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_SEGMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ICONE_NOME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SEGMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOBRENOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: false),
                    EMPRESA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_VOTACAO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIOID = table.Column<int>(type: "int", nullable: false),
                    LOCALID = table.Column<int>(type: "int", nullable: false),
                    VOTO = table.Column<bool>(type: "bit", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VOTACAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_LOCAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SEGMENTOID = table.Column<int>(type: "int", nullable: false),
                    USUARIOID = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    LATITUDE = table.Column<double>(type: "float", nullable: false),
                    LONGITUDE = table.Column<double>(type: "float", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOTAL_VOTACAO = table.Column<int>(type: "int", nullable: true),
                    IMAGEM_URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOCAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_LOCAL_T_SEGMENTO_SEGMENTOID",
                        column: x => x.SEGMENTOID,
                        principalTable: "T_SEGMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_LOCAL_T_USUARIO_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "T_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_LOGIN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIOID = table.Column<int>(type: "int", nullable: false),
                    DATA_ULTIMO_ACESSO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOGIN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_LOGIN_T_USUARIO_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "T_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_LOCAL_PRODUTO",
                columns: table => new
                {
                    LOCALID = table.Column<int>(type: "int", nullable: false),
                    PRODUTOID = table.Column<int>(type: "int", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOCAL_PRODUTO", x => new { x.LOCALID, x.PRODUTOID });
                    table.ForeignKey(
                        name: "FK_T_LOCAL_PRODUTO_T_LOCAL_LOCALID",
                        column: x => x.LOCALID,
                        principalTable: "T_LOCAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_LOCAL_PRODUTO_T_PRODUTO_PRODUTOID",
                        column: x => x.PRODUTOID,
                        principalTable: "T_PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_SEGMENTOID",
                table: "T_LOCAL",
                column: "SEGMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_USUARIOID",
                table: "T_LOCAL",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_PRODUTO_PRODUTOID",
                table: "T_LOCAL_PRODUTO",
                column: "PRODUTOID");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOGIN_USUARIOID",
                table: "T_LOGIN",
                column: "USUARIOID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_LOCAL_PRODUTO");

            migrationBuilder.DropTable(
                name: "T_LOGIN");

            migrationBuilder.DropTable(
                name: "T_VOTACAO");

            migrationBuilder.DropTable(
                name: "T_LOCAL");

            migrationBuilder.DropTable(
                name: "T_PRODUTO");

            migrationBuilder.DropTable(
                name: "T_SEGMENTO");

            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }
    }
}