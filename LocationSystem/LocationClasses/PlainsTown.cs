using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationClasses
{
    internal class PlainsTown : BaseLocation
    {
        public PlainsTown()
        {
            Name = "Plains Town";
            LocationKey = 8;
            ConnectingLocations = [5, 7, 9];
            Map = LocationMaps.MapSheet.PlainsTown;
            Sprite = LocationSprites.LocationSprites.PlainsTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in plains town, a rich town on the coast.");
            Console.ReadKey();
            Console.WriteLine("People are agitated as the town often gets raided by the Castle Lord's men.");
            Console.ReadKey();
            Console.WriteLine("They come through the dungeon to attack.");
            Console.ReadKey();
        }

        public override int LocationMenu(BaseLocation location, Player.Player player, PlayerInventory playerInventory, LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
        {
            return base.LocationMenu(location, player, playerInventory, locationHandler, locationCreator); // might chance to add visit()
        }
    }
}
