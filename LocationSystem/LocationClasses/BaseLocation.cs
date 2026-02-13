using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Monsters.MonsterClasses;
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

        public int BoardDimentions { get; set; }

        public bool IsDungeon = false;
        public bool HasBattle = false;
        public string Name { get; set; }
        public int LocationKey { get; set; }
        public int[] ConnectingLocations { get; set; }
        public string Map { get; set; }
        public string Sprite { get; set; }


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

        public virtual void LocationBattle(BattleHandler.BattleHandler battleHandler, Player.Player player, PlayerInventory playerInventory, ItemCreator itemCreator, BattleText battleText)
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


        public virtual int LocationMenu(BaseLocation location, Player.Player player, PlayerInventory playerInventory, LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - View Map");
            Console.WriteLine("[2] - View Stats");
            Console.WriteLine("[3] - View Inventory");
            Console.WriteLine("[4] - Shop");
            Console.WriteLine("[5] - Leave");
            // add rest to re-set hp?

            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    return 1;
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 2:
                    return 2;
                    Console.Clear();
                    player.PrintStats();
                    Console.ReadKey();
                    break;

                case 3:
                    return 3;
                    Console.Clear();
                    playerInventory.Display();
                    Console.ReadKey();
                    break;

                case 4:  //shop
                    return 4;
                    Console.Clear();
                    Console.WriteLine("Not Implemented");
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location
                    return 5;
                    locationHandler.ChangeLocation(location);
                    location = locationCreator.CreateTownWithKey(locationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationHandler.FirstTimeInLocationCheckWithKey(location, player);
                    break;

                default:
                    return 9;
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }
            //return location;

        }

        //-----
    }
}
