using RPG.Inventory.PlayerInventory;
using RPG.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Weapons
{
    internal class Weapon : Item
    {
        
        public int Power { get; set; }
        public float WeaponSpeed { get; set; }

        public override void UseItem(Player.Player player, PlayerInventory playerInventory)
        {
            player.EquipWeapon(this, playerInventory);
        }
    }
}
