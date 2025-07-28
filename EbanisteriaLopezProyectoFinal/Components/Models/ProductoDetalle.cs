using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class ProductoDetalle
{
    public int ProductoDetalleId { get; set; }

    [Required]
    public string Descripcion { get; set; }

    public string Material { get; set; }
    public string Color { get; set; }
    public string Dimensiones { get; set; }

    public int ProductoId { get; set; } // importante
    public Producto Producto { get; set; }
}

