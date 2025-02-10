using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AionRhC_.Migrations
{
    /// <inheritdoc />
    public partial class TableContratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroProcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecebimentoNf = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrazoComissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecebimentoDefinitivo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrazoParaLiquidacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrazoPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Liquidacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PagamentoSigef = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");
        }
    }
}
