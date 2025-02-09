using Microsoft.EntityFrameworkCore;
using CRUD.WebApp.Models;

namespace CRUD.WebApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>(tb =>  {
                tb.HasKey(col => col.Idusuario);
                tb.Property(col => col.Idusuario)
                .UseIdentityColumn();

                tb.Property(col => col.Nombre).HasMaxLength(30);
                tb.Property(col => col.CorreoElectronico).HasMaxLength(30);
            });

            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
        }
    }
}
