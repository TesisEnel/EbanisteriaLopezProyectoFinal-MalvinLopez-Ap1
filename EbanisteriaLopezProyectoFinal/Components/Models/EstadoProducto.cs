using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class EstadoProducto
{
    [Key]
    public int EstadoProductoId { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public List<Producto> Productos { get; set; } = new();

   
}
