using System;

class BitBall
{
    static void Main()
    {
        byte Number;
        char[,] field = new char[8, 8];
        int X = 0, Y = 0;
        for (int i = 0; i < 8; i++)
        {
            Number = byte.Parse(Console.ReadLine());
            byte step = 7;
            while (Number != 0)
            {
                if (Number % 2 == 1)
                    field[i, step] = 'T';
                Number /= 2;
                step--;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            Number = byte.Parse(Console.ReadLine());
            byte step = 7;
            while (Number != 0)
            {
                if (Number % 2 == 1)
                {
                    if (field[i, step] == 'T')
                        field[i, step] = ' ';
                    else
                        field[i, step] = 'B';
                }
                Number /= 2;
                step--;
            }
        }

        bool isBlocked;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                isBlocked = false;
                if (field[i, j] == 'T')
                {
                    if (i == 7)
                        X++;
                    else
                    {
                        for (int k = i + 1; k < 8; k++)
                        {
                            if (field[k, j] == 'T' || field[k, j] == 'B')
                            {
                                k = 8;
                                isBlocked = true;
                            }
                        }
                        if (!isBlocked)
                            X++;
                    }
                }
                else if (field[i, j] == 'B')
                {
                    if (i == 0)
                        Y++;
                    else
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (field[k, j] == 'T' || field[k, j] == 'B')
                            {
                                k = -1;
                                isBlocked = true;
                            }
                        }
                        if (!isBlocked)
                            Y++;
                    }

                }
            }
        }
        Console.WriteLine(X + ":" + Y);

    }
}

