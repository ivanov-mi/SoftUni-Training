namespace OnlineShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Common.Enums;
    using Models.Products.Components;
    using Models.Products.Computers;
    using Models.Products.Peripherals;

    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, 
            string model, decimal price, double overallPerformance, int generation)
        {
            //Check if exists computer with the same Id
            CheckComputerIdExists(computerId);

            var currentComputer = this.computers.
                FirstOrDefault(x => x.Id == computerId);

            //Check if component type is valid
            bool isValidComponent = Enum.TryParse(componentType, out ComponentType validComponentType);

            if (!isValidComponent)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType));
            }

            //Check if component Id already exist in the collection of components
            bool isComponentIdExistsInCollection = components.Any(x => x.Id == id);

            if (isComponentIdExistsInCollection)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));
            }

            //Add component to computer
            IComponent component = null;
            switch (validComponentType)
            {
                case ComponentType.CentralProcessingUnit:
                    component = new CentralProcessingUnit(id, manufacturer, model,
                        price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    component = new Motherboard(id, manufacturer, model,
                        price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    component = new PowerSupply(id, manufacturer, model,
                    price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    component = new RandomAccessMemory(id, manufacturer, model,
                        price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    component = new SolidStateDrive(id, manufacturer, model,
                        price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    component = new VideoCard(id, manufacturer, model,
                        price, overallPerformance, generation);
                    break;
            }

            currentComputer.AddComponent(component);

            //Add component to the collection of components
            components.Add(component);

            //Return success message
            return string.Format(SuccessMessages.AddedComponent,
                componentType,
                id,
                computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            //Check if computer with the same Id already exists
            bool isComputerIdExists = this.computers.Any(x => x.Id == id);
            if (isComputerIdExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            //Check if computer type is valid
            bool isValidComputer = Enum.TryParse(computerType, out ComputerType validComputerType);
            if (!isValidComputer)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }

            //Add new computer
            IComputer computer = null;
            switch (validComputerType)
            {
                case ComputerType.DesktopComputer:
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            computers.Add(computer);

            //Return success message
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            //Check if exists computer with the same Id
            CheckComputerIdExists(computerId);

            var currentComputer = this.computers.
                FirstOrDefault(x => x.Id == computerId);

            //Check if peripheral type is valid
            bool isValidPeripheral = Enum.TryParse(peripheralType, out PeripheralType validPeripheralType);

            if (!isValidPeripheral)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType));
            }

            //Check if periperal Id already exist in the peripehral collection
            bool isPeripharalIdExistsInCollection = peripherals.Any(x => x.Id == id);

            if (isPeripharalIdExistsInCollection)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheralId));
            }

            //Add peripheral to computer
            IPeripheral peripheral = null;
            switch (validPeripheralType)
            {
                case PeripheralType.Headset:
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            currentComputer.AddPeripheral(peripheral);

            //Add peripheral to collection of peripherals
            peripherals.Add(peripheral);

            //Return seccess message
            return string.Format(SuccessMessages.AddedPeripheral, 
                peripheralType, 
                id, 
                computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computersInPriceRange = this.computers.
                Where(x => x.Price <= budget);

            if (!computersInPriceRange.Any())
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.CanNotBuyComputer, 
                    budget));
            }

            var computerToBuy = computersInPriceRange
                .OrderByDescending(x => x.Price).
                FirstOrDefault();

            var result = BuyComputer(computerToBuy.Id);

            return result;
        }

        public string BuyComputer(int id)
        {
            CheckComputerIdExists(id);
            var computerToBuy = this.computers.
                FirstOrDefault(x => x.Id == id);

            computers.Remove(computerToBuy);
            var result = computerToBuy.ToString();

            return result;
        }

        public string GetComputerData(int id)
        {
            CheckComputerIdExists(id);
            var computerToCheckData = this.computers.
                FirstOrDefault(x => x.Id == id);

            var result = computerToCheckData.ToString();

            return result;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckComputerIdExists(computerId);
            var currentComputer = this.computers.
                FirstOrDefault(x => x.Id == computerId);

            var commponentToRemove = currentComputer.Components.
                FirstOrDefault(x => x.GetType().Name == componentType);

            currentComputer.RemoveComponent(componentType);

            return string.Format(SuccessMessages.RemovedComponent, 
                componentType, 
                commponentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckComputerIdExists(computerId);
            var currentComputer = this.computers.
                FirstOrDefault(x => x.Id == computerId);

            var peripheralToRemove = currentComputer.Peripherals.
                FirstOrDefault(x => x.GetType().Name == peripheralType);

            currentComputer.RemovePeripheral(peripheralType);

            return string.Format(SuccessMessages.RemovedPeripheral,
                peripheralType,
                peripheralToRemove.Id);
        }

        private void CheckComputerIdExists(int computerId)
        {
            bool isComputerIdExists = this.computers.Any(x => x.Id == computerId);

            if (!isComputerIdExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }
        }
    }
}
