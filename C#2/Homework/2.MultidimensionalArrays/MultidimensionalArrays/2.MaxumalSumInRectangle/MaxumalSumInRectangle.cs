using System;
using System.Threading;

class MaxumalSumInRectangle
{
    static void Main()
    {

        int N = 0;
        while (N < 3)
        {
            Console.Write("Enter N (N>=3):");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not an integer greater or equal to 1");
                Thread.Sleep(1400);
                Console.Clear();
                Console.Write("Enter N (N>=3):");
            }
        }

        int M=0;
         while (M < 3)
        {
            Console.Write("Enter M (M>=3):");
            while (!(int.TryParse(Console.ReadLine(), out M)))
            {
                Console.WriteLine("Not an integer greater or equal to 3");
                Thread.Sleep(1400);
                Console.Clear();
                Console.WriteLine("Enter N (N>=3):{0}",N);
                Console.Write("Enter M (M>=3):");
            }
        }
         int[,] matrix = new int[N, M];
        int posX=0, posY=0;
        int maxValue = int.MinValue;
        int curValue;

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                Console.Write("Enter matrix[{0}][{1}]:",row,col);
                while (!(int.TryParse(Console.ReadLine(), out matrix[row,col])))
                {
                    Console.WriteLine("Not an integer!");
                    Thread.Sleep(1400);
                    Console.Write("Enter matrix[{0}][{1}]:", row, col);
                }
            }
        }

        for (int row = 0; row <=N-3; row++)
        {
            for (int col = 0; col <= N-3; col++)
            {
                curValue = matrix[row, col] + matrix[row+1, col] + matrix[row+2, col] + matrix[row, col+1] + matrix[row, col+2] +
                    matrix[row+1, col+1] + matrix[row+1, col+2] + matrix[row+2, col+1] + matrix[row+2, col+2];
                if (curValue > maxValue)
                {
                    maxValue = curValue;
                    posX = col;
                    posY = row;
                }
            }   
        }

        for (int row = posY; row < posY+3; row++)
        {
            for (int col = posX; col < posX+3; col++)
            {
                Console.Write(matrix[row,col]+" ");   
            }
            Console.WriteLine();
        }
    }
}

