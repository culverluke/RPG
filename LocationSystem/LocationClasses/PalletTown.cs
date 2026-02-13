using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem.LocationHandler;
using RPG.LocationSystem.LocationSprites;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
using RPG.Player;
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
            LocationKey = 1;
            ConnectingLocations = [2];
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



        public override void LocationBattle(BattleHandler.BattleHandler battleHandler, Player.Player player, PlayerInventory playerInventory, ItemCreator itemCreator, BattleText battleText)
        {
            Monster dad = new Monster("Dad", 20, 50, 12, 20, MonsterSprites.Dad, itemCreator.CreateIronSword());

            battleHandler.Battle(player, dad, playerInventory, battleText);
        }


        //  viewMap, viewStats, viewInventory, shop, visit ?, leaveLocation
        
        

        //---------------
    }
}
