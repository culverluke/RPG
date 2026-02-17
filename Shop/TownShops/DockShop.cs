using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class DockShop : TownShop
    {
        public DockShop(ItemCreator itemCreator)
        {
            ShopKey = 9;

            ShopInventory.AddToInventory(itemCreator.CreateSteelAxe());
            ShopInventory.AddToInventory(itemCreator.CreateSteelSword());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }
    }
}
