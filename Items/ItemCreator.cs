using RPG.Items.Consumables;
using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Items.Weapons;

namespace RPG.Items
{
    internal class ItemCreator
    {

        public Item CreatePotion()
        {
            Item potion = new Potion();
            return potion;
        }

        public Weapon CreateIronAxe()
        {
            Weapon ironAxe = new IronAxe();
            return ironAxe;
        }
        
        public Weapon CreateSteelAxe()
        {
            Weapon steelaxe = new SteelAxe();
            return steelaxe;
        }

        public Weapon CreateIronDagger()
        {
            Weapon ironDagger = new IronDagger();
            return ironDagger;
        }

        public Weapon CreateSteelDagger()
        {
            Weapon steelDagger = new SteelDagger();
            return steelDagger;
        }

        public Weapon CreateIronSword()
        {
            Weapon ironSword = new IronSword();
            return ironSword;
        }

        public Weapon CreateSteelSword()
        {
            Weapon steelSword = new SteelSword();
            return steelSword;
        }

        public Weapon CreateClaws()
        {
            Weapon claws = new Claws();
            return claws;
        }
    }
}
