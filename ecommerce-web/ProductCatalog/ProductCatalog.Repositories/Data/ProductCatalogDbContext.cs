using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models.Entities;

namespace ProductCatalog.Repositories.Data;

public class ProductCatalogDbContext : DbContext, IProductCatalogDbContext
{
    public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
        : base(options){}
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}