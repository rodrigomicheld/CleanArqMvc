using CleanArqMvc.Domain.Entities;

namespace CleanArqMvc.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetproductCategoryAsync(int code);
    }
}
