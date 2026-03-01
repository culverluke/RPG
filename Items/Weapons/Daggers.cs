using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Weapons
{
    internal class IronDagger : Weapon
    {
        public IronDagger()
        {
            Name = "Iron Dagger";
            Weight = 1.2f;
            Value = 5;
            Power = 6;
            WeaponSpeed = 1f;
        }

    }


    internal class SteelDagger : Weapon
    {
        public SteelDagger()
        {
            Name = "Steel Dagger";
            Weight = 1f;
            Value = 10;
            Power = 15;
            WeaponSpeed = 1f;
        }

    }

}
