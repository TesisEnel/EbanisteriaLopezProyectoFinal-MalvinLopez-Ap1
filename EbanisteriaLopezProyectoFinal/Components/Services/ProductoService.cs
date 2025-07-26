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

    
    public async Task<List<Producto>> ListarTodos()
    {
        try
        {
            return await _context.Producto
                .Include(p => p.Imagenes)
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
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al obtener producto por ID: {ex.Message}");
            return null;
        }
    }

   
    public async Task<bool> Crear(Producto producto)
    {
        try
        {
            _context.Producto.Add(producto);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al crear producto: {ex.Message}");
            return false;
        }
    }

    
    public async Task<bool> Editar(Producto producto)
    {
        try
        {
            _context.Producto.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al editar producto: {ex.Message}");
            return false;
        }
    }

    
    public async Task<bool> Eliminar(int id)
    {
        try
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
                return false;

            _context.Producto.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al eliminar producto: {ex.Message}");
            return false;
        }
    }

   
    public async Task<bool> Guardar(Producto producto)
    {
        try
        {
            if (producto.ProductoId == 0)
            {
                _context.Producto.Add(producto);
            }
            else
            {
                _context.Producto.Update(producto);
            }

            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al guardar producto: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> AgregarImagen(ImagenProducto imagen)
    {
        try
        {
            var producto = await _context.Producto
                .Include(p => p.Imagenes)
                .FirstOrDefaultAsync(p => p.ProductoId == imagen.ProductoId);

            if (producto == null)
                return false;

            producto.Imagenes.Add(imagen);
            _context.Producto.Update(producto);

            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            
            Console.Error.WriteLine($"Error al agregar imagen: {ex.Message}");
            return false;
        }
    }
}
