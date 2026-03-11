using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransporteEscolar.Relatorios.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos_snapshot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos_snapshot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rotas_historicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    DistanciaKm = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    QuantidadeAlunosTransportados = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotas_historicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "presencas_historicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    ConfirmouPresenca = table.Column<bool>(type: "boolean", nullable: false),
                    CancelouPresenca = table.Column<bool>(type: "boolean", nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataCancelamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EnderecoUtilizado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presencas_historicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_presencas_historicas_alunos_snapshot_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos_snapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_presencas_historicas_AlunoId",
                table: "presencas_historicas",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "presencas_historicas");

            migrationBuilder.DropTable(
                name: "rotas_historicas");

            migrationBuilder.DropTable(
                name: "alunos_snapshot");
        }
    }
}
