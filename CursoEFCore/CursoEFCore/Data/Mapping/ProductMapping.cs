using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Mapping
{
    class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.ProductType).HasConversion<string>();

        }
    }
}
