using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
class BullsAndCows
{
    static void Main()
    {
        string number = Console.ReadLine();
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
 
        bool Solution = false;
 
        for (int candidate = 1111; candidate <= 9999; candidate++)
        {
            int bulls = 0;
            int cows = 0;
            char[] newNumber = candidate.ToString().ToCharArray();
            if (newNumber[0] >= '1' && newNumber[1] >= '1' && newNumber[2] >= '1' && newNumber[3] >= '1')
            {
                char[] theNumber = number.ToCharArray();
                for (int j = 0; j < 4; j++)
                {
                    if (theNumber[j] == newNumber[j])
                    {
                        bulls++;
                        theNumber[j] = '*';
                        newNumber[j] = '&';
                    }
                }
 
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (theNumber[j] == newNumber[k])
                        {
                            cows++;
                            theNumber[j] = '*';
                            newNumber[k] = '&';
                        }
                    }
                }
                if (b == bulls && c == cows)
                {
                    if (Solution)
                    {
                        Console.Write(" " + candidate);
                    }
                    else
                    {
                        Console.Write(candidate);
                        Solution = true;
                    }
                }
            }
        }
 
        if (!Solution)
        {
            Console.WriteLine("No");
        }
    }
}