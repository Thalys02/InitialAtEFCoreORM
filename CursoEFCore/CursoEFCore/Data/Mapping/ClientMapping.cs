using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnType("CHAR(11)");
            builder.Property(p => p.Cep).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(p => p.State).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.City).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.PhoneNumber).HasDatabaseName("index_client_phoneNumber");

        }
    }
}
