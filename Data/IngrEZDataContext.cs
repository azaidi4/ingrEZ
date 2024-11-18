using ingrEZ.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ingrEZ.Data
{
  public class IngrEZDataContext(DbContextOptions<IngrEZDataContext> options) : IdentityDbContext<User>(options)
  {
    public DbSet<Recipe> Recipe { get; set; } = default!;
    public DbSet<MealPlan> MealPlan { get; set; } = default!;
    public DbSet<MealPlanRecipe> MealPlanRecipe { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Recipe>()
          .HasIndex(r => r.Hash)
          .HasDatabaseName("idx_hash");
    }
  }
}
