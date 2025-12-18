using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi1.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithExpensesAsync();
    }
}
