using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        return Ok(product);
    }
    
    [HttpPost]
    // Add authentication later?
    public IActionResult CreateArtist([FromBody] ProductInputModel product)
    {
        return Ok(product);
    }
    
    [HttpPut("{id}")]
    // Add authentication later?
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductInputModel product)
    {
        var ok = await _productService.UpdateProduct(id, product);
        if (!ok) return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    // Add authentication later?
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var success = await _productService.DeleteProduct(id);
        if (success == true)
        {
            return NoContent();
        }
        return NotFound();
    }
}