using RPG.Inventory.PlayerInventory;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
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


        public void Battle(Player.Player player, Monster monster, PlayerInventory playerInventory, BattleText battleText)
        {
            bool playerFaster = SpeedCheck(player, monster);
            bool playerDead = false;
            bool monsterDead = false;

            do
            {
                Console.Clear();
                if (playerFaster)
                {
                    battleText.PrintHealthValues(player, monster);
                    monster.PrintSprite();

                    BattleMenu(player, monster, playerInventory, battleText);
                    //monster.TakeDamage(player);
                    //Console.ReadKey();

                    if (monster.Health >= 1)
                    {
                        Console.Clear();
                        battleText.PrintHealthValues(player, monster);
                        monster.PrintSprite();
                        battleText.PrintYouAreAttackedBy(monster);
                        player.TakeDamage(monster);
                        Console.ReadKey();

                        if (player.Health <= 0)
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
                    battleText.PrintHealthValues(player, monster);
                    monster.PrintSprite();
                    battleText.PrintYouAreAttackedBy(monster);
                    player.TakeDamage(monster);
                    Console.ReadKey();

                    if (player.Health >= 1)
                    {
                        Console.Clear();
                        battleText.PrintHealthValues(player, monster);
                        monster.PrintSprite();

                        BattleMenu(player, monster, playerInventory, battleText);
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
            battleText.PrintHealthValues(player, monster);
            Console.ReadKey();
        }



        public void BattleMenu(Player.Player player, Monster monster, PlayerInventory playerInventory, BattleText battleText)
        {
            int choice = 99;


            do
            {
                Console.Clear();
                battleText.PrintHealthValues(player, monster);
                monster.PrintSprite();

                battleText.PrintBattleMenu();

                Int32.TryParse(Console.ReadLine(), out choice);


                switch (choice)
                {
                    case 1: // attack
                        Console.WriteLine("You attack");
                        Console.ReadKey();
                        monster.TakeDamage(player);
                        break;

                    case 2: // use item
                        playerInventory.PickItemToUse(player);
                        Console.ReadKey();
                        break;

                    case 3: // view stats
                        Console.Clear();
                        Console.WriteLine();

                        player.PrintName();
                        player.PrintStats();
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
