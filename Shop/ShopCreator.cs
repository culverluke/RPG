using RPG.Items;
using RPG.Shop.TownShops;
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

                case 5:
                    return CreateIronShop(itemCreator);
                    break;

                case 6:
                    return CreateNorthShop(itemCreator);
                    break;

                case 8:
                    return CreatePlainsShop(itemCreator);
                    break;

                case 10:
                    return CreateDockShop(itemCreator);
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

        public TownShop CreateIronShop(ItemCreator itemCreator)
        {
            IronShop ironShop = new IronShop(itemCreator);
            return ironShop;
        }

        public TownShop CreateNorthShop(ItemCreator itemCreator)
        {
            NorthShop northShop = new NorthShop(itemCreator);
            return northShop;
        }

        public TownShop CreatePlainsShop(ItemCreator itemCreator)
        {
            PlainsShop plainsShop = new PlainsShop(itemCreator);
            return plainsShop;
        }

        public TownShop CreateDockShop(ItemCreator itemCreator)
        {
            DockShop dockShop = new DockShop(itemCreator);
            return dockShop;
        }

    }
}
