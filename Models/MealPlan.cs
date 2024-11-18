using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace ingrEZ.Models;

public class MealPlan
{
  public int Id { get; set; }

  [Column(TypeName = "text")]
  public string Name { get; set; } = string.Empty;

  public DateOnly StartDate { get; set; } = DateOnly.MaxValue;
  public DateOnly EndDate { get; set; } = DateOnly.MinValue;

  public List<MealPlanRecipe> Recipes { get; set; } = [];

  [NotMapped]
  public MealPlanValidator _validator = new();

  [NotMapped]
  public class MealPlanValidator : AbstractValidator<MealPlan>
  {
    public MealPlanValidator()
    {
      RuleFor(recipe => recipe.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name cannot be empty!")
        .MinimumLength(3).WithMessage("Name must have 3 or more characters!");
      RuleFor(recipe => recipe.Recipes).NotEmpty().WithMessage("No recipes added!");
      RuleFor(recipe => recipe.StartDate).NotEmpty().WithMessage("Please enter a valid start date!");
      RuleFor(recipe => recipe.EndDate).NotEmpty().WithMessage("Please enter a valid end date!");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
      var result = await ValidateAsync(ValidationContext<MealPlan>.CreateWithOptions(
        (MealPlan)model, x => x.IncludeProperties(propertyName)));
      if (result.IsValid)
        return [];
      return result.Errors.Select(e => e.ErrorMessage);
    };
  }
}

public record MealPlanRecipe
{
  public int Id { get; set; }
  public int MealPlanId { get; set; }
  public Meal? Meal { get; set; }
  public DateOnly Date { get; set; }

  public Recipe Recipe { get; set; } = null!;
}


