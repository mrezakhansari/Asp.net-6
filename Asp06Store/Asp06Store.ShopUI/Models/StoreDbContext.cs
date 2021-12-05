using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Asp06Store.ShopUI.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Category = "Mobile",
                    Name = "Xiaomi Redmi Note 11",
                    Description = "Fingerprint (side-mounted), unspecified sensors",
                    Price = 30_000_000
                },
                new Product
                {
                    Id = 2,
                    Category = "Mobile",
                    Name = "Apple iPhone 13 mini",
                    Description = "Face ID, accelerometer, gyro, proximity, compass, barometer",
                    Price = 50_000_000
                },
                new Product
                {
                    Id = 3,
                    Category = "Laptop",
                    Name = "Asus",
                    Description = "Fingerprint",
                    Price = 300_000_000
                },
                new Product
                {
                    Id = 4,
                    Category = "Laptop",
                    Name = "Dell",
                    Description = "Face ID",
                    Price = 500_000_000
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
