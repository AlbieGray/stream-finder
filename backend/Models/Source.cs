using System.Text.Json.Serialization;

namespace StreamFinder.Api.Models;

public class Source
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public List<string> Regions { get; set; } = [];
    [JsonPropertyName("logo_100px")]
    public string? LogoUrl { get; set; }
}
