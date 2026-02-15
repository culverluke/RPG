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
        public BattleParams(BattleHandler battleHandler, BattleText battleText, List<Monster> monsterList)
        {
            BattleHandler = battleHandler;
            BattleText = battleText;
            MonsterList = monsterList;
        }

        public BattleHandler BattleHandler { get; set; }
        public BattleText BattleText { get; set; }
        public List<Monster> MonsterList { get; set; }
    }
}
