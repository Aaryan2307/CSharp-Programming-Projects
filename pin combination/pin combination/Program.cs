using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pin_combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pinComb = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("Please enter a number to put into combinatorics array");
                int.TryParse(Console.ReadLine(), out pinComb[i]);
            }
            printCombinations(pinComb);
            Console.ReadKey();
        }

        static void printCombinations(int[] intArray)
        {
            int temp;
              for (int i = 0; i <= 2; i++)
              {
                  for (int j = 0; j <= 1; j++)
                  {
                      Console.WriteLine(String.Join(" ", intArray));
                      temp = intArray[j + 2];
                      intArray[j + 2] = intArray[j+1];
                      intArray[j+1] = temp;
                  }
              } 
            changeFirstNum(intArray, 1);
             for (int i = 0; i <= 2; i++)
             {

                 for (int j = 0; j <= 1; j++)
                 {
                     Console.WriteLine(String.Join(" ", intArray));
                     temp = intArray[j + 2];
                     intArray[j + 2] = intArray[j+1];
                     intArray[j+1] = temp;
                 }
             } 
            changeFirstNum(intArray, 2);
              for (int i = 0; i <= 2; i++)
               {
                   for (int j = 0; j <= 1; j++)
                   {
                       Console.WriteLine(String.Join(" ", intArray));
                       temp = intArray[j + 2];
                       intArray[j + 2] = intArray[j + 1];
                       intArray[j + 1] = temp;
                   }
               }
            changeFirstNum(intArray, 3);
              for (int i = 0; i <= 2; i++)
              {
                  for (int j = 0; j <= 1; j++)
                  {
                      Console.WriteLine(String.Join(" ", intArray));
                      temp = intArray[j + 2];
                      intArray[j + 2] = intArray[j + 1];
                      intArray[j + 1] = temp;
                  }
              }
        }
         
        static void changeFirstNum(int[] intArray, int count)
        {
            int temp;
                temp = intArray[count];
                intArray[count] = intArray[0];
                intArray[0] = temp;
            Console.WriteLine(string.Join(" ", intArray));
        }
    }
}
