using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService =  categoryService;
    }
    
    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _categoryService.GetCategories();
        return Ok(categories);
    }
    
    [HttpPost]
    // Add authentication later?
    public IActionResult CreateCategory([FromBody] CategoryInputModel category)
    {
        return Ok(category);
    }
    
    [HttpPut("{id}")]
    // Add authentication later?
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryInputModel category)
    {
        var ok = await _categoryService.UpdateCategory(id, category);
        if (!ok) return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    // Add authentication later?
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var success = await _categoryService.DeleteCategory(id);
        if (success == true)
        {
            return NoContent();
        }
        return NotFound();
    }
}