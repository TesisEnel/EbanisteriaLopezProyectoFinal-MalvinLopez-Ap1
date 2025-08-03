using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class Servicio
{
    [Key]
    public int ServicioId { get; set; }

    [Required(ErrorMessage = "El título es requerido")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es requerida")]
    public string Descripcion { get; set; } = string.Empty;

    public string? Icono { get; set; }
}
