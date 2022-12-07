using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=RentACar2021;Username=postgres;Password=postgre84,SQL43");
        }

        public DbSet<Car> cars { get; set; }    // <-- Postgre'de tablo ismini PascalCase Cars yaptığımda sorun çıkardı!
        public DbSet<Brand> brands { get; set; }
        public DbSet<Color> colors { get; set; } 
    }
}
