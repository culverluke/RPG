using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class NorthShop : TownShop
    {
        public NorthShop(ItemCreator itemCreator)
        {
            ShopKey = 5;

            ShopInventory.AddToInventory(itemCreator.CreateSteelSword());
            ShopInventory.AddToInventory(itemCreator.CreateIronAxe());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }
    }
}
