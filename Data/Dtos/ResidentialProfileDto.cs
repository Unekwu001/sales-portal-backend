using API.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ResidentialProfileDto : UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
        public TypeOfBuildingResidentialEnum? TypeOfBuilding { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? GovernmentId { get; set; }
        public string? UtilityBill { get; set; }
    }
}
