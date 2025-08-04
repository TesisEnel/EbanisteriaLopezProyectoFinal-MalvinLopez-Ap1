using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    public List<Producto> Productos { get; set; } = new();
}
