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
    internal class DockTown : BaseLocation
    {
        public DockTown()
        {
            Name = "DockTown";
            LocationKey = 10;
            ConnectingLocations = [9, 11];
            Map = LocationMaps.MapSheet.DockTown;
            Sprite = LocationSprites.LocationSprites.DockTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Dock town, another major trade hub.");
            Console.ReadKey();
            Console.WriteLine("The town is controlled by the Castle Lord and his men.");
            Console.ReadKey();
            Console.WriteLine("You try to draw as little attention as possible.");
            Console.ReadKey();
        }


    }
}
