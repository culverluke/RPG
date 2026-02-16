using RPG.LocationSystem.LocationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem
{
    internal class LocationParams
    {
        public LocationParams(LocationHandler.LocationHandler locationHandler, LocationCreator locationCreator)
        {
            LocationHandler = locationHandler;
            LocationCreator = locationCreator;
        }


        public LocationHandler.LocationHandler LocationHandler { get; set; }
        public LocationCreator LocationCreator { get; set; }
    }
}
