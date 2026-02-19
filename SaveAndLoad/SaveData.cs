using RPG.Inventory.PlayerInventory;
using RPG.Items.Weapons;
using RPG.LocationSystem.LocationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RPG.Items;

namespace RPG.SaveAndLoad
{
    internal class SaveData
    {

        public void SavePlayerInventory(PlayerInventory playerInventory)
        {

            FileStream fileStream = File.Open("PlayerInventory.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach(Item item in playerInventory.InventoryList)
            {
                streamWriter.WriteLine(item.ToString());
            }
            streamWriter.Close();
            //Console.WriteLine("SAVED");
        }


        public void SavePlayer(Player.Player player)
        {

            string[] playerStats = new string[]
            {
                player.Name,
                player.MaxHealth.ToString(),
                player.Health.ToString(),
                player.Attack.ToString(),
                player.Defence.ToString(),
                player.Speed.ToString(),
                player.Gold.ToString(),
                player.WoodsKey.ToString(),
                player.CurrentWeapon.ToString()
            };

            FileStream fileStream = File.Open("PlayerStats.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach(string stat in playerStats)
            {
                streamWriter.WriteLine(stat);
            }

            streamWriter.Close();

            Console.WriteLine("SAVED");
            Console.ReadKey();
        }

        public void SaveLocationHandler(LocationHandler locationHandler)
        {
            string[] locationData = new string[]
            {
                locationHandler.CurrentLocationKey.ToString(),
                locationHandler.FirstTimeInPallet.ToString(),
                locationHandler.FirstTimeInFaire.ToString(),
                locationHandler.FirstTimeInKanto.ToString(),
                locationHandler.FirstTimeInWoods.ToString(),
                locationHandler.FirstTimeInIron.ToString(),
                locationHandler.FirstTimeInNorth.ToString(),
                locationHandler.FirstTimeInSome.ToString(),
                locationHandler.FirstTimeInPlains.ToString(),
                locationHandler.FirstTimeInDungeon.ToString(),
                locationHandler.FirstTimeInDock.ToString(),
                locationHandler.FirstTimeInEnd.ToString(),
                locationHandler.WoodsCleared.ToString(),
                locationHandler.DungeonCleared.ToString()
            };

            FileStream fileStream = File.Open("LocationData.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach(string field in locationData)
            {
                streamWriter.WriteLine(field);
            }
            streamWriter.Close();

        }


        //---
    }
}
