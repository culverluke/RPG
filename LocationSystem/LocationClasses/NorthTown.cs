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
    internal class NorthTown : BaseLocation
    {
        public NorthTown()
        {
            Name = "North Town";
            LocationKey = 6;
            ConnectingLocations = [5, 7];
            Map = LocationMaps.MapSheet.NorthTown;
            Sprite = LocationSprites.LocationSprites.NorthTown;
            HasBattle = true;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive at North town, the northern most town.");
            Console.ReadKey();
            Console.WriteLine("The land here is rough and life is tough.");
            Console.ReadKey();
            Console.WriteLine("You hear murmurs of bandits stealing the towns cattle.");
            Console.ReadKey();
        }

        public override void LocationBattle(BattleParams battleParams, PlayerParams playerParams, ItemCreator itemCreator)
        {
            Monster banditSecond = new Monster("Second in Command", 30, 18, 18, 15, MonsterSprites.BanditSecond, itemCreator.CreateIronSword());

            battleParams.BattleHandler.Battle(playerParams, banditSecond, battleParams.BattleText);

            if (playerParams.Player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("Your fight drew the attention of the bandit leader.");
                Console.ReadKey();
                Console.WriteLine("Without giving you time to breathe he strikes!");
                Console.ReadKey();
                Console.Clear();

                Monster banditLeader = new Monster("Bandit Leader", 35, 22, 12, 25, MonsterSprites.BanditLeader, itemCreator.CreateSteelSword());

                battleParams.BattleHandler.Battle(playerParams, banditLeader, battleParams.BattleText);

                Console.Clear();
                Console.WriteLine("You cut down the bandit leader and the rest scattered.");
                Console.ReadKey();
                Console.WriteLine("When you return the townsfolk are delighted.");
                Console.ReadKey();
                Console.WriteLine("They say life should be a little bit easier from now on.");
                Console.ReadKey();
            }
        }

        public override void VisitPerson()
        {
            Console.WriteLine("You walk up to a group of villagers and offer to stop the bandits.");
            Console.ReadKey();
            Console.WriteLine("They look you up and down doubting whether you are up to the task.");
            Console.ReadKey();
            Console.WriteLine("They agree they dont have much of a choice and point you in their direction.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("You arrive at the bandits hideout, but they wont let you see their leader.");
            Console.ReadKey();
            Console.WriteLine("\"If you want to see the boss you'll have to go through me first!\"");
            Console.ReadKey();
            Console.WriteLine("A large proud man steps up and draws his sword.");
            Console.ReadKey();
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
            Console.WriteLine("[4] - Shop");
            Console.WriteLine("[5] - Leave");
            Console.WriteLine("[6] - Offer to stop the bandits");
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

                case 4:  //shop
                    
                    Console.Clear();
                    shopParams.Shop = shopParams.ShopCreator.CreateShopWithKey(location.LocationKey, shopParams.ItemCreator);
                    shopParams.Shop.BuyOrSell(playerParams.PlayerInventory);
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location
                    
                    locationParams.LocationHandler.ChangeLocation(location);
                    location = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationParams.LocationHandler.FirstTimeInLocationCheckWithKey(location, playerParams.Player);
                    break;

                case 6:  // visit()
                    location.VisitPerson();

                    if (location.HasBattle)
                    {
                        location.LocationBattle(battleParams, playerParams, shopParams.ItemCreator);
                    }
                    break;
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
