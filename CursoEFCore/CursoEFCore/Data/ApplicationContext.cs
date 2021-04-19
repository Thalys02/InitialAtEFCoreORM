using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-RUGBG0T\\SQLEXPRESS;Initial Catalog=CursoEFCore;Integrated Security=true",
                p => p.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null)
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            MapearPropriedadesEsquecidas(modelBuilder);
        }

        //CONFIGURA PROPRIEDADES STRING QUE NÃO FORAM MAPEADAS, COM VARCHAR(200)
        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(w => w.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType())
                        && !property.GetMaxLength().HasValue)
                    {
                        property.SetColumnType("VARCHAR(200)");
                    }
                }
            }
        }
    }
}
