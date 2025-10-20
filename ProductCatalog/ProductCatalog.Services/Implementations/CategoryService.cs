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

    public async Task<bool> CreateCategory(CategoryInputModel category)
    {
        return await _categoriesRepository.CreateCategory(category);
    }

    public async Task<bool> UpdateCategory(int id, CategoryInputModel category)
    {
        return await _categoriesRepository.UpdateCategory(id, category);
    }

    public async Task<bool> DeleteCategory(int id)
    {
        return await _categoriesRepository.DeleteCategory(id);
    }
}