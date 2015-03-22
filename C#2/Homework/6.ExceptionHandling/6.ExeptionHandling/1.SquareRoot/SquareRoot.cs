using System;

class SquareRoot
{
    static void Main()
    {
        double number;

        try
        {
            number = double.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number should be positive!");
            }
            else
            {
                Console.WriteLine("The sqrt of {0} is {1}.", number, Math.Sqrt(number));
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }

        catch (OverflowException)
        {
            Console.WriteLine("Invalid number! The number is too long.");
        }

        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Invalid number!\n" + ex.ParamName);
        }

        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}
