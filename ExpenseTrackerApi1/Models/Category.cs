
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
