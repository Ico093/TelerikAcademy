using System;
using System.Collections.Generic;

class JoroTheRabbit
{
    static void Main()
    {
        string[]  numbers= Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] route=new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
			{
                route[i] = int.Parse(numbers[i]);
			}

        List<int> usedNumbers = new List<int>();
        List<int> teqUsedNumbers = new List<int>();
        int maxLength = 1;
        int whichNumber = 0;
        int position = whichNumber+1;
        int teqPosition = position;
        int passedPosition;

        while (whichNumber != route.Length)
        {
            while (route[position] <= route[whichNumber]&&position!=whichNumber)
            {
                position=(position+1)%route.Length;
            }

            if (position == whichNumber)
            {
                whichNumber++;
                if (whichNumber == route.Length)
                {
                    break;
                }
                else
                {
                    position = (whichNumber + 1) % route.Length;
                    continue;
                }
            }

            int step;
            if (position < whichNumber)
            {
                step = route.Length - whichNumber + position;
            }
            else
            {
                step = position - whichNumber;
            }
            teqUsedNumbers.Add(route[whichNumber]);
            teqPosition = position;
            passedPosition=whichNumber;
            while (route[teqPosition] > route[passedPosition]&&!teqUsedNumbers.Contains(route[teqPosition]))
            {
                teqUsedNumbers.Add(route[teqPosition]);
                passedPosition = teqPosition;
                teqPosition = (teqPosition + step) % route.Length;
            }


            if (maxLength < teqUsedNumbers.Count)
            {
                maxLength = teqUsedNumbers.Count;
            }

            position = (position + 1) % route.Length;
            teqUsedNumbers.Clear();
        }

        Console.WriteLine(maxLength);
    }
}