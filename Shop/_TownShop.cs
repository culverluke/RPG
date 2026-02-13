using RPG.Inventory.PlayerInventory;
using RPG.Inventory.ShopInventory;
using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop
{
    internal abstract class TownShop
    {
        public TownShop()
        {
            ShopInventory = new();
        }


        public ShopInventory ShopInventory { get; set; }
        public int ShopKey { get; set; }


        public void BuyOrSell(PlayerInventory playerInventory)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] - Buy");
            Console.WriteLine("[2] - Sell");
            Console.WriteLine("[0] - EXIT");

            int choice = 99;

            do
            {
                Int32.TryParse(Console.ReadLine(), out choice);

                switch(choice)
                {
                    case 1:// buy
                        ShopInventory.Display();
                        break;

                    case 2:// sell
                        playerInventory.Display();
                        break;

                    case 0:
                        Console.WriteLine("You leave the shop");
                        break;

                    default:
                        Console.WriteLine("Pick an option from the menu");
                        break;
                }

            } while (choice < 0 || choice > 2);

            if (choice != 0)
            {
                BuyOrSell(playerInventory);
            }
        }

        public void Buy(PlayerInventory playerInventory)
        {

        }


        //---
    }
}
