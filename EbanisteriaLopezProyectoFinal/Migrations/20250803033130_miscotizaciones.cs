using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class miscotizaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Cotizacion",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Mensaje",
                table: "Cotizacion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Respuesta",
                table: "Cotizacion",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "Mensaje",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "Respuesta",
                table: "Cotizacion");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Cotizacion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
