namespace EbanisteriaLopezProyectoFinal.Components.Services
{
    using EbanisteriaLopezProyectoFinal.Components.Models;
    using System.Threading.Tasks;

    public interface IContactoService
    {
        Task EnviarFormularioAsync(ContactFormModel form);
    }

}