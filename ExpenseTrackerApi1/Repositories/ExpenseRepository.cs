using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi1.Repositories
{


    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Expense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToListAsync();
        }
    }
}
