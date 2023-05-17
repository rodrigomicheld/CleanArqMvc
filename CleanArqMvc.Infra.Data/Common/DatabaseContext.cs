using CleanArqMvc.Domain.Entities;
using CleanArqMvc.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CleanArqMvc.Infrastructure.Common
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CategoryMapping().Initialize(modelBuilder.Entity<Category>());
            new ProductMapping().Initialize(modelBuilder.Entity<Product>());
        }
    }
}
