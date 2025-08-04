using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class ServicioService(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<bool> Existe(int servicioId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Servicio.AnyAsync(s => s.ServicioId == servicioId);
    }

    public async Task<bool> Insertar(Servicio servicio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Servicio.Add(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Servicio servicio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Servicio.Update(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Servicio servicio)
    {
        if (await Existe(servicio.ServicioId))
            return await Modificar(servicio);
        return await Insertar(servicio);
    }

    public async Task<Servicio?> Buscar(int servicioId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Servicio.AsNoTracking().FirstOrDefaultAsync(s => s.ServicioId == servicioId);
    }

    public async Task<List<Servicio>> Listar(Expression<Func<Servicio, bool>> criterio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Servicio.Where(criterio).AsNoTracking().ToListAsync();
    }

    public async Task<bool> Eliminar(int servicioId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Servicio.Where(s => s.ServicioId == servicioId).ExecuteDeleteAsync() > 0;
    }
}
