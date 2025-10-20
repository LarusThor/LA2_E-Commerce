using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models.Entities;

namespace ProductCatalog.Repositories.Data;

public interface IProductCatalogDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}