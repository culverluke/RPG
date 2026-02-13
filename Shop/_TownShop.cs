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
            Console.Clear();
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
           // ShopInventory.Display();
            //Console.WriteLine("Select the item you want to buy");
            int choice = 99;

            do
            {
                Console.Clear();
                ShopInventory.Display();
                Console.WriteLine("Select the item you want to buy");
                Console.WriteLine("\n0 to EXIT");
                int.TryParse(Console.ReadLine(), out choice);

                if (choice > 0 && choice <= ShopInventory.InventoryList.Count())
                {
                    playerInventory.AddToInventory(ShopInventory.InventoryList[choice - 1]);
                    //ShopInventory.InventoryList.Remove(ShopInventory.InventoryList[choice - 1]);
                    Console.WriteLine($"\nYou bought the {ShopInventory.InventoryList[choice - 1].Name}");
                    Console.ReadKey();
                    choice = 99;
                }


            } while (choice < 0 || choice > ShopInventory.InventoryList.Count());


            if (choice > 0 && choice <= ShopInventory.InventoryList.Count())
            {
                playerInventory.AddToInventory(ShopInventory.InventoryList[choice - 1]);
                //ShopInventory.InventoryList.Remove(ShopInventory.InventoryList[choice - 1]);
            }
        }

        public void Sell(PlayerInventory playerInventory)
        {
            //playerInventory.Display();

            int choice = 99;

            if(playerInventory.InventoryList.Count() > 0)
            {
                do
                {
                    Console.Clear();
                    playerInventory.Display();
                    Console.WriteLine("Select the item you want to sell");
                    Console.WriteLine("\n0 to EXIT");
                    int.TryParse(Console.ReadLine(), out choice);

                    if (choice > 0 && choice <= playerInventory.InventoryList.Count())
                    {
                        //ShopInventory.AddToInventory(playerInventory.InventoryList[choice - 1]);
                        Console.WriteLine($"\nYou sold the {playerInventory.InventoryList[choice - 1].Name}");
                        playerInventory.RemoveFromInventory(playerInventory.InventoryList[choice - 1]);
                        Console.ReadKey();
                        choice = 99;
                    }

                    if(playerInventory.InventoryList.Count() <= 0)
                    {
                        Console.WriteLine("\nYou have nothing left to sell.");
                        Console.ReadKey();
                        //choice = 0;
                        break;
                    }

                } while (choice < 0 || choice > playerInventory.InventoryList.Count());
            }
            else
            {
                Console.WriteLine("You have nothing to sell.");
                Console.ReadKey();
            }


        }


        //---
    }
}
