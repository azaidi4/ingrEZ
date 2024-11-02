using System.Text.Json.Serialization;

namespace ingrEZ;

public partial class RecipesRequestBodySchema
{
  [JsonPropertyName("contents")]
  public required ContentSchema[] Contents { get; set; }

  [JsonPropertyName("systemInstruction")]
  public SystemInstructionSchema SystemInstruction { get; set; } = new();

  [JsonPropertyName("generationConfig")]
  public GenerationConfigSchema GenerationConfig { get; set; } = new();

  public partial class ContentSchema
  {
    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("parts")]
    public required Part[] Parts { get; set; }
  }

  public partial class SystemInstructionSchema
  {
    [JsonPropertyName("role")]
    public string Role { get; set; } = "user";

    [JsonPropertyName("parts")]
    public Part[] Parts { get; set; } = [new() {
    Text = "You are a resourceful and creative chef that can provide recipes ranging from Easy to Difficult difficulty. Based on the meal that the user wants (Breakfast, Lunch, or Dinner) and a list of ingredients present in their fridge, respond with 5 recipes that the user can make. Assume that the user has basic and essential seasonsings such as salt, pepper, oil, etc. You do not need to use all the provided ingredients for the recipe. Make sure that the recipes have flavor and not bland. Additionally, provide some suggestions to improve the recipe and make it more delicious, like extra ingredients or toppings that are not provided. Order recipes by meal type, then Preperation Time. Do not prefix the instructions with numbers."
  }];
  }

  public partial class Part
  {
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
  }

  public partial class GenerationConfigSchema
  {
    [JsonPropertyName("temperature")]
    public long Temperature { get; set; } = 1;

    [JsonPropertyName("topK")]
    public long TopK { get; set; } = 40;

    [JsonPropertyName("topP")]
    public double TopP { get; set; } = 0.95;

    [JsonPropertyName("maxOutputTokens")]
    public long MaxOutputTokens { get; set; } = 8192;

    [JsonPropertyName("responseMimeType")]
    public string ResponseMimeType { get; set; } = "application/json";

    [JsonPropertyName("responseSchema")]
    public ResponseSchema ResponseSchema { get; set; } = new();
  }

  public partial class ResponseSchema
  {
    [JsonPropertyName("type")]
    public string Type { get; set; } = "object";

    [JsonPropertyName("properties")]
    public ResponseSchemaProperties Properties { get; set; } = new();

    [JsonPropertyName("required")]
    public string[] ResponseSchemaRequired { get; set; } = ["recipes"];
  }

  public partial class ResponseSchemaProperties
  {
    [JsonPropertyName("recipes")]
    public Recipes Recipes { get; set; } = new();
  }

  public partial class Recipes
  {
    [JsonPropertyName("type")]
    public string Type { get; set; } = "array";

    [JsonPropertyName("items")]
    public Items Items { get; set; } = new();
  }

  public partial class Items
  {
    [JsonPropertyName("type")]
    public string Type { get; set; } = "object";

    [JsonPropertyName("properties")]
    public ItemsProperties Properties { get; set; } = new();

    [JsonPropertyName("required")]
    public string[] ItemsRequired { get; set; } =
    [
      "name",
      "mealType",
      "preperationTime",
      "servingSize",
      "difficulty",
      "ingredients",
      "itemizedInstructions"
    ];
  }

  public partial class ItemsProperties
  {
    [JsonPropertyName("name")]
    public ItemPropertyField Name { get; set; } = new() { Type = "string" };

    [JsonPropertyName("difficulty")]
    public ItemPropertyField Difficulty { get; set; } = new() { Type = "string" };

    [JsonPropertyName("mealType")]
    public ItemPropertyField MealType { get; set; } = new() { Type = "string" };

    [JsonPropertyName("servingSize")]
    public ItemPropertyField ServingSize { get; set; } = new() { Type = "integer" };

    [JsonPropertyName("preperationTime")]
    public ItemPropertyField PreperationTime { get; set; } = new() { Type = "integer" };

    [JsonPropertyName("ingredients")]
    public ItemPropertyArray Ingredients { get; set; } = new()
    {
      Type = "array",
      Items = new() { Type = "string" }
    };

    [JsonPropertyName("itemizedInstructions")]
    public ItemPropertyArray ItemizedInstructions { get; set; } = new()
    {
      Type = "array",
      Items = new() { Type = "string" }
    };

    [JsonPropertyName("suggestions")]
    public ItemPropertyArray Suggestions { get; set; } = new()
    {
      Type = "array",
      Items = new() { Type = "string" }
    };
  }

  public partial class ItemPropertyField
  {
    [JsonPropertyName("type")]
    public required string Type { get; set; }
  }

  public partial class ItemPropertyArray
  {
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("items")]
    public required ItemPropertyField Items { get; set; }
  }
}


