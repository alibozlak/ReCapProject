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

        public DbSet<Car> Cars { get; set; }   
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("cars");
            modelBuilder.Entity<Car>().Property(c => c.CarId).HasColumnName("car_id");
            modelBuilder.Entity<Car>().Property(c => c.BrandId).HasColumnName("brand_id");
            modelBuilder.Entity<Car>().Property(c => c.ColorId).HasColumnName("color_id");
            modelBuilder.Entity<Car>().Property(c => c.ModelYear).HasColumnName("model_year");
            modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("daily_price");
            modelBuilder.Entity<Car>().Property(c => c.Description).HasColumnName("discription");

            modelBuilder.Entity<Brand>().ToTable("brands");
            modelBuilder.Entity<Brand>().Property(b => b.BrandId).HasColumnName("brand_id");
            modelBuilder.Entity<Brand>().Property(b => b.BrandName).HasColumnName("brand_name");

            modelBuilder.Entity<Color>().ToTable("colors");
            modelBuilder.Entity<Color>().Property(c => c.ColorId).HasColumnName("color_id");
            modelBuilder.Entity<Color>().Property(c => c.ColorName).HasColumnName("color_name");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("last_name");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password");

            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(c => c.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Customer>().Property(c => c.CompanyName).HasColumnName("company_name");

            modelBuilder.Entity<Rental>().ToTable("rentals");
            modelBuilder.Entity<Rental>().Property(r => r.RentalId).HasColumnName("rental_id");
            modelBuilder.Entity<Rental>().Property(r => r.CarId).HasColumnName("car_id");
            modelBuilder.Entity<Rental>().Property(r => r.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Rental>().Property(r => r.RentDate).HasColumnName("rent_date");
            modelBuilder.Entity<Rental>().Property(r => r.ReturnDate).HasColumnName("return_date");
        }
    }
}
