using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Entities;

namespace OrderManagement.Repositories.Data;

public class OrderManagementDbContext : DbContext
{
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(o => o.orderId);
    }
    
    public DbSet<Order> Orders { get; set;}

}
