using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GatewayAPI.Services;

public class Auth0TokenService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public Auth0TokenService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string> GetAccessTokenAsync(string audience)
    {
        var request = new
        {
            client_id = _config["Auth0:ClientId"],
            client_secret = _config["Auth0:ClientSecret"],
            audience = audience,
            grant_type = "client_credentials"
        };

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_config["Auth0:Domain"]}/oauth/token", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("access_token").GetString();
    }
}