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


        public override void LocationBattle(BattleHandler.BattleHandler battleHandler, Player.Player player, PlayerInventory playerInventory, ItemCreator itemCreator, BattleText battleText)
        {

            // if(!player.KantoBattleComplete) {do battle}     else{do nothing}
             
            Monster woodsman = new Monster("Woodsman", 25, 20, 17, 18, MonsterSprites.Woodsman, itemCreator.CreateIronAxe());

            battleHandler.Battle(player, woodsman, playerInventory, battleText);

            if(player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("\n\"You got me fair and square, here is the key to the woods.\"");
                Console.ReadKey();
                player.WoodsKey = true;
            }
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
            Console.WriteLine("[6] - Visit Woodsman");
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

                case 6:  // visit person
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
