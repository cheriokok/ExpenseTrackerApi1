using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi1.Repositories
{

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoriesWithExpensesAsync()
        {
            return await _context.Categories
                .Include(c => c.Expenses)
                .ToListAsync();
        }
    }
}
