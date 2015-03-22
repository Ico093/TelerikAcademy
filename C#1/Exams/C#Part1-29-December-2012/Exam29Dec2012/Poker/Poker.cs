using System;

class Poker
{
    static void Main()
    {
        int[,] Card = new int[5, 2];
        int differentCards = 0;
        for (int i = 0; i < 5; i++)
        {
            int number=0;
            string input = Console.ReadLine();
            switch (input)
            {
                case "2":
                    number = 2;
                    break;
                case "3":
                    number = 3;
                    break;
                case "4":
                    number = 4;
                    break;
                case "5":
                    number = 5;
                    break;
                case "6":
                    number = 6;
                    break;
                case "7":
                    number = 7;
                    break;
                case "8":
                    number = 8;
                    break;
                case "9":
                    number = 9;
                    break;
                case "10":
                    number = 10;
                    break;
                case "J":
                    number = 11;
                    break;
                case "D":
                    number = 12;
                    break;
                case "K":
                    number = 13;
                    break;
                case "A":
                    number = 14;
                    break;
                default:
                    break;
            }

            bool isIn = false;
            for (int different = 0; different < differentCards; different++)
            {
                if (Card[different, 0] == number)
                {
                    isIn = true;
                    Card[different, 1]++;
                    different = differentCards;
                }
            }
            if (!isIn)
            {
                Card[differentCards, 0] = number;
                Card[differentCards, 1] = 1;
                differentCards++;
            }
        }


        if (differentCards == 1)
            Console.WriteLine("Impossible");
        else if (differentCards == 2)
        {
            if (Card[0, 1] == 4 || Card[1, 1] == 4)
                Console.WriteLine("Four of a Kind");
            else
                Console.WriteLine("Full House");
        }
        else if (differentCards == 3)
        {
            if (Card[0, 1] == 3 || Card[1, 1] == 3 || Card[2, 1] == 3)
            {
                Console.WriteLine("Three of a Kind");
            }
            else
            {
                Console.WriteLine("Two Pairs");
            }
        }
        else if (differentCards == 4)
            Console.WriteLine("One Pair");
        else
        {
            int[] newCard = new int[5];
            for (int i = 0; i < 5; i++)
            {
                newCard[i] = Card[i, 0];
            }

            Array.Sort(newCard);
            if (newCard[4] == 14 && newCard[0] == 2 && newCard[1] == 3 && newCard[2] == 4 && newCard[3] == 5)
            {
                Console.WriteLine("Straight");
            }
            else
            {
                bool isIn = false;
                for (int i = 0; i < 4; i++)
                {
                    if (newCard[i] + 1 != newCard[i + 1])
                    {
                        Console.WriteLine("Nothing");
                        isIn = true;
                        break;
                    }
                }
                if (!isIn)
                    Console.WriteLine("Straight");
            }
        }
    }
}

