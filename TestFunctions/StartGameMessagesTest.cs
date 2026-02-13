using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.TestFunctions
{
    internal class StartGameMessagesTest
    {

        public void StartOfGame()
        {
            Console.WriteLine("You wake up in your home town of Pallet.");
            Console.ReadKey();
            Console.WriteLine("Today you set off on an adventure.");
            Console.ReadKey();
            Console.WriteLine("GO!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
