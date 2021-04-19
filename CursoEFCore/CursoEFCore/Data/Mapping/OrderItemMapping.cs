using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Mapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.ToTable("OrderItem");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Discount).IsRequired();

        }
    }
}
