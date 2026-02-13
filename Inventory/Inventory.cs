using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory
{
    internal abstract class Inventory
    {
        public Inventory()
        {
            InventoryList = new();
        }


        public List<Item> InventoryList { get; set; }


        public virtual void AddToInventory(Item item)
        {
            InventoryList.Add(item);
        }

        public virtual void RemoveFromInventory(Item item)
        {
            InventoryList.Remove(item);
        }

        public virtual void Display()
        {
            int count = 1;

            foreach (var item in InventoryList)
            {
                Console.WriteLine($"{count} - {item.Name}");
                count++;
            }
        }
        


    }
}
