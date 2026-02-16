using RPG.Items;
using RPG.Monsters.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    internal class MonsterLists
    {
        public MonsterLists(ItemCreator itemCreator)
        {
            WoodsMonsterList = CreateWoodsMonsterList(itemCreator);
            CastleMonsterList = new();
        }

        public List<Monster> WoodsMonsterList { get; set; }
        public List<Monster> CastleMonsterList { get; set; }



        public List<Monster> CreateWoodsMonsterList(ItemCreator itemCreator)
        {
            Monster skeleton = new Monster("Skeleton", 20, 13, 12, 14, 1, MonsterSprites.MonsterSprites.Skeleton, itemCreator.CreateIronAxe());
            Monster minotaur = new Monster("Minotaur", 25, 15, 12, 18, 3, MonsterSprites.MonsterSprites.Minotaur, itemCreator.CreateClaws());
            Monster harpy = new("Harpy", 20, 14, 15, 15, 2, MonsterSprites.MonsterSprites.Harpy, itemCreator.CreateClaws());

            WoodsMonsterList = [skeleton, minotaur, harpy];
            return WoodsMonsterList;
        }

    }
}
