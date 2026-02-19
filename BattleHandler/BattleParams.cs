using RPG.LocationSystem.LocationHandler;
using RPG.Monsters;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.BattleHandler
{
    internal class BattleParams
    {
        public BattleParams(BattleHandler battleHandler, BattleText battleText, MonsterLists monsterLists)
        {
            BattleHandler = battleHandler;
            BattleText = battleText;
            MonsterLists = monsterLists;
        }

        public BattleHandler BattleHandler { get; set; }
        public BattleText BattleText { get; set; }
        public MonsterLists MonsterLists { get; set; }
    }
}
