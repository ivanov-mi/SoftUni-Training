namespace Bakery.Models.Drinks
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        protected Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidName));
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidPortion));
                }

                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidPrice));
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidBrand));
                }

                this.brand = value;
            }
        }

        public override string ToString() => 
            $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:F2}lv";
    }
}
