using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Items.Weapons;
using RPG.LocationSystem.LocationHandler;
using RPG.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.SaveAndLoad
{
    internal class LoadData
    {

        public void LoadPlayer(Player.Player player)
        {
            if(File.Exists("PlayerStats.txt"))
            {
                List<string> playerStats = [];

                FileStream fileStream = File.Open("PlayerStats.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                while(!streamReader.EndOfStream)
                {
                    playerStats.Add(streamReader.ReadLine());
                }
                streamReader.Close();

                List<int> numericalStats = new();

                for(int i = 1; i <= 6; i++)
                {
                    int statHolder = 0;
                    int.TryParse(playerStats[i], out statHolder);
                    numericalStats.Add(statHolder);
                }

                bool woodsKey = false;
                Boolean.TryParse(playerStats[7], out woodsKey);

                Weapon playerWeapon = (Weapon)Activator.CreateInstance(Type.GetType(playerStats[8]));
                
                player.Name = playerStats[0];
                player.MaxHealth = numericalStats[0];
                player.Health = numericalStats[1];
                player.Attack = numericalStats[2];
                player.Defence = numericalStats[3];
                player.Speed = numericalStats[4];
                player.Gold = numericalStats[5];
                player.WoodsKey = woodsKey;
                player.CurrentWeapon = playerWeapon;

                player.PrintStats();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPlayer {player.Name} Loaded");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                
            }
        }


        public void LoadPlayerInventory(PlayerInventory playerInventory)
        {
            if(File.Exists("PlayerInventory.txt"))
            {
                List<string> itemList = [];

                FileStream fileStream = File.Open("PlayerInventory.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                while(!streamReader.EndOfStream)
                {
                    itemList.Add(streamReader.ReadLine());
                }
                streamReader.Close();


                foreach(string item in itemList)
                {
                    if(item.Contains("Weapons"))
                    {
                        Weapon weaponHolder = (Weapon)Activator.CreateInstance(Type.GetType(item));
                        playerInventory.InventoryList.Add(weaponHolder);
                    }
                    else
                    {
                        Item itemHolder = (Item)Activator.CreateInstance(Type.GetType(item));
                        playerInventory.InventoryList.Add(itemHolder);
                    }

                }                

            }

        }


        public void LoadLocationData(LocationHandler locationHandler)
        {
            if(File.Exists("LocationData.txt"))
            {
                List<string> dataList = [];

                FileStream fileStream = File.Open("LocationData.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                while(!streamReader.EndOfStream)
                {
                    dataList.Add(streamReader.ReadLine());
                }
                streamReader.Close();

                int intHolder = 0;
                int.TryParse(dataList[0], out intHolder);
                locationHandler.CurrentLocationKey = intHolder;

                List<bool> boolList = [];
                bool boolHolder = false;

                for(int i = 1; i < dataList.Count(); i++)
                {
                    bool.TryParse(dataList[i], out boolHolder);
                    boolList.Add(boolHolder);
                }

                locationHandler.FirstTimeInPallet = boolList[0];
                locationHandler.FirstTimeInFaire = boolList[1];
                locationHandler.FirstTimeInKanto = boolList[2];
                locationHandler.FirstTimeInWoods = boolList[3];
                locationHandler.FirstTimeInIron = boolList[4];
                locationHandler.FirstTimeInNorth = boolList[5];
                locationHandler.FirstTimeInSome = boolList[6];
                locationHandler.FirstTimeInPlains = boolList[7];
                locationHandler.FirstTimeInDungeon = boolList[8];
                locationHandler.FirstTimeInDock = boolList[9];
                locationHandler.FirstTimeInEnd = boolList[10];
                locationHandler.WoodsCleared = boolList[11];
                locationHandler.BanditsCleared = boolList[12];
                locationHandler.DungeonCleared = boolList[13];

            }

        }


        //----
    }
}
