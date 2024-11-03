using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Configuration;
using Data.Utility;
using Data.ipNXContext;
using Microsoft.Extensions.Configuration;
using Data.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Core.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IpNxDbContext _ipnxDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(IpNxDbContext ipnxDbContext, IConfiguration configuration)
        {
            _ipnxDbContext = ipnxDbContext;
            _configuration = configuration;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _ipnxDbContext.Users.FirstOrDefaultAsync(u => u.Email == username);
            if (user != null && VerifyPassword(user.HashedPassword, password))
            {
                return user;
            }
            return null;
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["AntiHackerSecretkey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Actor, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                  
                    // Add more claims as needed (e.g., roles)
                }),
                Expires = DateTime.UtcNow.AddHours(24), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "ipNX",
                Audience = "everyone"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public async Task<User> UserExistsAsync(string username)
        {
            return await _ipnxDbContext.Users.FirstOrDefaultAsync(e => e.Email == username);
        }


        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _ipnxDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
            user.HashedPassword = PasswordHashing.HashPassword(newPassword);
            await _ipnxDbContext.SaveChangesAsync();
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _ipnxDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
