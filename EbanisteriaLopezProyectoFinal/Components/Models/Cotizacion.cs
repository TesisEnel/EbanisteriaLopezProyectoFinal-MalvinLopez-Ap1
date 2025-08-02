using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class Cotizacion
{
    [Key]
    public int CotizacionId { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Correo { get; set; } = string.Empty;

    [Required]
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }
    public bool EstaResuelto { get; set; } = false;


    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
}
