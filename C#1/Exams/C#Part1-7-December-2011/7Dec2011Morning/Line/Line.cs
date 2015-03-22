using System;

class Line
{
    static void Main()
    {
        byte n;
        byte maxLength = 0, max = 0, step, sumRow, sumCol;
        byte[,] matrix = new byte[8, 8];
        for (int i = 0; i < 8; i++)
        {
            n = byte.Parse(Console.ReadLine());
            step = 0;
            while (n != 0)
            {
                matrix[i, 7 - step] = (byte)(n % 2);
                n /= 2;
                step++;
            }
        }


        for (int i = 0; i < 8; i++)
        {
            sumRow = 0;
            sumCol = 0;
            for (int j = 0; j < 8; j++)
            {
                if (matrix[i, j] == 0)
                {
                    if (sumRow > maxLength)
                    {
                        maxLength = sumRow;
                        max = 0;
                    }
                    if (sumRow == maxLength)
                        max++;
                    sumRow = 0;
                }
                if (matrix[j, i] == 0)
                {
                    if (sumCol > maxLength)
                    {
                        maxLength = sumCol;
                        max = 0;
                    }
                    if (sumCol == maxLength)
                        max++;
                    sumCol = 0;
                }
                sumRow += matrix[i, j];
                sumCol += matrix[j, i];
            }
            if (sumRow > maxLength)
            {
                maxLength = sumRow;
                max = 0;
            }
            if (sumRow == maxLength)
                max++;

            if (sumCol > maxLength)
            {
                maxLength = sumCol;
                max = 0;
            }
            if (sumCol == maxLength)
                max++;
        }
        if (maxLength == 1)
            max /= 2;
        Console.WriteLine(maxLength);
        Console.WriteLine(max);

    }
}

