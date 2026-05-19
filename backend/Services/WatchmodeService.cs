using System.Net;
using System.Text.Json;
using StreamFinder.Api.Models;

namespace StreamFinder.Api.Services;

public class WatchmodeService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;
    private readonly ILogger<WatchmodeService> _logger;

    public WatchmodeService(HttpClient http, IConfiguration config, ILogger<WatchmodeService> logger)
    {
        _http = http;
        _config = config;
        _logger = logger;
    }

    private string ApiKey =>
        _config["WATCHMODE_API_KEY"]
        ?? throw new InvalidOperationException("WATCHMODE_API_KEY is not configured.");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    private const string BaseUrl = "https://api.watchmode.com/v1";

    public async Task<List<SearchResult>> SearchAsync(string query)
    {
        var url = $"{BaseUrl}/search/?apiKey={ApiKey}&search_field=name&search_value={WebUtility.UrlEncode(query)}&types=movie,tv_series";
	Console.WriteLine(url);
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SearchResponse>(json, JsonOptions);

        if (result?.Results != null)
        {
            foreach (var r in result.Results)
            {
                r.Poster ??= $"https://cdn.watchmode.com/posters/{r.Id:D8}_poster_w185.jpg";
            }
        }

        return result?.Results ?? [];
    }

    public async Task<TitleDetail?> GetTitleDetailAsync(int id)
    {
        var url = $"{BaseUrl}/title/{id}/details/?apiKey={ApiKey}";
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TitleDetail>(json, JsonOptions);
    }

    public async Task<List<TitleSource>> GetTitleSourcesAsync(int id, string? region = null)
    {
        var url = $"{BaseUrl}/title/{id}/sources/?apiKey={ApiKey}";
        if (!string.IsNullOrWhiteSpace(region))
            url += $"&regions={region}";

        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<TitleSource>>(json, JsonOptions) ?? [];
    }

    public async Task<List<Source>> GetSourcesAsync()
    {
        var url = $"{BaseUrl}/sources/?apiKey={ApiKey}";
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Source>>(json, JsonOptions) ?? [];
    }

    public async Task<List<Region>> GetRegionsAsync()
    {
        var url = $"{BaseUrl}/regions/?apiKey={ApiKey}";
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Region>>(json, JsonOptions) ?? [];
    }
}
