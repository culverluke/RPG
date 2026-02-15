using RPG.BattleHandler;
using RPG.DungeonGameBoard;
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

        public override BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams, BattleParams battleParams)
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
                    
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 2:
                    
                    Console.Clear();
                    playerParams.Player.PrintStats();
                    Console.ReadKey();
                    break;

                case 3:
                    
                    Console.Clear();
                    playerParams.PlayerInventory.Display();
                    Console.ReadKey();
                    break;

                case 4:  // dungeon

                    if (playerParams.Player.WoodsKey)
                    {
                        Console.WriteLine("You unlock the gate with the key the Woodsman gave you.");
                        Console.ReadKey();

                        GameBoard gameBoard = new GameBoard();
                        gameBoard.CreateGameBoard(location.BoardDimentions, 30);
                        gameBoard.BeginDungeon(playerParams, battleParams);

                        if (location.LocationKey == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou made your way through the Woods.");
                            Console.ReadKey();
                            Console.WriteLine("A new location has been unlocked");
                            Console.ReadKey();
                            locationParams.LocationHandler.WoodsCleared = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have a key to unlock the gate.");
                        Console.ReadKey();
                        Console.WriteLine("You heard people in Faire town mention a Woodsman that lives in Kanto town");
                        Console.ReadKey();
                        Console.WriteLine("You cannot carry on so have to go back");
                        Console.ReadKey();

                        location = LocationMenu(location, playerParams, shopParams, locationParams, battleParams);
                    }

                    break;

                case 5:  // chamge/leave location

                    // if woodsCleared = false; send to faireTown / return 10
                    if(locationParams.LocationHandler.WoodsCleared)
                    {
                        ConnectingLocations = [2, 5];
                    }

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
