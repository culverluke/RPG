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
    internal class FaireTown : BaseLocation
    {
        public FaireTown()
        {
            Name = "Faire Town";
            LocationKey = 2;
            ConnectingLocations = [1, 3, 4];
            Map = LocationMaps.MapSheet.FaireTown;
            Sprite = LocationSprites.LocationSprites.FaireTown;
        }

        public override void FirstTimeInLocationEvent(Player.Player player)
        {
            Console.WriteLine("You arrive in Faire Town, well known for its festivals, however the streets are empty.");
            Console.ReadKey();
            Console.WriteLine("A local tells you this is because the town Mayor has banned all festivity to increace productivity");
            Console.ReadKey();
            Console.WriteLine("\"You might find the main continent on the other side of the Woods more intresting\" - they say");
            Console.ReadKey();
        }

    }
}
