namespace TheRace.Tests
{
    using NUnit.Framework;
    using TheRace;
    using System;

    public class RaceEntryTests
    {
        private RaceEntry entry;
        private UnitCar defaultCar;
        private UnitDriver defaultDriver;

        public RaceEntryTests()
        {
            this.defaultCar = new UnitCar("Porsche", 300, 2500);
            this.defaultDriver = new UnitDriver("Gosho", defaultCar);
        }

        [SetUp]
        public void Setup()
        {
            this.entry = new RaceEntry();
        }

        [Test]
        public void UnitCarConstructor_ShouldWorkCorrectly()
        {
            string model = "Lada";
            int horsePower = 75;
            double cubicCentimeters = 1600;

            var car = new UnitCar(model, horsePower, cubicCentimeters);

            Assert.IsNotNull(car);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(horsePower, car.HorsePower);
            Assert.AreEqual(cubicCentimeters, car.CubicCentimeters);
        }

        [Test]
        public void UnitDriverConstructor_ShouldWorkCorrectly()
        {
            string name = "Gosho";

            var driver = new UnitDriver(name, defaultCar);

            Assert.AreEqual(name, driver.Name);
            Assert.AreEqual(defaultCar, driver.Car);
        }

        [Test]
        public void UnitDriver_ShouldThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new UnitDriver(null, defaultCar));
        }

        [Test]
        public void CheckConstructorWorkingCorrectly()
        {
            Assert.IsNotNull(this.entry);
            Assert.AreEqual(0, this.entry.Counter);
        }

        [Test]
        public void CheckCountWorkingCorrectly()
        {
            var expextedResult = entry.Counter + 1;
            this.entry.AddDriver(this.defaultDriver);

            var actualResult = this.entry.Counter;

            Assert.AreEqual(expextedResult, actualResult);
        }

        [Test]
        public void AddDriver_ShouldWorkCorrectly()
        {
            var expextedResult = $"Driver {defaultDriver.Name} added in race.";

            var actualResult = this.entry.AddDriver(this.defaultDriver);

            Assert.AreEqual(expextedResult, actualResult);
        }

        [Test]
        public void AddDriver_ShouldThrowExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(
                () => entry.AddDriver(null),
                string.Format("Driver cannot be null."));
        }

        [Test]
        public void AddDriver_ShouldThrowExceptionIfDriverExists()
        {
            this.entry.AddDriver(this.defaultDriver);

            Assert.Throws<InvalidOperationException>(
                () => entry.AddDriver(this.defaultDriver));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldWorkCorrectly()
        {
            entry.AddDriver(defaultDriver);

            var secondCar = new UnitCar("Lada", 75, 1600);
            var secondDriver = new UnitDriver("Pesho", secondCar);
            entry.AddDriver(secondDriver);

            var expectedResult = (double) (defaultDriver.Car.HorsePower + 
                secondDriver.Car.HorsePower) / entry.Counter;
            var actualResult = entry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowExceptionIfCountLessThanMinParticipants()
        {
            entry.AddDriver(defaultDriver);

            Assert.Throws<InvalidOperationException>(
                 () => entry.CalculateAverageHorsePower());
        }
    }
}