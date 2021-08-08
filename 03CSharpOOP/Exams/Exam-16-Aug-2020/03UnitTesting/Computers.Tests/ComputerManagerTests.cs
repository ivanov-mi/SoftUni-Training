namespace Computers.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Tests
    {
        private List<Computer> defaultComputers
            ;
        private ComputerManager computerManager;

        public Tests()
        {
            this.defaultComputers = new List<Computer>
            {
                new Computer("HP", "Z200", 1000),
                new Computer("Asus", "Vivobook", 750),
                new Computer("Dell", "g5", 1900),
                new Computer("Dell", "g7", 1300),
                new Computer("Dell", "5510", 700),
                new Computer("Asus", "Zenbook", 1500),
            };
        }

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ConstructorShouldInitializeNewEmptyList()
        {
            var expectedCount = 0;

            var computerCollection = this.computerManager.Computers;
            var actualCount = this.computerManager.Count;

            Assert.IsNotNull(this.computerManager);
            Assert.IsEmpty(computerCollection);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void Count_ShouldWorkCorrectly(int numberOfComputers)
        {
            var computerCollection = this.defaultComputers.Take(numberOfComputers);

            foreach (var computer in computerCollection)
            {
                computerManager.AddComputer(computer);
            }

            var actualNumberOfComputers = computerManager.Count;

            Assert.AreEqual(numberOfComputers, actualNumberOfComputers);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void AddComputer_ShouldAddComputer(int numberOfComputers)
        {
            var computerCollection = this.defaultComputers.Take(numberOfComputers).ToList();

            foreach (var computer in computerCollection)
            {
                computerManager.AddComputer(computer);
            }

            Assert.AreEqual(computerCollection.Count, computerManager.Count);
            CollectionAssert.AreEqual(computerCollection, computerManager.Computers);
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionIfTryToAddNullReference()
        {
            Assert.Throws<ArgumentNullException> (
                () => computerManager.AddComputer(null),
                "Can not be null!");
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionIfComputerAlreadyExists()
        {
            var computer = defaultComputers.FirstOrDefault();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>( 
                () => computerManager.AddComputer(computer), 
                "This computer already exists.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void GetComputer_ShouldReturnComputerIfFound(int computerPosition)
        {
            foreach (var computer in this.defaultComputers)
            {
                computerManager.AddComputer(computer);
            }

            var expectedResult = this.defaultComputers.Skip(computerPosition).FirstOrDefault();

            var actualResult = computerManager.GetComputer(expectedResult.Manufacturer, expectedResult.Model);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "Z200"), 
                "Can not be null.");
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("HP", null),
                "Can not be null.");
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfNoComputerIsFound()
        {
            var computer = defaultComputers.FirstOrDefault();
            computerManager.AddComputer(computer);

            var anotherComputer = new Computer("Lenovo", "Y500", 1150);

            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer(anotherComputer.Manufacturer, anotherComputer.Model),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void RemoveComputer_ShouldWorkCorrectly(int computerPosition)
        {
            foreach (var computer in this.defaultComputers)
            {
                computerManager.AddComputer(computer);
            }

            var expectedResult = this.defaultComputers.Skip(computerPosition).FirstOrDefault();
            var expectedCount = defaultComputers.Count - 1;

            var actualResult = computerManager.RemoveComputer(expectedResult.Manufacturer, expectedResult.Model);

            Assert.AreEqual(expectedCount, computerManager.Count);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveComputer_ShouldThrowExceptionIfComputerNotFound()
        {
            var computer = defaultComputers.FirstOrDefault();
            computerManager.AddComputer(computer);

            var anotherComputer = new Computer("Lenovo", "Y500", 1150);

            Assert.Throws<ArgumentException>(
                () => computerManager.RemoveComputer(anotherComputer.Manufacturer, anotherComputer.Model),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        [TestCase("HP")]
        [TestCase("Asus")]
        [TestCase("Dell")]
        [TestCase("Lenovo")]
        public void GetComputersByManufacturer_ShouldReturnEmptyCollectionIfManifacturerNotFound(string manufacturer)
        {
            foreach (var computer in this.defaultComputers)
            {
                computerManager.AddComputer(computer);
            }

            var expectedResult = this.defaultComputers
                .Where(x => x.Manufacturer == manufacturer)
                .ToList();

            var actualResult = computerManager.GetComputersByManufacturer(manufacturer);

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(null)]
        public void GetComputersByManufacturer_ShouldThrowExceptionIfManufacturerNull(string manufacturer)
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(manufacturer),
                "Can not be null.");
        }
    }
}