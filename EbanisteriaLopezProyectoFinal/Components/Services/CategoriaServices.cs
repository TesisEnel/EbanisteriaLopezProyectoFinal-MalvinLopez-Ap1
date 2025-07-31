using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class CategoriaServices(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<List<Categoria>> Listar(Expression<Func<Categoria, bool>> criterio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Categoria
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}