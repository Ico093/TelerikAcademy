using System;

class InitializeBy5
{
    static void Main()
    {
        int[] numbers = new int[20];
        for (int i = 0; i < 20; i++)
        {
            numbers[i] = i * 5;
            Console.WriteLine("Number {0,-2}: {1,3}\n",i,numbers[i]);
        }
    }
}

