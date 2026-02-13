using RPG.DungeonGameBoard;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem.LocationClasses;
using RPG.LocationSystem.LocationHandler;
using RPG.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.CreateSystems
{
    internal class SystemCreator
    {

        public ItemCreator CreateItemCreator()
        {
            ItemCreator itemCreator = new ItemCreator();
            return itemCreator;
        }

        public LocationCreator CreateLocationCreator()
        {
            LocationCreator locationCreator = new LocationCreator();
            return locationCreator;
        }

        public LocationHandler CreateLocationHandler()
        {
            LocationHandler locationHandler = new LocationHandler();
            return locationHandler;
        }

        public PlayerInventory CreatePlayerInventory()
        {
            PlayerInventory playerInventory = new PlayerInventory();
            return playerInventory;
        }

        public Player.Player CreateBlankPlayer()
        {
            Player.Player player = new Player.Player();
            return player;
        }

        public Player.Player CreatePlayerWithStats()
        {
            Random dice = new Random();
            int attack = dice.Next(10, 21);
            int defence = dice.Next(10, 21);
            int speed = dice.Next(10, 21);

            Player.Player player = new Player.Player("Player", attack, defence, speed);
            return player;
        }

        public GameBoard CreateNewGameboard(int dimentions, int chanceOfBattle)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.CreateGameBoard(dimentions, chanceOfBattle);
            return gameBoard;
        }

    }
}
