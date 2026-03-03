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
using RPG.StartOfGame;
using RPG.TestFunctions;
using RPG.UserInput;



SystemCreator systemCreator = new SystemCreator();
TestFunctions testFunctions = new TestFunctions();

LocationParams locationParams = systemCreator.CreateLocationParams();
ItemCreator itemCreator = systemCreator.CreateItemCreator();
BaseLocation currentLocation = locationParams.LocationCreator.CreatePalletTown(); // CHANGE BACK TO PALLET AND CHANGE PLAYER STATS BACK
BattleParams battleParams = systemCreator.CreateBattleParams(itemCreator);
PlayerParams playerParams = systemCreator.CreatePlayerParams();
ShopParams shopParams = systemCreator.CreateShopParams(itemCreator);    // might remove the itemCreator from shopParams
UserInput userInput = systemCreator.CreateUserInput();
SaveData saveData = new(); // might change

StartOfGameFunctions startOfGame = new StartOfGameFunctions();

TownShop shop = shopParams.ShopCreator.CreateFaireShop(itemCreator);

bool loadGame = false;
//-------
loadGame = startOfGame.NewOrLoad(userInput);

if(loadGame)
{
    LoadData loadData = new();
    loadData.LoadPlayer(playerParams.Player);
    loadData.LoadPlayerInventory(playerParams.PlayerInventory);
    loadData.LoadLocationData(locationParams.LocationHandler);
}
else
{
    string playerName = userInput.PickAName();
    playerParams.Player.SetPlayerName(playerName);
    Console.Clear();
}

if (locationParams.LocationHandler.FirstTimeInPallet)
{
    Potion potion = new Potion();
    playerParams.PlayerInventory.AddToInventory(potion);

    startOfGame.StartGameText();

    currentLocation.PrintMap();
    Console.WriteLine("\nYou are here");
    Console.ReadKey();
    Console.Clear();

    currentLocation.FirstTimeInLocationEvent(playerParams.Player);
    currentLocation.LocationBattle(battleParams, playerParams, itemCreator, userInput, locationParams.LocationHandler);

    locationParams.LocationHandler.FirstTimeInPallet = false;
}
else
{
    currentLocation = locationParams.LocationCreator.CreateTownWithKey(locationParams.LocationHandler.CurrentLocationKey);
}


do
{

    currentLocation = currentLocation.LocationMenu(currentLocation, playerParams, shopParams, locationParams, battleParams, userInput, saveData);

} while (playerParams.Player.Health > 0);

Console.Clear();
Console.WriteLine("\n\n\t\t\tGAME OVER!");