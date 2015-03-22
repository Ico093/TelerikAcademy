using System;

class SubsetEqualToZero
{
    static void Main()
    {
        int[] numbers = new int[5];
        Console.Write("Enter the first number: ");
        while (!int.TryParse(Console.ReadLine(), out numbers[0]))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the first number: ");
        }
        Console.Write("Enter the secound number: ");
        while (!int.TryParse(Console.ReadLine(), out numbers[1]))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the secound number: ");
        }
        Console.Write("Enter the third number: ");
        while (!int.TryParse(Console.ReadLine(), out numbers[2]))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the third number: ");
        }
        Console.Write("Enter the fourth number: ");
        while (!int.TryParse(Console.ReadLine(), out numbers[3]))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the fourth number: ");
        }
        Console.Write("Enter the fifth number: ");
        while (!int.TryParse(Console.ReadLine(), out numbers[4]))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the fifth number: ");
        }

        int maxSubsets = (int)Math.Pow(2, 5) - 1;
        int sum=0;
        string output="";

        for (int i = 1; i < maxSubsets; i++)
        {
            sum = 0;
            output="";
            for (int j = 0; j < 5; j++)
            {
                int mask = 1 << j;
                sum += numbers[j] * ((i & mask) >> j);
                if(((i & mask)>>j)!=0)
                {
                    if(output==""||numbers[j]<0)
                    {
                        output+=numbers[j].ToString();
                    }
                    else
                    {
                        output+="+"+numbers[j].ToString();
                    }
                }
            }
            if (sum == 0)
                Console.WriteLine("The subset {0}=0", output);
        }
    }
}
