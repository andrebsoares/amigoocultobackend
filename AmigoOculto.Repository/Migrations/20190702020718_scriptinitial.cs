using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmigoOculto.Repository.Migrations
{
    public partial class scriptinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bdAmigoOculto");

            migrationBuilder.CreateTable(
                name: "tb_grupo",
                schema: "bdAmigoOculto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Localizacao = table.Column<string>(nullable: true),
                    DataHoraEntrega = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Grupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                schema: "bdAmigoOculto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Detalhes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_grupousuario",
                schema: "bdAmigoOculto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoId = table.Column<int>(nullable: false),
                    AmigoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_GrupoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_grupousuario_tb_usuario_AmigoId",
                        column: x => x.AmigoId,
                        principalSchema: "bdAmigoOculto",
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_grupousuario_tb_grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalSchema: "bdAmigoOculto",
                        principalTable: "tb_grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_grupousuario_AmigoId",
                schema: "bdAmigoOculto",
                table: "tb_grupousuario",
                column: "AmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_grupousuario_GrupoId",
                schema: "bdAmigoOculto",
                table: "tb_grupousuario",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_grupousuario",
                schema: "bdAmigoOculto");

            migrationBuilder.DropTable(
                name: "tb_usuario",
                schema: "bdAmigoOculto");

            migrationBuilder.DropTable(
                name: "tb_grupo",
                schema: "bdAmigoOculto");
        }
    }
}
