using MyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyStore.Infrastructure.Persistence.Configurations;

public class CategoryPropConfiguration : IEntityTypeConfiguration<CategoryProp>
{
    public void Configure(EntityTypeBuilder<CategoryProp> builder)
    {
        
        builder.HasKey(prop => new{prop.PropId, prop.CategoryId});
    }
}
