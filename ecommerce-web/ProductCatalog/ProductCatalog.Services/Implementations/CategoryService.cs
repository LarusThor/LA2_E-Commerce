using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoryService(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public IEnumerable<CategoryDto> GetCategories()
    {
        return _categoriesRepository.GetCategories();
    }

    public Task<bool> CreateCategory(CategoryInputModel category)
    {
        return _categoriesRepository.CreateCategory(category);
    }

    public Task<bool> UpdateCategory(int id, CategoryInputModel category)
    {
        return _categoriesRepository.UpdateCategory(id, category);
    }

    public Task<bool> DeleteCategory(int id)
    {
        return _categoriesRepository.DeleteCategory(id);
    }
}