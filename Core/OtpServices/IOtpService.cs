using Data.Models.OtpModel;

namespace Core.OtpServices
{
    public interface IOtpService
    {
        string GenerateOtp();
        Task SaveOtpAsync(string email, string otp);
        Task<UserOtp> OtpExistAsync(string email, string otp);
        Task<bool> IsOtpValidAsync(string otp, string email);
        Task OtpCleanUpJob();
    }
}
