using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_To_Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to convert to Morse Code");
            string inputString = Console.ReadLine();
            Console.WriteLine(convertToMorse(inputString));
            Console.ReadKey();
        }
        static string convertToMorse(string input)
        {
            string morseCode = "";
            foreach (char item in input)
            {
                if (item == 'A' || item == 'a')
                {
                    morseCode = morseCode + " .-";
                }
                else if (item == 'B' || item == 'b')
                {
                    morseCode = morseCode + " -...";
                }
                else if (item == 'C' || item == 'c')
                {
                    morseCode = morseCode + " -.-.";
                }
                else if (item == 'D' || item == 'd')
                {
                    morseCode = morseCode + " -..";
                }
                else if (item == 'E' || item == 'e')
                {
                    morseCode = morseCode + " .";
                }
                else if (item == 'F' || item == 'f')
                {
                    morseCode = morseCode + " ..-.";
                }
                else if (item == 'G' || item == 'g')
                {
                    morseCode = morseCode + " --.";
                }
                else if (item == 'H' || item == 'h')
                {
                    morseCode = morseCode + " ....";
                }
                else if (item == 'I' || item == 'i')
                {
                    morseCode = morseCode + " ..";
                }
                else if (item == 'J' || item == 'j')
                {
                    morseCode = morseCode + " .---";
                }
                else if (item == 'K' || item == 'k')
                {
                    morseCode = morseCode + " -.-";
                }
                else if (item == 'L' || item == 'l')
                {
                    morseCode = morseCode + " .-..";
                }
                else if (item == 'M' || item == 'm')
                {
                    morseCode = morseCode + " --";
                }
                else if (item == 'N' || item == 'n')
                {
                    morseCode = morseCode + " -.";
                }
                else if (item == 'O' || item == 'o')
                {
                    morseCode = morseCode + " ---";
                }
                else if (item == 'P' || item == 'p')
                {
                    morseCode = morseCode + " .--.";
                }
                else if (item == 'Q' || item == 'q')
                {
                    morseCode = morseCode + " --.-";
                }
                else if (item == 'R' || item == 'r')
                {
                    morseCode = morseCode + " .-.";
                }
                else if (item == 'S' || item == 's')
                {
                    morseCode = morseCode + " ...";
                }
                else if (item == 'T' || item == 't')
                {
                    morseCode = morseCode + " -";
                }
                else if (item == 'U' || item == 'u')
                {
                    morseCode = morseCode + " ..-";
                }
                else if (item == 'V' || item == 'v')
                {
                    morseCode = morseCode + " ...-";
                }
                else if (item == 'W' || item == 'w')
                {
                    morseCode = morseCode + " .--";
                }
                else if (item == 'X' || item == 'x')
                {
                    morseCode = morseCode + " -..-";
                }
                else if (item == 'Y' || item == 'y')
                {
                    morseCode = morseCode + " -.--";
                }
                else if (item == 'Z' || item == 'z')
                {
                    morseCode = morseCode + " --..";
                }
                else if (item == ' ')
                {
                    morseCode = morseCode + " | ";
                }
                else
                {
                    morseCode = morseCode + item;
                }
            }
            return morseCode;
        }
    }
}
