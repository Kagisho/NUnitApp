namespace NUnit.Logic
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public int Age(DateOnly dateRequested)
        {
            var age = dateRequested.Year - DateOfBirth.Year;

            if (age < 0) throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be less than 0");
            
            if (age > 120) throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be more than 120");

            return age;
        }
    }
}
