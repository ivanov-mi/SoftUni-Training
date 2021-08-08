namespace Bakery.Models.BakedFoods
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
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

        public override string ToString() => 
            $"{this.Name}: {this.Portion}g - {this.Price:F2}";
    }
}
