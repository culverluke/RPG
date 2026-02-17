using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class IronShop : TownShop
    {
        public IronShop(ItemCreator itemCreator)
        {
            ShopKey = 4;

            ShopInventory.AddToInventory(itemCreator.CreateSteelDagger());
            ShopInventory.AddToInventory(itemCreator.CreateSteelSword());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }

    }
}
