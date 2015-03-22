using System;

class EnterNumbresInRange
{
    static void Main()
    {
        int start = int.MinValue;
        int end = int.MaxValue;

        Console.WriteLine("Enter range (start,end):");

        while (true)
        {
            try
            {
                Console.Write("Enter start: ");
                start = int.Parse(Console.ReadLine());
                break;

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numbers too long!");
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Enter end: ");
                end = int.Parse(Console.ReadLine());
                break;
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numbers too long!");
            }
        }

        int number;

        for (int i = 0; i < 10; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter number No:{0}:", i + 1);
                    number = ReadNumber(start, end);
                    start = number;
                    break;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Numbers too long!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error!" + ex.ParamName);
                }
            }
        }
    }

    static int ReadNumber(int start, int end)
    {
        if (start > end)
        {
            throw new ArgumentException("The end of the range can't be bigger that the start!");
        }
        int number = int.Parse(Console.ReadLine());
        while (number <= start || number >= end)
        {
            Console.WriteLine("Number must be between {0} and {1}!", start, end);
            Console.Write("Enter again:");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }
}