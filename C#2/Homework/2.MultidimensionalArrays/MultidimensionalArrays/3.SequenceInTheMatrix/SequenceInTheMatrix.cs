using System;
using System.Threading;
using System.Collections.Generic;

class SequenceInTheMatrix
{
    static void Main()
    {
        //string[,] matrix ={
        //                  {"sad","s","asda"},
        //                  {"sad","s","s"},
        //                  {"s","sad","s"},
        //                  {"s","s","sad"},
        //              };
        //int N = 4;
        //int M = 3;

        int N = 0;
        while (N < 1)
        {
            Console.Write("Enter N (N>=1):");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not an integer greater or equal to 1");
                Thread.Sleep(1400);
                Console.Clear();
                Console.Write("Enter N (N>=1):");
            }
        }

        int M = 0;
        while (M < 3)
        {
            Console.Write("Enter M (M>=1):");
            while (!(int.TryParse(Console.ReadLine(), out M)))
            {
                Console.WriteLine("Not an integer greater or equal to 1");
                Thread.Sleep(1400);
                Console.Clear();
                Console.WriteLine("Enter N (N>=1):{0}", N);
                Console.Write("Enter M (M>=1):");
            }
        }

        string[,] matrix = new string[N, M];
        List<string> words = new List<string>();
        int maxCount = 0;
        int count = 0;

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                count = 0;
                if (row == N - 1)
                {
                    Right(matrix, M, row, col, ref maxCount, count, words);
                }

                else if (col == 0)
                {
                    Right(matrix, M, row, col, ref maxCount, count, words);
                    DownRight(matrix, N, M, row, col, ref maxCount, count, words);
                    Down(matrix, N, row, col, ref maxCount, count, words);
                }

                else if (col == M - 1)
                {
                    Down(matrix, N, row, col, ref maxCount, count, words);
                    DownLeft(matrix, N, M, row, col, ref maxCount, count, words);
                }

                else
                {
                    Right(matrix, M, row, col, ref maxCount, count, words);
                    DownRight(matrix, N, M, row, col, ref maxCount, count, words);
                    Down(matrix, N, row, col, ref maxCount, count, words);
                    DownLeft(matrix, N, M, row, col, ref maxCount, count, words);
                }
            }
        }

        Console.WriteLine("Max count: {0}", maxCount);
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();
    }


    private static int addOrNot(string[,] matrix, int pRow, int pCol, ref int maxCount, int count, List<string> words)
    {
        if (count >= maxCount)
        {
            if (count == maxCount)
            {
                if (!words.Contains(matrix[pRow, pCol]))
                    words.Add(matrix[pRow, pCol]);
            }
            else
            {
                words.Clear();
                maxCount = count;
                words.Add(matrix[pRow, pCol]);
            }
        }
        return maxCount;
    }


    private static void Right(string[,] matrix, int M, int pRow, int pCol, ref int maxCount, int count, List<string> words)
    {
        for (int col = pCol; col < M; col++)
        {
            if (matrix[pRow, col] == matrix[pRow, pCol])
                count++;
            else
            {
                break;
            }
        }
        addOrNot(matrix, pRow, pCol, ref maxCount, count, words);
    }


    private static void DownRight(string[,] matrix, int N, int M, int pRow, int pCol, ref int maxCount, int count, List<string> words)
    {
        int col = pCol;
        for (int row = pRow; row < N; row++)
        {
            if (col == M)
                break;
            if (matrix[pRow, pCol] == matrix[row, col])
            {
                count++;
                col++;
            }
            else
            {
                break;
            }
        }
        addOrNot(matrix, pRow, pCol, ref maxCount, count, words);
    }

    private static void Down(string[,] matrix, int N, int pRow, int pCol, ref int maxCount, int count, List<string> words)
    {
        for (int row = pRow; row < N; row++)
        {
            if (matrix[pRow, pCol] == matrix[row, pCol])
            {
                count++;
            }
            else
            {
                break;
            }
        }
        addOrNot(matrix, pRow, pCol, ref maxCount, count, words);
    }

    private static void DownLeft(string[,] matrix, int N, int M, int pRow, int pCol, ref int maxCount, int count, List<string> words)
    {
        int col = pCol;
        for (int row = pRow; row < N; row++)
        {
            if (col == -1)
                break;
            if (matrix[pRow, pCol] == matrix[row, col])
            {
                count++;
                col--;
            }
            else
            {
                break;
            }
        }
        addOrNot(matrix, pRow, pCol, ref maxCount, count, words);
    }
}

