using NUnit.Framework;

namespace Tests
{
    using CarManager;
    using System;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(null, "Golf", 10, 20)]
        [TestCase("VW", null, 10, 20)]
        [TestCase("VW", "Golf", -10, 20)]
        [TestCase("VW", "Golf", 0, 20)]
        [TestCase("VW", "Golf", 10, -20)]
        [TestCase("Vw", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenInputAmountIsNonPositive(double inputAmount)
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>( 
                () => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldRefuelAboveMaxCapacity()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(150);

            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveShouldThrowExceptionIfFuelIsNotEnough()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<InvalidOperationException>(
                () => car.Drive(20));
        }
    }
}