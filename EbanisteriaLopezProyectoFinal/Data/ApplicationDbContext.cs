using EbanisteriaLopezProyectoFinal.Components.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EbanisteriaLopezProyectoFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoDetalle> ProductoDetalle { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoProducto> EstadoProducto { get; set; }
        public DbSet<Cotizacion> Cotizacion { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<VentaItem> VentaItems { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Detalle)
                .WithOne(pd => pd.Producto)
                .HasForeignKey<ProductoDetalle>(pd => pd.ProductoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Imagenes)
                .WithOne(ip => ip.Producto)
                .HasForeignKey(ip => ip.ProductoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .IsRequired(false);

           
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
        }
    }
}