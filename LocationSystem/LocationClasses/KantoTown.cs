using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
using RPG.Player;
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
            LocationKey = 3;
            ConnectingLocations = [2];
            Map = LocationMaps.MapSheet.KantoTown;
            Sprite = LocationSprites.LocationSprites.KantoTown;
            HasBattle = true;
        }


        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Kanto town - a small northern town near the coast.");
            Console.ReadKey();

        }

        public override void VisitPerson()
        {
            Console.WriteLine("You visit the local Woodsman to ask about the lock on the Woods");
            Console.ReadKey();
            Console.WriteLine("\"The monsters are strong if you cant beat me you wont't stand a chance\"");
            Console.ReadKey();
            Console.WriteLine("They say you can have it, but only if you beat them in a fight");
            Console.ReadKey();
        }


        public override void LocationBattle(BattleParams battleParams, PlayerParams playerParams, ItemCreator itemCreator)
        {

            // if(!player.KantoBattleComplete) {do battle}     else{do nothing}
             
            Monster woodsman = new Monster("Woodsman", 25, 20, 17, 18, 0, MonsterSprites.Woodsman, itemCreator.CreateIronAxe());

            battleParams.BattleHandler.Battle(playerParams, woodsman, battleParams.BattleText);

            if(playerParams.Player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("\n\"You got me fair and square, here is the key to the woods.\"");
                Console.ReadKey();
                playerParams.Player.WoodsKey = true;
            }
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
            Console.WriteLine("[5] - Shop");
            Console.WriteLine("[6] - Leave");
            Console.WriteLine("[7] - Visit Woodsman");

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

                case 4:  //shop
                    Console.Clear();
                    playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location
                    Console.Clear();
                    shopParams.Shop = shopParams.ShopCreator.CreateShopWithKey(location.LocationKey, shopParams.ItemCreator);
                    shopParams.Shop.BuyOrSell(playerParams);
                    Console.ReadKey();
                    break;

                case 6:  // visit person
                    locationParams.LocationHandler.ChangeLocation(location);
                    location = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationParams.LocationHandler.FirstTimeInLocationCheckWithKey(location, playerParams.Player);
                    break;

                case 7:
                    location.VisitPerson();

                    if (location.HasBattle)
                    {
                        location.LocationBattle(battleParams, playerParams, shopParams.ItemCreator);
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






        //-----
    }
}
