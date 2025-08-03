using System.ComponentModel.DataAnnotations.Schema;

namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string CorreoUsuario { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string MetodoPago { get; set; } = string.Empty;
        public string? UrlVoucher { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public string EstadoEntrega { get; set; } = "Pedido recibido";

        public List<VentaItem> Items { get; set; } = new();

        // Nueva propiedad auxiliar solo para el componente
        [NotMapped]
        public string? NuevoEstadoEntrega { get; set; }
    }
}
