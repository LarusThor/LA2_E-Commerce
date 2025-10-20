using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using GatewayAPI.Services;

namespace GatewayAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly Auth0TokenService _tokenService;

    public ProductsController(HttpClient httpClient, IConfiguration config, Auth0TokenService tokenService)
    {
        _httpClient = httpClient;
        _config = config;
        _tokenService = tokenService;
    }

    [Authorize]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetProducts()
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync("http://productcatalogapi:8080/api/products");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductById(int id)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"http://productcatalogapi:8080/api/products/{id}");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] JsonElement product)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(product.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://productcatalogapi:8080/api/products", content);
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] JsonElement product)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(product.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://productcatalogapi:8080/api/products/{id}", content);
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:ProductCatalogAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.DeleteAsync($"http://productcatalogapi:8080/api/products/{id}");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }
}
