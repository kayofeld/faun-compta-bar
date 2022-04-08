using System.Text.Json.Serialization;

namespace FauntasticBack.Models;

public class Beverage
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("price_per_bottle")]
    public decimal PricePerBottle { get; set; }
}