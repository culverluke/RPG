using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop.TownShops
{
    internal class PlainsShop : TownShop
    {
        public PlainsShop(ItemCreator itemCreator)
        {
            ShopKey = 8;

            ShopInventory.AddToInventory(itemCreator.CreateSteelSword());
            ShopInventory.AddToInventory(itemCreator.CreateSteelAxe());
            ShopInventory.AddToInventory(itemCreator.CreatePotion());
        }
    }
}
