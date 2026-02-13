using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
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

        public override void LocationBattle(BattleHandler.BattleHandler battleHandler, Player.Player player, PlayerInventory playerInventory, ItemCreator itemCreator, BattleText battleText)
        {
            Monster banditSecond = new Monster("Second in Command", 30, 18, 18, 15, MonsterSprites.BanditSecond, itemCreator.CreateIronSword());

            battleHandler.Battle(player, banditSecond, playerInventory, battleText);

            if (player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("Your fight drew the attention of the bandit leader.");
                Console.ReadKey();
                Console.WriteLine("Without giving you time to breathe he strikes!");
                Console.ReadKey();
                Console.Clear();

                Monster banditLeader = new Monster("Bandit Leader", 35, 22, 12, 25, MonsterSprites.BanditLeader, itemCreator.CreateSteelSword());

                battleHandler.Battle(player, banditLeader, playerInventory, battleText);

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

        public override int LocationMenu(BaseLocation location, Player.Player player, PlayerInventory playerInventory, LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
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
                    return 1;
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    break;

                case 2:
                    return 2;
                    Console.Clear();
                    player.PrintStats();
                    Console.ReadKey();
                    break;

                case 3:
                    return 3;
                    Console.Clear();
                    playerInventory.Display();
                    Console.ReadKey();
                    break;

                case 4:  //shop
                    return 4;
                    Console.Clear();
                    Console.WriteLine("Not Implemented");
                    Console.ReadKey();
                    break;

                case 5:  // chamge/leave location
                    return 5;
                    locationHandler.ChangeLocation(location);
                    location = locationCreator.CreateTownWithKey(locationHandler.CurrentLocationKey);
                    Console.Clear();
                    location.PrintMap();
                    Console.ReadKey();
                    Console.WriteLine();
                    locationHandler.FirstTimeInLocationCheckWithKey(location, player);
                    break;

                case 6:  // visit()
                    return 6;
                    break;

                default:
                    return 9;
                    Console.Clear();
                    Console.WriteLine("Pick an option from the menu");
                    Console.ReadKey();
                    break;

            }


        }


        //-----
    }
}
