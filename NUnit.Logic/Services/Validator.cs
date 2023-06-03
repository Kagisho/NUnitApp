using NUnit.Logic.Models;

namespace NUnit.Logic.Services
{
    public class Validator : IValidator
    {
        public ValidationResult ValidateAge(Person person)
        {
            ValidationResult result = new()
            {
                IsValid = true
            };

            if (person.Age(DateOnly.FromDateTime(DateTime.Now)) < 18)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ValidationMessage = "Applicant too young, must be 18 or older"
                };
            }

            return result;
        }
    }
}
