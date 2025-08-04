using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EbanisteriaLopezProyectoFinal.Components.Services;



public class CategoriaServices(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<bool> Insertar(Categoria categoria)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Categoria.Add(categoria);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Categoria>> Listar()
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Categoria.AsNoTracking().ToListAsync();
    }

    public async Task<Categoria?> Buscar(int id)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Categoria
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CategoriaId == id);
    }

    public async Task<bool> Modificar(Categoria categoria)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Categoria.Update(categoria);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        var categoria = await contexto.Categoria.FindAsync(id);

        if (categoria is null)
            return false;

        contexto.Categoria.Remove(categoria);
        return await contexto.SaveChangesAsync() > 0;
    }
}
