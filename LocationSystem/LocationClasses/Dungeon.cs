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

        public override BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams, BattleParams battleParams)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - Rest");
            Console.WriteLine("[2] - View Map");
            Console.WriteLine("[3] - View Stats");
            Console.WriteLine("[4] - View Inventory");
            Console.WriteLine("[5] - Enter the Dungeon");
            Console.WriteLine("[6] - Leave");

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

                case 4:  // dungeon
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
                    Console.ReadKey();
                    
                    break;

                case 5:  // chamge/leave location
                    Console.WriteLine("You brace yourself and enter through the crack of the door.");
                    Console.ReadKey();

                    GameBoard gameBoard = new GameBoard();
                    gameBoard.CreateGameBoard(location.BoardDimentions, 30);
                    gameBoard.BeginDungeon(9, playerParams, battleParams);

                    if (playerParams.Player.Health > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou made your way through the Dungeon.");
                        Console.ReadKey();
                        Console.WriteLine("A new location has been unlocked");
                        Console.ReadKey();
                        locationParams.LocationHandler.DungeonCleared = true;
                    }
                    break;

                case 6:
                    if (locationParams.LocationHandler.DungeonCleared)
                    {
                        ConnectingLocations = [8, 10];
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



        //---
    }
}
