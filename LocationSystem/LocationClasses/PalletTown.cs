using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem.LocationHandler;
using RPG.LocationSystem.LocationSprites;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
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
    internal class PalletTown : BaseLocation
    {
        public PalletTown()
        {
            Name = "Pallet Town";
            LocationKey = 0;
            ConnectingLocations = [1];
            Map = LocationMaps.MapSheet.PalletTown;
            Sprite = LocationSprites.LocationSprites.PalletTown;
            HasBattle = true;
        }


        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("Your dad wants to see if you are ready to go out alone.");
            Console.ReadKey();
            Console.WriteLine("He gives you an Iron Dagger and tells you: ");
            Console.ReadKey();
            Console.WriteLine("DEFEND YOURSELF!");
            Console.ReadKey();
            Console.Clear();

        }



        public override void LocationBattle(BattleParams battleParams, PlayerParams playerParams, ItemCreator itemCreator, UserInput.UserInput userInput, LocationHandler.LocationHandler locationHandler)
        {
            Monster dad = new Monster("Dad", 20, 50, 12, 20, 0, MonsterSprites.Dad, itemCreator.CreateIronSword());

            battleParams.BattleHandler.Battle(playerParams, dad, battleParams.BattleText, userInput, locationHandler);
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

            Int32.TryParse(Console.ReadLine(), out choice);

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



        //---------------
    }
}
