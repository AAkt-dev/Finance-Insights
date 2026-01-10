using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_Insights.Entities.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId {  get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsIncome { get; set; }
        [Required]
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
