
using Data.Enums;
namespace Data.Dtos
{
    public class OrderIsReadyForPayment
    {
        public string OrderId { get; set; }
        public bool? IsSavedAndReadyForPayment { get; set; }
        public string PlanName { get; set; }
        public string PlanType { get; set; }
        public decimal? CostOfPlanType { get; set; }
        public int? NumberOfMonthsPaidFor { get; set; }
        public decimal? SetUpCharge { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalPaymentExpected { get; set; }
        public OrderStatusEnum PaymentStatus { get; set; }
        public string AgentName { get; set; }
        public string AgentType{ get; set; } 
    }
}
