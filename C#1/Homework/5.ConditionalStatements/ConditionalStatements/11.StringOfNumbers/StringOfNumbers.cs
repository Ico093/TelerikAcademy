using System;

class StringOfNumbers
{
    static void Main()
    {
        bool hundrets = false;
        bool tens = false;
        bool one=false;
        Console.Write("Write a number: ");
        string number = Console.ReadLine();
        
        for(int i=0;i<number.Length;i++)
        {
            if(number[i]<'0'||number[i]>'9')
            {
                Console.WriteLine("Not an integer number!");
                return;
            }
        }
        if (number.Length > 3)
        {
            Console.WriteLine("Too long!");
            return;
        }

        Console.SetCursorPosition(number.Length + 17, 0);
        Console.Write("-> ");

        int num=Convert.ToInt32(number);

        if (num == 0)
            Console.Write("Zero");
        else
        {
            switch (num / 100)
            {
                default:
                    break;
                case 1:
                    Console.Write("One hundred");
                    hundrets = true;
                    break;
                case 2:
                    Console.Write("Two hundred");
                    hundrets = true;
                    break;
                case 3:
                    Console.Write("Three hundred");
                    hundrets = true;
                    break;
                case 4:
                    Console.Write("Four hundred");
                    hundrets = true;
                    break;
                case 5:
                    Console.Write("Five hundred");
                    hundrets = true;
                    break;
                case 6:
                    Console.Write("Six hundred");
                    hundrets = true;
                    break;
                case 7:
                    Console.Write("Seven hundred");
                    hundrets = true;
                    break;
                case 8:
                    Console.Write("Eight hundred");
                    hundrets = true;
                    break;
                case 9:
                    Console.Write("Nine hundred");
                    hundrets = true;
                    break;
            }

            switch (num / 10 % 10)
            {
                default:
                    break;
                case 1:
                    tens = true;
                    one = true;
                    break;
                case 2:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Twenty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and twenty");
                    else
                        Console.Write(" twenty");
                    break;
                case 3:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Thirty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and thirty");
                    else
                        Console.Write(" thirty");
                    break;
                case 4:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Fourty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and fourty");
                    else
                        Console.Write(" fourty");
                    break;
                case 5:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Fifty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and fifty");
                    else
                        Console.Write(" fifty");
                    break;
                case 6:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Sixty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and sixty");
                    else
                        Console.Write(" sixty");
                    break;
                case 7:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Seventy");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and seventy");
                    else
                        Console.Write(" seventy");
                    break;
                case 8:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Eighty");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and eighty");
                    else
                        Console.Write(" eighty");
                    break;
                case 9:
                    tens = true;
                    if (!hundrets)
                        Console.Write("Ninety");
                    else if (hundrets && num % 10 == 0)
                        Console.Write(" and ninety");
                    else
                        Console.Write(" ninety");
                    break;
            }

            switch (num % 10)
            {
                default:
                    break;
                case 0:
                    if (hundrets && tens && one)
                        Console.Write(" and ten");
                    break;
                case 1:
                    if (hundrets && tens && one)
                        Console.Write(" and eleven");
                    else if (hundrets && !tens)
                        Console.Write(" and one");
                    else if (!hundrets && tens && one)
                        Console.Write("Eleven");
                    else if (tens && !one)
                        Console.Write(" one");
                    else
                        Console.Write("One");
                    break;
                case 2:
                    if (hundrets && tens && one)
                        Console.Write(" and twelve");
                    else if (hundrets && !tens)
                        Console.Write(" and two");
                    else if (!hundrets && tens && one)
                        Console.Write("Twelve");
                    else if (tens && !one)
                        Console.Write(" two");
                    else
                        Console.Write("Two");
                    break;
                case 3:
                    if (hundrets && tens && one)
                        Console.Write(" and thirteen");
                    else if (hundrets && !tens)
                        Console.Write(" and three");
                    else if (!hundrets && tens && one)
                        Console.Write("Thirteen");
                    else if (tens && !one)
                        Console.Write(" three");
                    else
                        Console.Write("Three");
                    break;
                case 4:
                    if (hundrets && tens && one)
                        Console.Write(" and fourteen");
                    else if (hundrets && !tens)
                        Console.Write(" and four");
                    else if (!hundrets && tens && one)
                        Console.Write("Fourteen");
                    else if (tens && !one)
                        Console.Write(" four");
                    else
                        Console.Write("Four");
                    break;
                case 5:
                    if (hundrets && tens && one)
                        Console.Write(" and fifteen");
                    else if (hundrets && !tens)
                        Console.Write(" and five");
                    else if (!hundrets && tens && one)
                        Console.Write("Fifteen");
                    else if (tens && !one)
                        Console.Write(" five");
                    else
                        Console.Write("Five");
                    break;
                case 6:
                    if (hundrets && tens && one)
                        Console.Write(" and sixteen");
                    else if (hundrets && !tens)
                        Console.Write(" and six");
                    else if (!hundrets && tens && one)
                        Console.Write("Sixteen");
                    else if (tens && !one)
                        Console.Write(" six");
                    else
                        Console.Write("Six");
                    break;
                case 7:
                    if (hundrets && tens && one)
                        Console.Write(" and seventeen");
                    else if (hundrets && !tens)
                        Console.Write(" and seven");
                    else if (!hundrets && tens && one)
                        Console.Write("Seventeen");
                    else if (tens && !one)
                        Console.Write(" seven");
                    else
                        Console.Write("Seven");
                    break;
                case 8:
                    if (hundrets && tens && one)
                        Console.Write(" and eighteen");
                    else if (hundrets && !tens)
                        Console.Write(" and eight");
                    else if (!hundrets && tens && one)
                        Console.Write("Eighteen");
                    else if (tens && !one)
                        Console.Write(" eight");
                    else
                        Console.Write("Eight");
                    break;
                case 9:
                    if (hundrets && tens && one)
                        Console.Write(" and nineteen");
                    else if (hundrets && !tens)
                        Console.Write(" and nine");
                    else if (!hundrets && tens && one)
                        Console.Write("Nineteen");
                    else if (tens && !one)
                        Console.Write(" nine");
                    else
                        Console.Write("Nine");
                    break;
            }
        }
        Console.WriteLine();
    }
}
