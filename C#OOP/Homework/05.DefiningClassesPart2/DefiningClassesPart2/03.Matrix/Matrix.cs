using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    private T[,] matrix;
    private long myRow;
    private long myCol;

    public long Row
    {
        get { return myRow; }
    }

    public long Col
    {
        get { return myCol; }
    }

    public T this[int row, int col]
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

    public Matrix(long row, long col)
    {
        if (row > 0 && col > 0)
        {
            this.myRow = row;
            this.myCol = col;
            this.matrix = new T[row, col];
        }
        else
        {
            throw new ArgumentOutOfRangeException("Sizes of matrices can't be negative or 0.");
        }
    }

    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
        {
            throw new ArgumentException("Can't add those matrices!");
        }
        else
        {
            Matrix<T> add = new Matrix<T>(a.matrix.GetLength(0), a.matrix.GetLength(1));
            for (int row = 0; row < add.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < add.matrix.GetLength(1); col++)
                {
                    add[row, col] = (dynamic)(a.matrix[row, col]) + (dynamic)(b.matrix[row, col]);
                }
            }
            return add;
        }
    }

    public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
    {
        if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
        {
            throw new ArgumentException("Can't substract those matrices!");
        }
        else
        {
            Matrix<T> sub = new Matrix<T>(a.matrix.GetLength(0), a.matrix.GetLength(1));
            for (int row = 0; row < sub.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < sub.matrix.GetLength(1); col++)
                {
                    sub[row, col] = (dynamic)(a.matrix[row, col]) - (dynamic)(b.matrix[row, col]);
                }
            }
            return sub;
        }
    }

    public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
    {
        if (a.matrix.GetLength(1) != b.matrix.GetLength(0))
        {
            throw new ArgumentException("Can't multiply those matrices!");
        }
        else
        {
            Matrix<T> multiply = new Matrix<T>(a.matrix.GetLength(0), b.matrix.GetLength(1));
            for (int row = 0; row < multiply.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < multiply.matrix.GetLength(1); col++)
                {
                    for (int items = 0; items < a.matrix.GetLength(1); items++)
                    {
                        multiply[row, col] += (dynamic)(a.matrix[row, items]) * (dynamic)(b.matrix[items, col]);
                    }
                }
            }
            return multiply;
        }
    }

    public static bool operator true(Matrix<T> elem)
    {
        for (int row = 0; row < elem.Row; row++)
        {
            for (int col = 0; col < elem.Col; col++)
            {
                if (elem[row,col].ToString() == "0")
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> elem)
    {
        for (int row = 0; row < elem.Row; row++)
        {
            for (int col = 0; col < elem.Col; col++)
            {
                if (elem[row,col].ToString() == "0")
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        string output = "";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                output += matrix[row, col].ToString().PadRight(4, ' ') + " ";
            }
            output += "\n";
        }
        return output;
    }
}
