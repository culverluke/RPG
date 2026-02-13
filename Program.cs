using RPG.BattleHandler;
using RPG.CreateSystems;
using RPG.DungeonGameBoard; 
using RPG.Inventory;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Items.Consumables;
using RPG.Items.Weapons;
using RPG.LocationSystem.LocationClasses;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
using RPG.Player;
using RPG.Shop;
using RPG.TestFunctions;

/* FirstTimeInLocation text held in location.Class - Shop text held in shopKeeper.class? - locationMenu.Class
 * startOfGame class?
 */

SystemCreator systemCreator = new SystemCreator();
TestFunctions testFunctions = new TestFunctions();

ItemCreator itemCreator = systemCreator.CreateItemCreator();
LocationCreator locationCreator = systemCreator.CreateLocationCreator();
LocationHandler locationHandler = systemCreator.CreateLocationHandler();
BaseLocation currentLocation = locationCreator.CreateFaireTown(); // change back to pallet

PlayerInventory playerInventory = systemCreator.CreatePlayerInventory(); // CREATE INV CLASS WITH SHOP INV TO REUSE VARIABLE FOR TOWNS?
Player player = systemCreator.CreatePlayerWithStats();

StartGameMessagesTest startGameMessages = new StartGameMessagesTest();
BattleHandler battleHandler = new BattleHandler();
BattleText battleText = new BattleText();

Monster dad = new Monster("Dad", 20, 50, 12, 20, MonsterSprites.Dad, itemCreator.CreateIronSword()); // monster list need adding (whole monster stuff need fleshing out)
Monster skeleton = new Monster("Skeleton", 20, 13, 12, 14, MonsterSprites.Skeleton, itemCreator.CreateIronAxe());
Monster minotaur = new Monster("Minotaur", 25, 15, 12, 18, MonsterSprites.Minotaur, itemCreator.CreateClaws());
Monster harpy = new Monster("Harpy", 20, 14, 15, 15, MonsterSprites.Harpy, itemCreator.CreateClaws());

List<Monster> monsterList = [skeleton, minotaur, harpy]; // Two or three monsterLists woods, dungeon, castle?

Potion potion = new Potion();
playerInventory.AddToInventory(potion);

ShopCreator shopCreator = new ShopCreator();
TownShop shop = new FaireShop(itemCreator);

//-------
//startGameMessages.StartOfGame();

currentLocation.PrintMap();
Console.WriteLine("\nYou are here");
Console.ReadKey();
Console.Clear();

currentLocation.FirstTimeInLocationEvent(player);
currentLocation.LocationBattle(battleHandler, player, playerInventory, itemCreator, battleText);

locationHandler.FirstTimeInPallet = false;


do
{

    switch(currentLocation.LocationMenu(currentLocation, player, playerInventory, locationHandler, locationCreator))
    {
        case 1:
            Console.Clear();
        currentLocation.PrintMap();
            Console.ReadKey();
            break;

        case 2:
            Console.Clear();
                player.PrintStats();
            Console.ReadKey();
            break;

        case 3:
            Console.Clear();
            playerInventory.Display();
            Console.ReadKey();
            break;

        case 4: // shop
            Console.Clear();
            shop = shopCreator.CreateShopWithKey(currentLocation.LocationKey, itemCreator);
            shop.BuyOrSell(playerInventory);
            Console.ReadKey();
            break;

        case 5:
            locationHandler.ChangeLocation(currentLocation);
            currentLocation = locationCreator.CreateTownWithKey(locationHandler.CurrentLocationKey);
            Console.Clear();
            currentLocation.PrintMap();
            Console.ReadKey();
            Console.WriteLine();
            locationHandler.FirstTimeInLocationCheckWithKey(currentLocation, player);
            break;
            

        case 6:
            currentLocation.VisitPerson();

            if (currentLocation.HasBattle)
            {
                currentLocation.LocationBattle(battleHandler, player, playerInventory, itemCreator, battleText);
            }
            break;


        case 8:// add dungeon generation here
            GameBoard gameBoard = new GameBoard();
            gameBoard.CreateGameBoard(currentLocation.BoardDimentions, 30);
            gameBoard.BeginDungeon(player, playerInventory, monsterList, battleHandler, battleText);

            if(currentLocation.LocationKey == 4)
            {
                Console.Clear();
                Console.WriteLine("\nYou made your way through the Woods.");
                Console.ReadKey();
                Console.WriteLine("A new location has been unlocked");
                Console.ReadKey();
                locationHandler.WoodsCleared = true;
            }
            else if(currentLocation.LocationKey == 9)
            {
                Console.Clear();
                Console.WriteLine("\nYou made your way through the Dungeon.");
                Console.ReadKey();
                Console.WriteLine("A new location has been unlocked");
                Console.ReadKey();
                locationHandler.DungeonCleared = true;
            }
                break;

        case 9:
            Console.Clear();
            Console.WriteLine("Pick an option from the menu");
            Console.ReadKey();
            break;

    }

} while (true);

