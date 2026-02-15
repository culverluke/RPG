using RPG.BattleHandler;
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
    internal class IronTown : BaseLocation
    {
        public IronTown()
        {
            Name = "Iron Town";
            LocationKey = 5;
            ConnectingLocations = [4, 6, 8];
            Map = LocationMaps.MapSheet.IronTown;
            Sprite = LocationSprites.LocationSprites.IronTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Iron town, famous for its mines.");
            Console.ReadKey();
            Console.WriteLine("Its central location make its the continents trade hub.");
            Console.ReadKey();
        }

        public override void VisitPerson()
        {
            Console.WriteLine("You overhear the locals talking about a Castle Lord in the Island's Castle.");
            Console.ReadKey();
            Console.WriteLine("They say his men are already coming round the mountains towards Plains town");
            Console.ReadKey();
            Console.WriteLine("\"If only someone would kill him then men would go back\"");
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
            Console.WriteLine("[6] - Listen in on locals");
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

                case 6:  // visit person

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


        //-------
    }
}
