using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class CotizacionService(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<bool> Insertar(Cotizacion cotizacion)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Cotizacion.Add(cotizacion);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Cotizacion>> Listar()
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Cotizacion
            .Include(c => c.Producto)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> ContarCotizaciones()
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Cotizacion
            .CountAsync(c => !c.EstaResuelto); 
    }


    public async Task<Cotizacion?> Buscar(int id)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Cotizacion
            .Include(c => c.Producto)
            .ThenInclude(p => p.Imagenes)
            .FirstOrDefaultAsync(c => c.CotizacionId == id);
    }

    public async Task<bool> Actualizar(Cotizacion cotizacion)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Cotizacion.Update(cotizacion);
        return await contexto.SaveChangesAsync() > 0;
    }
   

}
