using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class mejoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Producto",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Producto");
        }
    }
}
