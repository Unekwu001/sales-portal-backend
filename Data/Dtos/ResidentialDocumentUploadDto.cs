using Microsoft.AspNetCore.Http;
namespace API.Data.Dtos
{
    public class ResidentialDocumentUploadDto
    {

        public IFormFile? PassportPhotograph { get; set; }
        public IFormFile? GovernmentId { get; set; }
        public IFormFile? UtilityBill { get; set; }
    }
}
