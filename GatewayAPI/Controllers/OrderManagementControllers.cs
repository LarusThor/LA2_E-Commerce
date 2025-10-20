using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using GatewayAPI.Services;

namespace GatewayAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly Auth0TokenService _tokenService;

    public OrdersController(HttpClient httpClient, IConfiguration config, Auth0TokenService tokenService)
    {
        _httpClient = httpClient;
        _config = config;
        _tokenService = tokenService;
    }

    [Authorize]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetOrders()
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:OrderManagementAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync("http://ordermanagementapi:8080/api/orders");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:OrderManagementAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"http://ordermanagementapi:8080/api/orders/{id}");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] JsonElement order)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:OrderManagementAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(order.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://ordermanagementapi:8080/api/orders", content);
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }

    [Authorize]
    [HttpGet("users/{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetOrderForUser(string username)
    {
        var token = await _tokenService.GetAccessTokenAsync(_config["Auth0:OrderManagementAudience"]);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"http://ordermanagementapi:8080/api/orders/users/{username}");
        var body = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, body);
    }
}
