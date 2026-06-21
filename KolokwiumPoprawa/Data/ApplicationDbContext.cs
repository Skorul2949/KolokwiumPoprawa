using Microsoft.EntityFrameworkCore;
using KolokwiumPoprawa.Entities;

namespace KolokwiumPoprawa.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDelivery> ProductDeliveries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}