using System.Runtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
  protected static void ConfigureProperties(EntityTypeBuilder<T> builder)
  {
    throw new NotImplementedException();
  }

  protected abstract void SeedInitialData(EntityTypeBuilder<T> builder);
  /*
  builder.HasData(new T
  {
    Id = 1, ...
  });
  */

  protected abstract void CreateIndexes(EntityTypeBuilder<T> builder);
  /*
  modelBuilder.Entity<Client>().HasIndex(x => x.Cpf).IsUnique();
  modelBuilder.Entity<Address>().HasIndex(x => new { x.Cep, x.Typed }).IsUnique();
  */

  protected abstract void ApplySoftDelete(EntityTypeBuilder<T> builder);
  /*
  //incluir excluidos: return context.Products.IgnoreQueryFilters().AsNoTracking();
  modelBuilder.Entity<Client>().HasQueryFilter(p => !p.Deleted);
  */

  public void Configure(EntityTypeBuilder<T> builder)
  {
    //builder.Property(x => x.Name).HasMaxLength(32).IsRequired();
    ConfigureProperties(builder);
    CreateIndexes(builder);
    ApplySoftDelete(builder);
    SeedInitialData(builder);
  }

}
