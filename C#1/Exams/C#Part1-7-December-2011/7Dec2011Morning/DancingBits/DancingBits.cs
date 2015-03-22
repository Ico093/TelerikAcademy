using System;
using System.Numerics;

class DancingBits
{
    static void Main()
    {
        int sum = 0, sequence0 = 0, sequence1 = 0;
        string Number_ = "";
        string Num;
        int K;
        long N;
        K = int.Parse(Console.ReadLine());
        N = long.Parse(Console.ReadLine());
        long[] Numbers = new long[N];
        for (int i = 0; i < N; i++)
        {
            Num = "";
            Numbers[i] = long.Parse(Console.ReadLine());
            while (Numbers[i] != 0)
            {
                Num = string.Concat((Numbers[i]%2).ToString(), Num);
                Numbers[i] /= 2;
            }
            Number_ = string.Concat(Number_, Num);
        }
        for (int i = 0; i < Number_.Length - 1; i++)
        {
            if (Number_[i] == '1')
            {
                sequence0 = 0;
                sequence1++;
                if (sequence1 == K &&  Number_[i + 1] == '0')
                    sum++;
            }
            else
            {
                sequence1 = 0;
                sequence0++;
                if (sequence0 == K && Number_[i + 1] == '1')
                    sum++;
            }
        }
        if (Number_[Number_.Length - 1] == '1')
        {
            sequence0 = 0;
            sequence1++;
            if (sequence1 == K)
                sum++;
        }
        else
        {
            sequence1 = 0;
            sequence0++;
            if (sequence0 == K)
                sum++;
        }
        Console.WriteLine(sum);

    }
}

