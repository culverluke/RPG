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

        public void PickItemToUse(Player.Player player, UserInput.UserInput userInput)
        {
            Display();
            Console.WriteLine("\n0 - EXIT");

            Console.WriteLine("Pick an item to use");

            int choice = userInput.PickItemFromList(InventoryList);

            if(choice != 0)
            {
                InventoryList[choice - 1].UseItem(player, this);
            }
        }


        //---
    }
}
