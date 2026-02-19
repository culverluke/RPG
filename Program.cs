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
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using RPG.Monsters.MonsterSprites;
using RPG.Player;
using RPG.SaveAndLoad;
using RPG.Shop;
using RPG.Shop.TownShops;
using RPG.TestFunctions;
using RPG.UserInput;

/* final boss, saving and loading (should only need to save in player, playerInventory(playerParams) and locationHandler)
 */

SystemCreator systemCreator = new SystemCreator();
TestFunctions testFunctions = new TestFunctions();

UserInput userInput = new(); // MOVE IT

ItemCreator itemCreator = systemCreator.CreateItemCreator();
LocationCreator locationCreator = systemCreator.CreateLocationCreator();
LocationHandler locationHandler = systemCreator.CreateLocationHandler();
BaseLocation currentLocation = locationCreator.CreatePlainsTown(); // CHANGE BACK TO PALLET AND CHANGE PLAYER STATS BACK
LocationParams locationParams = new LocationParams(locationHandler, locationCreator);

PlayerInventory playerInventory = systemCreator.CreatePlayerInventory();
Player player = systemCreator.CreatePlayerWithStats();
PlayerParams playerParams = new PlayerParams(player, playerInventory);

StartGameMessagesTest startGameMessages = new StartGameMessagesTest();
BattleHandler battleHandler = new BattleHandler();
BattleText battleText = new BattleText();


MonsterLists monsterLists = new MonsterLists(itemCreator);
BattleParams battleParams = new BattleParams(battleHandler, battleText, monsterLists);

//Potion potion = new Potion();
//playerInventory.AddToInventory(potion);

Weapon steelSword = new SteelSword(); // REMOVE
playerInventory.AddToInventory(steelSword); //  REMOVE

ShopCreator shopCreator = systemCreator.CreateShopCreator();
TownShop shop = new FaireShop(itemCreator);
ShopParams shopParams = new ShopParams(shopCreator, itemCreator); // might remove ItemCreator from shopParams

SaveData saveData = new();
LoadData loadData = new();

//-------
//startGameMessages.StartOfGame();
loadData.LoadPlayer(player);
loadData.LoadPlayerInventory(playerInventory);

currentLocation.PrintMap();
Console.WriteLine("\nYou are here");
Console.ReadKey();
Console.Clear();

currentLocation.FirstTimeInLocationEvent(player);
currentLocation.LocationBattle(battleParams, playerParams, itemCreator, userInput, saveData);

locationHandler.FirstTimeInPallet = false;

do
{

    currentLocation = currentLocation.LocationMenu(currentLocation, playerParams, shopParams, locationParams, battleParams, userInput, saveData);

} while (true);