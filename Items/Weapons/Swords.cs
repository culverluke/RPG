using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Weapons
{
    internal class IronSword : Weapon
    {
        public IronSword()
        {
            Name = "Iron Sword";
            Weight = 4f;
            Value = 10;
            Power = 10;
            WeaponSpeed = 0.8f;
        }

    }

    internal class SteelSword :Weapon
    {
        public SteelSword()
        {
            Name = "Steel Sword";
            Weight = 4.5f;
            Value = 12;
            Power = 15;
            WeaponSpeed = 0.8f;
        }

    }




}
