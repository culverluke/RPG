using RPG.LocationSystem.LocationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationHandler
{
    internal class LocationHandler
    {
        public LocationHandler()
        {
            LocationDictionary = new();
            LocationDictionary = CreateDictionary();

            FirstTimeInPallet = true;
            FirstTimeInFaire = true;
            FirstTimeInKanto = true;
            FirstTimeInWoods = true;
            FirstTimeInIron = true;
            FirstTimeInNorth = true;
            FirstTimeInSome = true;
            FirstTimeInPlains = true;
            FirstTimeInDungeon = true;
            FirstTimeInDock = true;
            FirstTimeInEnd = true;
            WoodsCleared = false;
            DungeonCleared = false;
        }



        public int CurrentLocationKey { get; set; }
        public Dictionary<int, string> LocationDictionary { get; }

        public bool FirstTimeInPallet { get; set; }
        public bool FirstTimeInFaire { get; set; }
        public bool FirstTimeInKanto { get; set; }
        public bool FirstTimeInWoods { get; set; }
        public bool FirstTimeInIron { get; set; }
        public bool FirstTimeInNorth { get; set; }
        public bool FirstTimeInSome { get; set; }
        public bool FirstTimeInPlains { get; set; }
        public bool FirstTimeInDungeon { get; set; }
        public bool FirstTimeInDock { get; set; }
        public bool FirstTimeInEnd { get; set; }
        public bool WoodsCleared { get; set; }
        public bool DungeonCleared { get; set; }



        public Dictionary<int, string> CreateDictionary()
        {
            LocationDictionary.Add(1, "Pallet Town");
            LocationDictionary.Add(2, "Faire Town");
            LocationDictionary.Add(3, "Kanto Town");
            LocationDictionary.Add(4, "The Woods");
            LocationDictionary.Add(5, "Iron Town");
            LocationDictionary.Add(6, "North Town");
            LocationDictionary.Add(7, "Some Town");
            LocationDictionary.Add(8, "plains Town");
            LocationDictionary.Add(9, "Dungeon");
            LocationDictionary.Add(10, "Dock Town");
            LocationDictionary.Add(11, "End");

            return LocationDictionary;
        }

        public void GetConnectingLocations(BaseLocation currentlocation)
        {
            foreach (int locationKey in currentlocation.ConnectingLocations)
            {
                Console.Write($"[{locationKey}] - ");
                Console.WriteLine(LocationDictionary[locationKey]);
            }
        }

        public void ChangeLocation(BaseLocation currentLocation)
        {
            int locationChoice = 99;
            bool validChoice = false;

            do
            {
                Console.Clear();

                currentLocation.PrintMap();
                Console.WriteLine();

                GetConnectingLocations(currentLocation);
                Console.WriteLine("Pick a connecting location");

                Int32.TryParse(Console.ReadLine(), out locationChoice);

                foreach (int locationKey in currentLocation.ConnectingLocations)
                {
                    if (locationChoice == locationKey)
                    {
                        validChoice = true;
                    }
                }

                if (!validChoice)
                {
                    Console.WriteLine("Invalid Choice");
                    Console.ReadKey();
                }

            } while (!validChoice);

            CurrentLocationKey = locationChoice;
        }

        public void ArriveAtLocation(BaseLocation currentLocation)
        {
            Console.Clear();
            currentLocation.PrintMap();
            Console.WriteLine();
            Console.WriteLine($"You arrive at {currentLocation.Name}");
            Console.ReadKey();
            Console.Clear();
            currentLocation.PrintSprite();
            Console.ReadKey();

        }

        public void FirstTimeInLocationCheckWithKey(BaseLocation location, Player.Player player)  // DO SOMETHING ABOUT THIS
        {

            switch (location.LocationKey)
            {
                case 1:

                    if (FirstTimeInPallet)
                    {
                        FirstTimeInPallet = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 2:

                    if (FirstTimeInFaire)
                    {
                        FirstTimeInFaire = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 3:

                    if (FirstTimeInKanto)
                    {
                        FirstTimeInKanto = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 4:

                    if (FirstTimeInWoods)
                    {
                        FirstTimeInWoods = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 5:

                    if (FirstTimeInIron)
                    {
                        FirstTimeInIron = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 6:

                    if (FirstTimeInNorth)
                    {
                        FirstTimeInNorth = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 7:

                    if (FirstTimeInSome)
                    {
                        FirstTimeInSome = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 8:

                    if (FirstTimeInPlains)
                    {
                        FirstTimeInPlains = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 9:

                    if (FirstTimeInDungeon)
                    {
                        FirstTimeInDungeon = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 10:

                    if (FirstTimeInDock)
                    {
                        FirstTimeInDock = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;

                case 11:

                    if (FirstTimeInEnd)
                    {
                        FirstTimeInEnd = false;
                        location.FirstTimeInLocationEvent(player);
                    }

                    break;
            }



        }



        //----------
    }
}
