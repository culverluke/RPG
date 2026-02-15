using RPG.BattleHandler;
using RPG.CreateSystems;
using RPG.DungeonGameBoard; 
using RPG.Inventory;
using RPG.Inventory.PlayerInventory;
using RPG.Items;
using RPG.Items.Consumables;
using RPG.Items.Weapons;
using RPG.LocationSystem;
using RPG.LocationSystem.LocationClasses;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
using RPG.Player;
using RPG.Shop;
using RPG.Shop.TownShops;
using RPG.TestFunctions;

/* FirstTimeInLocation text held in location.Class - Shop text held in shopKeeper.class? - locationMenu.Class
 * startOfGame class?
 */

SystemCreator systemCreator = new SystemCreator();
TestFunctions testFunctions = new TestFunctions();

ItemCreator itemCreator = systemCreator.CreateItemCreator();
LocationCreator locationCreator = systemCreator.CreateLocationCreator();
LocationHandler locationHandler = systemCreator.CreateLocationHandler();
BaseLocation currentLocation = locationCreator.CreateFaireTown(); // CHANGE BACK TO PALLET AND CHANGE PLAYER STATS BACK
LocationParams locationParams = new LocationParams(locationHandler, locationCreator);

PlayerInventory playerInventory = systemCreator.CreatePlayerInventory();
Player player = systemCreator.CreatePlayerWithStats();
PlayerParams playerParams = new PlayerParams(player, playerInventory);

StartGameMessagesTest startGameMessages = new StartGameMessagesTest();
BattleHandler battleHandler = new BattleHandler();
BattleText battleText = new BattleText();

Monster dad = new Monster("Dad", 20, 50, 12, 20, MonsterSprites.Dad, itemCreator.CreateIronSword()); // monster list need adding (whole monster stuff need fleshing out)
Monster skeleton = new Monster("Skeleton", 20, 13, 12, 14, MonsterSprites.Skeleton, itemCreator.CreateIronAxe());
Monster minotaur = new Monster("Minotaur", 25, 15, 12, 18, MonsterSprites.Minotaur, itemCreator.CreateClaws());
Monster harpy = new Monster("Harpy", 20, 14, 15, 15, MonsterSprites.Harpy, itemCreator.CreateClaws());

List<Monster> monsterList = [skeleton, minotaur, harpy]; // Two or three monsterLists woods, dungeon, castle?
BattleParams battleParams = new BattleParams(battleHandler, battleText, monsterList);

Potion potion = new Potion();
playerInventory.AddToInventory(potion);

ShopCreator shopCreator = new ShopCreator();
TownShop shop = new FaireShop(itemCreator);
ShopParams shopParams = new ShopParams(shopCreator, itemCreator);

//-------
//startGameMessages.StartOfGame();

currentLocation.PrintMap();
Console.WriteLine("\nYou are here");
Console.ReadKey();
Console.Clear();

currentLocation.FirstTimeInLocationEvent(player);
currentLocation.LocationBattle(battleParams, playerParams, itemCreator);

locationHandler.FirstTimeInPallet = false;

do
{

    currentLocation = currentLocation.LocationMenu(currentLocation, playerParams, shopParams, locationParams, battleParams);

} while (true);