using System;
using System.Collections.Generic;

class Index
{
    static void Main()
    {
        int[] numbers;
        List<int> more = new List<int>();
        int number;
        Console.WriteLine("Enter numbers.If you enter something else than an integer the method will start!");
        Console.Write("I'm waiting:");
        while (int.TryParse(Console.ReadLine(), out number))
        {
            more.Add(number);
            Console.Write("And I wait again:");
        }

        int index;
        Console.Write("\nOk. Now enter the index we are going to look for:");
        while (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.Write("Cmooon:");
        }

        numbers = more.ToArray();
        bool isValid=true;
        if(IsBiggerAtIndex(numbers,index,ref isValid))
        {
            Console.WriteLine("Yes. The number is bigger than it's neighbors!");
        }
        else
        {
            if(isValid)
            Console.WriteLine("Nope.It is smaller tha it's neighbors!");
        }
    }

    static bool IsBiggerAtIndex(int[] arr, int index,ref bool isValid)
    {
        if (index < 1 || index >= arr.Length-1)
        {
            Console.WriteLine("Can't comapare with the index you gave me!");
            isValid=false;
            return false;
        }
        
        if (arr[index - 1] < arr[index] && arr[index] > arr[index + 1])
            return true;
        
        else
            return false;
    }
}

