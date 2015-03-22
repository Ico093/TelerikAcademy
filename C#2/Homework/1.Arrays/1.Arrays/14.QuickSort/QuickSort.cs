using System;
using System.Threading;
using System.Collections.Generic;

class QuickSort
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

        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            while (!(int.TryParse(Console.ReadLine(), out array[i])))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter array[{0}]: ", i);
            }
        }

        List<int> unorderdSequence=new List<int>(array);

        List<int> orderedSequence = new List<int>(orderThem(unorderdSequence));
       
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(orderedSequence[i]);
        }
    }

    static List<int> orderThem(List<int> unordered)
{
        List<int> minUnorderd=new List<int>();
        List<int> maxUnorderd=new List<int>();

        if (unordered.Count <= 1)
            return unordered;

        int middlepos = unordered.Count / 2;
        int middle=unordered[middlepos];
        

        for (int i = 0; i <middlepos; i++)
        {
            if (unordered[i] <= middle)
                minUnorderd.Add(unordered[i]);
            else
                maxUnorderd.Add(unordered[i]);
        }

        for (int i = middlepos+1; i < unordered.Count; i++)
        {
            if (unordered[i] <= middle)
                minUnorderd.Add(unordered[i]);
            else
                maxUnorderd.Add(unordered[i]);
        }
        return conctenate(orderThem(minUnorderd),middle, orderThem(maxUnorderd));
}
    static List<int> conctenate(List<int> a,int middle, List<int> b)
    {
        List<int> con = new List<int>();
        for (int i = 0; i < a.Count; i++)
        {
            con.Add(a[i]);
        }
        con.Add(middle);
        for (int i = 0; i < b.Count; i++)
        {
            con.Add(b[i]);
        }
        return con;
    }
}

