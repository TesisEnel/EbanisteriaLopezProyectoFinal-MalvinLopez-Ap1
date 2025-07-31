using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class ProductoDetalle
{
    public int ProductoDetalleId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El material no puede exceder los 100 caracteres.")]
    public string? Material { get; set; }

    [StringLength(50, ErrorMessage = "El color no puede exceder los 50 caracteres.")]
    public string? Color { get; set; }

    [StringLength(200, ErrorMessage = "Las dimensiones no pueden exceder los 200 caracteres.")]
    public string? Dimensiones { get; set; }

    [Required]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }
}
