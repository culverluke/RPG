using Microsoft.CodeAnalysis;
using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.SaveAndLoad;
using RPG.Shop;
using RPG.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPG.LocationSystem.LocationClasses
{
    internal abstract class BaseLocation
    {
        public BaseLocation()
        {
            Name = "";
            ConnectingLocations = [0];
            Map = "";
            Sprite = "";
        }

        public string Name { get; set; }
        public int LocationKey { get; set; }
        public int[] ConnectingLocations { get; set; }
        public string Map { get; set; }
        public string Sprite { get; set; }
        public int BoardDimentions { get; set; }
        public Action? CustomEvent { get; set; }
        public Action<BattleParams, PlayerParams, ItemCreator, UserInput.UserInput, LocationHandler.LocationHandler>? LocationBattle { get; set; }
        public Optional<Action> Event { get; }

        public bool IsDungeon = false;



        public abstract void FirstTimeInLocationEvent(Player.Player player);

        public abstract BaseLocation LocationMenu(BaseLocation location, PlayerParams playerParams, ShopParams shopParams, LocationParams locationParams,
                        BattleParams battleParams, UserInput.UserInput userInput, SaveData saveData);

        public void PrintSprite()
        {
            Console.WriteLine(Sprite);
        }

        public void PrintMap()
        {
            Console.WriteLine(Map);
        }

        public void DisplayLatterMenu() // latter half of the menu idk what to call it
        {
            Console.WriteLine("[3] - Leave");
            Console.WriteLine("[4] - View Inventory");
            Console.WriteLine("[5] - View Map");
            Console.WriteLine("[6] - View Stats");
            Console.WriteLine("[7] - Save");
            // ADD SAVE & QUIT
        }

        

        //-----
    }
}
