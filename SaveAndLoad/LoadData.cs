using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Items.Weapons;
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

                //string weaponName = playerStats[8];
                //weaponName = string.Concat(weaponName.Where(c => !char.IsWhiteSpace(c)));

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
                Console.WriteLine($"\nPlayer {player.Name} Loaded");
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

                    Console.WriteLine(item.ToString());
                }

                //Console.WriteLine();
                Console.ReadKey();
            }

            //return playerInventory;
        }


        //----
    }
}
