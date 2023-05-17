using CleanArqMvc.Domain.Common;
using CleanArqMvc.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArqMvc.Infrastructure.Database
{
    public abstract class BaseMapping<T> : IBaseMapping where T : AuditableEntity
    {
        public abstract string TableName { get; }

        public void Initialize(EntityTypeBuilder<T> builder)
        {
            MapearBase(builder);
            MapearChavePrimaria(builder);
            MapearEntidade(builder);
        }

        protected abstract void MapearEntidade(EntityTypeBuilder<T> entityTypeBuilder);

        private void MapearBase(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("criado_em").IsRequired();
            builder.Property(x => x.LastModifiedAt).HasColumnName("ultima_modificacao_em").IsRequired();
            builder.Property(x => x.Deleted).HasColumnName("excluido");
        }

        protected virtual void MapearChavePrimaria(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}