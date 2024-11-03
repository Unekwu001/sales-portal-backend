namespace API.Data.Dtos
{
    using global::Data.Utility;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SignUpDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name must be at most 50 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be at most 100 characters long")]
        public string Address { get; set; }

        //[PasswordComplexity(ErrorMessage = "Password must be at least 8 characters long and contain a mixture of letters, digits, and at least one special character")]
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }    
    }

}
