using NUnit.Logic.Models;

namespace NUnit.Logic.Services
{
    public interface IValidator
    {
        ValidationResult ValidateAge(Person person);
    }
}
