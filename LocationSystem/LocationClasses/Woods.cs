using RPG.BattleHandler;
using RPG.DungeonGameBoard;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationClasses
{
    internal class Woods : BaseLocation
    {
        public Woods()
        {
            Name = "The Woods";
            LocationKey = 4;
            ConnectingLocations = [2];
            Map = LocationMaps.MapSheet.Woods;
            Sprite = LocationSprites.LocationSprites.Woods;
            IsDungeon = true;
            BoardDimentions = 10;
        }


        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You stop before a big wood.");
            Console.ReadKey();
            Console.WriteLine("It looks dark and dangerous - however you know the only way past is to go through.");
            Console.ReadKey();
            Console.WriteLine("There is a big gate chained with a padlock.");
            Console.ReadKey();
            Console.WriteLine("Once you go in there is no way out aaside from the other side.");

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
            Console.WriteLine("[4] - Enter the Woods");
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

                    if (player.WoodsKey)
                    {
                        Console.WriteLine("You unlock the gate with the key the Woodsman gave you.");
                        Console.ReadKey();
                        return 8;
                    }
                    else
                    {
                        Console.WriteLine("You do not have a key to unlock the gate.");
                        Console.ReadKey();
                        Console.WriteLine("You heard people in Faire town mention a Woodsman that lives in Kanto town");
                        Console.ReadKey();
                        Console.WriteLine("You cannot carry on so have to go back");
                        Console.ReadKey();
                        return 5;
                    }

                    Console.Clear();
                    Console.WriteLine("Not Implemented");
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location

                    // if woodsCleared = false; send to faireTown / return 10
                    if(locationHandler.WoodsCleared)
                    {
                        ConnectingLocations = [2, 5];
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
            //return location;

        }
        //-----
    }
}
