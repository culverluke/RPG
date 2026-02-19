using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Items.Weapons;
using RPG.LocationSystem;
using RPG.LocationSystem.LocationClasses;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.SaveAndLoad;
using RPG.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.TestFunctions
{
    internal class TestFunctions
    {

        public void BattleTest(BattleParams battleParams, PlayerParams playerParams, Monster monster, UserInput.UserInput userInput, SaveData saveData)
        {
            battleParams.BattleHandler.Battle(playerParams, monster, battleParams.BattleText, userInput, saveData);
        }

        public void TestSpeedCheck(BattleHandler.BattleHandler battleHandler, Player.Player player, Monster monster)
        {
            Console.WriteLine(battleHandler.SpeedCheck(player, monster));
        }


        public void AddWeapons(PlayerInventory playerInventory)
        {
            Weapon ironSword = new IronSword();
            Weapon ironAxe = new IronAxe();
            Weapon ironDagger = new IronDagger();
            bool finished = false;

            do
            {
                int itemChoice = 99;

                Console.Clear();
                Console.WriteLine("Pick an item to add: ");
                Console.WriteLine("[1] - Iron Sword");
                Console.WriteLine("[2] - Iron Dagger");
                Console.WriteLine("[3] - Iron Axe");

                Int32.TryParse(Console.ReadLine(), out itemChoice);

                switch (itemChoice)
                {
                    case 1:
                        playerInventory.AddToInventory(ironSword);
                        break;

                    case 2:
                        playerInventory.AddToInventory(ironDagger);
                        break;

                    case 3:
                        playerInventory.AddToInventory(ironAxe);
                        break;
                }

                Console.Clear();
                playerInventory.Display();
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Do you want to add more? 1 = yes");
                Int32.TryParse(Console.ReadLine(), out itemChoice);

                if (itemChoice != 1)
                {
                    finished = true;
                }

            } while (!finished);
        }



        public void EndlessMoveLocation(LocationHandler locationHandler, BaseLocation currentLocation, LocationCreator locationCreator, UserInput.UserInput userInput)
        {
            do
            {
                locationHandler.ChangeLocation(currentLocation, userInput);
                currentLocation = locationCreator.CreateTownWithKey(locationHandler.CurrentLocationKey);
                locationHandler.ArriveAtLocation(currentLocation);
            } while (true);
        }


        public void TestFirstTimeInLocationEvents(LocationHandler locationHandler, BaseLocation currentLocation, LocationCreator locationCreator, Player.Player player, UserInput.UserInput userInput)
        {
            do
            {
                locationHandler.ChangeLocation(currentLocation, userInput);
                currentLocation = locationCreator.CreateTownWithKey(locationHandler.CurrentLocationKey);
                locationHandler.ArriveAtLocation(currentLocation);
                locationHandler.FirstTimeInLocationCheckWithKey(currentLocation, player);
            } while (true);
        }


        //------------------------------------
    }

}
