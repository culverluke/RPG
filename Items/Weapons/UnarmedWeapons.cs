using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Weapons
{
    internal class Claws : Weapon
    {
        public Claws()
        {
            Name = "Claws";
            Weight = 0;
            Value = 0;
            Power = 15;
            WeaponSpeed = 1;
        }
    }

    internal class Magic : Weapon
    {
        public Magic()
        {
            Name = "Magic";
            Weight = 0;
            Value = 0;
            Power = 30;
            WeaponSpeed = 0.8f;
        }
    }

}
