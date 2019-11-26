using System;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 29, 1, 13, 79, 33 };
            for (int i = 1; i <= 5; i++)
            {
                int j = i - 1;
                int temp1 = arr[i];
                    while (temp1 < arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    if ((i != 0) && (j!= 0))
                    {
                        i--;
                        j--;
                    }
                    }                   
            }
            Console.WriteLine(String.Join(" ", arr));
            Console.ReadKey();
        }
    }
}
