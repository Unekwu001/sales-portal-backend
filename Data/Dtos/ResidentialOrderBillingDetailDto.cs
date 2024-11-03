using API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class ResidentialOrderBillingDetailDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string StreetName { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public TypeOfBuildingResidentialEnum? TypeOfBuilding { get; set; }
    }
}
