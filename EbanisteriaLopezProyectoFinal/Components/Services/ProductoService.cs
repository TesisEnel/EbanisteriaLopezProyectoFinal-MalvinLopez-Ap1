using EbanisteriaLopezProyectoFinal.Components.Models;
using EbanisteriaLopezProyectoFinal.Data;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EbanisteriaLopezProyectoFinal.Components.Services;

public class ProductoService(IDbContextFactory<ApplicationDbContext> DbContext)
{
    public async Task<bool> Existe(int PropiedadId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Producto.AnyAsync(p => p.ProductoId == PropiedadId);
    }

    public async Task<bool> Insertar(Producto producto)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();

        contexto.Producto.Add(producto);

        if (producto.Detalle != null)
        {
            producto.Detalle.ProductoId = producto.ProductoId;
            contexto.ProductoDetalle.Add(producto.Detalle);
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Producto producto)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();

        contexto.Producto.Update(producto);

        if (producto.Detalle != null)
        {
            var detalleExistente = await contexto.ProductoDetalle
                .FirstOrDefaultAsync(d => d.ProductoId == producto.ProductoId);

            if (detalleExistente != null)
            {
                detalleExistente.Descripcion = producto.Detalle.Descripcion;
                detalleExistente.Material = producto.Detalle.Material;
                detalleExistente.Color = producto.Detalle.Color;
                detalleExistente.Dimensiones = producto.Detalle.Dimensiones;

                contexto.ProductoDetalle.Update(detalleExistente);
            }
            else
            {
                producto.Detalle.ProductoId = producto.ProductoId;
                contexto.ProductoDetalle.Add(producto.Detalle);
            }
        }

        return await contexto.SaveChangesAsync() > 0;
    }

   public async Task<bool> Guardar(Producto producto)
{
    if (await Existe(producto.ProductoId))
    {
        return await Modificar(producto); // ✔️ usar la variable
    }
    else
    {
        return await Insertar(producto); // ✔️ usar la variable
    }
}


    public async Task<Producto?> Buscar(int ProductoId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Producto
            .Include(p => p.Detalle)
            .Include(i => i.Imagenes)
            .Include(c => c.Categoria)
            .Include(e => e.EstadoProducto)
            
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductoId == ProductoId);
    }

    public async Task<bool> Eliminar(int productoId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Producto
            .Where(p => p.ProductoId == productoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Producto
            .Include(p => p.Detalle)
            .Include(i => i.Imagenes)
            .Include(c => c.Categoria)
            .Include(e => e.EstadoProducto)
            
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Producto>> GetUltimasPropiedadesAsync(int cantidad)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Producto
            .Include(p => p.Detalle)
            .Include(p => p.Imagenes)
            .Include(p => p.Categoria)
            .Include(p => p.EstadoProducto)
       
            
            .Take(cantidad)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> AgregarImagen(ImagenProducto imagen)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();

        var propiedadExiste = await contexto.Producto.AnyAsync(p => p.ProductoId == imagen.ProductoId);

        if (!propiedadExiste)
        {
            return false;
        }

        contexto.ImagenProducto.Add(imagen);

        return await contexto.SaveChangesAsync() > 0;
    }
}