using Data.Dtos;
using Data.ipNXContext;
using Data.Models.UserModels;
using Data.Utility;
using API.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserServices
{
    public class UserService : IUserService
    {
        private readonly IpNxDbContext _ipNxDbContext;

        public UserService(IpNxDbContext ipNxDbContext)
        {
          _ipNxDbContext = ipNxDbContext;
        }



        public async Task<UserProfileDto> GetUserProfileAsync(string email)
        {
            var result = await _ipNxDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);

            if (result != null)
            {
                return new UserProfileDto
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    PhoneNumber = result.PhoneNumber,
                    Address = result.Address,
                    Email = result.Email,
                    CompanyName = result.CompanyName
                };
            }          
            return null;
        }


        public async Task AddUserAsync(SignUpDto signUp)
        {
            var user = new User()
            {
                Email = signUp.Email,
                //HashedPassword = PasswordHashing.HashPassword(signUp.Password),
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                PhoneNumber = signUp.PhoneNumber,
                Address = signUp.Address,
                CompanyName = signUp.CompanyName
               
            };
            await _ipNxDbContext.Users.AddAsync(user);
            await _ipNxDbContext.SaveChangesAsync();
        }



        public async Task<bool> UserIdExistsAsync(Guid Id)
        {
            return await _ipNxDbContext.Users.AnyAsync(x=> x.Id == Id);
        }

        public async Task<bool> UserEmailExistsAsync(string email)
        {
            return await _ipNxDbContext.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<User> UserExistsAsync(Guid Id)
        {
            return await _ipNxDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }



    }
}
