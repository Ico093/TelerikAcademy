using System;



class SubsetSums
{
    static void Main()
    {
        byte N;
        long S;
        int sum = 0;
        S = long.Parse(Console.ReadLine());
        N = byte.Parse(Console.ReadLine());
        long[] Numbers = new long[16];
        for (int i = 0; i < N; i++)
            Numbers[i] = long.Parse(Console.ReadLine());
        for (int i = 1; i < Math.Pow(2, N); i++)
            if ((i % 2 * Numbers[0] + i / 2 % 2 * Numbers[1] + i / 4 % 2 * Numbers[2] + i / 8 % 2 * Numbers[3] + i / 16 % 2 * Numbers[4] 
                + i / 32 % 2 * Numbers[5] + i / 64 % 2 * Numbers[6] + i / 128 % 2 * Numbers[7] + i / 256 % 2 * Numbers[8] + i / 512 % 2 * Numbers[9]
                + i / 1024 % 2 * Numbers[10] + i / 2048 % 2 * Numbers[11] + i / 4096 % 2 * Numbers[12] + i / 8192 % 2 * Numbers[13]
                + i / 16384 % 2 * Numbers[14] + i / 32768 % 2 * Numbers[15]) == S)
                sum++;
        Console.WriteLine(sum);
    }
}

