using RPG.Inventory.PlayerInventory;
using RPG.Inventory.ShopInventory;
using RPG.Items;
using RPG.Player;
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


        public void BuyOrSell(PlayerParams playerParams)
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
                        Buy(playerParams);
                        break;

                    case 2:// sell
                        Sell(playerParams);
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
                BuyOrSell(playerParams);
            }
        }

        public void Buy(PlayerParams playerParams)
        {

            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine($"Player Gold - {playerParams.Player.Gold}\n");
                ShopInventory.Display();
                Console.WriteLine("Select the item you want to buy");
                Console.WriteLine("\n0 to EXIT");
                int.TryParse(Console.ReadLine(), out choice);

                if (choice > 0 && choice <= ShopInventory.InventoryList.Count())
                {
                    if(playerParams.Player.Gold >= ShopInventory.InventoryList[choice - 1].Value)
                    {
                        playerParams.PlayerInventory.AddToInventory(ShopInventory.InventoryList[choice - 1]);
                        Console.WriteLine($"\nYou bought the {ShopInventory.InventoryList[choice - 1].Name}");
                        playerParams.Player.RemoveGold(ShopInventory.InventoryList[choice - 1].Value);
                        Console.ReadKey();
                        choice = 99;
                    }
                    else
                    {
                        Console.WriteLine("You dont have enough Gold");
                        Console.ReadKey();
                    }

                }


            } while (choice < 0 || choice > ShopInventory.InventoryList.Count());


            //if (choice > 0 && choice <= ShopInventory.InventoryList.Count())
            //{
               // playerInventory.AddToInventory(ShopInventory.InventoryList[choice - 1]);
                //ShopInventory.InventoryList.Remove(ShopInventory.InventoryList[choice - 1]);
            //}
        }

        public void Sell(PlayerParams playerParams)
        {
            int choice = 99;

            if(playerParams.PlayerInventory.InventoryList.Count() > 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Player Gold - {playerParams.Player.Gold}\n");
                    playerParams.PlayerInventory.Display();
                    Console.WriteLine("Select the item you want to sell");
                    Console.WriteLine("\n0 to EXIT");
                    int.TryParse(Console.ReadLine(), out choice);

                    if (choice > 0 && choice <= playerParams.PlayerInventory.InventoryList.Count())
                    {
                        Console.WriteLine($"\nYou sold the {playerParams.PlayerInventory.InventoryList[choice - 1].Name}");
                        Console.WriteLine($"You got {playerParams.PlayerInventory.InventoryList[choice - 1].Value} Gold");
                        playerParams.Player.Gold += playerParams.PlayerInventory.InventoryList[choice - 1].Value;
                        playerParams.PlayerInventory.RemoveFromInventory(playerParams.PlayerInventory.InventoryList[choice - 1]);
                        Console.ReadKey();
                        choice = 99;
                    }

                    if(playerParams.PlayerInventory.InventoryList.Count() <= 0)
                    {
                        Console.WriteLine("\nYou have nothing left to sell.");
                        Console.ReadKey();
                        //choice = 0;
                        break;
                    }

                } while (choice < 0 || choice > playerParams.PlayerInventory.InventoryList.Count());
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
