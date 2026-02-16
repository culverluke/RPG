using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
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
    internal abstract class BaseLocation
    {
        public BaseLocation()
        {
            Name = "";
            ConnectingLocations = [0];
            Map = "";
            Sprite = "";
        }

        public string Name { get; set; }
        public int LocationKey { get; set; }
        public int[] ConnectingLocations { get; set; }
        public string Map { get; set; }
        public string Sprite { get; set; }
        public int BoardDimentions { get; set; }


        public bool IsDungeon = false;
        public bool HasBattle = false;


        public virtual void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("Location Event");
            Console.ReadKey();
        }

        public virtual void VisitPerson()
        {
            Console.WriteLine("You vivit someone in town");
            Console.ReadKey();
        }

        public virtual void LocationBattle(BattleParams battleParams, PlayerParams playerParams, ItemCreator itemCreator)
        {
            Console.WriteLine("Locastion has battle");
        }

        public void PrintSprite()
        {
            Console.WriteLine(Sprite);
        }

        public void PrintMap()
        {
            Console.WriteLine(Map);
        }


        public virtual BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams, BattleParams battleParams)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - Rest");
            Console.WriteLine("[2] - View Map");
            Console.WriteLine("[3] - View Stats");
            Console.WriteLine("[4] - View Inventory");
            Console.WriteLine("[5] - Shop");
            Console.WriteLine("[6] - Leave");
            // add rest to re-set hp?

            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    playerParams.Player.Rest();
                    break;

                case 2:
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    playerParams.Player.PrintStats();
                    Console.ReadKey();
                    break;

                case 4:  //shop
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location
                    Console.Clear();
                    shopParams.Shop = shopParams.ShopCreator.CreateShopWithKey(location.LocationKey, shopParams.ItemCreator);
                    shopParams.Shop.BuyOrSell(playerParams);
                    Console.ReadKey();
                    
                    break;

                case 6:
                    locationParams.LocationHandler.ChangeLocation(location);
                    location = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationParams.LocationHandler.FirstTimeInLocationCheckWithKey(location, playerParams.Player);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }

            return location;

        }

        //-----
    }
}
