using EbanisteriaLopezProyectoFinal.Components.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoDetalle> ProductoDetalle { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoProducto> EstadoProducto { get; set; }

    }



}
