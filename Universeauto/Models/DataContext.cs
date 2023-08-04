using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Universeauto.Models;

namespace Universeauto.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
   
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Other configuration settings
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Cars)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);
        }

    }
}
