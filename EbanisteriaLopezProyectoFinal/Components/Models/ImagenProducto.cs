using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;
public class ImagenProducto
{
    public int ImagenProductoId { get; set; }
    public int ProductoId { get; set; }
    public string Url { get; set; } = string.Empty;
    public int Orden { get; set; }
    public Producto Producto { get; set; }
   


}
