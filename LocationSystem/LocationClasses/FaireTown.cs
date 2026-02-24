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
    internal class FaireTown : BaseLocation
    {
        public FaireTown()
        {
            Name = "Faire Town";
            LocationKey = 1;
            ConnectingLocations = [0, 2, 3];
            Map = LocationMaps.MapSheet.FaireTown;
            Sprite = LocationSprites.LocationSprites.FaireTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Faire Town, well known for its festivals, however the streets are empty.");
            Console.ReadKey();
            Console.WriteLine("A local tells you this is because the town Mayor has banned all festivity to increace productivity");
            Console.ReadKey();
            Console.WriteLine("\"You might find the main continent on the other side of the Woods more intresting\" - they say");
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


        //---
    }
}
