using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit_CheckSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string creditString;
            int[] creditArray = new int[16];
            do
            {
                Console.WriteLine("Please enter a credit card number to check if it is valid");
                creditString = Console.ReadLine();                
            } while (creditString.Length != 16);
            for (int i = 0; i <= 15; i++)
            {
                int.TryParse(creditString[i].ToString(), out creditArray[i]);
            }
            checkSum(creditArray);
            Console.ReadKey();
        }

        static void checkSum(int[] creditNumber)
        {
            int total = 0;
            for (int i = 0; i <= 14; i = i + 2)
            {
                creditNumber[i] = creditNumber[i] * 2;
                if (creditNumber[i] >= 10)
                {
                    creditNumber[i] =  1 + (creditNumber[i] - 10);
                }
            }
            for (int j = 0; j <= 15; j++)
            {
                total = total + creditNumber[j];
            }
            if ((total % 10) == 0)
            {
                Console.WriteLine("Credit card number is valid");
            }
            else
            {
                Console.WriteLine("Credit card number is invalid");
            }
        }
    }
}
