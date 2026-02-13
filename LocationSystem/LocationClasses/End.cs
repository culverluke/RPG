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
    internal class End : BaseLocation
    {
        public End()
        {
            Name = "End";
            LocationKey = 11;
            ConnectingLocations = [10];
            Map = LocationMaps.MapSheet.End;
            Sprite = LocationSprites.LocationSprites.End;
            IsDungeon = true;
            BoardDimentions = 20;
        }


        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("FirstTimeInLocationEvent");
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
            Console.WriteLine("[4] - Enter the Castle");
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

                case 4:  // dungeon

                    Console.WriteLine("You brace yourself and enter through the crack of the door.");
                    Console.ReadKey();
                    return 8;
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
        }
    }
}
