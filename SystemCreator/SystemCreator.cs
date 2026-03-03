using RPG.BattleHandler;
using RPG.DungeonGameBoard;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.LocationSystem;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters;
using RPG.Player;
using RPG.Shop;
using RPG.UserInput;
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

        public LocationParams CreateLocationParams()
        {
            LocationHandler locationHandler = CreateLocationHandler();
            LocationCreator locationCreator = CreateLocationCreator();
            LocationParams locationParams = new LocationParams(locationHandler, locationCreator);
            return locationParams;
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
            int attack = dice.Next(15, 26);
            int defence = dice.Next(15, 26);
            int speed = dice.Next(15, 26);

            Player.Player player = new Player.Player("Player", attack, defence, speed);
            return player;
        }

        public PlayerParams CreatePlayerParams()
        {
            Player.Player player = CreatePlayerWithStats();
            PlayerInventory playerInventory = CreatePlayerInventory();
            PlayerParams playerParams = new PlayerParams(player, playerInventory);
            return playerParams;
        }

        public GameBoard CreateNewGameboard(int dimentions, int chanceOfBattle)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.CreateGameBoard(dimentions, chanceOfBattle);
            return gameBoard;
        }

        public BattleHandler.BattleHandler CreateBattleHandler()
        {
            BattleHandler.BattleHandler battleHandler = new BattleHandler.BattleHandler();
            return battleHandler;
        }

        public BattleText CreateBattleText()
        {
            BattleText battleText = new BattleText();
            return battleText;
        }

        public MonsterLists CreateMonsterLists(ItemCreator itemCreator)
        {
            MonsterLists monsterLists = new MonsterLists(itemCreator);
            return monsterLists;

        }

        public BattleParams CreateBattleParams(ItemCreator itemCreator)
        {
            BattleHandler.BattleHandler battleHandler = CreateBattleHandler();
            BattleText battleText = CreateBattleText();
            MonsterLists monsterLists = CreateMonsterLists(itemCreator);
            BattleParams battleParams = new BattleParams(battleHandler, battleText, monsterLists);
            return battleParams;
        }

        public ShopCreator CreateShopCreator()
        {
            ShopCreator shopCreator = new ShopCreator();
            return shopCreator;
        }

        public ShopParams CreateShopParams(ItemCreator itemCreator)
        {
            ShopCreator shopCreator = CreateShopCreator();
            ShopParams shopParams = new ShopParams(shopCreator, itemCreator);
            return shopParams;
        }

        public UserInput.UserInput CreateUserInput()
        {
            UserInput.UserInput userInput = new UserInput.UserInput();
            return userInput;
        }

        //------
    }
}
