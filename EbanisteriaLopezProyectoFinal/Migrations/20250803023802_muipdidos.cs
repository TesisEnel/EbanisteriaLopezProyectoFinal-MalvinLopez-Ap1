using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class muipdidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoEntrega",
                table: "Ventas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItem_ProductoId",
                table: "VentaItem",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaItem_Producto_ProductoId",
                table: "VentaItem",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaItem_Producto_ProductoId",
                table: "VentaItem");

            migrationBuilder.DropIndex(
                name: "IX_VentaItem_ProductoId",
                table: "VentaItem");

            migrationBuilder.DropColumn(
                name: "EstadoEntrega",
                table: "Ventas");
        }
    }
}
