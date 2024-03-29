using System.ComponentModel.DataAnnotations;

namespace Banking.WebApi
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object number, ValidationContext validationContext)
        {
            return int.Parse(number.ToString()) >= 0
                ? ValidationResult.Success : new ValidationResult("Positive value required.");
        }
    }
}
