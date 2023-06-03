using NUnit.Framework;
using NUnit.Logic.Models;

namespace NUnit.Logic.Tests
{
    public class PersonShould
    {
        private Person person = new();

        [OneTimeSetUp]
        public void CreatePerson()
        {
            person = new Person
            {
                FirstName = "Kagisho",
                LastName = "Tsoka",
                DateOfBirth = new DateOnly(1984, 7, 25)
            };
        }


        [Test]
        [Ignore("This test must be ignored")]
        public void None_Test()
        {
            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public void Get_Full_Name()
        {
            var person = new Person
            {
                FirstName = "Kagisho",
                LastName = "Tsoka",
                DateOfBirth = new DateOnly(1984, 7, 25)
            };

            Assert.That(person.FullName, Is.EqualTo("Kagisho Tsoka"), "The first name and last name concatenated");
        }

        [Test]
        public void Get_Age()
        {
           
            Assert.That(person.Age(DateOnly.FromDateTime(new DateTime(2023,6,3))), Is.EqualTo(39));
        }

        /// <summary>
        /// Demonstrate how property asserts can be chained
        /// </summary>
        [Test]
        public void Get_First_Name_And_Last_Name()
        {
           
            Assert.That(person, Has.Property(nameof(person.FirstName)).EqualTo("Kagisho")
                .And
                .Property(nameof(person.LastName)).EqualTo("Tsoka"));

        }

        [Test]
        public void Thorw_Exception_For_Negative_Age()
        {
           Assert.That(() => person.Age(DateOnly.FromDateTime(new DateTime(1983, 7, 25))), Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void Thorw_Exception_For_Old_Age()
        {
            Assert.That(() => person.Age(DateOnly.FromDateTime(new DateTime(2300, 7, 25))), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
