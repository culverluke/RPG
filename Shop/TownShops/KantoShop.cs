using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class KantoShop : TownShop
    {
        public KantoShop(ItemCreator itemCreator)
        {
            ShopKey = 3;

            ShopInventory.AddToInventory(itemCreator.CreateIronAxe());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }

    }
}
