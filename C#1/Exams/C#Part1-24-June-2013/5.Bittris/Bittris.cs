using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Bittris
{
    static void Main()
    {
        int[,] matrix = new int[4, 8];
        bool Stop = false;
        bool EndGame = false;
        bool LastRow = false;
        string Falling = "";
        string Command = "";
        BigInteger score = 0;
        int scoreCount = 0;

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount / 4; i++)
        {
            Falling = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');

            for (int j = 0; j < Falling.Length; j++)
            {
                if (Falling[j] == '1')
                {
                    scoreCount++;
                }
            }

            Falling = Falling.Substring(Falling.Length - 8);

            CanIStart(ref matrix, Falling, ref EndGame, ref score, scoreCount);

            for (int j = 0; j < 3; j++)
            {
                Command = Console.ReadLine();

                if (!Stop && !EndGame)
                {
                    switch (Command)
                    {
                        case "D":
                            CanIDown(ref matrix, Falling, j, ref Stop,ref LastRow);
                            break;
                        case "R":
                            CanIRightDown(ref matrix, ref Falling, j, ref Stop,ref LastRow);
                            break;
                        case "L":
                            CanILeftDown(ref matrix, ref Falling, j, ref Stop,ref LastRow);
                            break;
                    }
                    if (Stop)
                    {
                        if (LastRow)
                        {
                            if (isWhole(matrix, 3))
                            {
                                deleteRow(ref matrix, j+1, ref score, scoreCount);
                            }
                            else
                            {
                                score += scoreCount;
                            }
                        }
                        else
                        {
                            if (isWhole(matrix, j))
                            {
                                deleteRow(ref matrix, j, ref score, scoreCount);
                            }
                            else
                            {
                                score += scoreCount;
                            }
                        }
                    }
                }
            }

            Falling = "";
            scoreCount = 0;
            LastRow = false;
            Stop = false;
        }

        Console.WriteLine(score);
    }

    static void CanIStart(ref int[,] matrix, string Falling, ref bool EndGame, ref BigInteger score, int scoreCount)
    {
        for (int i = 0; i < 8; i++)
        {
            if (matrix[0, i] == 1 && Falling[i] == '1')
            {
                EndGame = true;
                return;
            }
            else
            {
                matrix[0, i] = Convert.ToInt32(Falling[i]) - 48;
            }
        }
    }

    static void CanIDown(ref int[,] matrix, string Falling, int row, ref bool Stop,ref bool LastRow)
    {

        for (int i = 0; i < 8; i++)
        {
            if (matrix[row + 1, i] != 0 && Falling[i] != '0')
            {
                Stop = true;
            }
        }
        if (!Stop)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Falling[i] == '1')
                {
                    matrix[row, i] = 0;
                    matrix[row + 1, i] = 1;
                }
            }
            if (row == 2)
            {
                Stop = true;
                LastRow = true;
            }
        }

    }

    static void CanILeftDown(ref int[,] matrix, ref string Falling, int row, ref bool Stop,ref bool LastRow)
    {
        if (Falling[0] == '1')
        {
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
        else if (matrix[row, Falling.IndexOf('1') - 1] == 1)
        {
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Falling[i] == '1')
                {
                    matrix[row, i] = 0;
                }
            }
            Falling = Falling.Substring(1) + "0";
            for (int i = 0; i < 8; i++)
            {
                if (Falling[i] == '1')
                {
                    matrix[row, i] = 1;
                }
            }
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
    }

    static void CanIRightDown(ref int[,] matrix, ref string Falling, int row, ref bool Stop, ref bool LastRow)
    {
        if (Falling[Falling.Length - 1] == '1')
        {
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
        else if (matrix[row, Falling.LastIndexOf('1') + 1] == 1)
        {
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Falling[i] == '1')
                {
                    matrix[row, i] = 0;
                }
            }
            Falling = "0" + Falling.Substring(0, Falling.Length - 1);
            for (int i = 0; i < 8; i++)
            {
                if (Falling[i] == '1')
                {
                    matrix[row, i] = 1;
                }
            }
            CanIDown(ref matrix, Falling, row, ref Stop,ref LastRow);
        }
    }

    static bool isWhole(int[,] matrix, int row)
    {
        for (int i = 0; i < 8; i++)
        {
            if (matrix[row, i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    static void deleteRow(ref int[,] matrix, int row, ref BigInteger score, int ChangingScore)
    {
        if (row == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                matrix[0, i] = 0;
            }
        }
        else
        {
            for (int j = row; j > 0; j--)
            {
                for (int i = 0; i < 8; i++)
                {
                    matrix[j, i] = matrix[j - 1, i];
                    matrix[j - 1, i] = 0;
                }
            }
        }
        score += ChangingScore * 10;
    }
}
