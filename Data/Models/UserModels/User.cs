namespace Data.Models.UserModels
{
    public class User : UserTracking
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string? HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? CompanyName { get; set; } 

    }
}
