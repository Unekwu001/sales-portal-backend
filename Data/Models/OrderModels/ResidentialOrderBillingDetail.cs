using Data.Models.UserModels;
using API.Data.Enums;

namespace Data.Models.OrderModels
{
    public class ResidentialOrderBillingDetail : UserTracking
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string ResidentialId { get; set; }
    }
}
