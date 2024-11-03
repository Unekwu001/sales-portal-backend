
using Data.ipNXContext;
using Data.Models.OtpModel;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace Core.OtpServices
{
    public class OtpService : IOtpService
    {
        private readonly IpNxDbContext _ipNXDbContext;

        public OtpService(IpNxDbContext ipNXDbContext)
        {
            _ipNXDbContext = ipNXDbContext;
        }

        public string GenerateOtp()
        {
            Random random = new Random();
            int otpValue = random.Next(100000, 999999);
            return otpValue.ToString();
        }

        public async Task SaveOtpAsync(string email, string otp)
        {
            var userOtp = new UserOtp
            {
                Email = email,
                Otp = otp,
                Expiration = DateTime.UtcNow.AddMinutes(10) // Set an expiration time for the OTP (e.g., 10 minutes in this code)
            };

            await _ipNXDbContext.UserOtps.AddAsync(userOtp);
            await _ipNXDbContext.SaveChangesAsync();
        }

        public async Task<UserOtp> OtpExistAsync(string email, string otp)
        {
            return await _ipNXDbContext.UserOtps.FirstOrDefaultAsync(e => e.Email == email && e.Otp == otp);
        }

        public async Task<bool> IsOtpValidAsync(string otp, string email)
        {
            return await _ipNXDbContext.UserOtps.AnyAsync(o => o.Otp == otp && o.Expiration > DateTime.UtcNow && o.Email == email);
        }

        public async Task OtpCleanUpJob()
        {
            RecurringJob.AddOrUpdate(() => CleanupExpiredOtps(), Cron.Daily);
            await CleanupExpiredOtps();
        }

        private async Task CleanupExpiredOtps()
        {
            var expiredOtps = await _ipNXDbContext.UserOtps
                .Where(o => o.Expiration < DateTime.UtcNow)
                .ToListAsync();

            _ipNXDbContext.UserOtps.RemoveRange(expiredOtps);
            await _ipNXDbContext.SaveChangesAsync();
        }

    }
}
