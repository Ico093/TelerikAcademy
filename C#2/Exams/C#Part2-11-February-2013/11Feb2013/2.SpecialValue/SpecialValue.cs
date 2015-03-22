using System;
using System.Collections.Generic;

class SpecialValue
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int maxSum = 0;

        List<string[]> colons = new List<string[]>();
        List<int[]> cols = new List<int[]>();
        for (int i = 0; i < rows; i++)
        {
            colons.Add(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));
            int[] newCols = new int[colons[i].Length];
            for (int j = 0; j < colons[i].Length; j++)
            {
                newCols[j] = int.Parse(colons[i][j]);
            }
            cols.Add(newCols);
        }

        for (int i = 0; i < cols[0].Length; i++)
        {
            CalculateNextRow(cols, i, ref maxSum);
        }

        Console.WriteLine(maxSum);
    }

    static void CalculateNextRow(List<int[]> cols,int start,ref int maxSum)
    {
        int teqSum = 1;
        bool isPassed = false;
        int row=0;
        List<int[]> passed=new List<int[]>();
        while (cols[row][start] >= 0)
        {
            isPassed = false;
            foreach (int[] indexes in passed)
            {
                if (indexes[0] == row && indexes[1] == start)
                {
                    isPassed = true;
                    break;
                }
            }
            if (isPassed)
            {
                break;
            }
            teqSum++;
            passed.Add(new int[]{row,start});
            start = cols[row][start];
            row = (row + 1) % cols.Count;
        }
        if (isPassed)
        {
            return;
        }
        else if (cols[row][start] < 0)
        {
            teqSum+=Math.Abs(cols[row][start]);
            if (teqSum > maxSum)
            {
                maxSum = teqSum;
            }
        }
    }
}
