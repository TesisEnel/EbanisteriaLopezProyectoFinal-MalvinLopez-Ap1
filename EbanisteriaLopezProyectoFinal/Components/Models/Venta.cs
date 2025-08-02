using EbanisteriaLopezProyectoFinal.Components.Models;

public class Venta
{
    public int VentaId { get; set; }
    public string UsuarioId { get; set; }  // O la relación con un usuario
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public List<Producto> Productos { get; set; }  // Relación muchos a muchos
}
