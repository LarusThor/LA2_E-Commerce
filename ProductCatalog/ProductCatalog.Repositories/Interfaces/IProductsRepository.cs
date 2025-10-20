using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Repositories.Interfaces;

public interface IProductsRepository
{
    public IEnumerable<ProductDto> GetProducts();
    
    public ProductDto GetProductById(int id);
    
    public Task<bool> CreateProduct(ProductInputModel product);
    
    public Task<bool> UpdateProduct(int id, ProductInputModel product);
    
    public Task<bool> DeleteProduct(int id);
}