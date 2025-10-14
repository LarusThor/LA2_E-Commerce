using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.Entities;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repositories.Data;
using ProductCatalog.Repositories.Interfaces;

namespace ProductCatalog.Repositories.Implementations;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly ProductCatalogDbContext _dbContext;

    public CategoriesRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<CategoryDto> GetCategories()
    {
        var query = _dbContext.Categories
            .Select(c => new CategoryDto()
            {
                id = c.id,
                name = c.name,
                description = c.description,
            });
        
        return query.ToList();
    }
    
    public async Task<bool> CreateCategory(CategoryInputModel category)
    {
        _dbContext.Categories.Add(new Category()
        {
            name = category.name,
            description = category.description,
        });
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateCategory(int id, CategoryInputModel category)
    {
        var entity = await _dbContext.Categories.FindAsync(id);
        if (entity == null) return false;

        entity.name = category.name;
        entity.description = category.description;
        
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteCategory(int id)
    {
        var entity = await _dbContext.Categories.FindAsync(id);
        if (entity != null)
        {
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}