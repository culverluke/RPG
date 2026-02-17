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
using RPG.Shop;
using RPG.Shop.TownShops;
using RPG.TestFunctions;

/* final boss 
 */

SystemCreator systemCreator = new SystemCreator();
TestFunctions testFunctions = new TestFunctions();

ItemCreator itemCreator = systemCreator.CreateItemCreator();
LocationCreator locationCreator = systemCreator.CreateLocationCreator();
LocationHandler locationHandler = systemCreator.CreateLocationHandler();
BaseLocation currentLocation = locationCreator.CreatePalletTown(); // CHANGE BACK TO PALLET AND CHANGE PLAYER STATS BACK
LocationParams locationParams = new LocationParams(locationHandler, locationCreator);

PlayerInventory playerInventory = systemCreator.CreatePlayerInventory();
Player player = systemCreator.CreatePlayerWithStats();
PlayerParams playerParams = new PlayerParams(player, playerInventory);

StartGameMessagesTest startGameMessages = new StartGameMessagesTest();
BattleHandler battleHandler = new BattleHandler();
BattleText battleText = new BattleText();


MonsterLists monsterLists = new MonsterLists(itemCreator);
BattleParams battleParams = new BattleParams(battleHandler, battleText, monsterLists);

Potion potion = new Potion();
playerInventory.AddToInventory(potion);

ShopCreator shopCreator = systemCreator.CreateShopCreator();
TownShop shop = new FaireShop(itemCreator);
ShopParams shopParams = new ShopParams(shopCreator, itemCreator); // might remove ItemCreator from shopParamas

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