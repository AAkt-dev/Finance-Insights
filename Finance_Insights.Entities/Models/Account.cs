using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_Insights.Entities.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Balance Cannot be Negative")]
        public decimal Balance { get; set; } = 0;
        [Required]
        public string? UserId { get; set;}
        [Required]
        public Enums.AccountStatus AccountStatus { get; set; } = Enums.AccountStatus.Active;
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
