using Data.Dtos;
using Data.Models.UserModels;
using API.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserServices
{
    public interface IUserService
    {
        Task AddUserAsync(SignUpDto signUp);
        Task<UserProfileDto> GetUserProfileAsync(string email);
        Task<bool> UserIdExistsAsync(Guid Id);
        Task<bool> UserEmailExistsAsync(string email);
        Task<User> UserExistsAsync(Guid Id);
    }
}
