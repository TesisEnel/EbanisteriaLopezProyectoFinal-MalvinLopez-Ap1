using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EbanisteriaLopezProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class CreateServicioTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Ventas_VentaId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_VentaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Ventas",
                newName: "UrlVoucher");

            migrationBuilder.AddColumn<string>(
                name: "CorreoUsuario",
                table: "Ventas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "ProductoDetalle",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    DetalleVentaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VentaId = table.Column<int>(type: "integer", nullable: false),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.DetalleVentaId);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ProductoId",
                table: "DetalleVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaId",
                table: "DetalleVenta",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "CorreoUsuario",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "ProductoDetalle");

            migrationBuilder.RenameColumn(
                name: "UrlVoucher",
                table: "Ventas",
                newName: "UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "Producto",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_VentaId",
                table: "Producto",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Ventas_VentaId",
                table: "Producto",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId");
        }
    }
}
