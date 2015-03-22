using System;

class Cards
{
    static void Main()
    {
        for (int i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("Clubs \"♣\"");
                    break;
                case 2:
                    Console.WriteLine("Diamonds \"♦\"");
                    break;
                case 3:
                    Console.WriteLine("Hearts \"♥\"");
                    break;
                case 4:
                    Console.WriteLine("Spades \"♠\"");
                    break;
            }

            for (int j = 2; j <= 14; j++)
            {
                switch (j)
                {
                    case 2:
                        Console.Write("Two of ");
                        break;
                    case 3:
                        Console.Write("Three of ");
                        break;
                    case 4:
                        Console.Write("Four of ");
                        break;
                    case 5:
                        Console.Write("Five of ");
                        break;
                    case 6:
                        Console.Write("Six of ");
                        break;
                    case 7:
                        Console.Write("Seven of ");
                        break;
                    case 8:
                        Console.Write("Eight of ");
                        break;
                    case 9:
                        Console.Write("Nine of ");
                        break;
                    case 10:
                        Console.Write("Ten of ");
                        break;
                    case 11:
                        Console.Write("Jack of ");
                        break;
                    case 12:
                        Console.Write("Queen of ");
                        break;
                    case 13:
                        Console.Write("King of ");
                        break;
                    case 14:
                        Console.Write("Ace of ");
                        break;
                }
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Spades");
                        break;
                    case 2:
                        Console.WriteLine("Diamonds");
                        break;
                    case 3:
                        Console.WriteLine("Hearts");
                        break;
                    case 4:
                        Console.WriteLine("Clubs");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}

