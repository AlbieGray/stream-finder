using System.Text.Json.Serialization;

namespace StreamFinder.Api.Models;

public class TitleSource
{
    [JsonPropertyName("source_id")]
    public int SourceId { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public string Region { get; set; } = "";
    [JsonPropertyName("web_url")]
    public string? WebUrl { get; set; }
    [JsonPropertyName("android_url")]
    public string? AndroidUrl { get; set; }
    [JsonPropertyName("ios_url")]
    public string? IosUrl { get; set; }
    public string? Format { get; set; }
    public double? Price { get; set; }
    public string? Currency { get; set; }
}
