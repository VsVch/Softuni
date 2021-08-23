using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
       
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
            Load = Capacity;
        }

        public int Capacity { get ; set ; }

        public int Load { get; }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (item.Weight > this.Load)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            this.Capacity -= item.Weight;
            items.Add(item);           
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item curItem = items.FirstOrDefault(i => i.GetType().Name == name);

            if (curItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            this.Capacity -= curItem.Weight;
            items.RemoveAt(items.Count - 1);

            return curItem;
        }
    }
}
