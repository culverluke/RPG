using RPG.Inventory.PlayerInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Player
{
    internal class PlayerParams
    {
        public PlayerParams(Player player, PlayerInventory playerInventory)
        {
            Player = player;
            PlayerInventory = playerInventory;
        }


        public Player Player { get; set; }
        public PlayerInventory PlayerInventory { get; set; }
    }
}
