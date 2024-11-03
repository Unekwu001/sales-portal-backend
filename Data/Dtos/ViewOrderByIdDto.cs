using API.Data.Enums;
using Data.Enums;
using Data.Models.AgentModel;
using Data.Models.OrderModels;

namespace Data.Dtos
{
    public class ViewOrderByIdDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string networkCoverageAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public string? Occupation { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? FlatNumber { get; set; }
        public string? HouseNumber { get; set; }
        public string? StreetName { get; set; }
        public string? EstateName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string TypeOfBuilding { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }
        public ResidentialOrderBillingDetail? ResidentialBillingDetails { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? GovernmentId { get; set; }
        public string? UtilityBill { get; set; }
        public Guid PlanTypeId { get; set; }
        public Guid PlanId { get; set; }
        public bool IsFormCompleted { get; set; }
        public OrderStatusEnum PaymentStatus { get; set; }
        public string? PaymentReferenceNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Password { get; set; }
        public string? TypeOfBusiness { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
        public string? ContactPersonAlternativePhoneNumber { get; set; }
        public string? CompanyStreetName { get; set; }
        public SmeOrderBillingDetail? SmeBillingDetails { get; set; }
        public string? LetterOfIntroduction { get; set; }
        public string? CertificateOfIncorporation { get; set; }
        public bool HasRequestedInstallation { get; set; } = false;
        public bool HasRequestedToAddWifi { get; set; } = false;
        public string AgentName {  get; set; }
        public decimal? Discount {  get; set; }
    }
}
