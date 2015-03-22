using System;
using System.Collections.Generic;

class ThreeInOne
{
    static void Main()
    {
        string[] numbersStr = Console.ReadLine().Split(',');
        int maxScoreWiner = 0;
        int winners = 0;
        int index = -1;
        for (int i = 0; i < numbersStr.Length; i++)
        {
            int number = int.Parse(numbersStr[i]);
            if (number <= 21)
            {
                if (maxScoreWiner <= number)
                {
                    if (maxScoreWiner < number)
                    {
                        maxScoreWiner = number;
                        index = i;
                        winners = 1;
                    }
                    else
                    {
                        winners++;
                    }
                }
            }
        }

        if (winners == 1)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine(-1);
        }

        //-------------------------------------------------

        string[] bitesStr = Console.ReadLine().Split(',');
        int[] bites = new int[bitesStr.Length];
        for (int i = 0; i < bitesStr.Length; i++)
        {
            bites[i] = int.Parse(bitesStr[i]);
        }

        Array.Sort(bites, (a, b) => b.CompareTo(a));
        int myBites = 0;
        int friends = int.Parse(Console.ReadLine());
        for (int i = 0; i < bites.Length; i += friends + 1)
        {
            myBites += bites[i];
        }

        Console.WriteLine(myBites);

        //--------------------------------------------------

        string[] coins = Console.ReadLine().Split(' ');
        int[] coins1 = new int[] { int.Parse(coins[0]), int.Parse(coins[1]), int.Parse(coins[2]) };
        int[] coins2 = new int[] { int.Parse(coins[3]), int.Parse(coins[4]), int.Parse(coins[5]) };
        bool noMoney = false;

        int restGold = 0, restSilver = 0, restBronze = 0;
        int operations = 0;

        if (coins1[0] >= coins2[0])
        {
            restGold = coins1[0] - coins2[0];
        }
        else
        {
            while (coins1[0] < coins2[0] && !noMoney)
            {
                if (coins1[1] - 11 >= coins2[1])
                {
                    coins1[0]++;
                    coins1[1] -= 11;
                    operations++;
                }
                else
                {
                    if (coins1[2] - 11 >= coins2[2])
                    {
                        coins1[1]++;
                        coins1[2] -= 11;
                        operations++;
                    }
                    else
                    {
                        noMoney = true;
                    }
                }
            }
        }

        if (coins1[1] >= coins2[1])
        {
            restSilver = coins1[1] - coins2[1];
        }
        else
        {
            while (coins1[1] < coins2[1] && !noMoney)
            {
                if (restGold > 0)
                {
                    restGold--;
                    coins1[1] += 9;
                    operations++;
                }
                else
                {
                    if (coins1[2] - 11 >= coins2[2])
                    {
                        coins1[1]++;
                        coins1[2] -= 11;
                        operations++;
                    }
                    else
                    {
                        noMoney = true;
                    }
                }
            }
        }

        while (coins1[2] < coins2[2])
        {
            if (restSilver > 0)
            {
                restSilver--;
                coins1[2] += 9;
                operations++;
            }
            else if (restGold > 0)
            {
                restSilver += 9;
                operations++;
            }
            else
            {
                noMoney = true;
            }
        }

        if (noMoney == true)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(operations);
        }
    }
}