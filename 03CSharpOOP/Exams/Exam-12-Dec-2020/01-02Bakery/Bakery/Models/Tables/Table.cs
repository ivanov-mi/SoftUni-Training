namespace Bakery.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BakedFoods.Contracts;
    using Bakery.Utilities.Messages;
    using Drinks.Contracts;
    using Tables.Contracts;

    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0;
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidTableCapacity));
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidNumberOfPeople));
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price { get; private set; }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            var billAmount = 
                this.numberOfPeople * this.PricePerPerson + 
                this.foodOrders.Sum(x => x.Price) + 
                this.drinkOrders.Sum(x => x.Price);

            return billAmount;
        }

        public string GetFreeTableInfo()
        {
            var tableInfo = new StringBuilder();
            tableInfo.AppendLine($"Table: {this.TableNumber}");
            tableInfo.AppendLine($"Type: {this.GetType().Name}");
            tableInfo.AppendLine($"Capacity: {this.Capacity}");
            tableInfo.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return tableInfo.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
