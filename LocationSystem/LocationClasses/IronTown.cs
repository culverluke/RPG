using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationClasses
{
    internal class IronTown : BaseLocation
    {
        public IronTown()
        {
            Name = "Iron Town";
            LocationKey = 5;
            ConnectingLocations = [4, 6, 8];
            Map = LocationMaps.MapSheet.IronTown;
            Sprite = LocationSprites.LocationSprites.IronTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Iron town, famous for its mines.");
            Console.ReadKey();
            Console.WriteLine("Its central location make its the continents trade hub.");
            Console.ReadKey();
        }

        public override void VisitPerson()
        {
            Console.WriteLine("You overhear the locals talking about a Castle Lord in the Island's Castle.");
            Console.ReadKey();
            Console.WriteLine("They say his men are already coming round the mountains towards Plains town");
            Console.ReadKey();
            Console.WriteLine("\"If only someone would kill him then men would go back\"");
            Console.ReadKey();
        }

        public override int LocationMenu(BaseLocation location, Player.Player player, PlayerInventory playerInventory, LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
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
            Console.WriteLine("[6] - Listen in on locals");
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

                case 6:  // visit person
                    return 6;
                    break;

                default:
                    return 9;
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }


        }


        //-------
    }
}
