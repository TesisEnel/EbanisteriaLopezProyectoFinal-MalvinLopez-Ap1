using EbanisteriaLopezProyectoFinal.Components.Models;
public enum EstadoEntrega
{
    Pendiente,
    Confirmada,
    EnCamino,
    Entregada,
    Cancelada
}
public class Venta
{
    public int VentaId { get; set; }
    public string CorreoUsuario { get; set; } = string.Empty;
    public string NombreCliente { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string MetodoPago { get; set; } = string.Empty;
    public string? UrlVoucher { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    public List<VentaItem> Items { get; set; } = new();
}
