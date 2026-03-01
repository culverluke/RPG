using Microsoft.CodeAnalysis;
using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem.LocationHandler;
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
    internal class KantoTown : BaseLocation
    {
        public KantoTown()
        {
            Name = "Kanto Town";
            LocationKey = 2;
            ConnectingLocations = [1];
            Map = LocationMaps.MapSheet.KantoTown;
            Sprite = LocationSprites.LocationSprites.KantoTown;
            CustomEvent = VisitWoodsman;
            LocationBattle = WoodsmanBattle;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Kanto town - a small northern town near the coast.");
            Console.ReadKey();

        }

        public void VisitWoodsman()
        {
            Console.WriteLine("You visit the local Woodsman to ask about the lock on the Woods");
            Console.ReadKey();
            Console.WriteLine("\"The monsters are strong if you cant beat me you wont't stand a chance\"");
            Console.ReadKey();
            Console.WriteLine("They say you can have it, but only if you beat them in a fight");
            Console.ReadKey();
        }


        public void WoodsmanBattle(BattleParams battleParams, PlayerParams playerParams, ItemCreator itemCreator, UserInput.UserInput userInput, LocationHandler.LocationHandler locationHandler)
        {

            // if(!player.KantoBattleComplete) {do battle}     else{do nothing}
             
            Monster woodsman = new Monster("Woodsman", 25, 20, 17, 18, 0, MonsterSprites.Woodsman, itemCreator.CreateIronAxe());

            battleParams.BattleHandler.Battle(playerParams, woodsman, battleParams.BattleText, userInput, locationHandler);

            if(playerParams.Player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("\n\"You got me fair and square, here is the key to the woods.\"");
                Console.ReadKey();
                playerParams.Player.WoodsKey = true;
            }
           
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
            Console.WriteLine("[8] - Visit Woodsman");

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

                    location.LocationBattle(battleParams, playerParams, shopParams.ItemCreator, userInput, locationParams.LocationHandler);
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
