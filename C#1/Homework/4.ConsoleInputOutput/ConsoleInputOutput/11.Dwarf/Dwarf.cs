using System;
using System.Threading;

namespace System.Windows.Forms
{
    class Dwarf
    {
        static void Main()
        {
            Console.WindowHeight = 9;
            Console.WindowWidth = 23;
            //Declaring variables
            char[,] gameTable = new char[9, 23];
            int xDwarf = 12, yDwarf = 8;
            bool isHit = false;
            int inFunction = 0;
            char[] rocks = new char[12] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
            int score=0;
            //Initializing Game Table
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    gameTable[i, j] = ' ';
                }
            }
          
            gameTable[yDwarf, xDwarf - 1] = '(';
            gameTable[yDwarf, xDwarf] = '0';
            gameTable[yDwarf, xDwarf + 1] = ')';
            //Printing to start the game
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    Console.Write(gameTable[i, j]);
                }
                Console.WriteLine();
            }

            while (!isHit)
            {
                if (System.Console.KeyAvailable)
                {
                    var ch = System.Console.ReadKey(true);
                    if (ch.Key == ConsoleKey.LeftArrow)
                    {
                        if (xDwarf - 2 >= 0)
                        {
                            if (gameTable[yDwarf, xDwarf] != '0' || gameTable[yDwarf, xDwarf - 1] != '(' || gameTable[yDwarf, xDwarf + 1] != ')')
                            {
                                isHit = true;
                            }
                            else
                            {
                                if (gameTable[yDwarf, xDwarf - 2] != ' ')
                                    isHit = true;

                                gameTable[yDwarf, xDwarf + 1] = ' ';
                                gameTable[yDwarf, xDwarf] = ')';
                                xDwarf--;
                                gameTable[yDwarf, xDwarf] = '0';
                                gameTable[yDwarf, xDwarf - 1] = '(';
                                Console.SetCursorPosition(0, Console.CursorTop-1);
                                for(int i=0;i<23;i++)
                                    Console.Write(gameTable[8,i]);
                                Console.WriteLine();
                            }
                        }
                    }
                    if (ch.Key == ConsoleKey.RightArrow)
                    {
                        if (xDwarf + 2 <= 22)
                        {
                            if (gameTable[yDwarf, xDwarf] != '0' || gameTable[yDwarf, xDwarf - 1] != '(' || gameTable[yDwarf, xDwarf + 1] != ')')
                            {
                                isHit = true;
                            }
                            else
                            {
                                if (gameTable[yDwarf, xDwarf + 2] != ' ')
                                    isHit = true;
                                                                
                                    gameTable[yDwarf, xDwarf - 1] = ' ';
                                    gameTable[yDwarf, xDwarf] = '(';
                                    xDwarf++;
                                    gameTable[yDwarf, xDwarf] = '0';
                                    gameTable[yDwarf, xDwarf + 1] = ')';
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    for (int i = 0; i < 23; i++)
                                        Console.Write(gameTable[8, i]);
                                    Console.WriteLine();
                                
                            }
                        }
                    }
                }
                //Calling the function so you can move a little before the next row of rocks starts falling
                if (inFunction == 10)
                {
                    getDown(ref gameTable, rocks, xDwarf, yDwarf,ref isHit);
                    score += 10;
                    inFunction = 0;
                }
                inFunction++;
                Thread.Sleep(50);

            }
            Console.Clear();
            Console.WriteLine("Game Over!\nYour score is {0}",score);
        }

        public static void getDown(ref char[,] table, char[] rock, int x, int y,ref bool hit)
        {
            Random rnd=new Random();
            for (int i = 0; i < 23; i++)
            {
                if (i == x - 1)
                {
                    if (table[7, i] != ' ' || table[7, i + 1] != ' ' || table[7, i + 2] != ' ')
                    {
                        hit = true;
                        i = 23;
                    }
                    else
                    {
                        i += 2;
                    }

                }
                else
                    table[8, i] = table[7, i];
            }
            if (!hit)
            {
                for (int i = 7; i > 0; i--)
                    for (int j = 0; j < 23; j++)
                        table[i, j] = table[i - 1, j];
                for (int i = 0; i < 23; i++)
                {
                    int random = rnd.Next(0, 21);
                    if (random > 18)
                    {
                        double p = rnd.NextDouble();
                        table[0, i] = rock[(int)(11 * p)];
                    }
                    else
                        table[0, i] = ' ';
                }
            }

            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}

