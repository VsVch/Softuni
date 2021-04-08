using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public class Bag : IBag
    {
        private List<Item> itemsByName;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            itemsByName = new List<Item>();
        }

        public int Capacity { get ; set ; }

        public int Load => itemsByName.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => itemsByName.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            itemsByName.Add( item);
        }

        public Item GetItem(string name)
        {
            if (itemsByName.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = itemsByName.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            
            itemsByName.Remove(item);

            return item;
        }        
    }
}
