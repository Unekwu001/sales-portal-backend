
namespace Data.Dtos
{
    public class ApproveForPaymentDto
    {
        public string OrderId { get; set; }
        public string? AgentId { get; set; }
        public int NumberOfMonthsPaidFor { get; set; }
    }
}
