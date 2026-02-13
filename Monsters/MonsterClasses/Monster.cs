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

        public Monster(string name, int maxHealth, int attack, int defence, int speed, string sprite, Weapon weapon)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defence = defence;
            Speed = speed;
            Sprite = sprite;
            Weapon = weapon;
        }


        public string Name { get; set; }
        public int MaxHealth { get; set; } 
        public int Health { get; set; } 
        public int Attack { get; set; } 
        public int Defence { get; set; } 
        public int Speed { get; set; } 
        public string Sprite { get; }
        public Weapon Weapon { get; } 



        public void PrintHealth()
        {
            Console.Write($"HP   {Health} / {MaxHealth}");
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
        }

        public void PrintName()
        {
            Console.WriteLine(Name);
        }

        public void PrintStats()
        {
            Console.WriteLine();
            Console.WriteLine($"Max HP - {MaxHealth}");
            Console.WriteLine($"Current HP - {Health}");
            Console.WriteLine($"Attack - {Attack}");
            Console.WriteLine($"Defence - {Defence}");
            Console.WriteLine($"Speed - {Speed}");
            Console.WriteLine($"Weapon - {Weapon.Name}");
        }
    }
}
