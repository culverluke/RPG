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
            Monster skeleton = new Monster("Skeleton", 20, 8, 9, 14, 5, MonsterSprites.MonsterSprites.Skeleton, itemCreator.CreateIronAxe());
            Monster minotaur = new Monster("Minotaur", 25, 13, 10, 18, 9, MonsterSprites.MonsterSprites.Minotaur, itemCreator.CreateClaws());
            Monster harpy = new("Harpy", 20, 10, 12, 15, 7, MonsterSprites.MonsterSprites.Harpy, itemCreator.CreateClaws());

            WoodsMonsterList = [skeleton, minotaur, harpy];
            return WoodsMonsterList;
        }

    }
}
