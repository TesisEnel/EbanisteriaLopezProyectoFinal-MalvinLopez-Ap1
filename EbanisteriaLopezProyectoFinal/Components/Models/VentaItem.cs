using EbanisteriaLopezProyectoFinal.Components.Models;

public class VentaItem
{
    public int VentaItemId { get; set; }

    public int ProductoId { get; set; } 

    public int VentaId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    
    public Producto Producto { get; set; } = default!;
    public Venta Venta { get; set; } = default!;
}
