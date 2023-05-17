using CleanArqMvc.Application.Common;
using CleanArqMvc.Domain.Common;
using InvestControl.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArqMvc.Infrastructure.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<T> Entity;
        protected readonly IDateTime _dateTime;

        public BaseRepository(DatabaseContext context, IDateTime dateTime)
        {
            Context = context;
            Entity = Context.Set<T>();
            _dateTime = dateTime;
        }

        public async Task CreateAsync(T entidade)
        {
            entidade.CreatedAt = _dateTime.Now;
            entidade.LastModifiedAt = null;
            Entity.Add(entidade);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async Task<T> GetByCodeAsync(int code)
        {
            return await Entity.FindAsync(code);
        }

        public async Task RemoveAsync(T entidade)
        {
            Entity.Remove(entidade);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entidade)
        {
            entidade.LastModifiedAt = _dateTime.Now;
            Entity.Update(entidade);
            await Context.SaveChangesAsync();
        }
    }
}
