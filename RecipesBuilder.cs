using FluentValidation;

namespace ingrEZ;

public enum Meal
{
  BREAKFAST,
  LUNCH,
  DINNER,
}

public class RecipeBuilder
{
    public IReadOnlyCollection<Meal> Meals { get; set; } = [];
    public List<string> Ingredients { get; set; } = [];

    public string? MealError { get; set; }
    public string? IngredientError { get; set; }

    public RecipeBuilderValidator validator = new();

    public void AddIngredient(string ingredient)
    {
        if (!Ingredients.Contains(ingredient))
        {
            IngredientError = string.Empty;
            Ingredients.Add(ingredient);
        }
    }

    public void RemoveIngredient(MudBlazor.MudChip<string> ingredient)
    {
        Ingredients.Remove(ingredient.Value ?? "");
    }

    public void AddMeals(IReadOnlyCollection<Meal>? meals)
    {
        if (meals!.Count != 0)
        {
            Meals = meals;
            MealError = string.Empty;
        }
        else
        {
            Meals = [];
        }
    }
}

public class RecipeBuilderValidator : AbstractValidator<RecipeBuilder>
{
    public RecipeBuilderValidator()
    {
        RuleFor(recipe => recipe.Meals).NotEmpty().WithMessage("Choose a meal type!");
        RuleFor(recipe => recipe.Ingredients).NotEmpty().WithMessage("No ingredients added!");
        RuleFor(recipe => recipe.Ingredients).Must(x => x.Count > 1)
            .WithMessage("Please enter more than 1 ingredient!");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<RecipeBuilder>.CreateWithOptions(
            (RecipeBuilder)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return [];
        return result.Errors.Select(e => e.ErrorMessage);
    };
}