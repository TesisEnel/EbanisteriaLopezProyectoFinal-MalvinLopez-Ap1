using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class ContactoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
{
    public async Task<Contacto> ObtenerAsync()
    {
        await using var contexto = await dbContextFactory.CreateDbContextAsync();
        return await contexto.Contactos.FirstOrDefaultAsync() ?? new Contacto();
    }

    public async Task<bool> GuardarAsync(Contacto contacto)
    {
        await using var contexto = await dbContextFactory.CreateDbContextAsync();

        var existente = await contexto.Contactos.FirstOrDefaultAsync();

        if (existente is null)
        {
            contexto.Contactos.Add(contacto);
        }
        else
        {
            existente.Email = contacto.Email;
            existente.Telefono = contacto.Telefono;
            existente.HorarioSemana = contacto.HorarioSemana;
            existente.HorarioSabado = contacto.HorarioSabado;
            existente.Descripcion = contacto.Descripcion;
            contexto.Contactos.Update(existente);
        }

        return await contexto.SaveChangesAsync() > 0;
    }
}
