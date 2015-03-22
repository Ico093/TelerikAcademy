using System;
using System.Collections.Generic;

class Calculator
{
    static char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

    static void Main()
    {
        string expression = Console.ReadLine();

        List<string> _RPN = new List<string>();

        RPN(expression, ref _RPN);

        for (int i = 0; i < _RPN.Count; i++)
        {
            Console.Write(_RPN[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(ReversePolish(_RPN));
    }

    static double ReversePolish(List<string> _RPN)
    {
        List<double> numbers = new List<double>();

        for (int i = 0; i < _RPN.Count; i++)
        {
            switch (_RPN[i])
            {
                case "*":
                    {
                        numbers[numbers.Count - 2] = numbers[numbers.Count - 1] * numbers[numbers.Count - 2];
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    break;
                case "/":
                    {
                        numbers[numbers.Count - 2] = numbers[numbers.Count - 2] / numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    break;
                case "+":
                    {
                        numbers[numbers.Count - 2] = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    break;
                case "-":
                    {
                        numbers[numbers.Count - 2] = numbers[numbers.Count - 2] - numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    break;
                case "ln":
                    {
                        numbers[numbers.Count - 1] = Math.Log(numbers[numbers.Count - 1],2.718281828459);
                    }
                    break;
                case "pow":
                    {
                        numbers[numbers.Count - 2] = Math.Pow(numbers[numbers.Count - 2] , numbers[numbers.Count - 1]);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    break;
                case "sqrt":
                    {
                        numbers[numbers.Count - 1] = Math.Sqrt(numbers[numbers.Count - 1]);
                    }
                    break;
                default:
                    {
                        numbers.Add(double.Parse(_RPN[i]));
                    }
                    break;
            }
        }

        return numbers[0] ;
    }

    static void RPN(string expression, ref List<string> _RPN)
    {
        List<string> operators = new List<string>();

        for (int i = 0; i < expression.Length; i++)
        {
            switch (expression[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    {

                        int length = 1;
                        while (true)
                        {
                            bool ok = false;
                            foreach (char n in number)
                            {
                                if (i + length >= expression.Length)
                                {
                                    break;
                                }
                                else
                                {
                                    if (n == expression[i + length])
                                    {
                                        length++;
                                        ok = true;
                                        break;
                                    }
                                }
                            }
                            if (!ok)
                            {
                                break;
                            }
                        }
                        _RPN.Add(expression.Substring(i, length));
                        i += length - 1;
                    }
                    break;
                case '+':
                case '*':
                case '/':
                    {
                        if (operators.Count == 0)
                        {
                            operators.Add(expression[i].ToString());
                        }
                        else
                        {
                            switch (isEqual(expression[i], operators[operators.Count - 1][0]))
                            {
                                case 0:
                                case -1:
                                    _RPN.Add(operators[operators.Count - 1]);
                                    operators[operators.Count - 1] = expression[i].ToString();
                                    break;
                                case 1:
                                    operators.Add(expression[i].ToString());
                                    break;
                            }
                        }
                    }
                    break;
                case '-':
                    {
                        int j = i;
                        if (j != 0 && expression[j - 1] == ' ')
                        {
                            j--;
                        }
                        if (j == 0 || (j != 0 && (expression[j - 1] == ',' || expression[j - 1] == '(')))
                        {
                            int length = 1;
                            while (true)
                            {
                                bool ok = false;
                                foreach (char n in number)
                                {
                                    if (i + length >= expression.Length)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (n == expression[i + length])
                                        {
                                            length++;
                                            ok = true;
                                            break;
                                        }
                                    }
                                }
                                if (!ok)
                                {
                                    break;
                                }
                            }
                            _RPN.Add(expression.Substring(i, length));
                            i += length - 1;
                        }
                        else
                        {
                            if (operators.Count == 0)
                            {
                                operators.Add(expression[i].ToString());
                            }
                            else
                            {
                                switch (isEqual(expression[i], operators[operators.Count - 1][0]))
                                {
                                    case 0:
                                    case -1:
                                        _RPN.Add(operators[operators.Count - 1]);
                                        operators[operators.Count - 1] = expression[i].ToString();
                                        break;
                                    case 1:
                                        operators.Add(expression[i].ToString());
                                        break;
                                }
                            }
                        }
                    }
                    break;
                case '(':
                    operators.Add("(");
                    break;
                case ')':
                    {
                        while (operators[operators.Count - 1] != "(")
                        {
                            _RPN.Add(operators[operators.Count - 1]);
                            operators.RemoveAt(operators.Count - 1);
                            if (operators.Count == 0)
                            {
                                Console.WriteLine("\n\nWrong input!");
                            }
                        }
                        operators.RemoveAt(operators.Count - 1);
                        if (operators.Count != 0)
                        {
                            if (isFunction(operators[operators.Count - 1]))
                            {
                                _RPN.Add(operators[operators.Count - 1]);
                                operators.RemoveAt(operators.Count - 1);
                            }
                        }
                    }
                    break;
                case 'l':
                    operators.Add("ln");
                    i++;
                    break;
                case 'p':
                    operators.Add("pow");
                    i += 2;
                    break;
                case 's':
                    operators.Add("sqrt");
                    i += 3;
                    break;
            }
        }

        for (int i = operators.Count - 1; i >= 0; i--)
        {
            _RPN.Add(operators[i]);
        }
    }

    static int isEqual(char operator1, char operator2)
    {
        int op1 = whatPrecedence(operator1);
        int op2 = whatPrecedence(operator2);

        if (op1 > op2)
            return 1;
        if (op1 == op2)
            return 0;
        if (op1 < op2)
            return -1;

        return 3;
    }


    static int whatPrecedence(char _operator)
    {
        switch (_operator)
        {
            case '*':
            case '/':
                return 2;
            case '+':
            case '-':
                return 1;
            default:
                return 0;
        }
    }

    static bool isFunction(string function)
    {
        switch (function)
        {
            case "ln":
            case "pow":
            case "sqrt":
                return true;
            default:
                return false;
        }
    }
}

