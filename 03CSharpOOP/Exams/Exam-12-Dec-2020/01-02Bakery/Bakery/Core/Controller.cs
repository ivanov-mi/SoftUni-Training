namespace Bakery.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Enums;
    using Bakery.Utilities.Messages;

    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totallIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            var isDrink = Enum.TryParse(type, out DrinkType drinkType);
           
            if (!isDrink)
            {
                throw new ArgumentNullException("No such type of drink");
            }

            switch (drinkType)
            {
                case DrinkType.Tea:
                    drinks.Add(new Tea(name, portion, brand));
                    break;
                case DrinkType.Water:
                    drinks.Add(new Water(name, portion, brand));
                    break;
            }

            return string.Format(
                OutputMessages.DrinkAdded, 
                name, 
                brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            var isFood = Enum.TryParse(type, out BakedFoodType foodType);
           
            if (!isFood)
            {
                throw new ArgumentNullException("No such type of food");
            }

            switch (foodType)
            {
                case BakedFoodType.Bread:
                    bakedFoods.Add(new Bread(name, price));
                    break;
                case BakedFoodType.Cake:
                    bakedFoods.Add(new Cake(name, price));
                    break;
            }

            return string.Format(
                OutputMessages.FoodAdded,
                name,
                type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var isTable = Enum.TryParse(type, out TableType tableType);

            if (!isTable)
            {
                throw new ArgumentNullException("No such type of table");
            }

            switch (tableType)
            {
                case TableType.InsideTable:
                    tables.Add(new InsideTable(tableNumber, capacity));
                    break;
                case TableType.OutsideTable:
                    tables.Add(new OutsideTable(tableNumber, capacity));
                    break;
            }

            return string.Format(
                OutputMessages.TableAdded,
                tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(x => x.IsReserved == false);

            var freeTablesInfo = new StringBuilder();

            foreach (var table in freeTables)
            {
                freeTablesInfo.AppendLine(table.GetFreeTableInfo());
            }

            return freeTablesInfo.ToString().TrimEnd();
        }

        public string GetTotalIncome() => string.Format(
            OutputMessages.TotalIncome, 
            totallIncome);

        public string LeaveTable(int tableNumber)
        {
            var tableToLeave = this.tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);

            if (tableToLeave == null)
            {
                throw new ArgumentNullException("Table with this number not found.");
            }

            var bill = tableToLeave.GetBill();
            this.totallIncome += bill;
            tableToLeave.Clear();

            var result = new StringBuilder();
            result.AppendLine($"Table: {tableNumber}");
            result.AppendLine($"Bill: {bill:f2}");

            return result.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var orderTableNumber = this.tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);

            if (orderTableNumber == null)
            {
                return string.Format(
                    OutputMessages.WrongTableNumber,
                    tableNumber);
            }

            var drinkToOrder = this.drinks
                .FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drinkToOrder == null)
            {
                return string.Format(
                    OutputMessages.NonExistentDrink,
                    drinkName,
                    drinkBrand);
            }

            orderTableNumber.OrderDrink(drinkToOrder);

            return string.Format(
                OutputMessages.DrinkOrderSuccessful,
                tableNumber,
                drinkName,
                drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var orderTableNumber = this.tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);

            if (orderTableNumber == null)
            {
                return string.Format(
                     OutputMessages.WrongTableNumber,
                     tableNumber);
            }

            var foodOrderName = this.bakedFoods
                .FirstOrDefault(x => x.Name == foodName);

            if (foodOrderName == null)
            {
                return string.Format(
                    OutputMessages.NonExistentFood,
                    foodName);
            }

            orderTableNumber.OrderFood(foodOrderName);

            return string.Format(
                OutputMessages.FoodOrderSuccessful,
                tableNumber,
                foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
           var tableToReserve = this.tables
                .Where(x => x.Capacity >= numberOfPeople && x.IsReserved == false)
                .FirstOrDefault();

            if (tableToReserve == null)
            {
                return string.Format(
                     OutputMessages.ReservationNotPossible,
                     numberOfPeople);
            }

            tableToReserve.Reserve(numberOfPeople);

            return string.Format(
                 OutputMessages.TableReserved,
                 tableToReserve.TableNumber,
                 numberOfPeople);
        }
    }
}
