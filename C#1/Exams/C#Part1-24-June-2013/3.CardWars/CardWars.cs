using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());

        string[] player1Cards = new string[3];
        BigInteger player1Score = 0;
        int player1ChangingScore = 0;
        int player1Wins = 0;
        bool player1Stop = false;

        string[] player2Cards = new string[3];
        BigInteger player2Score = 0;
        int player2ChangingScore = 0;
        int player2Wins = 0;
        bool player2Stop = false;

        for (int i = 0; i < N; i++)
        {
            if (!player1Stop ^ player2Stop)
            {
                for (int j = 0; j < 3; j++)
                {
                    player1Cards[j] = Console.ReadLine();
                }
                for (int j = 0; j < 3; j++)
                {
                    player2Cards[j] = Console.ReadLine();
                }
                HowManyPoints(player1Cards, ref player1ChangingScore, ref player1Score, ref player1Stop);
                HowManyPoints(player2Cards, ref player2ChangingScore, ref player2Score, ref player2Stop);

                if (!player1Stop ^ player2Stop)
                {
                    if (player1Stop)
                    {
                        player1Score += 50;
                        player2Score += 50;


                        player1Stop = false;
                        player2Stop = false;
                    }

                    if (player1ChangingScore > player2ChangingScore)
                    {
                        player1Score += player1ChangingScore;
                        player1Wins++;
                    }
                    else if (player1ChangingScore < player2ChangingScore)
                    {
                        player2Score += player2ChangingScore;
                        player2Wins++;
                    }
                    player1ChangingScore = 0;
                    player2ChangingScore = 0;

                }
            }
            else
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.ReadLine();
                }
            }
        }

        if (player1Stop)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if (player2Stop)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if (player1Score > player2Score)
        {
            Console.WriteLine("First player wins!\nScore: {0}\nGames won: {1}", player1Score, player1Wins);
        }
        else if (player1Score < player2Score)
        {
            Console.WriteLine("Second player wins!\nScore: {0}\nGames won: {1}", player2Score, player2Wins);
        }
        else
        {
            Console.WriteLine("It's a tie!\nScore: {0}", player1Score);
        }
    }

    static void HowManyPoints(string[] cards, ref int score, ref BigInteger playerScore, ref bool Stop)
    {
        for (int i = 0; i < 3; i++)
        {
            switch (cards[i])
            {
                case "2":
                    score += 10;
                    break;
                case "3":
                    score += 9;
                    break;
                case "4":
                    score += 8;
                    break;
                case "5":
                    score += 7;
                    break;
                case "6":
                    score += 6;
                    break;
                case "7":
                    score += 5;
                    break;
                case "8":
                    score += 4;
                    break;
                case "9":
                    score += 3;
                    break;
                case "10":
                    score += 2;
                    break;
                case "A":
                    score += 1;
                    break;
                case "J":
                    score += 11;
                    break;
                case "Q":
                    score += 12;
                    break;
                case "K":
                    score += 13;
                    break;
                case "Z":
                    {
                        playerScore *= 2;
                    }
                    break;
                case "Y":
                    {
                        playerScore -= 200;
                    }
                    break;
                case "X":
                    {
                        Stop = true;
                    }
                    break;
            }
        }
    }
}

