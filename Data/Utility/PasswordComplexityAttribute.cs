using System.ComponentModel.DataAnnotations;

namespace Data.Utility
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordComplexityAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
                return false;

            // Check if the password contains at least one letter, one digit, and one special character
            // and has a minimum length of 8 characters
            return password.Length >= 8 && password.Any(char.IsLetter) && password.Any(char.IsDigit) && password.Any(IsSpecialCharacter);
        }

        private bool IsSpecialCharacter(char c)
        {
            // Define your list of special characters here
            var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '{', '}', '[', ']', '|', '\\', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/' };
            return specialCharacters.Contains(c);
        }
    }
}
