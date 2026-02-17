using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationClasses
{
    internal class DockTown : BaseLocation
    {
        public DockTown()
        {
            Name = "DockTown";
            LocationKey = 9;
            ConnectingLocations = [8, 10];
            Map = LocationMaps.MapSheet.DockTown;
            Sprite = LocationSprites.LocationSprites.DockTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Dock town, another major trade hub.");
            Console.ReadKey();
            Console.WriteLine("The town is controlled by the Castle Lord and his men.");
            Console.ReadKey();
            Console.WriteLine("You try to draw as little attention as possible.");
            Console.ReadKey();
        }

        public override BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams, BattleParams battleParams)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - Rest");
            Console.WriteLine("[2] - Shop");
            DisplayLatterMenu();

            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    playerParams.Player.Rest();
                    break;

                case 2: // shop 
                    Console.Clear();
                    shopParams.Shop = shopParams.ShopCreator.CreateShopWithKey(location.LocationKey, shopParams.ItemCreator);
                    shopParams.Shop.BuyOrSell(playerParams);
                    Console.ReadKey();
                    break;

                case 3: // leave
                    locationParams.LocationHandler.ChangeLocation(location);
                    location = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationParams.LocationHandler.FirstTimeInLocationCheckWithKey(location, playerParams.Player);
                    break;

                case 4:  // inv
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
                    Console.ReadKey();
                    break;

                case 5:  // map
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 6: // stats
                    Console.Clear();
                    playerParams.Player.PrintStats();
                    Console.ReadKey();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }

            return location;

        }


        //---
    }
}
