using Data.Utility;
using API.Data.Enums;
using Data.Dtos;


namespace API.Data.Dtos
{
    public class SmeOrderDto 
    {
        public string CompanyName { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string? TypeOfBusiness { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
        public string? ContactPersonAlternativePhoneNumber { get; set; }
        public string? CompanyStreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public TypeOfBuildingSmeEnum? TypeOfBuilding { get; set; }
        public Guid PlanTypeId { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }
        public string? networkCoverageAddress { get; set; }

        [RequiredIfBillingIsNotSameAsSme]
        public SmeOrderBillingDetailDto? SmeBillingDetails { get; set; }
        
        
    }
}
