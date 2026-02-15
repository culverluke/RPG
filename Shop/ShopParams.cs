using RPG.Items;
using RPG.LocationSystem.LocationClasses;
using RPG.LocationSystem.LocationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop
{
    internal class ShopParams
    {
        public ShopParams(ShopCreator shopCreator, ItemCreator itemCreator)// remove locationHandler?
        {
            ShopCreator = shopCreator;
            ItemCreator = itemCreator;
            Shop = ShopCreator.CreateKantoShop(itemCreator); 
        }

        public ShopCreator ShopCreator { get; set; }
        public TownShop Shop { get; set; }
        public ItemCreator ItemCreator { get; set; }
    }
}
