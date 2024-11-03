using Microsoft.AspNetCore.Http;

namespace API.Data.Dtos
{
    public class SmeDocumentUploadDto
    {

        public IFormFile? PassportPhotograph { get; set; }
        public IFormFile? LetterOfIntroduction { get; set; }
        public IFormFile? GovernmentId { get; set; }
        public IFormFile? UtilityBill { get; set; }
        public IFormFile? CertificateOfIncorporation { get; set; }
    }
}
