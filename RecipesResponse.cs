using System.Text.Json;
using System.Text.Json.Serialization;

namespace ingrEZ;

public static class MockResponse
{
  private static Random random = new();
  private static readonly string[] jsonString =
  [
    """
    {
      "candidates": [
        {
          "content": {
            "parts": [
              {
                "text": "{\"recipes\": [{\"difficulty\": \"Easy\", \"ingredients\": [\"Chicken\", \"Rice\", \"Carrots\", \"String beans\", \"Curry powder\"], \"itemizedInstructions\": [\"Dice chicken into bite-sized pieces.\", \"Steam rice until cooked.\", \"Cut carrots and string beans into small pieces.\", \"Stir-fry chicken with carrots and string beans.\", \"Add curry powder to taste.\", \"Serve chicken and vegetables over rice\"], \"mealType\": \"Lunch\", \"name\": \"Curried Chicken with Rice and Vegetables\", \"servingSize\": 4, \"preperationTime\": 30}, {\"difficulty\": \"Medium\", \"ingredients\": [\"Chicken\", \"Rice\", \"Egg\", \"Brown Sugar\", \"Sriracha\"], \"itemizedInstructions\": [\"Marinate chicken in a mixture of brown sugar and sriracha.\", \"Grill or bake chicken until cooked through.\", \"Scramble eggs.\", \"Serve chicken with rice and scrambled eggs.\", \"Drizzle remaining sriracha-brown sugar marinade over chicken and rice\"], \"mealType\": \"Dinner\", \"name\": \"Sweet and Spicy Chicken with Rice and Eggs\", \"servingSize\": 4, \"preperationTime\": 45}, {\"difficulty\": \"Easy\", \"ingredients\": [\"Chicken\", \"Rice\", \"Egg\", \"Carrots\"], \"itemizedInstructions\": [\"Boil or steam rice until cooked.\", \"Shred or dice cooked chicken.\", \"Whisk eggs and cook into an omelet or scrambled eggs.\", \"Dice carrots.\", \"Mix rice, chicken, eggs, and carrots together.\", \"Serve hot or cold\"], \"mealType\": \"Lunch\", \"name\": \"Chicken and Rice Salad\", \"servingSize\": 4, \"preperationTime\": 25}, {\"difficulty\": \"Medium\", \"ingredients\": [\"Chicken\", \"Rice\", \"Carrots\", \"String beans\", \"Sugar\"], \"itemizedInstructions\": [\"Steam rice until cooked.\", \"Cut chicken into small pieces.\", \"Sauté carrots and string beans with a little sugar.\", \"Stir-fry chicken with the vegetables.\", \"Serve chicken and vegetables over rice\"], \"mealType\": \"Dinner\", \"name\": \"Stir-fried Chicken and Vegetables with Rice\", \"servingSize\": 2, \"preperationTime\": 40}, {\"difficulty\": \"Easy\", \"ingredients\": [\"Chicken\", \"Rice\", \"Egg\"], \"itemizedInstructions\": [\"Dice chicken into bite-sized pieces.\", \"Scramble eggs with diced chicken.\", \"Steam rice until cooked.\", \"Serve scrambled eggs and chicken over rice\"], \"mealType\": \"Lunch\", \"name\": \"Chicken and Egg Scramble with Rice\", \"servingSize\": 2, \"preperationTime\": 20}]}\n"
              }
            ],
            "role": "model"
          },
          "finishReason": "STOP",
          "avgLogprobs": -0.15371185800303583
        }
      ],
      "usageMetadata": {
        "promptTokenCount": 98,
        "candidatesTokenCount": 552,
        "totalTokenCount": 650
      },
      "modelVersion": "gemini-1.5-pro-002"
    }
    """,
    """
      {
    "candidates": [
      {
        "content": {
          "parts": [
            {
              "text": "{\"recipes\": [{\"difficulty\": \"Easy\", \"ingredients\": [\"Beef\", \"Rice\", \"Egg\"], \"itemizedInstructions\": [\"Cook rice according to package directions.\", \"While rice cooks, brown ground beef in a skillet. Drain excess fat.\", \"Push beef to one side of the skillet and fry an egg to your liking.\", \"Serve beef, egg, and rice together. Season with salt and pepper to taste if needed\"], \"mealType\": \"Breakfast\", \"name\": \"Beef, Egg, and Rice Bowl\", \"servingSize\": 1, \"preperationTime\": 20}, {\"difficulty\": \"Easy\", \"ingredients\": [\"Beef\", \"Lettuce\"], \"itemizedInstructions\": [\"If using ground beef, brown it thoroughly and drain the excess fat.\", \"Chop or shred your lettuce while the beef cooks\", \"Combine beef and lettuce\", \"Serve and season with desired dressing and toppings\"], \"mealType\": \"Lunch\", \"name\": \"Beef and Lettuce Salad\", \"servingSize\": 1, \"preperationTime\": 15}, {\"difficulty\": \"Medium\", \"ingredients\": [\"Beef\", \"Rice\", \"Egg\", \"Lettuce\"], \"itemizedInstructions\": [\"Prepare rice according to package directions.\", \"Cook ground beef until browned, then drain off excess fat.\", \"Scramble eggs in a separate pan.\", \"Chop lettuce into bite-sized pieces.\", \"Combine cooked rice, ground beef, scrambled eggs, and chopped lettuce in a bowl.\", \"Serve warm and optionally dress with your favorite dressing and toppings\"], \"mealType\": \"Dinner\", \"name\": \"Beef, Rice, Egg, and Lettuce Bowl\", \"servingSize\": 1, \"preperationTime\": 25}, {\"difficulty\": \"Easy\", \"ingredients\": [\"Beef\", \"Egg\"], \"itemizedInstructions\": [\"Cook ground beef until browned and drain excess fat.\", \"Crack eggs into the pan with the cooked beef.\", \" Scramble the eggs with the beef, breaking the yolks and mixing everything together.\", \"Cook until eggs are set but still moist.\", \"Season with salt and pepper to taste and serve\"], \"mealType\": \"Dinner\", \"name\": \"Scrambled Eggs with Beef\", \"servingSize\": 1, \"preperationTime\": 15}, {\"difficulty\": \"Medium\", \"ingredients\": [\"Beef\", \"Rice\", \"Egg\"], \"itemizedInstructions\": [\"Cook rice according to package directions.\", \"While rice is cooking, brown ground beef in a skillet over medium heat. Drain excess fat.\", \"In a separate bowl, whisk eggs with a splash of milk or water. Season with salt and pepper.\", \"Once beef is cooked, pour the egg mixture into the skillet. Cook until eggs are set but still slightly moist, stirring occasionally.\", \"Serve the beef and egg mixture over rice\"], \"mealType\": \"Lunch\", \"name\": \"Beef and Egg Scramble with Rice\", \"servingSize\": 1, \"preperationTime\": 25}]}\n"
            }
          ],
          "role": "model"
        },
        "finishReason": "STOP",
        "avgLogprobs": -0.19548831841884515
      }
    ],
    "usageMetadata": {
      "promptTokenCount": 76,
      "candidatesTokenCount": 624,
      "totalTokenCount": 700
    },
    "modelVersion": "gemini-1.5-pro-002"
    }
    """
  ];

  public static string GetJson(int? index = null)
  {
    return index == null ? jsonString[random.Next(2)] : jsonString[(int)index];
  }
}

public partial class RecipeResponseSchema
{

  [JsonPropertyName("candidates")]
  public CandidateSchema[] Candidates { get; set; } = [];

  [JsonPropertyName("usageMetadata")]
  public UsageMetadataSchema UsageMetadata { get; set; } = new();

  [JsonPropertyName("modelVersion")]
  public string ModelVersion { get; set; } = string.Empty;

  public partial class CandidateSchema
  {
    [JsonPropertyName("content")]
    public Content Content { get; set; } = new();

    [JsonPropertyName("finishReason")]
    public string FinishReason { get; set; } = string.Empty;

    [JsonPropertyName("avgLogprobs")]
    public double AvgLogprobs { get; set; }
  }

  public partial class Content
  {
    [JsonPropertyName("parts")]
    public Part[] Parts { get; set; } = [];

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;
  }

  public partial class Part
  {
    [JsonPropertyName("text"), JsonConverter(typeof(JsonStringToObjectConverter<RecipeData>))]
    public RecipeData Text { get; set; } = new();
  }

  public partial class RecipeData
  {
    [JsonPropertyName("recipes")]
    public Recipe[] Recipes { get; set; } = [];
  }

  public partial class UsageMetadataSchema
  {
    [JsonPropertyName("promptTokenCount")]
    public long PromptTokenCount { get; set; }

    [JsonPropertyName("candidatesTokenCount")]
    public long CandidatesTokenCount { get; set; }

    [JsonPropertyName("totalTokenCount")]
    public long TotalTokenCount { get; set; }
  }
}

public class JsonStringToObjectConverter<T> : JsonConverter<T>
{
  public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonString = reader.GetString() ?? throw new JsonException("Recipe list is empty");
    return JsonSerializer.Deserialize<T>(jsonString, options);
  }

  public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
  {
    var jsonString = JsonSerializer.Serialize(value, options);
    writer.WriteStringValue(jsonString);
  }
}