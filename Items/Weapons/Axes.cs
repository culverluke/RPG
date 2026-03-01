using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items.Weapons
{
    internal class IronAxe : Weapon
    {
        public IronAxe()
        {
            Name = "Iron Axe";
            Weight = 5.5f;
            Value = 12;
            Power = 15;
            WeaponSpeed = 0.6f;
        }

    }

    internal class SteelAxe : Weapon
    {
        public SteelAxe()
        {
            Name = "Steel Axe";
            Weight = 6f;
            Value = 18;
            Power = 30;
            WeaponSpeed = 0.6f;
        }


    }

}
