using System;
using System.Text.RegularExpressions;

class CorrectBrackets
{
    //The other solution is in comments
    //static char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    //static char[] operations = { '-', '+', '*', '\\' };

    static Regex valid = new Regex(@"[^\w\)]\s*\+\s*\(|"+
@"[^\w\)]\s*\-\s*\(|"+
@"[^\w\)]\s*\*\s*\(|"+
@"[^\w\)]\s*/\s*\(|"+
@"\)\s*\+\s*[^\w\(\s]|"+
@"\)\s*\-\s*[^\w\(\s]|"+
@"\)\s*\*\s*[^\w\(\s]|" +
@"\)\s*/\s*[^\w\(\s]|"+
@"\(\s*\+|"+
@"\(\s*\-|" +
@"\(\s*\*|" +
@"\(\s*/|" +
@"\+\s*\)|"+
@"\-\s*\)|" +
@"\*\s*\)|" +
@"/\s*\)|" +
@"\s*\b(?!(ln|pow|sqrt)\b)\w+\s*\(|"+
@"(pow|sqrt|ln)\s*[^\(]");

    static void Main()
    {
        string expression =Console.ReadLine();

        Match match = valid.Match(expression);
        if (valid.IsMatch(expression))
        {
            Console.WriteLine(match.Value+" "+match.Index);
           
            Console.WriteLine("Brackets aren't correct!");
            return;
        }

        int leftBrackets = 0;
        int rightBrackets = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                leftBrackets++;
            }
            else if (expression[i] == ')')
            {
                rightBrackets++;
                if (rightBrackets > leftBrackets)
                {
                    Console.WriteLine("Right brackets are more than left at position: {0}!",i);
                    return;
                }
            }
        }
        if (leftBrackets != rightBrackets)
        {
            Console.WriteLine("Brackets aren't equal");
        }
        else
        {
            Console.WriteLine("Correct!");
        }
        //bool correct = true;

        //for (int i = 0; i < expression.Length; i++)
        //{
        //    if (expression[i] == '(')
        //    {
        //        if (i == 0)
        //        {
        //            leftBrackets++;
        //            checkForOperation(expression, i + 1, ref correct);
        //        }
        //        else
        //        {
        //            checkForDigit(expression, i - 1, ref correct);
        //            checkForOperation(expression, i + 1, ref correct);
        //        }
        //    }
        //    else if (expression[i] == ')')
        //    {
        //        if (i == expression.Length - 1)
        //        {
        //            rightBrackets++;
        //            checkForOperation(expression, i - 1, ref correct);
        //        }
        //        else
        //        {
        //            rightBrackets++;
        //            checkForDigit(expression, i + 1, ref correct);
        //            checkForOperation(expression, i - 1, ref correct);
        //        }
        //        if (rightBrackets > leftBrackets)
        //        {
        //            correct = false;
        //        }
        //    }
        //    if (!correct)
        //    {
        //        break;
        //    }
        //}

        //Console.WriteLine("Brackets are {0}!", correct ? "correct" : "incorrect");
    }

    //static void checkForOperation(string expression, int pos, ref bool correct)
    //{
    //    foreach (var operation in operations)
    //    {
    //        if (expression[pos] == operation)
    //        {
    //            correct = false;
    //            return;
    //        }
    //    }
    //}

    //static void checkForDigit(string expression, int pos, ref bool correct)
    //{
    //    foreach (var digit in digits)
    //    {
    //        if (expression[pos] == digit)
    //        {
    //            correct = false;
    //            return;
    //        }
    //    }
    //}
}

