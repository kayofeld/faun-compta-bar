using System.Text.Json;
using FauntasticBack.Models;

namespace FauntasticBack.Services;

public class BeverageService
{
    public Beverage[]? GetBeverages()
    {
        var json = File.ReadAllText("beverages.json");
        return JsonSerializer.Deserialize<Beverage[]>(json);
    }
}