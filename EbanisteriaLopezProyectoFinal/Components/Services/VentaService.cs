using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class VentaService
{
    private readonly ApplicationDbContext _context;
    private readonly SupabaseStorageService _supabaseStorageService;
    private readonly ProductoService _productoService;

    public VentaService(
        ApplicationDbContext context,
        SupabaseStorageService supabaseStorageService,
        ProductoService productoService)
    {
        _context = context;
        _supabaseStorageService = supabaseStorageService;
        _productoService = productoService;
    }

    public async Task<string> SubirVoucher(IBrowserFile archivo)
    {
        var urls = await _supabaseStorageService.UploadFiles(new List<IBrowserFile> { archivo });
        return urls.FirstOrDefault() ?? string.Empty;
    }

    public async Task<bool> RegistrarVenta(Venta venta)
    {
        try
        {
            // Validar stock disponible antes de guardar
            foreach (var item in venta.Items)
            {
                var producto = await _context.Producto.FindAsync(item.ProductoId);
                if (producto == null || producto.Cantidad < item.Cantidad)
                {
                    Console.WriteLine($"No hay suficiente inventario para el producto ID {item.ProductoId}");
                    return false;
                }
            }

            // Registrar la venta
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            // Descontar inventario
            foreach (var item in venta.Items)
            {
                await _productoService.DescontarInventarioAsync(item.ProductoId, item.Cantidad);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar venta: {ex.Message}");
            Console.WriteLine(ex.InnerException?.Message); // Muestra más detalle si hay
            return false;
        }
    }

    public async Task<List<Venta>> Listar()
    {
        return await _context.Ventas
            .Include(v => v.Items)
            .ToListAsync();
    }

    public async Task<int> ContarVentasAsync()
    {
        return await _context.Ventas.CountAsync();
    }

    public async Task<List<Venta>> ObtenerVentasPorCorreoAsync(string correo)
    {
        return await _context.Ventas
            .Include(v => v.Items)
            .Where(v => v.CorreoUsuario == correo)
            .ToListAsync();
    }

    // Versión que acepta string
    public async Task ActualizarEstadoEntregaAsync(int ventaId, string nuevoEstado)
    {
        var venta = await _context.Ventas.FindAsync(ventaId);
        if (venta != null)
        {
            venta.EstadoEntrega = nuevoEstado;
            await _context.SaveChangesAsync();
        }
    }

  
}
