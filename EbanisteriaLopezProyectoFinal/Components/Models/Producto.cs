using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Moneda { get; set; } = "Dolar"; 

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public int EstadoProductoId { get; set; }
    public EstadoProducto? EstadoProducto { get; set; }

    public ProductoDetalle? Detalle { get; set; }

    public List<ImagenProducto> Imagenes { get; set; } = new();

    public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;
    public byte[] Imagen { get; internal set; }
}
