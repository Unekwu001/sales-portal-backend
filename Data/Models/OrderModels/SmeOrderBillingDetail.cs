using Data.Models.UserModels;

namespace Data.Models.OrderModels
{
    public class SmeOrderBillingDetail : UserTracking
    {
        public Guid Id { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
        public string? CompanyStreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string SmeId { get; set; }
    }
}
