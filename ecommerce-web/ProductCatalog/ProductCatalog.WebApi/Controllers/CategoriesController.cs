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
    public async Task<IActionResult> CreateCategory([FromBody] CategoryInputModel category)
    {
        var result = await  _categoryService.CreateCategory(category);
        if (!result) return BadRequest();
        return Ok(category);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryInputModel category)
    {
        var ok = await _categoryService.UpdateCategory(id, category);
        if (!ok) return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
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