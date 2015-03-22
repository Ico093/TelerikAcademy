using System;
using System.Collections.Generic;

class _3DSlices
{
    static void Main()
    {
        string[] WHD = Console.ReadLine().Split(' ');
        int W = int.Parse(WHD[0]);
        int H = int.Parse(WHD[1]);
        int D = int.Parse(WHD[2]);
        int[, ,] cube = new int[W, H, D];

        long cubeSum = 0;

        for (int height = 0; height < H; height++)
        {
            string[] lines = Console.ReadLine().Split('|');
            for (int depth = 0; depth < D; depth++)
            {
                string[] numbers = lines[depth].Trim().Split(' ');
                for (int width = 0; width < W; width++)
                {
                    cube[width, height,depth] = int.Parse(numbers[width]);
                    cubeSum += cube[width, height,depth];
                }
            }
        }

        int equal=0;

        long first = Right(cube, 0, H, D);
        long second = cubeSum - first;
        for (int width = 1; width < W; width++)
        {
            if (first == second)
            {
                equal++;
            }
            first += Right(cube, width, H, D);
            second = cubeSum - first;
        }

        first = Front(cube, 0, H, W);
        second = cubeSum - first;
        for (int depth = 1; depth < D; depth++)
        {
            if (first == second)
            {
                equal++;
            }
            first += Front(cube, depth, H, W);
            second = cubeSum - first;
        }

        first = Top(cube, 0, D, W);
        second = cubeSum - first;
        for (int height = 1; height < H; height++)
        {
            if (first == second)
            {
                equal++;
            }
            first += Top(cube, height, D, W);
            second = cubeSum - first;
        }

        Console.WriteLine(equal);
    }

    static int Right(int[, ,] cube, int width,int H,int D)
    {
        int sum = 0;

        for (int height = 0; height < H; height++)
        {
            for (int depth = 0; depth < D; depth++)
            {
                sum += cube[width, height, depth];
            }
        }

        return sum;
    }

    static int Front(int[, ,] cube, int depth, int H, int W)
    {
        int sum = 0;

        for (int height = 0; height < H; height++)
        {
            for (int width = 0; width < W; width++)
            {
                sum += cube[width, height, depth];
            }
        }

        return sum;
    }

    static int Top(int[, ,] cube, int height, int D, int W)
    {
        int sum = 0;

        for (int depth = 0; depth < D; depth++)
        {
            for (int width = 0; width < W; width++)
            {
                sum += cube[width, height, depth];
            }
        }

        return sum;
    }
}
