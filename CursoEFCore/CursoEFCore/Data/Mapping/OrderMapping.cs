using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Order");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.InitialAtDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.StatusOrder).HasConversion<string>();
            builder.Property(p => p.DispatchType).HasConversion<int>();
            builder.Property(p => p.Observation).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.Itens).WithOne(p => p.Order).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
