using System;
using System.Collections.Generic;

class KukataIsDancing
{
    static string[,] cube = new string[,]{
                                      {"RED","BLUE","RED"},
                                      {"BLUE","GREEN","BLUE"},
                                      {"RED","BLUE","RED"}
                                      };

    static void Main()
    {
        int numberOfDances = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfDances; i++)
        {
            Dance(Console.ReadLine().ToCharArray());
        }
    }

    static void Dance(char[] moves)
    {
        int x = 0, y = 1;
        int KukaX=1,KukaY=1;
        for (int i = 0; i < moves.Length; i++)
        {
            switch (moves[i])
            {
                case 'L':
                    {
                        x *= (-1);
                        y *= (-1);
                        Turn(ref x,ref y);
                    }
                    break;
                case 'R':
                    {
                        Turn(ref x, ref y);
                    }
                    break;
                case 'W':
                    {
                        if (KukaX + x > 2)
                        {
                            KukaX = 0;
                        }
                        else if (KukaX + x < 0)
                        {
                            KukaX = 2;
                        }
                        else
                        {
                            KukaX += x;
                        }
                        if (KukaY + y > 2)
                        {
                            KukaY = 0;
                        }
                        else if (KukaY + y < 0)
                        {
                            KukaY = 2;
                        }
                        else
                        {
                            KukaY += y;
                        }
                    }
                    break;
            }
        }

        Console.WriteLine(cube[KukaX,KukaY]);
    }

    static void Turn(ref int x, ref int y)
    {
        if (x == 0 && y == 1)
        {
            x = 1;
            y = 0;
        }
        else if (x == 1 && y == 0)
        {
            x = 0;
            y = -1;
        }
        else if (x == 0 && y == -1)
        {
            x = -1;
            y = 0;
        }
        else
        {
            x = 0;
            y = 1;
        }
    }
}
