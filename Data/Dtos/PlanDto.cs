
namespace API.Data.Dtos
{
    public class PlanDto: AddPlanDto
    {
        public Guid Id { get; set; }
    }

    public class AddPlanDto
    {
        public string PlanName { get; set; }
        public decimal? SetUpCharge { get; set; }
        public string? PhoneLine { get; set; }
    }
}
