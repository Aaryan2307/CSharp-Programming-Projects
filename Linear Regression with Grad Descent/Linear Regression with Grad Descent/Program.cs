using System;
using System.Collections.Generic;
using System.IO;

namespace Linear_Regression_with_Grad_Descent
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] dataSet = getData();
            double m = 0;
            double c = 0;
        }
        static double[,] getData()
        {
            using var reader = new StreamReader(@"C:\Users\LegendDude\Desktop\training data.csv");
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
            double[,] dataSet = new double[listB.Count, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j < listA.Count; j++)
                {
                    if (i == 0)
                    {
                        double.TryParse(listA[j], out dataSet[j - 1, i]);
                    }
                    else
                    {
                        double.TryParse(listB[j], out dataSet[j - 1, i]);
                    }
                }
            }
            return dataSet;
        }
    }
}
