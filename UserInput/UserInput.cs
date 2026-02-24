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

        public string PickAName()
        {
            string name = "???";
            Console.Clear();
            Console.WriteLine();
            Console.Write("Enter a name: ");

            do
            {
                name = Console.ReadLine();

                if(name == null)
                {
                    Console.WriteLine("INVALID");
                    Console.ReadKey();
                }

            } while (name == null);

            return name;
        }

        public void PickAValidText()
        {
            Console.WriteLine("Pick a valid option");
            Console.ReadKey();
        }

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

        public bool GetValidBool()
        {
            bool result = false;
            string input = "";

            Console.WriteLine("'Y' or 'N'");
            Console.ReadLine();

            if(input.ToLower().Contains('n'))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }



    }
}
