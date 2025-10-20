using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using GatewayAPI.Services;

namespace GatewayAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly Auth0TokenService _tokenService;

    public CategoriesController(HttpClient httpClient, IConfiguration config, Auth0TokenService tokenService)
    {
        _httpClient = httpClient;
        _config = config;
        _tokenService = tokenService;
    }

    [Authorize]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetCategories()
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync("http://productcatalogapi:8080/api/categories");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] JsonElement category)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(category.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://productcatalogapi:8080/api/categories", content);
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] JsonElement category)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(category.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://productcatalogapi:8080/api/categories/{id}", content);
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.DeleteAsync($"http://productcatalogapi:8080/api/categories/{id}");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }
}
