using System;
using System.Text;

class AddFromString
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        numbers=numbers.Trim(' ');
        long sum=0;

        while (numbers.IndexOf(' ') != -1)
        {
            sum += long.Parse(numbers.Substring(0, numbers.IndexOf(' ')));
            numbers = numbers.Substring(numbers.IndexOf(' ') + 1);
            numbers = numbers.TrimStart(' ');
        }
        sum += long.Parse(numbers);
        Console.WriteLine("\nThe sum is: {0}",sum);
    }
}
