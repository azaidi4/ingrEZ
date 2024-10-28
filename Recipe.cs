using System.Text.Json.Serialization;

namespace ingrEZ;

public class Recipe
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("difficulty")]
  public string Difficulty { get; set; } = string.Empty;

  [JsonPropertyName("mealType")]
  public string MealType { get; set; } = string.Empty;

  [JsonPropertyName("servingSize")]
  public int ServingSize { get; set; }

  [JsonPropertyName("preperationTime")]
  public int PreperationTime { get; set; }

  [JsonPropertyName("ingredients")]
  public string[] Ingredients { get; set; } = [];

  [JsonPropertyName("itemizedInstructions")]
  public string[] ItemizedInstructions { get; set; } = [];

  [JsonPropertyName("suggestions")]
  public string[]? Suggestions { get; set; }
}
