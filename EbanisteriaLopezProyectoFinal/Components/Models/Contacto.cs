namespace EbanisteriaLopezProyectoFinal.Components.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string HorarioSemana { get; set; } = string.Empty;
        public string HorarioSabado { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
