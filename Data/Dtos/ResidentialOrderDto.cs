using API.Data.Enums;
using Data.Utility;
using Data.Enums;
using Data.Dtos;

namespace API.Data.Dtos
{
    public class ResidentialOrderDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public string? Occupation { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? FlatNumber { get; set; }
        public string? HouseNumber { get; set; }
        public string? StreetName { get; set; }
        public string? EstateName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public TypeOfBuildingResidentialEnum? TypeOfBuilding { get; set; }
        public Guid PlanTypeId { get; set; }
        public string? NetworkCoverageAddress { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }

        [RequiredIfBillingIsNotSame]
        public ResidentialOrderBillingDetailDto? ResidentialBillingDetails { get; set; }

    }
}
