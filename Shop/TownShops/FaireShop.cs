using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class FaireShop : TownShop
    {
        public FaireShop(ItemCreator itemCreator)
        {
            ShopKey = 1;

            ShopInventory.AddToInventory(itemCreator.CreateIronSword());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }

    }
}
