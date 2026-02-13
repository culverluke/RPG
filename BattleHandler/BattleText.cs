using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.BattleHandler
{
    internal class BattleText
    {

        public void PrintBattleMenu()
        {
            Console.WriteLine("[1] - Attack");
            Console.WriteLine("[2] - Use Item");
            Console.WriteLine("[3] - View Stats");
            Console.WriteLine("[4] - Save");
            Console.WriteLine("[5] - Quit\n");
        }

        public void PrintHealthValues(Player.Player player, Monster monster)
        {
            player.PrintHealth();
            Console.Write("\t\t\t\t");
            monster.PrintHealth();
            Console.WriteLine();
        }

        public void PrintYouAreAttackedBy(Monster monster)
        {
            Console.WriteLine($"You are attacked by {monster.Name}");
        }

        //------
    }
}
