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
    public async Task<IActionResult> CreateProduct([FromBody] ProductInputModel product)
    {
        var result = await _productService.CreateProduct(product);
        if (!result) return BadRequest();
        return Ok(product);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductInputModel product)
    {
        var success = await _productService.UpdateProduct(id, product); // ✅ await here
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var success = await _productService.DeleteProduct(id); // ✅ await here
        if (!success) return NotFound();
        return NoContent();
    }
}