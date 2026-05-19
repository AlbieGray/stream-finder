using System.Text.Json.Serialization;

namespace StreamFinder.Api.Models;

public class TitleDetail
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? Year { get; set; }
    [JsonPropertyName("runtime_minutes")]
    public int? RuntimeMinutes { get; set; }
    [JsonPropertyName("plot_overview")]
    public string? PlotOverview { get; set; }
    public string? Poster { get; set; }
    public string? Backdrop { get; set; }
    [JsonPropertyName("imdb_id")]
    public string? ImdbId { get; set; }
    [JsonPropertyName("tmdb_id")]
    public int? TmdbId { get; set; }
    [JsonPropertyName("genre_names")]
    public List<string>? Genres { get; set; }
    [JsonPropertyName("user_rating")]
    public double? UserRating { get; set; }
    [JsonPropertyName("critic_score")]
    public double? CriticScore { get; set; }
    public string Type { get; set; } = "";
    [JsonPropertyName("relevance_percentile")]
    public double? RelevancyScore { get; set; }
}
