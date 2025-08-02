 using EbanisteriaLopezProyectoFinal.Components.Models;
    

namespace EbanisteriaLopezProyectoFinal.Components.Services;



public class ContactoService : IContactoService
{
    public async Task EnviarFormularioAsync(ContactFormModel form)
    {
        await Task.Delay(500);

        Console.WriteLine("📬 Nuevo mensaje de contacto recibido:");
        Console.WriteLine($"Nombre: {form.FirstName} {form.LastName}");
        Console.WriteLine($"Correo: {form.Email}");
        Console.WriteLine($"Teléfono: {form.Phone}");
        Console.WriteLine($"Mensaje: {form.Message}");

       
    }
}
