using System;

class FallDown
{
    static void Main()
    {
        byte[,] matrix = new byte[8, 8];
        byte count=0;
        byte Number=0;
        for (int i = 0; i < 8; i++)
        {
            Number = byte.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                matrix[i, j] = (byte)(Number % 2);
                Number /= 2;
            }
        }

        

        for (int i = 0; i < 8; i++)
        {
            count = 0;
            for (int j = 7; j >= 0; j--)
            {
                if (matrix[j, i] == 1)
                {
                    matrix[j, i] = 0;
                    matrix[7-count,i] = 1;
                    count++;
                }
            }
        }
        
        for (int i = 0; i < 8; i++)
        {
            Number = 0;
            for (int j = 7; j >= 0; j--)
                Number += (byte)(matrix[i, j] * (byte)(Math.Pow(2, 7 - j)));
            Console.WriteLine(Number);
        }
    }
}

