using RPG.BattleHandler;
using RPG.DungeonGameBoard;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.SaveAndLoad;
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
            LocationKey = 3;
            ConnectingLocations = [1];
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
            Console.WriteLine("Once you go in there is no way out aside from the other side.");

        }

        public override BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams,
                        BattleParams battleParams, UserInput.UserInput userInput, SaveData saveData)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - Rest");
            Console.WriteLine("[2] - Enter the Woods");
            DisplayLatterMenu();

            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    playerParams.Player.Rest();
                    break;

                case 2: //  enter
                    if (playerParams.Player.WoodsKey)
                    {
                        Console.WriteLine("You unlock the gate with the key the Woodsman gave you.");
                        Console.ReadKey();

                        GameBoard gameBoard = new GameBoard();
                        gameBoard.CreateGameBoard(location.BoardDimentions, 30);
                        gameBoard.BeginDungeon(4, playerParams, battleParams, userInput, saveData, locationParams.LocationHandler);

                        if (playerParams.Player.Health > 0)
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

                        location = LocationMenu(location, playerParams, shopParams, locationParams, battleParams, userInput, saveData);
                    }
                    break;

                case 3: // leave
                    if (locationParams.LocationHandler.WoodsCleared)
                    {
                        ConnectingLocations = [1, 4];
                    }

                    locationParams.LocationHandler.ChangeLocation(location, userInput);
                    location = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationParams.LocationHandler.FirstTimeInLocationCheckWithKey(location, playerParams.Player); 
                    break;

                case 4:  // inv
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player, userInput);
                    Console.ReadKey();
                    break;

                case 5: // map
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 6: // stats
                    Console.Clear();
                    playerParams.Player.PrintStats();
                    Console.ReadKey();
                    break;

                case 7:
                    saveData.SaveLocationHandler(locationParams.LocationHandler);
                    saveData.SavePlayer(playerParams.Player);
                    saveData.SavePlayerInventory(playerParams.PlayerInventory);
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
