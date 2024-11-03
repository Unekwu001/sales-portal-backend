
using Data.Utility;
using Data.Utility;

namespace API.Data.Dtos
{
    public class NewPasswordDto
    {
        [PasswordComplexity]
        public string NewPassword { get; set; }
    }
}
