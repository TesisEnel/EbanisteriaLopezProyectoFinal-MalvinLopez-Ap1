using System.Text.Json.Serialization;

namespace EbanisteriaLopezProyectoFinal.Components.Models;

public class CarritoItem
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }

    [JsonIgnore]
    public Producto? Producto { get; set; }
}
