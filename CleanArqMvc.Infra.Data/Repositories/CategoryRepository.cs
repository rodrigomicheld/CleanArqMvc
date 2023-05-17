using CleanArqMvc.Application.Interfaces;
using CleanArqMvc.Domain.Entities;
using CleanArqMvc.Infrastructure.Common;
using InvestControl.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArqMvc.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context, IDateTime dateTime) : base(context, dateTime) { }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await Context.Categories.ToListAsync();
        }
    }
}
