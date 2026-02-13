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
    internal class Dungeon : BaseLocation
    {
        public Dungeon()
        {
            Name = "Dungeon";
            LocationKey = 9;
            ConnectingLocations = [8];
            Map = LocationMaps.MapSheet.Dungeon;
            Sprite = LocationSprites.LocationSprites.Dungeon;
            IsDungeon = true;
            BoardDimentions = 15;
        }


        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive at the entrance to a cave.");
            Console.ReadKey();
            Console.WriteLine("The only way in is through a crack in a wooden door.");
            Console.ReadKey();
            Console.WriteLine("There is no other way around the mountains, you must go through");
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
            Console.WriteLine("[4] - Enter the Dungeon");
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

                    if (locationHandler.DungeonCleared)
                    {
                        ConnectingLocations = [8, 10];
                    }

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

            //-----
        }
    }
}
