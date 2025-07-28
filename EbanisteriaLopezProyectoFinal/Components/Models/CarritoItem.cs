using Supabase.Postgrest.Models; // Asegúrate de incluir este namespace
using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    // Heredamos de BaseModel para que sea compatible con Supabase
    public class CarritoItem : BaseModel
    {
        // Esta propiedad hace referencia al producto específico
        [Key]
        public int ProductoId { get; set; }

        // En lugar de tener la propiedad Producto directamente, se maneja con el ProductoId
        public Producto Producto { get; set; } = default!;

        // Cantidad del producto en el carrito
        public int Cantidad { get; set; } = 1;
    }
}
