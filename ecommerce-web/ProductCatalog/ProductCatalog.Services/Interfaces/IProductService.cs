using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts();
    
    ProductDto GetProductById(int id);
    
    Task<bool> CreateProduct(ProductInputModel product);
    
    Task<bool> UpdateProduct(int id, ProductInputModel product);
    
    Task<bool> DeleteProduct(int id);
}