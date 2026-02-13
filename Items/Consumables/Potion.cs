using RPG.Inventory.PlayerInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Consumables
{
    internal class Potion : Item
    {
        public Potion()
        {
            Name = "Potion";
            Weight = 0.5f;
            Value = 10;
        }

        public override void UseItem(Player.Player player, PlayerInventory playerInventory)
        {
            player.Health += 10;
            player.Health = Math.Clamp(player.Health, 0, player.MaxHealth);

            playerInventory.RemoveFromInventory(this);
        }
    }
}
