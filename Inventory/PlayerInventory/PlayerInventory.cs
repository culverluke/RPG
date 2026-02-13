using RPG.Items;
using RPG.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.PlayerInventory
{
    internal class PlayerInventory : Inventory
    {

        public void PickItemToUse(Player.Player player)
        {
            Display();
            Console.WriteLine("\n0 - EXIT");

            Console.WriteLine("Pick an item to use");

            int choice = 0;

            do
            {
                Int32.TryParse(Console.ReadLine(), out choice);

                if(choice > InventoryList.Count() || choice < 0)
                {
                    Console.WriteLine("Pick a valid option");
                }
               

            } while (choice > InventoryList.Count() || choice < 0);

            if(choice != 0)
            {
                InventoryList[choice - 1].UseItem(player, this);
            }
        }


        //---
    }
}
