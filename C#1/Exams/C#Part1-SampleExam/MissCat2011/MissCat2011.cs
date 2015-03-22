using System;


class MissCat2011
{
    static void Main()
    {
        uint N;
        uint VoteFor;
        uint Winner = 0;
        uint WinnerVotes=0;
        uint[] cat = new uint[10];
        N = uint.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            VoteFor = uint.Parse(Console.ReadLine());
            switch (VoteFor)
            {
                case 1:
                    cat[0]++;
                    break;
                case 2:
                    cat[1]++;
                    break;
                case 3:
                    cat[2]++;
                    break;
                case 4:
                    cat[3]++;
                    break;
                case 5:
                    cat[4]++;
                    break;
                case 6:
                    cat[5]++;
                    break;
                case 7:
                    cat[6]++;
                    break;
                case 8:
                    cat[7]++;
                    break;
                case 9:
                    cat[8]++;
                    break;
                case 10:
                    cat[9]++;
                    break;
                default:
                    break;
            }
        }
        for (uint i = 0; i < 10; i++)
            if (WinnerVotes < cat[i])
            {
                Winner = i+1;
                WinnerVotes = cat[i];
            }
        Console.WriteLine(Winner);
    }
}

