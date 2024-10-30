using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ingrEZ.Models;

public class RecipeEntity : Recipe
{
  public int Id { get; set; }
  public DateTime PinnedDate { get; set; }
  
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public string Hash { get; private set; }

  public RecipeEntity() { }

  public RecipeEntity(Recipe recipe)
  {
    Name = recipe.Name;
    Difficulty = recipe.Difficulty;
    MealType = recipe.MealType;
    ServingSize = recipe.ServingSize;
    PreperationTime = recipe.PreperationTime;
    Ingredients = recipe.Ingredients;
    ItemizedInstructions = recipe.ItemizedInstructions;
    Suggestions = recipe.Suggestions;
    PinnedDate = DateTime.Now;
  }
}