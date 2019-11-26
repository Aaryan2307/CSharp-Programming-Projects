using System;
using System.Linq;

namespace Card_Trick_NEA
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialising arrays for the piles and the overall total pile
            string[,] fullDeck = createDeck();
            string[] pile1 = getRandomPile(fullDeck);
            string[] pile2 = getRandomPile(fullDeck);
            string[] pile3 = getRandomPile(fullDeck);
            string[] pileTotal = new string[21];
            int choice1;
            int choice2;
            int choice3;
            //outputting each pile
            outputPiles(pile1, pile2, pile3);
            Console.Write("\nPlease choose a card, and enter the pile it is in: \n");
            //casting the userinput to an integer to use in the following function
            int.TryParse(Console.ReadLine(), out choice1);
            pileTotal = organisePiles(pileTotal, pile1, pile2, pile3, choice1);
            redistributePiles(pileTotal, pile1, pile2, pile3);
            //process is repeated two more times
            outputPiles(pile1, pile2, pile3);
            Console.Write("\nPlease choose a card, and enter the pile it is in: \n");
            int.TryParse(Console.ReadLine(), out choice2);
            pileTotal = organisePiles(pileTotal, pile1, pile2, pile3, choice2);
            redistributePiles(pileTotal, pile1, pile2, pile3);
            outputPiles(pile1, pile2, pile3);
            Console.Write("\nPlease choose a card, and enter the pile it is in: \n");
            int.TryParse(Console.ReadLine(), out choice3);
            pileTotal = organisePiles(pileTotal, pile1, pile2, pile3, choice3);
            //the users card is in the middle of the final total pile
            Console.WriteLine("\nYour card is " + pileTotal[10]);
            Console.ReadKey();
        }
        static string[,] createDeck()
            //function that generates a full card deck of 52
        {
            string[,] fullDeck = new string[4, 13];
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 12; j++)
                {                  
                    if (j >= 1 && j <= 9)
                    {
                        //numerical values of card in respective elements
                        fullDeck[i, j] = findSuit(i) + (j+1).ToString();
                    }
                    else if (j == 0)
                    {
                        //fills elements with appropriate worded values
                        fullDeck[i, j] = findSuit(i) + "Ace";
                    }
                    else if (j == 10)
                    {
                        fullDeck[i, j] = findSuit(i) + "Jack";
                    }
                    else if (j == 11)
                    {
                        fullDeck[i, j] = findSuit(i) + "Queen";
                    }
                    else
                    {
                        fullDeck[i, j] = findSuit(i) + "King";
                    }
                }
            }
            return fullDeck;
        }
        static string findSuit(int i)
        {        
            string suit = "0";
            //depending on value of i(counts as rows in the 2d array), each suit is assigned to these values
            switch (i)
            {
                case 0:
                    suit = "Clubs ";
                    return suit;                    
                case 1:
                    suit = "Diamonds ";
                    return suit;                
                case 2:
                    suit = "Hearts ";
                    return suit;                   
                case 3:
                    suit = "Spades ";
                    return suit;                   
                default:
                    return suit;                
            }
            
        }
        static string[] getRandomPile(string[,] deck)
        {
            //gets a random pile of 7 from the full deck of 52
            string[] pile = new string[7];
            int rnd1;
            int rnd2;
            for (int i = 0; i < 7; i++)
            {
                Random random1 = new Random();
                Random random2 = new Random();
                do
                    //loop will check whether randomly generated card has been taken or not
                {
                    rnd1 = random1.Next(0, 3);
                    rnd2 = random2.Next(0, 12);
                    pile[i] = deck[rnd1, rnd2];
                    deck[rnd1, rnd2] = "Empty";

                } while (pile[i] == "Empty");
            }
            return pile;
        }
        static string[] organisePiles(string[] totalPile, string[] pile1, string[] pile2, string[] pile3, int choice)
        {
            //checks which pile the user chose, and puts that in the middle of the other two in the total pile of 21
            if (choice == 1)
            {
                //concatenates arrays
                totalPile = pile2.Concat(pile1).ToArray();
                totalPile = totalPile.Concat(pile3).ToArray();
            }
            else if (choice == 2)
            {
                totalPile = pile1.Concat(pile2).ToArray();
                totalPile = totalPile.Concat(pile3).ToArray();
            }
            else
            {
                totalPile = pile1.Concat(pile3).ToArray();
                totalPile = totalPile.Concat(pile2).ToArray();
            }
            return totalPile;
            
        }
        static void redistributePiles(string[] pileTotal, string[] pile1, string[] pile2, string[] pile3)
        {
            //from the new total pile, cards are redistributed to each pile from the top of the deck one by one
            int j = 0;
            for (int i = 0; i < 19; i+=3)
            {
                pile1[j] = pileTotal[i];
                pile2[j] = pileTotal[i+1];
                pile3[j] = pileTotal[i+2];
                j++;
                if (j == 7)
                {
                    break;
                }
            }
        }
        static void outputPiles(string[] pile1, string[] pile2, string[] pile3)
        {
            //This output is stored in a procedure becuase it is used more than once
            Console.WriteLine("Pile 1: " + String.Join(", ", pile1) + "\n");
            Console.WriteLine("Pile 2: " + String.Join(", ", pile2) + "\n");
            Console.WriteLine("Pile 3: " + String.Join(", ", pile3) + "\n");
        }
    }
}
