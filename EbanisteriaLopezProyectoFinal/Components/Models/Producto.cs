using EbanisteriaLopezProyectoFinal.Components.Models;

public class Producto
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public int EstadoProductoId { get; set; }
    public EstadoProducto EstadoProducto { get; set; }

    public ProductoDetalle Detalle { get; set; }
    public ICollection<ImagenProducto> Imagenes { get; set; } = new List<ImagenProducto>();
   


}
