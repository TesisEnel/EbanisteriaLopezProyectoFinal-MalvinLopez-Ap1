using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models;


public class CarritoItem
{
    [Key]
    public Producto Producto { get; set; } = default!;
    public int Cantidad { get; set; } = 1;
}
