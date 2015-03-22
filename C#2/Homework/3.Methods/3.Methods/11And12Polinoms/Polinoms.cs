using System;

class Polinoms
{
    static void Main()
    {
        double[] polinom1=new double[3];
        double[] polinom2=new double[3];
        Console.Write("Enter coefficents for Ax2+Bx+c=0\nEnter coeficent A int the first polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom1[2]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent A in the first polinom:");
        }

        Console.Write("Enter coeficent B in the first polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom1[1]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent B in the first polinom:");
        }

        Console.Write("Enter coeficent C in the first polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom1[0]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent C in the first polinom:");
        }

        Console.Write("Enter coefficents for Ax2+Bx+c=0\nEnter coeficent A int the secound polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom2[2]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent A in the secound polinom:");
        }

        Console.Write("Enter coeficent B in the secound polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom2[1]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent B in the secound polinom:");
        }

        Console.Write("Enter coeficent C in the secound polinom:");
        while (!double.TryParse(Console.ReadLine(), out polinom2[0]))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter coeficent C in the secound polinom:");
        }

        double[] newPolinom = new double[5];
        newPolinom = Add(polinom1, polinom2);

        string thePolinom = PrintPolinomx4(newPolinom);
        Console.WriteLine("\n\nThe added polinom looks like {0}=0",thePolinom);

        newPolinom = Substract(polinom1, polinom2);

        thePolinom = PrintPolinomx4(newPolinom);
        Console.WriteLine("\n\nThe substracted polinom looks like {0}=0", thePolinom);

        newPolinom = Multiply(polinom1, polinom2);

        thePolinom = PrintPolinomx4(newPolinom);
        Console.WriteLine("\n\nThe multiplied polinom looks like {0}=0", thePolinom);

    }

    static string PrintPolinomx4(double[] newPolinom)
    {
        
        string thePolinom = "";
        if (newPolinom[4] != 0)
            thePolinom += newPolinom[4].ToString() + "x4";
        if (newPolinom[3] != 0)
        {
            if (newPolinom[3] < 0)
                thePolinom += newPolinom[3].ToString() + "x3";
            else if (thePolinom != "")
                thePolinom += "+" + newPolinom[3].ToString() + "x3";
            else
                thePolinom += newPolinom[1].ToString() + "x3";
        }
        if (newPolinom[2] != 0)
        {
            if (newPolinom[2] < 0)
                thePolinom += newPolinom[2].ToString() + "x2";
            else if (thePolinom != "")
                thePolinom += "+" + newPolinom[2].ToString() + "x2";
            else
                thePolinom += newPolinom[2].ToString() + "x2";
        }
        if (newPolinom[1] != 0)
        {
            if (newPolinom[1] < 0)
                thePolinom += newPolinom[1].ToString() + "x";
            else if (thePolinom != "")
                thePolinom += "+" + newPolinom[1].ToString() + "x";
            else
                thePolinom += newPolinom[1].ToString() + "x";
        }
        if (newPolinom[0] != 0)
        {
            if (newPolinom[0] < 0)
                thePolinom += newPolinom[0].ToString();
            else if (thePolinom != "")
                thePolinom += "+" + newPolinom[0].ToString();
            else
                thePolinom += newPolinom[0].ToString();
        }
        return thePolinom;
    }

    static double[] Add(double[] polinom1, double[] polinom2)
    {
        double[] newPolinom = new double[5];
        for (int i = 0; i < 3; i++)
        {
            newPolinom[i] = polinom1[i] + polinom2[i];
        }
        return newPolinom;
    }
    static double[] Substract(double[] polinom1, double[] polinom2)
    {
        double[] newPolinom = new double[5];
        for (int i = 0; i < 3; i++)
        {
            newPolinom[i] = polinom1[i] - polinom2[i];
        }
        return newPolinom;
    }
    static double[] Multiply(double[] polinom1, double[] polinom2)
    {
        double[] newPolinom = new double[5];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                newPolinom[i + j] += polinom1[i] * polinom2[j];
            }
        }
        return newPolinom;
    }
}

