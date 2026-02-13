using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.DungeonGameBoard
{
    internal class PlayerController
    {

        public void MovePlayer(GameBoard gameBoard)
        {
            bool validInput = false;

            do
            {

                ConsoleKey playerInput = Console.ReadKey().Key;

                switch(playerInput)
                {
                    case ConsoleKey.W:

                        if(gameBoard.PlayerLocation[1] <= 1)
                        {
                            // do nothing will be out of bounds
                        }
                        else
                        {
                            gameBoard.PlayerLocation[1] -= 1;
                            validInput = true;
                        }

                            break;

                    case ConsoleKey.S:

                        if (gameBoard.PlayerLocation[1] >= gameBoard.Dimentions)
                        {
                            // out of bounds
                        }
                        else
                        {
                            gameBoard.PlayerLocation[1] += 1;
                            validInput = true;
                        }

                            break;

                    case ConsoleKey.A:

                        if (gameBoard.PlayerLocation[0] <= 1)
                        {
                            // out of bounds
                        }
                        else
                        {
                            gameBoard.PlayerLocation[0] -= 1;
                            validInput = true;
                        }

                            break;

                    case ConsoleKey.D:

                        if (gameBoard.PlayerLocation[0] >= gameBoard.Dimentions)
                        {
                            // out of bounds
                        }
                        else
                        {
                            gameBoard.PlayerLocation[0] += 1;
                            validInput = true;
                        }

                            break;

                }


            } while (!validInput);


        }

    }
}
