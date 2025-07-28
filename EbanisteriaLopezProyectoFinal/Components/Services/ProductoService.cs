using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class ProductoServices
{
    private readonly ApplicationDbContext _context;

    public ProductoServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int productoId)
    {
        return await _context.Producto.AnyAsync(p => p.ProductoId == productoId);
    }

    // Insertar un nuevo producto con su detalle
    public async Task<bool> Insertar(Producto producto)
    {
        // Establecer la relación para que EF la detecte correctamente
        if (producto.Detalle != null)
        {
            producto.Detalle.Producto = producto;
        }

        _context.Producto.Add(producto);
        return await _context.SaveChangesAsync() > 0;
    }


    public async Task<bool> Modificar(Producto producto)
    {
        _context.Producto.Update(producto);

        if (producto.Detalle != null)
        {
            var detalleExistente = await _context.ProductoDetalle
                .FirstOrDefaultAsync(d => d.ProductoId == producto.ProductoId);

            if (detalleExistente != null)
            {
                detalleExistente.Descripcion = producto.Detalle.Descripcion;
                detalleExistente.Material = producto.Detalle.Material;
                detalleExistente.Color = producto.Detalle.Color;
                detalleExistente.Dimensiones = producto.Detalle.Dimensiones;

                _context.ProductoDetalle.Update(detalleExistente);
            }
            else
            {
                producto.Detalle.ProductoId = producto.ProductoId;
                _context.ProductoDetalle.Add(producto.Detalle);
            }
        }

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Producto producto)
    {
        if (await Existe(producto.ProductoId))
        {
            return await Modificar(producto);
        }
        else
        {
            return await Insertar(producto);
        }
    }

    public async Task<List<Producto>> ListarTodos()
    {
        try
        {
            return await _context.Producto
                .Include(p => p.Imagenes)
                .Include(p => p.Detalle)
                .Include(p => p.Categoria)
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error al listar productos: {ex.Message}");
            return new List<Producto>();
        }
    }

    public async Task<List<Producto>> Listar(Func<Producto, bool> filtro)
    {
        try
        {
            return await Task.Run(() =>
                _context.Producto
                    .Include(p => p.Imagenes)
                    .Include(p => p.Detalle)
                    .Include(p => p.Categoria)
                    .AsEnumerable()
                    .Where(filtro)
                    .ToList()
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error al listar productos con filtro: {ex.Message}");
            return new List<Producto>();
        }
    }

    public async Task<Producto?> ObtenerPorId(int id)
    {
        try
        {
            return await _context.Producto
                .Include(p => p.Imagenes)
                .Include(p => p.Detalle)
                .Include(p => p.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error al obtener producto por ID: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        try
        {
            return await _context.Producto
                .Where(p => p.ProductoId == id)
                .ExecuteDeleteAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error al eliminar producto: {ex.Message}");
            return false;
        }
    }

    public async Task<List<Producto>> GetUltimosProductosAsync(int cantidad)
    {
        return await _context.Producto
            .Include(p => p.Imagenes)
            .Include(p => p.Detalle)
            .Include(p => p.Categoria)
            .OrderByDescending(p => p.ProductoId)
            .Take(cantidad)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> AgregarImagen(ImagenProducto imagen)
    {
        _context.ImagenProducto.Add(imagen);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Producto?> BuscarPorId(int id)
    {
        return await _context.Producto.FirstOrDefaultAsync(p => p.ProductoId == id);
    }

}
