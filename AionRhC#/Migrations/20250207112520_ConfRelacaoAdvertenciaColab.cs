using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AionRhC_.Migrations
{
    /// <inheritdoc />
    public partial class ConfRelacaoAdvertenciaColab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdColaborador",
                table: "Advertencias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdColaborador",
                table: "Advertencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
