using RPG.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters.MonsterClasses
{
    internal class Monster
    {

        public Monster(string name, int maxHealth, int attack, int defence, int speed, int goldDrop, string sprite, Weapon weapon)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defence = defence;
            Speed = speed;
            GoldDrop = goldDrop;
            Sprite = sprite;
            Weapon = weapon;
        }


        public string Name { get; set; }
        public int MaxHealth { get; set; } 
        public int Health { get; set; } 
        public int Attack { get; set; } 
        public int Defence { get; set; } 
        public int Speed { get; set; } 
        public int GoldDrop { get; set; }
        public string Sprite { get; }
        public Weapon Weapon { get; } 



        public void PrintHealth()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("HP : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Health} / {MaxHealth}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintSprite()
        {
            Console.WriteLine(Sprite);
            Console.WriteLine();
        }

        public void TakeDamage(Player.Player player)
        {
            int lvl = 20;
            int damage = ((2 * lvl + 2) / 5) * player.CurrentWeapon.Power * player.Attack / Defence / 50 + 2;
            Health -= damage;
            Health = Math.Clamp(Health, 0, MaxHealth);
        }

        public void PrintName()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Name);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintStats()
        {
            Console.WriteLine();
            Console.WriteLine(Name);
            Console.WriteLine($"Max HP - {MaxHealth}");
            Console.WriteLine($"Current HP - {Health}");
            Console.WriteLine($"Attack - {Attack}");
            Console.WriteLine($"Defence - {Defence}");
            Console.WriteLine($"Speed - {Speed}");
            Console.WriteLine($"Weapon - {Weapon.Name}");
        }
    }
}
