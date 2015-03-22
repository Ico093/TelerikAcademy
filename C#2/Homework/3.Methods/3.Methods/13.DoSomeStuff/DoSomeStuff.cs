using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;



class DoSomeStuff
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Enter 1 to reverse the digits of a number.");
        Console.WriteLine("Enter 2 to calculate the average of a sequence of integers");
        Console.WriteLine("Enter 3 to solve a linear equation a * x + b = 0");

        int choise = 0;
        Console.Write("\nEnter your choise: ");
        while (choise < 1 || choise > 3)
        {
            while (!int.TryParse(Console.ReadLine(), out choise))
            {
                Console.WriteLine("I don't recognise this choise...");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Enter 1 to reverse the digits of a number.");
                Console.WriteLine("Enter 2 to calculate the average of a sequence of integers");
                Console.WriteLine("Enter 3 to solve a linear equation a * x + b = 0");
                Console.Write("\nEnter your choise: ");
            }
            if (choise < 1 || choise > 3)
            {
                Console.WriteLine("I don't recognise this choise!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Enter 1 to reverse the digits of a number.");
                Console.WriteLine("Enter 2 to calculate the average of a sequence of integers");
                Console.WriteLine("Enter 3 to solve a linear equation a * x + b = 0");
                Console.Write("\nEnter your choise: ");
            }
        }

        switch (choise)
        {
            case 1:
                {
                    Console.Write("\n\nEnter an integer number: ");
                    int number;
                    while (!int.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Not a valid integer number!");
                        Console.Write("\nEnter an integer number: ");
                    }
                    Console.WriteLine("The reversed number is {0}!", Reverse(number));
                }
                break;
            case 2:
                {
                    List<double> sequence = new List<double>();
                    Console.WriteLine("\n\nEnter numbers.When you enter something else the method will start!");
                    double number = 0;
                    Console.Write("\nEnter a number: ");
                    while (double.TryParse(Console.ReadLine(), out number))
                    {
                        sequence.Add(number);
                        Console.Write("Enter a number: ");
                    }
                    if (sequence.Count != 0)
                    {
                        double[] newSequence = sequence.ToArray();

                        Console.WriteLine("\n\nThe average of the sequence is {0}!", AverageOfSequence(newSequence));
                    }
                    else
                    Console.WriteLine("There is nothing in the array!");
                }
                break;
            case 3:
                {
                    Console.WriteLine("\n\nEnter coeficents of equation ax+b=0");
                    Console.Write("Enter a: ");
                    double a=0;
                    while (a == 0)
                    {
                        while (!double.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Not a correct double!");
                            Console.Write("Enter a: ");
                        }
                        if (a == 0)
                        {
                            Console.WriteLine("a shouldn't be equal to 0!");
                            Console.Write("Enter a: ");
                        }
                    }
                    Console.Write("\nEnter b: ");
                    double b;
                    while (!double.TryParse(Console.ReadLine(), out b))
                    {
                        Console.WriteLine("Not a correct double!");
                        Console.Write("Enter b: ");
                    }

                    Console.WriteLine("\nThe solution of the equation is x={0}",SolveEquation(a,b));
                }
                break;
        }
    }

    static int Reverse(int number)
    {

        string theNumber = number.ToString();
        char[] newNumber = theNumber.ToCharArray();
        Array.Reverse(newNumber);
        string theNewNumber = "";
        if (newNumber[theNumber.Length - 1] == '-')
        {
            theNewNumber = "-" + string.Concat(newNumber);
            theNewNumber = theNewNumber.Remove(theNumber.Length);
        }
        else
        {
            theNewNumber = string.Concat(newNumber);
        }
        number = Convert.ToInt32(theNewNumber);
        return number;
    }

    static double AverageOfSequence(double[] sequence)
    {
        double average=0;
        foreach (var number in sequence)
        {
            average += number;
        }
        return average / sequence.Length;
    }

    static double SolveEquation(double a, double b)
    {
        return (-b) / a;
    }
}

