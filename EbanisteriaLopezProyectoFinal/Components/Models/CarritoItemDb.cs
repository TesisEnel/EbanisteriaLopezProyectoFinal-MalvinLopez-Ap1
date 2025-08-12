namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    public class CarritoItemDb
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; } // FK al usuario
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public Producto? Producto { get; set; }
    }

}
