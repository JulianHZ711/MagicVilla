using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Nombre = "Vista Real",
                    Detalle = "Detalle de la Villa...",
                    Tarifa = 200,
                    ocupantes = 5,
                    MetrosCuadrados = 50,
                    ImagenUrl = "",
                    Amenidad = "",
                    FechaCreacion = System.DateTime.Now,
                    FechaActualizacion = System.DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Nombre = "Vista a la Piscibna",
                    Detalle = "Detalle de la Villa...",
                    Tarifa = 150,
                    ocupantes = 4,
                    MetrosCuadrados = 40,
                    ImagenUrl = "",
                    Amenidad = "",
                    FechaCreacion = System.DateTime.Now,
                    FechaActualizacion = System.DateTime.Now
                }
            );
        }


    }
}
