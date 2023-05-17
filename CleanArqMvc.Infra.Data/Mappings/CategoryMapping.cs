using CleanArqMvc.Domain.Entities;
using CleanArqMvc.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArqMvc.Infra.Data.Mappings
{
    public class CategoryMapping : BaseMapping<Category>
    {
        public override string TableName => "categoria";

        protected override void MapearEntidade(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(TableName);

            entityTypeBuilder
                .HasAlternateKey(p => new { p.Code});

            entityTypeBuilder.Property(p => p.Code)
                .IsRequired()
                .HasColumnName("codigo");

            entityTypeBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("descricao_categoria");

        }
    }
}