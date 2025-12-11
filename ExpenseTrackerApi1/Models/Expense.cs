using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApi.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
