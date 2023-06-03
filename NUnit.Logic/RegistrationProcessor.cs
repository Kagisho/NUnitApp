namespace NUnit.Logic
{
    public partial class RegistrationProcessor
    {
        public bool IsRegisetered { get; set; } = false;
        public string RejectionReason { get; set; } = string.Empty;
        private DateTime _currentDateTime { get; set; } 

        private IValidator? _validator;
        public RegistrationProcessor(IValidator validator, DateTime? currentDateTime)
        {
            _validator = validator;
            _currentDateTime = currentDateTime ?? DateTime.Now;
        }

        public RegistrationResult Register(Person person)
        {
            if (_validator == null)
            {
                throw new ArgumentNullException(nameof(Validator));
            }

            if (person.Age(DateOnly.FromDateTime(_currentDateTime)) <= 0)
            {
                return new RegistrationResult
                {
                    RejectionReason = "Invalid age."
                };
            }

            var ageValidation = _validator.ValidateAge(person);

            if (!ageValidation.IsValid)
            {
                return new RegistrationResult
                {
                    RejectionReason = ageValidation.ValidationMessage
                };
            }

            return new  RegistrationResult { 
                StudentNumber = new Random().Next(1000000, 10000000),
            };
        }
    }
}
