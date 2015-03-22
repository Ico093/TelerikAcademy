using System;

class AngryBits
{
    static void Main()
    {
        int[,] playGround = new int[8, 16];

        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int col = 15; col >= 0; col--)
            {
                playGround[row, col] = number % 2;
                number >>= 1;
            }
        }

        int score = 0;

        for (int col = 7; col >= 0; col--)
        {
             for (int row = 0; row < 8; row++)
            {
                if (playGround[row, col] == 1)
                {
                    score += StartGame(playGround, row, col);
                    break;
                }
            }
        }

        bool Win = true;
        for (int row = 0; row < 8; row++)
        {
            for (int col = 8; col < 16; col++)
            {
                if (playGround[row, col] == 1)
                {
                    Win = false;
                    break;
                }
            }
        }
        Console.WriteLine("{0} {1}", score, Win ? "Yes" : "No");
    }

    private static int StartGame(int[,] playGround, int row, int col)
    {
        bool isEnd = false;
        bool isHit = false;
        int lenght = 0;
        int direction = 1;
        int score = 0;
        while (!isEnd && col != 8)
        {
            if (direction == 1)
            {
                if (!UpNoHit(playGround, ref row, ref col, ref lenght))
                {
                    direction = 2;
                }
            }
            else
            {
                if (!DownNoHit(playGround, ref row, ref col, ref lenght))
                {
                    isEnd = true;
                }
            }
        }

        while (!isEnd && !isHit)
        {
            if (direction == 1)
            {
                if (UpHit(playGround, ref row, ref col, ref lenght, ref isHit, ref score))
                {
                    if (isHit)
                        break;
                    else
                        direction = 2;
                }
            }
            else
            {
                if (DownHit(playGround, ref row, ref col, ref lenght, ref isHit, ref score))
                {
                    if (isHit)
                        break;
                    else
                        isEnd = true;
                }
            }
        }
        return score;
    }

    private static bool UpNoHit(int[,] playGround, ref int row, ref int col, ref int lenght)
    {
        int location = 0;
        DeterminLocation(row, col, ref location);

        if (location == 4 || location == 5)
        {
            return false;
        }
        else
        {
            row--;
            col++;
            lenght++;
            return true;
        }

    }

    private static bool DownNoHit(int[,] playGround, ref int row, ref int col, ref int lenght)
    {
        int location = 0;
        DeterminLocation(row, col, ref location);
        if (location == 7)
            return false;
        else
        {
            row++;
            col++;
            lenght++;
            return true;
        }
    }
    private static bool UpHit(int[,] playGround, ref int row, ref int col, ref int lenght, ref bool isHit, ref int score)
    {
        int location = 0;
        DeterminLocation(row, col, ref location);
        if (playGround[row, col] == 1)
        {
            Hit(playGround, row, col, location, lenght, ref score);
            isHit = true;
            return true;
        }
        else
        {
            if (location == 4 || location == 5)
            {
                return true;
            }
            else
            {
                row--;
                col++;
                lenght++;
                return false;
            }
        }
    }
    private static bool DownHit(int[,] playGround, ref int row, ref int col, ref int lenght, ref bool isHit, ref int score)
    {
        int location = 0;
        DeterminLocation(row, col, ref location);
        if (playGround[row, col] == 1)
        {
            Hit(playGround, row, col, location, lenght, ref score);
            isHit = true;
            return true;
        }
        else
        {
            if (location == 7 || location == 6 || location == 2)
                return true;
            else
            {
                row++;
                col++;
                lenght++;
                return false;
            }
        }
    }

    private static void Hit(int[,] playGround, int row, int col, int location, int lenght, ref int score)
    {
        score++;
        playGround[row, col] = 0;
        if (location == 2)
        {
            if (playGround[row - 1, col] == 1)
            {
                playGround[row - 1, col] = 0;
                score++;
            }
            if (playGround[row, col - 1] == 1)
            {
                playGround[row, col - 1] = 0;
                score++;
            }
            if (playGround[row - 1, col - 1] == 1)
            {
                playGround[row - 1, col - 1] = 0;
                score++;
            }
        }
        else if (location == 5)
        {
            if (col == 8)
            {
                if (playGround[row + 1, col] == 1)
                {
                    playGround[row + 1, col] = 0;
                    score++;
                }
                if (playGround[row + 1, col + 1] == 1)
                {
                    playGround[row + 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
            }
            else
            {
                if (playGround[row, col - 1] == 1)
                {
                    playGround[row, col - 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col - 1] == 1)
                {
                    playGround[row + 1, col - 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col] == 1)
                {
                    playGround[row + 1, col] = 0;
                    score++;
                }
                if (playGround[row + 1, col + 1] == 1)
                {
                    playGround[row + 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
            }
        }
        else if (location == 6)
        {
            if (playGround[row - 1, col] == 1)
            {
                playGround[row - 1, col] = 0;
                score++;
            }
            if (playGround[row - 1, col - 1] == 1)
            {
                playGround[row - 1, col - 1] = 0;
                score++;
            }
            if (playGround[row, col - 1] == 1)
            {
                playGround[row, col - 1] = 0;
                score++;
            }
            if (playGround[row + 1, col - 1] == 1)
            {
                playGround[row + 1, col - 1] = 0;
                score++;
            }
            if (playGround[row + 1, col] == 1)
            {
                playGround[row + 1, col] = 0;
                score++;
            }
        }
        else if (location == 7)
        {
            if (col == 8)
            {
                if (playGround[row - 1, col] == 1)
                {
                    playGround[row - 1, col] = 0;
                    score++;
                }
                if (playGround[row - 1, col + 1] == 1)
                {
                    playGround[row - 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
            }
            else
            {
                if (playGround[row, col - 1] == 1)
                {
                    playGround[row, col - 1] = 0;
                    score++;
                }
                if (playGround[row - 1, col - 1] == 1)
                {
                    playGround[row - 1, col - 1] = 0;
                    score++;
                }
                if (playGround[row - 1, col] == 1)
                {
                    playGround[row - 1, col] = 0;
                    score++;
                }
                if (playGround[row - 1, col + 1] == 1)
                {
                    playGround[row - 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
            }
        }
        else
        {
            if (col == 8)
            {
                if (playGround[row - 1, col] == 1)
                {
                    playGround[row - 1, col] = 0;
                    score++;
                }
                if (playGround[row - 1, col + 1] == 1)
                {
                    playGround[row - 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col + 1] == 1)
                {
                    playGround[row + 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col] == 1)
                {
                    playGround[row + 1, col] = 0;
                    score++;
                }
            }
            else
            {
                if (playGround[row - 1, col - 1] == 1)
                {
                    playGround[row - 1, col - 1] = 0;
                    score++;
                }
                if (playGround[row - 1, col] == 1)
                {
                    playGround[row - 1, col] = 0;
                    score++;
                }
                if (playGround[row - 1, col + 1] == 1)
                {
                    playGround[row - 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row, col + 1] == 1)
                {
                    playGround[row, col + 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col + 1] == 1)
                {
                    playGround[row + 1, col + 1] = 0;
                    score++;
                }
                if (playGround[row + 1, col] == 1)
                {
                    playGround[row + 1, col] = 0;
                    score++;
                }
                if (playGround[row + 1, col - 1] == 1)
                {
                    playGround[row + 1, col - 1] = 0;
                    score++;
                }
                if (playGround[row, col - 1] == 1)
                {
                    playGround[row, col - 1] = 0;
                    score++;
                }
            }
        }
        score *= lenght;
    }
    private static void DeterminLocation(int row, int col, ref int location)
    {
        if (row == 0 && col == 0)
        {
            location = 4;
        }
        else if (row == 0 && col == 15)
        {
            location = 1;
        }
        else if (row == 7 && col == 0)
        {
            location = 3;
        }
        else if (row == 7 && col == 15)
        {
            location = 2;
        }
        else if (row == 0)
        {
            location = 5;
        }
        else if (row == 7)
        {
            location = 7;
        }
        else if (col == 0)
        {
            location = 8;
        }
        else if (col == 15)
        {
            location = 6;
        }
        else
        {
            location = 9;
        }

    }
    private static void Print(int[,] playGround)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 16; col++)
            {
                Console.Write(playGround[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

}
