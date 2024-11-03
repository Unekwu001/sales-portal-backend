using System.ComponentModel.DataAnnotations;

namespace Data.Utility
{
    using API.Data.Dtos;
    using System.ComponentModel.DataAnnotations;






    public class RequiredIfBillingIsNotSameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Cast the validation context's object instance to the expected type (Residential or equivalent)
            var residential = validationContext.ObjectInstance as ResidentialOrderDto;

            if (residential == null)
            {
                // If the object instance is not of the expected type, return an error
                return new ValidationResult("The validation attribute is applied to an unexpected type.");
            }

            // Check if the 'isBillingAddressSameAsResidentialAddress' property is false and 'value' is null
            if (!residential.IsBillingAddressSameAsResidentialAddress && value == null)
            {
                // Return validation error if billing details are required but not provided
                return new ValidationResult("Billing Details are required when billing address is not the same as residential address.");
            }

            // Return success if the conditions are met
            return ValidationResult.Success;
        }
    }







    public class RequiredIfBillingIsNotSameAsSmeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Cast the validation context's object instance to the expected type (Residential or equivalent)
            var sme = validationContext.ObjectInstance as SmeOrderDto;

            if (sme == null)
            {
                // If the object instance is not of the expected type, return an error
                return new ValidationResult("The validation attribute is applied to an unexpected type.");
            }

            // Check if the 'isBillingAddressSameAsResidentialAddress' property is false and 'value' is null
            if (!sme.IsBillingAddressSameAsResidentialAddress && value == null)
            {
                // Return validation error if billing details are required but not provided
                return new ValidationResult("Billing Details are required when billing address is not the same as sme address.");
            }

            // Return success if the conditions are met
            return ValidationResult.Success;
        }
    }









}
