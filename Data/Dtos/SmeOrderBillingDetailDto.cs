namespace API.Data.Dtos
{
    public class SmeOrderBillingDetailDto
    {
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
        public string? CompanyStreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
