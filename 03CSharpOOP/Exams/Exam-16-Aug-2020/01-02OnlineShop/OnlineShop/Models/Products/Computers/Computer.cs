namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.Products.Components;
    using Models.Products.Peripherals;
    using OnlineShop.Common.Constants;

    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance 
        {
            get
            {
                double overallPerformance; 

                if (components.Count == 0)
                {
                    overallPerformance = base.OverallPerformance;
                }
                else
                {
                    overallPerformance = base.OverallPerformance + 
                        components.Average(x => x.OverallPerformance);
                }

                return overallPerformance;
            }
        }

        public override decimal Price 
        {
            get => base.Price + 
                this.components.Sum(x => x.Price) + 
                this.peripherals.Sum(x => x.Price);
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            var componentType = component.GetType().Name;

            if (this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingComponent, 
                    componentType, 
                    this.GetType().Name, 
                    this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var peripheralType = peripheral.GetType().Name;

            if (this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id));
            }

            var componentToRemove = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            var peripheralToRemove = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            double peripheralOverallPerformance = 0;
            if (peripherals.Count != 0)
            {
                peripheralOverallPerformance = this.peripherals.Average(x => x.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({peripheralOverallPerformance:F2}):");
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
