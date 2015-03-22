using System;
using System.Threading;


class ApacheCombatGame
{
    public static int consoleWindowWidth = 120;
    public static int consoleWindowHeight = 46;
    static bool collisionExists = false;



    static void HandleCollision(Rock rock, Helicopter helicopter, out bool collision)
    {
        collision = false;

        if ((rock.StartX == helicopter.EndX && !(rock.EndY < helicopter.StartY || rock.StartY > helicopter.EndY))
            || ((rock.EndY == helicopter.StartY || rock.StartY == helicopter.EndY) && !(rock.EndX < helicopter.StartX || rock.StartX > helicopter.EndX)))
        {
            Console.Clear();
            Console.SetCursorPosition(consoleWindowWidth / 2 - 8, consoleWindowHeight / 2);
            collision = true;
            Console.Write("Crash!!!");
            Console.ReadLine();
        }
    }

    public static void PlayApacheCombat()
    {
        Console.Clear();

        string[,] rockElements = new string[,] { { " ", "P", " " }, { "P", " ", "P" } };

        Helicopter helicopter = new Helicopter();
        Helicopter.SetPosition(helicopter);
        Rock rock = new Rock(rockElements, consoleWindowWidth - 3, 13);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Helicopter.MoveUp(helicopter);
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Helicopter.MoveDown(helicopter);
                }
            }

            HandleCollision(rock, helicopter, out collisionExists);

            if (collisionExists == true)
            {
                break;
            }
            Helicopter.Draw(helicopter);
            Rock.Draw(rock);
            Rock.MoveLeft(rock);
            Thread.Sleep(100);
            Console.Clear();
        }
    }
}