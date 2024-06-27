using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoClean.Migrations
{
    /// <inheritdoc />
    public partial class AddMorador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CoordenadaX = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CoordenadaY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Cidade = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Destinatario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Assunto = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Mensagem = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoResiduo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoResiduo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Morador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EnderecoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Morador_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RotaId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CaminhaoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EnderecoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PrevisaoHorario = table.Column<DateTime>(type: "DATE", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coleta_Caminhao_CaminhaoId",
                        column: x => x.CaminhaoId,
                        principalTable: "Caminhao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coleta_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coleta_Rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaEndereco",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RotaId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaEndereco", x => new { x.EnderecoId, x.RotaId });
                    table.ForeignKey(
                        name: "FK_RotaEndereco_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaEndereco_Rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColetaTipoResiduo",
                columns: table => new
                {
                    ColetaId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TipoResiduoId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColetaTipoResiduo", x => new { x.ColetaId, x.TipoResiduoId });
                    table.ForeignKey(
                        name: "FK_ColetaTipoResiduo_Coleta_ColetaId",
                        column: x => x.ColetaId,
                        principalTable: "Coleta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColetaTipoResiduo_TipoResiduo_TipoResiduoId",
                        column: x => x.TipoResiduoId,
                        principalTable: "TipoResiduo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_CaminhaoId",
                table: "Coleta",
                column: "CaminhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_EnderecoId",
                table: "Coleta",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_RotaId",
                table: "Coleta",
                column: "RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColetaTipoResiduo_TipoResiduoId",
                table: "ColetaTipoResiduo",
                column: "TipoResiduoId");

            migrationBuilder.CreateIndex(
                name: "IX_Morador_EnderecoId",
                table: "Morador",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_RotaEndereco_RotaId",
                table: "RotaEndereco",
                column: "RotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColetaTipoResiduo");

            migrationBuilder.DropTable(
                name: "Morador");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "RotaEndereco");

            migrationBuilder.DropTable(
                name: "Coleta");

            migrationBuilder.DropTable(
                name: "TipoResiduo");

            migrationBuilder.DropTable(
                name: "Caminhao");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Rota");
        }
    }
}
