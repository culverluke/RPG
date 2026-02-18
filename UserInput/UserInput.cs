using RPG.Inventory.PlayerInventory;
using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.UserInput
{
    internal class UserInput
    {


        public int GetValidInt()
        {
            bool validChoice = false;
            int result = 99;

            do
            {
                validChoice = int.TryParse(Console.ReadLine(), out result);

            } while (!validChoice);

            return result;
        }

        public int PickItemFromList(List<Item> itemList)
        {
            int result = 0;
            bool valid = false;

            do
            {

                int.TryParse(Console.ReadLine(), out result);

                if(result > itemList.Count || result < 0)
                {
                    Console.WriteLine("Pick a valid option");
                }
                else
                {
                    valid = true;
                }

            } while (!valid);

            return result;
        }

        



    }
}
