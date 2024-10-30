using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace ingrEZ;

public class Recipe
{
  [JsonPropertyName("name")]
  [Column(TypeName = "text")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("difficulty")]
  [Column(TypeName = "varchar(6)")]
  public string Difficulty { get; set; } = string.Empty;

  [JsonPropertyName("mealType")]
  [Column(TypeName = "varchar(9)")]
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

  public string ComputeHash()
  {
    var textBuilder = new StringBuilder();
    var sb = new StringBuilder();

    textBuilder.Append('[');
    for (var i = 0; i < ItemizedInstructions.Length; i++)
    {
      textBuilder.Append($"\"{ItemizedInstructions[i]}\"");
      if (i != ItemizedInstructions.Length - 1)
      {
        textBuilder.Append(',');
      }
    }
    textBuilder.Append(']');

    Console.WriteLine(textBuilder.ToString());

    using (var hash = SHA256.Create())
    {
      var result = hash.ComputeHash(Encoding.UTF8.GetBytes(textBuilder.ToString()));
      for (int i = 0; i < result.Length; i++)
        sb.Append(result[i].ToString("x2"));
    }
    return sb.ToString();
  }
}
