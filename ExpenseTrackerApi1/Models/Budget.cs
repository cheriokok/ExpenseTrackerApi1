
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApi.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal Limit { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
