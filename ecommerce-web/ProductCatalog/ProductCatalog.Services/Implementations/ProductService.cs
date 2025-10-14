using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductsRepository _productsRepository;

    public ProductService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
    
    public IEnumerable<ProductDto> GetProducts()
    {
        return _productsRepository.GetProducts();
    }

    public ProductDto GetProductById(int id)
    {
        return _productsRepository.GetProductById(id);
    }
    
    public Task<bool> CreateProduct(ProductInputModel product)
    {
        return _productsRepository.CreateProduct(product);
    }
    
    public Task<bool> UpdateProduct(int id, ProductInputModel product)
    {
        return _productsRepository.UpdateProduct(id, product);
    }
    
    public Task<bool> DeleteProduct(int id)
    {
        return _productsRepository.DeleteProduct(id);
    }
}