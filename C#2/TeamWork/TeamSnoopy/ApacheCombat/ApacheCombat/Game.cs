using System;
using System.Collections.Generic;
using System.Threading;
using ApacheCombat;
using System.Numerics;

class Game
{
    public static void PlayApacheCombat()
    {
        Console.Clear();
        int lives = 3;
        int bombs = 1;
        BigInteger score = 0;
        int nukeCounter = 10;
        bool bombAway = false;
        int bombScoreCounter = 0;

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write(new string('*', StartScreen.consoleWindowWidth));
        Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
        Console.Write(new string('*', StartScreen.consoleWindowWidth));


        Helicopter helicopter = new Helicopter();

        helicopter.SetStartPosition(15, StartScreen.playgroundHeight / 2 - helicopter.Height / 2 - 2);

        List<Obstacle> obstacles = new List<Obstacle>();
        List<Shot> shots = new List<Shot>();

        Window.HelicopterInitialPrint(helicopter);

        int mainLoopCount = 0;
        int createRockInLoops = 200000;
        int createGroundTargetInLoops = 450000;
        int printMoveObstaclesInLoops = 9000;
        int printMoveShotsInLoops = 900;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    helicopter.MoveUp();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    helicopter.MoveDown();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    helicopter.MoveLeft();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    helicopter.MoveRight();
                    Collision.HelicopterObstacleColision(obstacles, helicopter, ref lives,ref score, bombs);
                    Window.PrintHelicopter(helicopter);
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    shots.Add(Helicopter.Shoot(helicopter));
                }

                else if (keyInfo.Key == ConsoleKey.Z)
                {
                    if (!bombAway)
                    {
                        if (bombs != 0)
                        {
                            bombAway = true;
                            bombs--;
                        }
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (Console.CursorTop == 2)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }

            if (mainLoopCount % createRockInLoops == 0)
            {
                obstacles.Add(ObstacleGenerator.CreateRock());
            }

            if (mainLoopCount % createGroundTargetInLoops == 0)
            {
                obstacles.Add(ObstacleGenerator.CreateGroundTaget());
            }

            if (mainLoopCount % printMoveShotsInLoops == 0)
            {
                for (int i = 0; i < shots.Count; i++)
                {
                    shots[i].MoveRight();
                    bool hit = false;
                    Collision.HandleShotObstacleCollisions(obstacles, shots[i], ref hit, lives, ref score, bombs);
                    if (hit)
                    {
                        shots.Remove(shots[i]);
                        i--;
                        if (bombScoreCounter >= 100)
                        {
                            if (bombs < 3)
                            {
                                bombs++;
                            }
                            bombScoreCounter = 0;
                        }
                        bombScoreCounter += 10;
                    }
                    else
                    {
                        Window.PrintShot(shots[i]);

                        if (shots[i].EndX >= StartScreen.consoleWindowWidth)
                        {
                            if (shots[i].EndX == 121)
                            {
                                Window.DeleteShot(shots[i]);
                            }
                            shots.Remove(shots[i]);
                            i--;
                        }
                    }
                }
            }


            if (mainLoopCount % printMoveObstaclesInLoops == 0)
            {
                for (int i = 0; i < obstacles.Count; i++)
                {
                    obstacles[i].MoveLeft();
                    bool hit = false;
                    Collision.HandleObstacleCollisionsWithShots(obstacles[i], shots, ref hit, lives, ref score, bombs);
                    Collision.ObstacleHelicopterColision(obstacles[i], helicopter, ref hit, ref lives,ref score, bombs);
                    if (hit)
                    {
                        obstacles.RemoveAt(i);
                        i--;
                        if (bombScoreCounter >= 100)
                        {
                            if (bombs < 3)
                            {
                                bombs++;
                            }
                            bombScoreCounter = 0;
                        }
                        bombScoreCounter += 10;
                    }
                    else
                    {
                        Window.PrintObstacle(obstacles[i]);

                        //checks if obstacle has exit the console and if so removes it from the obstacles list.  
                        if (obstacles[i].EndX < 0)
                        {
                            obstacles.Remove(obstacles[i]);
                        }
                    }
                }
            }

            if (bombAway)
            {
                if (nukeCounter == 0)
                {
                    bombAway = false;
                    nukeCounter = 10;
                    Collision.NucklearBombExplosion(obstacles, ref score);
                    Window.NuklearBOMB(helicopter);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.Write(new string('*', StartScreen.consoleWindowWidth));
                    Window.UpdateScoreAndLives(lives, bombs, score, false, 0);
                    Console.Write(new string('*', StartScreen.consoleWindowWidth));
                }
                else
                {
                    if (Window.nukeSlowDownABit == 20000)
                    {
                        nukeCounter--;
                        Window.UpdateScoreAndLives(lives, bombs, score, true, nukeCounter);
                        Window.nukeSlowDownABit = 0;
                    }
                    else
                    {
                        Window.nukeSlowDownABit++;
                    }
                }
            }
            mainLoopCount = (mainLoopCount + 1) % int.MaxValue;
        }
    }
}