using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.Price).HasDefaultValue(50).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Price).HasDefaultValue(0).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            // builder.Property(p => p.CreateTime).HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.CreateTime).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
