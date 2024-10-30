using ingrEZ.Models;
using Microsoft.EntityFrameworkCore;

namespace ingrEZ.Data
{
  public class IngrEZDataContext(DbContextOptions<IngrEZDataContext> options) : DbContext(options)
  {
    public DbSet<RecipeEntity> Recipe { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<RecipeEntity>()
          .Property(r => r.Hash)
          .HasComputedColumnSql("SHA2(ItemizedInstructions, 256)", stored: true);
      
      modelBuilder.Entity<RecipeEntity>()
          .HasIndex(r => r.Hash)
          .HasDatabaseName("idx_hash");
    }
  }
}
