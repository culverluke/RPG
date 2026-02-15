using RPG.Inventory.PlayerInventory;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using RPG.Player;
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


        public void Battle(PlayerParams playerParams, Monster monster, BattleText battleText)
        {
            bool playerFaster = SpeedCheck(playerParams.Player, monster);
            bool playerDead = false;
            bool monsterDead = false;

            do
            {
                Console.Clear();
                if (playerFaster)
                {
                    battleText.PrintHealthValues(playerParams.Player, monster);
                    monster.PrintSprite();

                    BattleMenu(playerParams, monster, battleText);
                    //monster.TakeDamage(player);
                    //Console.ReadKey();

                    if (monster.Health >= 1)
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

                    if (playerParams.Player.Health >= 1)
                    {
                        Console.Clear();
                        battleText.PrintHealthValues(playerParams.Player, monster);
                        monster.PrintSprite();

                        BattleMenu(playerParams, monster, battleText);
                        //monster.TakeDamage(player);
                        //Console.ReadKey();

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

            } while ((!playerDead) && (!monsterDead));
            Console.WriteLine("BattleOver");
            battleText.PrintHealthValues(playerParams.Player, monster);
            Console.ReadKey();
        }



        public void BattleMenu(PlayerParams playerParams, Monster monster, BattleText battleText)
        {
            int choice = 99;


            do
            {
                Console.Clear();
                battleText.PrintHealthValues(playerParams.Player, monster);
                monster.PrintSprite();

                battleText.PrintBattleMenu();

                Int32.TryParse(Console.ReadLine(), out choice);


                switch (choice)
                {
                    case 1: // attack
                        Console.WriteLine("You attack");
                        Console.ReadKey();
                        monster.TakeDamage(playerParams.Player);
                        break;

                    case 2: // use item
                        playerParams.PlayerInventory.PickItemToUse(playerParams.Player);
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

                    case 4: // save
                        Console.WriteLine("Not Implemented");
                        Console.ReadKey();
                        break;

                    case 5: // quit
                        Console.WriteLine("Not Implemented");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Pick  Option From Menu");
                        Console.ReadKey();
                        break;
                }

            } while (choice != 1);

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
