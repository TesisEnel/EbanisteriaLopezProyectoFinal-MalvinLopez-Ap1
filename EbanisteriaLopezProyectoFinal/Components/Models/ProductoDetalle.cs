using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class ProductoDetalle
{
    [Key]
    public int ProductoDetalleId { get; set; }
    public int ProductoId { get; set; }
    public string? Material { get; set; }
    public string? Color { get; set; }
    public string? Dimensiones { get; set; }
    public string? Descripcion { get; set; }

    public Producto? Producto { get; set; }
}
