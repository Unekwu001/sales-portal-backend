using Data.Models.UserModels;

namespace Data.Models.PlanModels
{
    public class Plan : UserTracking
    {
        public Plan() => PlanTypes = new List<PlanType>();
        public Guid Id { get; set; }
        public string PlanName { get; set; }
        public decimal? SetUpCharge { get; set; }
        public string? PhoneLine { get; set; }
        public virtual ICollection<PlanType> PlanTypes { get; set; }
    }
}
