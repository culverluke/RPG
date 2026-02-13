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
                        Buy(playerInventory);
                        break;

                    case 2:// sell
                        Sell(playerInventory);
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
            ShopInventory.Display();

            //Console.WriteLine("Select the item you want to buy");

            int choice = 99;

            do
            {
                Console.WriteLine("Select the item you want to buy");
                Console.WriteLine("0 to EXIT");
                int.TryParse(Console.ReadLine(), out choice);

            } while (choice < 0 || choice > ShopInventory.InventoryList.Count());


            if (choice > 0 && choice <= ShopInventory.InventoryList.Count())
            {
                playerInventory.AddToInventory(ShopInventory.InventoryList[choice - 1]);
                ShopInventory.InventoryList.Remove(ShopInventory.InventoryList[choice - 1]);
            }
        }

        public void Sell(PlayerInventory playerInventory)
        {
            playerInventory.Display();

            int choice = 99;

            do
            {
                Console.WriteLine("Select the item you want to buy");
                Console.WriteLine("0 to EXIT");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice < 0 || choice > playerInventory.InventoryList.Count());

            if (choice > 0 && choice <= playerInventory.InventoryList.Count())
            {
                ShopInventory.AddToInventory(playerInventory.InventoryList[choice - 1]);
                playerInventory.RemoveFromInventory(playerInventory.InventoryList[choice - 1]);
            }
        }


        //---
    }
}
