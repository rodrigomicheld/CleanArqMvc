using CleanArqMvc.Domain.Common;


namespace CleanArqMvc.Application.Common
{
    public interface IBaseRepository<T> where T : AuditableEntity
    {
        Task<T> GetByCodeAsync(int code);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entidade);
        Task UpdateAsync(T entidade);
        Task RemoveAsync(T entidade);
    }
}