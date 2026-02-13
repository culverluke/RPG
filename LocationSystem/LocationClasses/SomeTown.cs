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
    internal class SomeTown : BaseLocation
    {
        public SomeTown()
        {
            Name = "Some Town";
            LocationKey = 7;
            ConnectingLocations = [6, 8];
            Map = LocationMaps.MapSheet.SomeTown;
            Sprite = LocationSprites.LocationSprites.SomeTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive at Some town, a small forgettable town.");
            Console.ReadKey();
            Console.WriteLine("Not much happens here and people enjoy a quiet life.");
            Console.ReadKey();
            Console.WriteLine("They dont particularly like outsider as they bring trouble.");
            Console.ReadKey();
        }

        public override int LocationMenu(BaseLocation location, Player.Player player, PlayerInventory playerInventory, LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
        {
            return base.LocationMenu(location, player, playerInventory, locationHandler, locationCreator); // change at some point 
        }
    }
}
