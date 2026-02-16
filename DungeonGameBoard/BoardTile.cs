using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG.DungeonGameBoard
{
    internal class BoardTile
    {
        public BoardTile(int y, int x)
        {
            Contents = " ";
            ChanceOfBattle = 0;
            Coordinates.Y = y;
            Coordinates.X = x;
        }

        public string Contents { get; set; }
        public int ChanceOfBattle { get; set; }

        public Vector2 Coordinates = new Vector2(0, 0);

    }
}
