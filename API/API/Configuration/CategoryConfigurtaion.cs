using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class CategoryConfigurtaion : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(25);
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            // builder.Property(p => p.CreateTime).HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.CreateTime).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
