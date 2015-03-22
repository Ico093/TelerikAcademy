using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class FindMaxSum
{
    static Regex numbers = new Regex(@"\d+");
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\matrix.txt");
        using (reader)
        {
            int rowsAndCols = int.Parse(reader.ReadLine());
            int[,] matrix = new int[rowsAndCols, rowsAndCols];
            for (int i = 0; i < rowsAndCols; i++)
            {
                string line = reader.ReadLine().Trim();
                Match number = numbers.Match(line);
                for (int j = 0; j < rowsAndCols; j++)
                {
                    matrix[i, j] = int.Parse(number.Value.ToString());
                    Console.Write(matrix[i, j] + " ");
                    number = number.NextMatch();
                }
                Console.WriteLine();
            }

            int maxSum = int.MinValue;

            List<int[]> max = new List<int[]>();
            for (int i = 0; i < rowsAndCols - 1; i++)
            {
                for (int j = 0; j < rowsAndCols - 1; j++)
                {
                    int tempSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (tempSum >= maxSum)
                    {
                        if (tempSum != maxSum)
                        {
                            max.Clear();
                            maxSum = tempSum;
                        }
                        max.Add(new int[2] { i, j });
                    }
                }
            }

            Console.WriteLine("\n\nAll matrixes with max sum of {0} are:\n", maxSum);
            foreach (int[] index in max)
            {
                int i = index[0];
                int j = index[1];
                Console.WriteLine(matrix[i, j] + " " + matrix[i, j + 1] + "\n" + matrix[i + 1, j] + " " + matrix[i + 1, j + 1] + "\n");
            }
        }
    }
}
