using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class ventas4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaItem_Producto_ProductoId",
                table: "VentaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaItem_Ventas_VentaId",
                table: "VentaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaItem",
                table: "VentaItem");

            migrationBuilder.DropColumn(
                name: "NuevoEstadoEntrega",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Mensaje",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "Respuesta",
                table: "Cotizacion");

            migrationBuilder.RenameTable(
                name: "VentaItem",
                newName: "VentaItems");

            migrationBuilder.RenameIndex(
                name: "IX_VentaItem_VentaId",
                table: "VentaItems",
                newName: "IX_VentaItems_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaItem_ProductoId",
                table: "VentaItems",
                newName: "IX_VentaItems_ProductoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Cotizacion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaItems",
                table: "VentaItems",
                column: "VentaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaItems_Producto_ProductoId",
                table: "VentaItems",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaItems_Ventas_VentaId",
                table: "VentaItems",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaItems_Producto_ProductoId",
                table: "VentaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaItems_Ventas_VentaId",
                table: "VentaItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaItems",
                table: "VentaItems");

            migrationBuilder.RenameTable(
                name: "VentaItems",
                newName: "VentaItem");

            migrationBuilder.RenameIndex(
                name: "IX_VentaItems_VentaId",
                table: "VentaItem",
                newName: "IX_VentaItem_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaItems_ProductoId",
                table: "VentaItem",
                newName: "IX_VentaItem_ProductoId");

            migrationBuilder.AddColumn<string>(
                name: "NuevoEstadoEntrega",
                table: "Ventas",
                type: "text",
                nullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaItem",
                table: "VentaItem",
                column: "VentaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Producto_ProductoId",
                table: "Cotizacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaItem_Producto_ProductoId",
                table: "VentaItem",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaItem_Ventas_VentaId",
                table: "VentaItem",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
