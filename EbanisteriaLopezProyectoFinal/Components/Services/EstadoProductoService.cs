using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class EstadoProductoService(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<bool> Insertar(EstadoProducto estado)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.EstadoProducto.Add(estado);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<EstadoProducto>> Listar()
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.EstadoProducto.AsNoTracking().ToListAsync();
    }

    public async Task<EstadoProducto?> Buscar(int id)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.EstadoProducto
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EstadoProductoId == id);
    }

    public async Task<bool> Modificar(EstadoProducto estado)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.EstadoProducto.Update(estado);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        var estado = await contexto.EstadoProducto.FindAsync(id);

        if (estado is null)
            return false;

        contexto.EstadoProducto.Remove(estado);
        return await contexto.SaveChangesAsync() > 0;
    }
}
