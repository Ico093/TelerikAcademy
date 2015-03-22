using System;

class Matrix
{
    int[,] matrix;
    int col, row;
    public Matrix(int N = 0, int M = 0)
    {
        matrix = new int[N, M];
        col = 0;
        row = 0;
    }

    public void addNumber(int number)
    {
        if (col == matrix.GetLength(1))
        {
            if (row == matrix.GetLength(0) - 1)
                Console.WriteLine("There is no more space!");
            else
            {
                row++;
                col = 0;
                matrix[row, col] = number;
                col++;
            }
        }
        else
        {
            matrix[row, col] = number;
            col++;
        }
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
        {
            Matrix g = new Matrix();
            Console.WriteLine("Can't add those matrices!");
            return g;
        }
        else
        {
            Matrix add = new Matrix(a.matrix.GetLength(0), a.matrix.GetLength(1));
            for (int row = 0; row < add.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < add.matrix.GetLength(1); col++)
                {
                    add.addNumber(a.matrix[row, col] + b.matrix[row, col]);
                }
            }
            return add;
        }
    }
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
        {
            Matrix g = new Matrix();
            Console.WriteLine("Can't substract those matrices!");
            return g;
        }
        else
        {
            Matrix sub = new Matrix(a.matrix.GetLength(0), a.matrix.GetLength(1));
            for (int row = 0; row < sub.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < sub.matrix.GetLength(1); col++)
                {
                    sub.addNumber(a.matrix[row, col] - b.matrix[row, col]);
                }
            }
            return sub;
        }
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.matrix.GetLength(1) != b.matrix.GetLength(0))
        {
            Matrix g = new Matrix();
            Console.WriteLine("Can't multiply those matrices!");
            return g;
        }
        else
        {
            Matrix multiply = new Matrix(a.matrix.GetLength(0), b.matrix.GetLength(1));
            for (int row = 0; row < multiply.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < multiply.matrix.GetLength(1); col++)
                {
                    for (int items = 0; items < a.matrix.GetLength(1); items++)
                    {
                        multiply.matrix[row, col] += a.matrix[row, items] * b.matrix[items, col];
                    }
                }
            }
            return multiply;
        }
    }

    public override string ToString()
    {
        string output = "";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                output += matrix[row, col] + " ";
            }
            output += "\n";
        }
        return output;
    }

    public int this[int row, int col]
    {
        get
        {
            return matrix[row, col];
        }
        set
        {
            matrix[row, col] = value;
        }
    }

}


class Execute
{
    static void Main()
    {
        Matrix a = new Matrix(2, 2);
        a.addNumber(1);
        a.addNumber(2);
        a.addNumber(3);
        a.addNumber(4);
        a.ToString();
       

        Console.WriteLine();
        Matrix b = new Matrix(2, 3);
        b.addNumber(1);
        b.addNumber(2);
        b.addNumber(3);
        b.addNumber(4);
        b.addNumber(5);
        b.addNumber(6);
        b.ToString();

        (a + b).Print();

        Console.WriteLine();

        (a - b).Print();

        Console.WriteLine();

        (a * b).Print();

        Console.WriteLine();
        Console.WriteLine((a * b).ToString());
        a[1, 1] = 8;
        Console.WriteLine();
        Console.WriteLine(a[1, 1]);
    }
}

