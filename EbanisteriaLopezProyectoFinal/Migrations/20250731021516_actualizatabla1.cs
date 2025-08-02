using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class actualizatabla1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimensiones",
                table: "Producto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Producto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensiones",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Producto");
        }
    }
}
