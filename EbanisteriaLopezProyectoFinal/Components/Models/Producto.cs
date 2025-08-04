using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "El color no puede exceder los 50 caracteres.")]
    public string Color { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El material no puede exceder los 100 caracteres.")]
    public string Material { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Las dimensiones no pueden exceder los 200 caracteres.")]
    public string Dimensiones { get; set; } = string.Empty;

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría.")]
    public int CategoriaId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado.")]
    public int EstadoProductoId { get; set; }

    public int Cantidad { get; set; }

    public Categoria? Categoria { get; set; }

    public EstadoProducto? EstadoProducto { get; set; }

    public ProductoDetalle? Detalle { get; set; }

    public ICollection<ImagenProducto>? Imagenes { get; set; }
}
