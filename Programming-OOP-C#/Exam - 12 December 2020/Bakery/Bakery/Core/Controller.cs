using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncome;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();            
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {           

            if (type == "Water")
            {
                drinks.Add(new Water(name, portion, brand));
            }
            else if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }            

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {           

            if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }
            else if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }           

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {          

            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }          
            
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            ITable[] filteredTables = tables.Where(t => t.IsReserved == false).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var table in filteredTables)
            {
               sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill() + table.Price;
            totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }
        
        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = tables.FirstOrDefault(t => t.Capacity >= numberOfPeople && t.IsReserved == false);

           // if (freeTable.Capacity < numberOfPeople || freeTable.IsReserved == true)
           if(freeTable == null)
           {
               return $"No available table for {numberOfPeople} people";
           }

            freeTable.Reserve(numberOfPeople);

            return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
