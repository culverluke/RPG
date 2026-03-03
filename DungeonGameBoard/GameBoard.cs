using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.SaveAndLoad;
using RPG.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG.DungeonGameBoard
{
    internal class GameBoard
    {
        public GameBoard()
        {
            TileList = new();
            ExitLocation = [0, 0];
        }

        public GameBoard(int dimentions)
        {
            TileList = new();
            ExitLocation = [0, 0];
            Dimentions = dimentions;
        }

        public List<BoardTile> TileList { get; set; }
        public int Dimentions { get; set; }
        public int[] ExitLocation { get; set; }

        public Vector2 PlayerLocation = new Vector2(1, 1);
        public bool GameOver = false;


        public void CreateGameBoard(int dimentions, int chanceOfBattle)
        {
            Dimentions = dimentions;

            for (int i = 1; i <= dimentions; i++)
            {

                for (int j = 1; j <= dimentions; j++)
                {
                    BoardTile boardTile = new BoardTile(j, i);
                    boardTile.ChanceOfBattle = chanceOfBattle;
                    TileList.Add(boardTile);
                }

            }
            PlaceExit();
        }

        public void DisplayBoard()
        {
            int count = 1;

            foreach (var tile in TileList)
            {
                if(tile.Contents == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if(tile.Contents == "E")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write($"[{tile.Contents}]");
                Console.ForegroundColor = ConsoleColor.White;

                if (count >= Dimentions)
                {
                    Console.WriteLine();
                    count = 0;
                }

                count++;
            }
        }

        public void UpdateBoard()
        {
            for (int i = 0; i < TileList.Count(); i++)
            {
                if (PlayerLocation[0] == TileList[i].Coordinates.Y && PlayerLocation[1] == TileList[i].Coordinates.X)
                {
                    TileList[i].Contents = "X";
                }
                else if (TileList[i].Contents == "E")
                {
                    // do nothing / dont change
                }
                else
                {
                    TileList[i].Contents = " ";
                }

            }

            Console.Clear();
            DisplayBoard();
        }

        public void PlaceExit()
        {
            Random dice = new Random();

            ExitLocation[0] = dice.Next(Dimentions / 2, Dimentions);
            ExitLocation[1] = dice.Next(Dimentions / 2, Dimentions);

            for (int i = 0; i < TileList.Count(); i++)
            {
                if (TileList[i].Coordinates.Y == ExitLocation[0] && TileList[i].Coordinates.X == ExitLocation[1])
                {
                    TileList[i].Contents = "E";
                }
            }

        }

        public bool CheckForGameOver(Player.Player player)
        {
            if (player.Health <= 0)
            {
                Console.WriteLine("Player Died");
                GameOver = true;
            }


            if (PlayerLocation[0] == ExitLocation[0] && PlayerLocation[1] == ExitLocation[1])
            {
                Console.WriteLine("Player reached the Exit");
                GameOver = true;
            }


            return GameOver;
        }

        public bool CheckForBattle()
        {
            Random dice = new Random();
            
            if(dice.Next(1, 101) <= TileList[1].ChanceOfBattle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BeginDungeon(int locationKey, PlayerParams playerParams, BattleParams battleParams, UserInput.UserInput userInput, SaveData saveData, LocationHandler locationHandler)
        {
            PlayerController playerController = new PlayerController(); // add to sys creator
            do
            {
                UpdateBoard();
                playerController.MovePlayer(this);
                if (CheckForBattle())
                {
                    switch(locationKey)
                    {
                        case 9: // NEEDS NEW LIST
                            battleParams.BattleHandler.Battle(playerParams, battleParams.BattleHandler.GetRandomMonsterFromList(battleParams.MonsterLists.WoodsMonsterList), battleParams.BattleText, userInput, locationHandler);
                            break;

                        case 11: // NEEDS NEW LIST
                            battleParams.BattleHandler.Battle(playerParams, battleParams.BattleHandler.GetRandomMonsterFromList(battleParams.MonsterLists.WoodsMonsterList), battleParams.BattleText, userInput, locationHandler);
                            break;

                        default:
                            battleParams.BattleHandler.Battle(playerParams, battleParams.BattleHandler.GetRandomMonsterFromList(battleParams.MonsterLists.WoodsMonsterList), battleParams.BattleText, userInput, locationHandler);
                            break;
                    }
                }
            } while (!CheckForGameOver(playerParams.Player));
        }

        //-----
    }
}
