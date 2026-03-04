using RPG.Inventory.PlayerInventory;
using RPG.LocationSystem.LocationHandler;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
using RPG.SaveAndLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.BattleHandler
{
    internal class BattleHandler 
    {

        public Monster GetRandomMonsterFromList(List<Monster> monsterList)
        {
            Random dice = new Random();

            return monsterList[dice.Next(0, monsterList.Count())];
        }


        public void Battle(PlayerParams playerParams, Monster monster, BattleText battleText, UserInput.UserInput userInput, LocationHandler locationHandler)
        {
            bool playerFaster = SpeedCheck(playerParams.Player, monster);
            bool playerDead = false;
            bool monsterDead = false;

            monster.Health = monster.MaxHealth;

            do
            {
                Console.Clear();
                if (playerFaster)
                {
                    battleText.PrintHealthValues(playerParams.Player, monster);
                    monster.PrintSprite();

                    BattleMenu(playerParams, monster, battleText, userInput, locationHandler);

                    if (monster.Health >= 1 && !playerParams.Player.quitGame)
                    {
                        Console.Clear();
                        battleText.PrintHealthValues(playerParams.Player, monster);
                        monster.PrintSprite();
                        battleText.PrintYouAreAttackedBy(monster);
                        playerParams.Player.TakeDamage(monster);
                        Console.ReadKey();

                        if (playerParams.Player.Health <= 0)
                        {
                            playerDead = true;
                        }

                    }
                    else
                    {
                        monsterDead = true;
                    }

                }
                else
                {
                    battleText.PrintHealthValues(playerParams.Player, monster);
                    monster.PrintSprite();
                    battleText.PrintYouAreAttackedBy(monster);
                    playerParams.Player.TakeDamage(monster);
                    Console.ReadKey();

                    if (playerParams.Player.Health >= 1 && !playerParams.Player.quitGame)
                    {
                        Console.Clear();
                        battleText.PrintHealthValues(playerParams.Player, monster);
                        monster.PrintSprite();

                        BattleMenu(playerParams, monster, battleText, userInput, locationHandler);

                        if (monster.Health <= 0)
                        {
                            monsterDead = true;
                        }

                    }
                    else
                    {
                        playerDead = true;
                    }

                }

            } while ((!playerDead) && (!monsterDead) && !playerParams.Player.quitGame);

            if(playerParams.Player.quitGame)
            {
                Console.Clear();
                Console.WriteLine("You quit the game");
            }
            else
            {
                Console.Clear();
                battleText.PrintHealthValues(playerParams.Player, monster);
                monster.PrintSprite();

                Console.WriteLine("\nBattle Over\n");
                Console.Write($"{monster.Name} dropped ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{monster.GoldDrop} gold");
                Console.ForegroundColor = ConsoleColor.White;


                playerParams.Player.AddGold(monster.GoldDrop);
            }
                Console.ReadKey();
        }


        public void BattleMenu(PlayerParams playerParams, Monster monster, BattleText battleText, UserInput.UserInput userInput, LocationHandler locationHandler)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                battleText.PrintHealthValues(playerParams.Player, monster);
                monster.PrintSprite();

                battleText.PrintBattleMenu();

                choice = userInput.GetValidInt();

                switch (choice)
                {
                    case 1: // attack
                        Console.WriteLine("You attack");
                        Console.ReadKey();
                        monster.TakeDamage(playerParams.Player);
                        break;

                    case 2: // use item
                        Console.Clear();
                        Console.WriteLine();
                        playerParams.PlayerInventory.PickItemToUse(playerParams.Player, userInput);
                        Console.ReadKey();
                        break;

                    case 3: // view stats
                        Console.Clear();
                        Console.WriteLine();

                        playerParams.Player.PrintName();
                        playerParams.Player.PrintStats();
                        Console.WriteLine();
                        monster.PrintName();
                        monster.PrintStats();

                        Console.ReadKey();
                        break;

                    case 4: // QUIT
                        playerParams.Player.QuitGame();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Pick  Option From Menu");
                        Console.ReadKey();
                        break;
                }

            } while (choice != 1 && !playerParams.Player.quitGame); // maybe add  != 2  so using an item costs a turn

        }


        public bool SpeedCheck(Player.Player player, Monster monster)
        {
            bool playerFaster = false;

            if (player.Speed * player.CurrentWeapon.WeaponSpeed > monster.Speed * monster.Weapon.WeaponSpeed)
            {
                playerFaster = true;
            }
            else
            {
                playerFaster = false;
            }

            return playerFaster;
        }

        //-----
    }
}
