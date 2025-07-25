using System.ComponentModel.DataAnnotations;

namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    public class ImagenProducto
    {
        [Key]
        public int ImagenProductoId { get; set; }
        public string Url { get; set; } = string.Empty;
        public int Orden { get; set; } = 1;

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
