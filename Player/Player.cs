using RPG.Inventory.PlayerInventory;
using RPG.Items.Weapons;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Player
{
    internal class Player
    {
        public Player()
        {
            Name = "Player";
            MaxHealth = 50;
            Health = 50;
            CurrentWeapon = new IronDagger();
            WoodsKey = false;
        }

        public Player(string name, int attack, int defence, int speed)
        {
            Name = name;
            MaxHealth = 500;
            Health = 500;
            Attack = 1000;
            Defence = defence;
            Speed = speed;
            Gold = 5;
            CurrentWeapon = new IronDagger();
            WoodsKey = false;
        }

        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; } 
        public int Gold { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public bool WoodsKey { get; set; }


        public void PrintName()
        {
            Console.WriteLine(Name);
        }

        public void PrintHealth()
        {
            Console.Write($"HP   {Health} / {MaxHealth}");
        }

        public void PrintStats()
        {
            Console.WriteLine();
            Console.WriteLine($"Max HP - {MaxHealth}");
            Console.WriteLine($"Current HP - {Health}");
            Console.WriteLine($"Attack - {Attack}");
            Console.WriteLine($"Defence - {Defence}");
            Console.WriteLine($"Speed - {Speed}");
            Console.WriteLine($"Gold - {Gold}");
            Console.WriteLine($"Weapon - {CurrentWeapon.Name}");
        }

        public void TakeDamage(Monster monster)
        {
            int lvl = 20; // monsters lvl
            int damage = ((2 * lvl + 2) / 5) * monster.Weapon.Power * monster.Attack / Defence / 50 + 2;
            Health -= damage;
            Health = Math.Clamp(Health, 0, MaxHealth);
        }

        public void EquipWeapon(Weapon weapon, PlayerInventory playerInventory)
        {
            playerInventory.AddToInventory(CurrentWeapon);

            CurrentWeapon = weapon;
            Console.WriteLine($"You equip {weapon.Name}");
            playerInventory.RemoveFromInventory(CurrentWeapon);
        }

        public void SetHpToMax()
        {
            Health = MaxHealth;
        }

        public void Rest()
        {
            Console.Clear();
            Console.WriteLine();
            PrintHealth();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou rest to regain your health.\n");
            SetHpToMax();
            PrintHealth();
            Console.ReadKey();
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public void RemoveGold(int amount)
        {
            Gold -= amount;
        }

        //--------
    }
}
