using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.Migrate();

        if (context.Categories.Any()) return;

        var categories = new List<Category>
        {
            new Category { Name = "Продукты", Description = "Все траты на еду" },
            new Category { Name = "Транспорт", Description = "Проезды и такси" },
            new Category { Name = "Развлечения", Description = "Парки, кино, рестораны и прочее" },
            new Category { Name = "Коммунальные услуги", Description = "Ну коммунальные услуги что" },
            new Category { Name = "Одежда", Description = "Одежда, обувь и аксессуары" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var random = new Random();
        var expenses = new List<Expense>();

        foreach (var category in categories)
        {
            for (int i = 1; i <= 5; i++)
            {
                expenses.Add(new Expense
                {
                    Description = $"Расход {i} по категории {category.Name}",
                    Amount = random.Next(100, 5000),
                    Date = DateTime.Now.AddDays(-random.Next(1, 30)),
                    CategoryId = category.Id
                });
            }
        }

        context.Expenses.AddRange(expenses);
        context.SaveChanges();

        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        var budgets = categories.Select(c => new Budget
        {
            Month = currentMonth,
            Year = currentYear,
            Limit = random.Next(5000, 20000),
            CategoryId = c.Id
        }).ToList();

        context.Budgets.AddRange(budgets);
        context.SaveChanges();

    }
}