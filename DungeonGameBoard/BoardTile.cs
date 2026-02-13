using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.DungeonGameBoard
{
    internal class BoardTile
    {
        public BoardTile(int y, int x)
        {
            Contents = " ";
            X = x;
            Y = y;
            ChanceOfBattle = 0;
        }

        public string Contents { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ChanceOfBattle { get; set; }

    }
}
