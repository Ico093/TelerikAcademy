using System;
using System.Collections.Generic;
using System.Numerics;

class GreedyDwarf
{
    static void Main()
    {
        string[] valleyString =Console.ReadLine().Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries);

        int[] valley=new int[valleyString.Length];

        for (int i = 0; i < valleyString.Length; i++)
			{
			 valley[i]=int.Parse(valleyString[i]);
			}

        int mapsNumber = int.Parse(Console.ReadLine());

        List<int[]> maps = new List<int[]>();

        for (int i = 0; i < mapsNumber; i++)
        {
            string[] positions=Console.ReadLine().Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries);
            int[] map = new int[positions.Length];
            for (int j = 0; j < positions.Length; j++)
            {
                map[j] = int.Parse(positions[j]);
            }
            maps.Add(map);
        }

        long maxGold = long.MinValue;


        List<int> allPositions = new List<int>();
        for (int i = 0; i < mapsNumber; i++)
			{
            allPositions.Clear();
            int position=0;
            long teqGold = valley[position];
            allPositions.Add(position);

            while (position >= 0 && position < valley.Length)
            {
                bool End=false;
                for (int j = 0; j < maps[i].Length; j++)
                {
                    position += maps[i][j];
                    if (position >= 0 && position < valley.Length&&!allPositions.Contains(position))
                    {
                        teqGold += valley[position];
                        allPositions.Add(position);
                    }
                    else
                    {
                        End=true;
                        break;
                    }
                }
                if (End)
                {
                    break;
                }
            }
            if (teqGold > maxGold)
            {
                maxGold = teqGold;
            }
        }

        Console.WriteLine(maxGold);
    }
}