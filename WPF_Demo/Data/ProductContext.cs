using Microsoft.EntityFrameworkCore;

namespace WPF_Demo.Data;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Product>().HasData(GetProducts());
    }

    private Product[] GetProducts()
    {
        return new Product[]
        {
            new Product
            {
                Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1000, StockQuantity = 10
            },
            new Product
            {
                Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m,
                StockQuantity = 100
            },
            new Product
            {
                Id = 3, Name = "Tablet", Description = "Portable tablet with stylus support", Price = 499.99m,
                StockQuantity = 75
            }
        };
    }
}