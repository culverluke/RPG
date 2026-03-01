using RPG.BattleHandler;
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
    internal class IronTown : BaseLocation
    {
        public IronTown()
        {
            Name = "Iron Town";
            LocationKey = 4;
            ConnectingLocations = [3, 5, 7];
            Map = LocationMaps.MapSheet.IronTown;
            Sprite = LocationSprites.LocationSprites.IronTown;
            CustomEvent = ListenToLocals;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Iron town, famous for its mines.");
            Console.ReadKey();
            Console.WriteLine("Its central location make its the continents trade hub.");
            Console.ReadKey();
        }

        public void ListenToLocals()
        {
            Console.WriteLine("You overhear the locals talking about a Castle Lord in the Island's Castle.");
            Console.ReadKey();
            Console.WriteLine("They say his men are already coming round the mountains towards Plains town");
            Console.ReadKey();
            Console.WriteLine("\"If only someone would kill him then men would go back\"");
            Console.ReadKey();
        }


        public override BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams,
                        BattleParams battleParams, UserInput.UserInput userInput, SaveData saveData)
        {
            Console.Clear();
            location.PrintSprite();
            Console.WriteLine("\n");

            int choice = 99;

            Console.WriteLine("[1] - Rest");
            Console.WriteLine("[2] - Shop");
            DisplayLatterMenu();
            Console.WriteLine("[8] - Listen in on locals");

            choice = userInput.GetValidInt();

            switch (choice)
            {
                case 1:
                    playerParams.Player.Rest();
                    break;

                case 2: // shop
                    Console.Clear();
                    shopParams.Shop = shopParams.ShopCreator.CreateShopWithKey(location.LocationKey, shopParams.ItemCreator);
                    shopParams.Shop.BuyOrSell(playerParams, userInput);
                    Console.ReadKey();
                    
                    break;

                case 3: // leave
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

                case 5:  // map
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 6:  // stats
                    Console.Clear();
                    playerParams.Player.PrintStats();
                    Console.ReadKey();
                    break;

                case 7:
                    saveData.SaveLocationHandler(locationParams.LocationHandler);
                    saveData.SavePlayer(playerParams.Player);
                    saveData.SavePlayerInventory(playerParams.PlayerInventory);
                    break;

                case 8: // visit
                    location.CustomEvent();

                    if (LocationBattle != null)
                    {
                        location.LocationBattle(battleParams, playerParams, shopParams.ItemCreator, userInput, locationParams.LocationHandler);
                    }
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }

            return location;

        }


        //-------
    }
}
