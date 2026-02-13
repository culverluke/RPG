using RPG.Inventory.PlayerInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    internal abstract class Item
    {
        public Item()
        {
            Name = "";
        }

        public string Name { get; set; } 
        public float Weight { get; set; } 
        public int Value { get; set; }


        public abstract void UseItem(Player.Player player, PlayerInventory playerInventory);


    }
}
