using Moq;
using NUnit.Framework;
using NUnit.Logic.Models;
using NUnit.Logic.Services;

namespace NUnit.Logic.Tests
{
    public class RegistrationProcessorShould
    {
        [Test]
        public void Reject_By_Invalid_Age()
        {
            var person = new Person
            {
                FirstName = "Young",
                LastName = "Child",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now)
            };

            var validatorMock = new Mock<IValidator>();
            var regProcessor = new RegistrationProcessor(validatorMock.Object, null);
            
            var isRegistered = regProcessor.Register(person);

            Assert.That(isRegistered, Has
                                      .Property(nameof(isRegistered.RejectionReason)).EqualTo("Invalid age.")
                                      .And
                                      .Property(nameof(isRegistered.StudentNumber)).EqualTo(0));

        }

        [Test]
        public void Accept()
        {
            var person = new Person
            {
                FirstName = "Valid",
                LastName = "Age",
                DateOfBirth = DateOnly.FromDateTime(new DateTime(1980,1,1))
            };

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(v => v.ValidateAge(person)).Returns(new ValidationResult { IsValid = true});

            var regProcessor = new RegistrationProcessor(validatorMock.Object, null);

            var registrationResult = regProcessor.Register(person);

            Console.WriteLine(registrationResult.StudentNumber);

            Assert.That(registrationResult, Has
                                      .Property(nameof(registrationResult.RejectionReason)).Empty
                                      .And
                                      .Property(nameof(registrationResult.StudentNumber)).GreaterThan(0));

        }
    }
}
