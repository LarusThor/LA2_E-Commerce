using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Repositories.Interfaces;

public interface ICategoriesRepository
{
    public IEnumerable<CategoryDto> GetCategories();
    
    public Task<bool> CreateCategory(CategoryInputModel category);
    
    public Task<bool> UpdateCategory(int id, CategoryInputModel category);
    
    public Task<bool> DeleteCategory(int id);
}