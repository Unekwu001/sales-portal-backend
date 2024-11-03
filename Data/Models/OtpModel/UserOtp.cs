using Data.Models.UserModels;

namespace Data.Models.OtpModel
{
    public class UserOtp : UserTracking
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Otp { get; set; }
        public DateTime Expiration { get; set; }
    }
}
