using System;

class Pillar
{
    static void Main()
    {
        int N = 8;
        bool Found = false;
        int Number;
        int left;
        int right;
        int[,] Numbers = new int[N, N];

        for (int row = 0; row < N; row++)
        {
            Number = int.Parse(Console.ReadLine());
            for (int col = N-1; col >=0; col--)
            {
                Numbers[row, col] = Number % 2;
                Number /= 2;
            }
        }


        for (int pillar= 0; pillar < N; pillar++)
        {
            left = 0;
            right = 0;
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < pillar; col++)
                {
                    if (Numbers[row, col] == 1)
                        left++;
                }
            }

            for (int row = 0; row < N; row++)
            {
                for (int col = pillar+1; col < N; col++)
                {
                    if (Numbers[row, col] == 1)
                        right++;
                }
            }
            if (left == right)
            {
                Console.WriteLine(7-pillar);
                Console.WriteLine(left);
                Found = true;
                break;
            }
        }
        if (!Found)
        {
            Console.WriteLine("No");
        }
    }
}