using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi1.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<List<Expense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
