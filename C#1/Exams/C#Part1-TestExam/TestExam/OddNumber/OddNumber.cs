using System;

class OddNumber
{
    static void Main()
    {
        //uint step = 0;
        //uint N = uint.Parse(Console.ReadLine());
        //long[] Numbers = new long[N];
        //for (int i = 0; i < N; i++)
        //    Numbers[i] = long.Parse(Console.ReadLine());
        //long[,] _Numbers = new long[N, 2];
        //Array.Sort(Numbers);
        //_Numbers[0, 0] = Numbers[0];
        //_Numbers[step, 1] = 1;
        //for (int i = 1; i < N; i++)
        //{
        //    if (Numbers[i] == _Numbers[step, 0])
        //        _Numbers[step, 1]++;
        //    else
        //    {
        //        step++;
        //        _Numbers[step, 0] = Numbers[i];
        //        _Numbers[step, 1] = 1;
        //    }
        //}
        //switch (step)
        //{
        //    case 0:
        //        Console.WriteLine(_Numbers[step,0]);
        //        break;
        //    case 1:
        //        if(_Numbers[0,1]>_Numbers[1,1])
        //            Console.WriteLine(_Numbers[1,0]);
        //        else
        //            Console.WriteLine(_Numbers[0,0]);
        //        break;
        //    default:
        //        if (_Numbers[0, 1] != _Numbers[1, 1])
        //        {
        //            if(_Numbers[1,1]!=_Numbers[2,1])
        //                Console.WriteLine(_Numbers[1,0]);
        //            else
        //                Console.WriteLine(_Numbers[0,0]);
        //        }
        //        else
        //        {
        //            for (int i = 0; i <= step; i++)
        //                if (_Numbers[i, 1] != _Numbers[0, 1])
        //                    Console.WriteLine(_Numbers[i,0]);
        //        }
        //        break;
        //}

        int N = int.Parse(Console.ReadLine());
        long theNumber = 0;
        for (int i = 0; i < N; i++)
        {
            theNumber ^= long.Parse(Console.ReadLine());
        }
        Console.WriteLine(theNumber);

    }
}

