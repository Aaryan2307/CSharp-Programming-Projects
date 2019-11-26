using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int intToFind;
            int count = 0;
            int factorialAnswer = 1;
            do
            {
                Console.Write("Please enter an integer to find the factorial of: ");
               string nString = Console.ReadLine();
                if (int.TryParse(nString, out intToFind) == true)
                {
                    break;
                }
            } while (count == 0);
            if (intToFind != 0)
            {
                for (int i = 1; i <= intToFind; i++)
                {
                    factorialAnswer = factorialAnswer * i;
                }
            }
            else
            {
                factorialAnswer = 1;
            }
            Console.WriteLine(factorialAnswer.ToString());
            Console.ReadLine();
        }
    }
}
