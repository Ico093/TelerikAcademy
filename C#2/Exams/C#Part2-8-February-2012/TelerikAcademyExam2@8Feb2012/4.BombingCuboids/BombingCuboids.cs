using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class BombingCuboids
{
    static int W, H, D;
    static SortedDictionary<string, int> colorsKilled = new SortedDictionary<string, int>();

    static void Main()
    {
        string[] coordinates = Console.ReadLine().Split(' ');

        W = int.Parse(coordinates[0]);
        H = int.Parse(coordinates[1]);
        D = int.Parse(coordinates[2]);

        string[, ,] cube = new string[W, H, D];
        for (int k = 0; k < H; k++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int i = 0; i < D; i++)
            {
                char[] colors = line[i].ToCharArray();
                for (int j = 0; j < W; j++)
                {
                    cube[j, k, i] = colors[j].ToString();
                }
            }
        }
        int bombsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < bombsCount; i++)
        {
            string[] bombCoord = Console.ReadLine().Split(' ');
            Kabooom(ref cube, bombCoord);
        }


        int killed = 0;
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < D; j++)
            {
                for (int k = 0; k < W; k++)
                {
                    if (cube[k, i, j] == "")
                    {
                        killed++;
                    }
                }
            }
        }

        Console.WriteLine(killed);

        foreach (KeyValuePair<string, int> color in colorsKilled)
        {
            Console.WriteLine("{0} {1}", color.Key, color.Value);
        }
    }

    static void Kabooom(ref string[, ,] cube, string[] bombCoord)
    {
        int w = int.Parse(bombCoord[0]);
        int h = int.Parse(bombCoord[1]);
        int d = int.Parse(bombCoord[2]);
        int power = int.Parse(bombCoord[3]);

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < D; j++)
            {
                for (int k = 0; k < W; k++)
                {
                    if (Math.Sqrt((k - w) * (k - w) + (j - d) * (j - d) + (i - h) * (i - h)) <= power)
                    {
                        if (cube[k, i, j] != "")
                        {
                            if (colorsKilled.ContainsKey(cube[k, i, j]))
                            {
                                colorsKilled[cube[k, i, j]]++;
                            }
                            else
                            {
                                colorsKilled.Add(cube[k, i, j], 1);
                            }
                        }
                        cube[k, i, j] = "";
                    }
                }
            }
        }

        for (int i = 1; i < H; i++)
        {
            for (int j = 0; j < D; j++)
            {
                for (int k = 0; k < W; k++)
                {
                    if (cube[k, i, j] != "")
                    {
                        int height = i;
                        while (height != 0)
                        {
                            if (cube[k, height - 1, j] == "")
                            {
                                cube[k, height - 1, j] = cube[k, height, j];
                                cube[k, height, j] = "";
                            }
                            height--;
                        }
                    }
                }
            }
        }
    }
}