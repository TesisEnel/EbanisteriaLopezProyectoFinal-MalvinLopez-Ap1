using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class CategoriaServices
{
    private readonly ApplicationDbContext _context;

    public CategoriaServices(ApplicationDbContext context)
    {
        _context = context;
    }

    // Listar todas o filtradas
    public async Task<List<Categoria>> Listar(Func<Categoria, bool> filtro)
    {
        return await Task.Run(() =>
            _context.Categoria
                .AsEnumerable()
                .Where(filtro)
                .ToList()
        );
    }

    // Insertar nueva categoría
    public async Task<bool> Insertar(Categoria categoria)
    {
        _context.Categoria.Add(categoria);
        return await _context.SaveChangesAsync() > 0;
    }

    // Buscar por ID
    public async Task<Categoria?> ObtenerPorId(int id)
    {
        return await _context.Categoria.FindAsync(id);
    }

    // Editar categoría
    public async Task<bool> Editar(Categoria categoria)
    {
        _context.Categoria.Update(categoria);
        return await _context.SaveChangesAsync() > 0;
    }

    // Eliminar categoría
    public async Task<bool> Eliminar(int id)
    {
        var categoria = await _context.Categoria.FindAsync(id);
        if (categoria == null)
            return false;

        _context.Categoria.Remove(categoria);
        return await _context.SaveChangesAsync() > 0;
    }
}
