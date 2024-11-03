using Data.Utility;
using API.Data.Dtos;
using API.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class SmeProfileDto : UserProfileDto
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
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? LetterOfIntroduction { get; set; }
        public string? GovernmentId { get; set; }
        public string? UtilityBill { get; set; }
        public string? CertificateOfIncorporation { get; set; }
    }
}
