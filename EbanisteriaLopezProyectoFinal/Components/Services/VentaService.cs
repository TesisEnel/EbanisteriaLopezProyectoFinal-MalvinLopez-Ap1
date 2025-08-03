using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class VentaService
{
    private readonly ApplicationDbContext _context;
    private readonly SupabaseStorageService _supabaseStorageService;

    public VentaService(ApplicationDbContext context, SupabaseStorageService supabaseStorageService)
    {
        _context = context;
        _supabaseStorageService = supabaseStorageService;
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
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
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

}
