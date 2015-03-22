using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        Matrix<int> matrix1 = new Matrix<int>(3, 3);
        Matrix<int> matrix2 = new Matrix<int>(3, 3);

        int counter=0;

        for (int row = 0; row < matrix1.Row; row++)
        {
            for (int col = 0; col < matrix1.Col; col++)
            {
                matrix1[row, col] = counter;
                counter++;
            }
        }

        for (int row = 0; row < matrix2.Row; row++)
        {
            for (int col = 0; col < matrix2.Col; col++)
            {
                matrix2[row, col] = counter;
                counter++;
            }
        }

        Console.WriteLine(matrix1.ToString() + "\n");
        Console.WriteLine(matrix2.ToString() + "\n");

        Console.WriteLine("Is matrix1 containing any elements that are zero: {0}",matrix1?"YES":"NO");
        Console.WriteLine("Is matrix2 containing any elements that are zero: {0}\n", matrix2 ? "YES" : "NO");

        Console.WriteLine((matrix1 + matrix2).ToString()+"\n");
        Console.WriteLine((matrix1 - matrix2).ToString() + "\n");
        Console.WriteLine((matrix1 * matrix2).ToString() + "\n");
    }
}
