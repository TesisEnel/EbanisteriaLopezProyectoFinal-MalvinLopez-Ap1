using Supabase.Postgrest.Models; // Asegúrate de incluir este namespace
using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    // Heredamos de BaseModel para que sea compatible con Supabase
    public class CarritoItem
    {
        public Producto Producto { get; set; } = default!;
        public int Cantidad { get; set; }
    }

}
