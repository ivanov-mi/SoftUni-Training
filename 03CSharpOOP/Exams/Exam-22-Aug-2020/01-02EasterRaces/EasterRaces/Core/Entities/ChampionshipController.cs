namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Text;
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Contracts;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;

    class ChampionshipController : IChampionshipController
    {
        private const int MinRaceParticipants = 3;
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.DriverNotFound,
                    driverName));
            }

            var car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.CarNotFound,
                    carModel));
            }

            driver.AddCar(car);

            return string.Format(
                OutputMessages.CarAdded,
                driverName,
                carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.DriverNotFound,
                    driverName));
            }

            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.RaceNotFound,
                    raceName));
            }

            race.AddDriver(driver);

            return string.Format(
                OutputMessages.DriverAdded,
                driverName,
                raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var car = this.cars.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CarExists,
                    model));
            }

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            cars.Add(car);

            return string.Format(
                OutputMessages.CarCreated,
                car.GetType().Name,
                model);
        }

        public string CreateDriver(string driverName)
        {
            var driver = this.drivers.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.DriversExists,
                    driverName));
            }

            driver = new Driver(driverName);
            this.drivers.Add(driver);

            return string.Format(
                OutputMessages.DriverCreated, 
                driverName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.RaceExists,
                    name));
            }

            race = new Race(name, laps);
            races.Add(race);

            return string.Format(
                OutputMessages.RaceCreated,
                name);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.RaceNotFound,
                    raceName));
            }

            var numberOfDrivers = race.Drivers.Count;

            if (numberOfDrivers < MinRaceParticipants)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.RaceInvalid,
                    raceName,
                    MinRaceParticipants));
            }

            var laps = race.Laps;
            var driversAssignToTheRace = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(laps));

            races.Remove(race);

            var winner = driversAssignToTheRace.FirstOrDefault();
            var secondPlace = driversAssignToTheRace.Skip(1).FirstOrDefault();
            var thirdPlace = driversAssignToTheRace.Skip(2).FirstOrDefault();

            var standings = new StringBuilder();
            standings.AppendLine(string.Format(
                OutputMessages.DriverFirstPosition, 
                winner.Name, 
                raceName));
            standings.AppendLine(string.Format(
                OutputMessages.DriverSecondPosition, 
                secondPlace.Name, 
                raceName));
            standings.AppendLine(string.Format(
                OutputMessages.DriverThirdPosition,
                thirdPlace.Name, 
                raceName));

            return standings.ToString().TrimEnd();
        }
    }
}
