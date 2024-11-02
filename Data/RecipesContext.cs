using ingrEZ.Models;
using Microsoft.EntityFrameworkCore;

namespace ingrEZ.Data
{
  public class IngrEZDataContext(DbContextOptions<IngrEZDataContext> options) : DbContext(options)
  {
    public DbSet<Recipe> Recipe { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Recipe>()
          .HasIndex(r => r.Hash)
          .HasDatabaseName("idx_hash");
    }
  }
}
