using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;


namespace ingrEZ.Models;

public class Recipe
{
  public int Id { get; set; }

  [Required]
  public DateTime? PinnedDate { get; set; }

  [Column(TypeName = "text")]
  public string Hash { get; set; } = string.Empty;

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
    var sb = new StringBuilder();
    var result = MD5.HashData(Encoding.UTF8.GetBytes(ToString()));

    for (int i = 0; i < result.Length; i++)
    {
      sb.Append(result[i].ToString("x2"));
    }

    return sb.ToString();
  }

  public override string ToString()
  {
    var sb = new StringBuilder();

    // Ingredients
    sb.Append('[');
    for (var i = 0; i < Ingredients.Length; i++)
    {
      sb.Append($"\"{Ingredients[i]}\"");
      if (i != Ingredients.Length - 1)
      {
        sb.Append(',');
      }
    }
    sb.Append(']');

    // ItemizedInstructions
    sb.Append('[');
    for (var i = 0; i < ItemizedInstructions.Length; i++)
    {
      sb.Append($"\"{ItemizedInstructions[i]}\"");
      if (i != ItemizedInstructions.Length - 1)
      {
        sb.Append(',');
      }
    }
    sb.Append(']');

    return sb.ToString();
  }
}