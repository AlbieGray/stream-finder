using System.Text.Json.Serialization;

namespace StreamFinder.Api.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = "";
}
