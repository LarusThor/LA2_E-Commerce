using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Entities;

namespace OrderManagement.Repositories.Data;

public class OrderManagementDbContext : DbContext, IOrderManagementDbContext
{
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=ecommerce;Username=postgres;Password=postgres");
    }

    public DbSet<Order> Orders { get; set;}

}
