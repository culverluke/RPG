using RPG.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.StartOfGame
{
    internal class StartOfGameFunctions
    {

        public void StartGameText()
        {
            Console.WriteLine("\nYou wake up in your home town of Pallet.");
            Console.ReadKey();
            Console.WriteLine("Today you set off on an adventure.");
            Console.ReadKey();
            Console.WriteLine("GO!");
            Console.ReadKey();
            Console.Clear();
        }

        public bool NewOrLoad(UserInput.UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t[1] - New Game\t\t[2] - Load Game");
            int awnser = 99;

            do
            {
                awnser = userInput.GetValidInt();

                switch (awnser)
                {
                    case 1:
                        return false;
                        break;
                    case 2:
                        return true;
                        break;
                    default:
                        userInput.PickAValidText();
                        break;
                }
            } while (awnser != 1 || awnser != 2);

            return false;
        }


        //------
    }
}
