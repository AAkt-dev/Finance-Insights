using Finance_Insights.Entities.Enums;

namespace Finance_Insights.Shared.DTOs
{
    public record AccountForUpdateDto
    {
        public decimal Balance {  get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
