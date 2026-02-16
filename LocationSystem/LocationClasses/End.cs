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
            Console.WriteLine("[5] - Enter the Castle");
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

                case 4: 
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
                    Console.ReadKey();
                    break;

                case 5:  
                    Console.WriteLine("You enter the castle unsure of what you will find");
                    Console.ReadKey();

                    GameBoard gameBoard = new GameBoard();
                    gameBoard.CreateGameBoard(location.BoardDimentions, 30);
                    gameBoard.BeginDungeon(11, playerParams, battleParams);

                    if (playerParams.Player.Health > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou made your way through the castle");
                        Console.ReadKey();
                        Console.WriteLine("The big bad awaits you");
                        Console.ReadKey();
                        Console.WriteLine("Not Implemented");
                    }
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


        //---
    }
}
