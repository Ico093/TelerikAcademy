using System;

class Carpets
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());
        for(int i=0;i<N/2;i++)
        {
            for(int j=1;j<N/2-i;j++)
                Console.Write('.');
            for (int j = 0; j < 1 + i; j++)
            {
                if (j % 2 == 1)
                    Console.Write(" ");
                else
                    Console.Write('/');
            }
            for (int j = 0; j < 1 + i; j++)
            {
                if (i % 2 == 1)
                {
                    if (j % 2 == 0)
                        Console.Write(" ");
                    else
                        Console.Write(@"\");
                }
                else
                {
                    if (j % 2 == 1)
                        Console.Write(" ");
                    else
                        Console.Write(@"\");
                }
            }
            for(int j=1;j<N/2-i;j++)
                Console.Write('.');
            Console.WriteLine();
        }


        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j <i; j++)
                Console.Write('.');
            for (int j = 0; j < N / 2 - i; j++)
            {
                
                    if (j % 2 == 1)
                        Console.Write(" ");
                    else
                        Console.Write(@"\");
                
            }
            for (int j = 0; j < N / 2 - i; j++)
            {
                if (N % 4 != 0)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                            Console.Write(" ");
                        else
                            Console.Write("/");
                    }
                    else
                    {
                        if (j % 2 == 1)
                            Console.Write(" ");
                        else
                            Console.Write('/');
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            Console.Write(" ");
                        else
                            Console.Write("/");
                    }
                    else
                    {
                        if (j % 2 == 1)
                            Console.Write(" ");
                        else
                            Console.Write('/');
                    }
                }
            }
            for (int j = 0; j < i; j++)
                Console.Write('.');
            Console.WriteLine();
        }
    }
}

