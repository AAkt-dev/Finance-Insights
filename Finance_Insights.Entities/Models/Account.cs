using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Insights.Entities.Models
{
    public enum AccountStatus
    {
        Pending,  
        Active,    
        Suspended, 
        Closed    
    }
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage ="Balance Cannot be Negative")]
        public decimal Balance {  get; set; }
        [Required]
        public string? UserId { get; set;}
        [Required]
        [EnumDataType(typeof(AccountStatus))]
        public string? AccountStatus { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
