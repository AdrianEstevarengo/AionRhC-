using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AionRhC_.Migrations
{
    /// <inheritdoc />
    public partial class ColumStatusColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Situacao",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Setor",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Colaboradores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneEmergencia",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "TelefoneEmergencia",
                table: "Colaboradores");

            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
