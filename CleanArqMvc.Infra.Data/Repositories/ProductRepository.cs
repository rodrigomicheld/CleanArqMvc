using CleanArqMvc.Application.Interfaces;
using CleanArqMvc.Domain.Entities;
using CleanArqMvc.Infrastructure.Common;
using InvestControl.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArqMvc.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context, IDateTime dateTime) : base(context, dateTime)
        {
        }

        public async Task<Product> GetproductCategoryAsync(int code)
        {
            return await Context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Code == code);
        }
    }
}
