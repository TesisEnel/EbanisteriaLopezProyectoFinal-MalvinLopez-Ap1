using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class COTIZACION1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaResuelto",
                table: "Cotizacion",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaResuelto",
                table: "Cotizacion");
        }
    }
}
