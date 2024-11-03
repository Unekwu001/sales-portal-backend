using Data.Models.UserModels;

namespace Core.AuthServices
{
    public interface IAuthService
    {
        Task<User> AuthenticateUserAsync(string username, string password);
        string GenerateJwtToken(User user);
        Task<User> UserExistsAsync(string username);
        Task ResetPasswordAsync(string email, string newPassword);
        Task<User> GetUserByEmailAsync(string email);
    }
}
