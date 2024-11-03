using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class OtpLoginDto
    {

        [Required(ErrorMessage = "Please enter the Otp")]
        public string Otp { get; set; }
    }

}
