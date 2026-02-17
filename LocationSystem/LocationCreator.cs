using RPG.LocationSystem.LocationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem
{
    internal class LocationCreator
    {

        public BaseLocation CreateTownWithKey(int locationKey)
        {

            switch (locationKey)
            {
                case 0:
                    return CreatePalletTown();
                    break;

                case 1:
                    return CreateFaireTown();
                    break;

                case 2:
                    return CreateKantoTown();
                    break;

                case 3:
                    return CreateWoods();
                    break;

                case 4:
                    return CreateIronTown()
;                    break;

                case 5:
                    return CreateNorthTown();
                    break;

                case 6:
                    return CreateSomeTown();
                    break;

                case 7:
                    return CreatePlainsTown();
                    break;

                case 8:
                    return CreateDungeon();
                    break;

                case 9:
                    return CreateDockTown();
                    break;

                case 10:
                    return CreateEnd();
                    break;
            }
            return CreatePalletTown();
        }


        public PalletTown CreatePalletTown()
        {
            PalletTown palletTown = new PalletTown();
            return palletTown;
        }

        public FaireTown CreateFaireTown()
        {
            FaireTown faireTown = new FaireTown();
            return faireTown;
        }

        public KantoTown CreateKantoTown()
        {
            KantoTown kantoTown = new KantoTown();
            return kantoTown;
        }

        public Woods CreateWoods()
        {
            Woods woods = new Woods();
            return woods;
        }

        public IronTown CreateIronTown()
        {
            IronTown ironTown = new IronTown();
            return ironTown;
        }

        public NorthTown CreateNorthTown()
        {
            NorthTown northTown = new NorthTown();
            return northTown;
        }

        public SomeTown CreateSomeTown()
        {
            SomeTown someTown = new SomeTown();
            return someTown;
        }

        public PlainsTown CreatePlainsTown()
        {
            PlainsTown plainsTown = new PlainsTown();
            return plainsTown;
        }

        public Dungeon CreateDungeon()
        {
            Dungeon dungeon = new Dungeon();
            return dungeon;
        }

        public DockTown CreateDockTown()
        {
            DockTown dockTown = new DockTown();
            return dockTown;
        }

        public End CreateEnd()
        {
            End end = new End();
            return end;
        }
    }
}
