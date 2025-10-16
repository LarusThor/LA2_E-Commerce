using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.Entities;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repositories.Data;
using ProductCatalog.Repositories.Interfaces;

namespace ProductCatalog.Repositories.Implementations;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductCatalogDbContext _dbContext;

    public ProductsRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ProductDto> GetProducts()
    {
        var query = _dbContext.Products
            .Select(p => new ProductDto()
            {
                id = p.id,
                name = p.name,
                description = p.description,
                price = p.price,
                categoryId = p.categoryId
            });
        
        return query.ToList();
    }

    public ProductDto GetProductById(int id)
    {
        var products = _dbContext.Products
            .FirstOrDefault(p => p.id == id);
        
        var product = new ProductDto()
        {
            id = products.id,
            name = products.name,
            description = products.description,
            price = products.price,
            categoryId = products.categoryId
        };

        return product;
    }
    
    public async Task<bool> CreateProduct(ProductInputModel product)
    {
        _dbContext.Products.Add(new Product()
        {
            // Handle ID incrementation
            name = product.name,
            description = product.description,
            price = product.price,
            categoryId = product.categoryId
        });
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateProduct(int id, ProductInputModel product)
    {
        var entity = await _dbContext.Products.FindAsync(id);
        if (entity == null) return false;

        entity.name = product.name;
        entity.description = product.description;
        entity.price = product.price;
        entity.categoryId = product.categoryId;

        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteProduct(int id)
    {
        var entity = await _dbContext.Products.FindAsync(id);
        if (entity != null)
        {
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
}