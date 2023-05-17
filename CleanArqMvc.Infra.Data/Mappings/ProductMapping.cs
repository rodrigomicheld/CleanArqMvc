using CleanArqMvc.Domain.Entities;
using CleanArqMvc.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArqMvc.Infra.Data.Mappings
{
    public class ProductMapping : BaseMapping<Product>
    {
        public override string TableName => "produto";

        protected override void MapearEntidade(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(TableName);

            entityTypeBuilder
                .HasAlternateKey(p => new { p.Code });

            entityTypeBuilder.Property(p => p.Code)
                .IsRequired()
                .HasColumnName("codigo");

            entityTypeBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");

            entityTypeBuilder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnName("descricao");

            entityTypeBuilder.Property(p => p.Price)
               .IsRequired()
               .HasPrecision(10,2)
               .HasColumnName("preco");
        }
    }
}
