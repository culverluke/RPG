using RPG.BattleHandler;
using RPG.Inventory.PlayerInventory;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.DungeonGameBoard
{
    internal class GameBoard
    {
        public GameBoard()
        {
            TileList = new();
            PlayerLocation = [1, 1];
            ExitLocation = [0, 0];
        }

        public GameBoard(int dimentions)
        {
            TileList = new();
            PlayerLocation = [1, 1];
            ExitLocation = [0, 0];
            Dimentions = dimentions;
        }

        public List<BoardTile> TileList { get; set; }
        public int Dimentions { get; set; }
        public int[] PlayerLocation { get; set; } // 0 is y axis  -  1 is x axis // USE A FUCKING VECTOR    
        public int[] ExitLocation { get; set; }

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
                Console.Write($"[{tile.Contents}]");

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
                if (PlayerLocation[0] == TileList[i].Y && PlayerLocation[1] == TileList[i].X)
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
                if (TileList[i].Y == ExitLocation[0] && TileList[i].X == ExitLocation[1])
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

        public void BeginDungeon(Player.Player player, PlayerInventory playerInventory, List<Monster> monsterList, BattleHandler.BattleHandler battleHandler, BattleText battleText)
        {
            PlayerController playerController = new PlayerController(); // add to sys creator
            do
            {
                UpdateBoard();
                playerController.MovePlayer(this);
                if (CheckForBattle())
                {
                    battleHandler.Battle(player, battleHandler.GetRandomMonsterFromList(monsterList), playerInventory, battleText);
                }
            } while (!CheckForGameOver(player));
        }

        //-----
    }
}
