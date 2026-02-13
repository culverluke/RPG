using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Shop
{
    internal class ShopCreator
    {

        public TownShop CreateShopWithKey(int locationKey, ItemCreator itemCreator)
        {
            switch(locationKey)
            {
                case 2:
                    return CreateFaireShop(itemCreator);
                    break;

                case 3:
                    return CreateKantoShop(itemCreator);
                    break;

            }

            return CreateFaireShop(itemCreator);
        }

        public TownShop CreateFaireShop(ItemCreator itemCreator)
        {
            FaireShop faireShop = new FaireShop(itemCreator);
            return faireShop;
        }

        public TownShop CreateKantoShop(ItemCreator itemCreator)
        {
            KantoShop kantoShop = new KantoShop(itemCreator);
            return kantoShop;
        }

    }
}
