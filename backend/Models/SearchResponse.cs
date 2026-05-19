using System.Text.Json.Serialization;

namespace StreamFinder.Api.Models;

public class SearchResponse
{
    [JsonPropertyName("title_results")]
    public List<SearchResult> Results { get; set; } = [];
}

public class SearchResult
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? Year { get; set; }
    public string? Poster { get; set; }
    public string Type { get; set; } = "";
    [JsonPropertyName("imdb_id")]
    public string? ImdbId { get; set; }
    [JsonPropertyName("tmdb_id")]
    public int? TmdbId { get; set; }
}
