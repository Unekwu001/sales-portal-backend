using Asp.Versioning;
using AutoMapper;
using Core.UserServices;
using API.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Data.Models.EmailModels;
using System.Text;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;



        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }




        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var CustomerDataExists = await _userService.UserEmailExistsAsync(signUpDto.Email);
                if (CustomerDataExists)
                {
                    return Conflict(ipNXApiResponse.Failure("An account already exists with this email address"));
                }
                await _userService.AddUserAsync(signUpDto);

                return Ok(ipNXApiResponse.Success("Sign up was successful"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the sign-up request for email: {Email}", signUpDto.Email);
                return BadRequest(ipNXApiResponse.Failure("An error occurred while processing the sign up request"));
            }

        }



        [Authorize]
        [HttpGet("get-user-details")]
        public async Task<IActionResult> ViewCustomerOrderById()
        {
            try
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var userProfileDetails = await _userService.GetUserProfileAsync(email);
                if (userProfileDetails == null)
                {
                    return NotFound(ipNXApiResponse.Failure("User not found"));
                }
                return Ok(userProfileDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while trying to view the details of : {User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value}");
                return StatusCode(500, ipNXApiResponse.Failure("An error occurred while trying to view profile details."));
            }
        }


        





    }
}
