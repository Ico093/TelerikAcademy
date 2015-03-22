using System;
using System.Threading;

class CharArray
{
    static void Main()
    {
        int N = 0;
        while (N < 1)
        {
            Console.Clear();
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number N (N>=1): ");
            }
        }

        char[] array1 = new char[N];
        string arr1;
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array1[{0}]:", i);
            arr1 = Console.ReadLine();
            if(arr1.Length>1)
                Console.WriteLine("I'll take only the first char!");
            array1[i] =arr1[0];
        }
        Console.WriteLine();

        char[] array2 = new char[N];
        string arr2;
        bool equal = true;

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array2[{0}]:", i);
            arr2 = Console.ReadLine();
            if(arr2.Length>1)
                Console.WriteLine("I'll take only the first char!\n");
            array2[i] = arr2[0];
            if (array1[i] != array2[i])
                equal = false;
        }

        Console.WriteLine("Array1:");
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("No:{0} - {1}",i,array1[i]);
        }
        Console.WriteLine("\nArray2:");
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("No:{0} - {1}", i, array2[i]);
        }
        if (equal)
            Console.WriteLine("\nArrays are equal!");
        else
            Console.WriteLine("\nArrays arn't equal!");
    }
}
