using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;
    using System.Linq;

    public class ExtendedDatabaseTests
    {
        private const int MaxPersonArrayLength = 16;
        private const long DefaultID = 0l;
        private const string DefaultUsername = "TestUsername";
        private Person TestPerson = new Person(9999, "George");
        private Person[] uniquePersonDataCollection = new[]
        {
            new Person (123, "Pesho" ),
            new Person (125, "Gosho" ),
            new Person (200, "Tosho" ),
            new Person (220, "Dimo" ),
            new Person (234, "Ivancho" ),
            new Person (250, "Dragancho"),
            new Person (300, "Ani" ),
            new Person (784, "Tom" ),
            new Person (992, "Jerry" ),
            new Person (999, "Mira" ),
            new Person (1000, "Petq"),
            new Person (1024, "Sasho" ),
            new Person (1506, "Mariq" ),
            new Person (4096, "Alex" ),
            new Person (5200, "Evgeni" ),
            new Person (5345, "Kiril"),
            new Person (6789, "Teodor" ),
            new Person (7001, "Tanq" ),
            new Person (7890, "Anna-Mariq" ),
            new Person (8100, "Dancho" ),
        };

        private Person[] GetPersonArray(int numberOfRequeredPeople) 
            => this.uniquePersonDataCollection
                .Take(numberOfRequeredPeople)
                .ToArray();

        [Test]
        public void ConstructorShouldBeInitializedWith16People()
        {
            var arrayOfPeople = this.GetPersonArray(MaxPersonArrayLength);
            var database = new ExtendedDatabase(arrayOfPeople);

            var expectedResult = MaxPersonArrayLength;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(16)]
        public void ConstructorShouldAddCollectionOfPeople(int numberOfPeople)
        {
            var arrayOfPeople = this.GetPersonArray(numberOfPeople);

            var database = new ExtendedDatabase(arrayOfPeople);

            var expectedResult = numberOfPeople;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ShouldThrowExceptionWhenTryToInitializeWithCollectionWithMoreThan16Elements()
        {
            var arrayOfPeople = this.GetPersonArray(MaxPersonArrayLength + 1);
            Assert.Throws<ArgumentException>(
                () => new ExtendedDatabase(arrayOfPeople));
        }

        [Test]
        public void AddMethodShouldAddPersonAndIncreaseCounter()
        {
            var database = new ExtendedDatabase();
            var expectedResult = database.Count + 1;

            database.Add(this.TestPerson);

            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTryToAddMoreThan16People()
        {
            var arrayOfPeople = this.GetPersonArray(MaxPersonArrayLength);
            var database = new ExtendedDatabase(arrayOfPeople);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(TestPerson));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithThisUsernameExists()
        {
            var database = new ExtendedDatabase(this.TestPerson);
            var person = new Person(DefaultID, this.TestPerson.UserName);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(person));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithThisIDExists()
        {
            var database = new ExtendedDatabase(this.TestPerson);
            var person = new Person(this.TestPerson.Id, DefaultUsername);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(person));
        }

        [Test]
        public void RemoveMethodShouldRemovePersonAndDecrementCount()
        {
            var database = new ExtendedDatabase(this.TestPerson);
            var expectedResult = database.Count - 1;

            database.Remove();
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenArrayIsEmpty()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        public void FindByUsernameShouldReturnPersonByUsername()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            var expectedPerson = this.TestPerson;

            var actualPerson = database.FindByUsername(expectedPerson.UserName);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenUsernameIsNull()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenNoPersonWithUsernameIsFound()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            var expectedPerson = new Person(DefaultID, DefaultUsername);

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(expectedPerson.UserName));
        }

        [Test]
        public void FindByIDShouldReturnPersonByID()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            var expectedPerson = this.TestPerson;

            var actualPerson = database.FindById(expectedPerson.Id);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByIDShouldThrowExceptionWhenIDIsNegative()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(-1));
        }

        [Test]
        public void FindByIDShouldThrowExceptionWhenNoPersonWithIDIsFound()
        {
            var database = new ExtendedDatabase();
            database.Add(this.TestPerson);

            var expectedPerson = new Person(DefaultID, DefaultUsername);

            Assert.Throws<InvalidOperationException>(
                () => database.FindById(expectedPerson.Id));
        }
    }
}