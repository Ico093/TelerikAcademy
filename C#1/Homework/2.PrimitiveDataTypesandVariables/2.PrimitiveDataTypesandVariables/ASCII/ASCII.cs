using System;
using System.Text;

    class ASCII
    {
        static void Main()
        {
            char variable;
            for (int i = 0; i <= 127; i++)
            {
                variable = (char)i;
                Console.Write(variable+" ");
            }
            Console.WriteLine();
        }
    }

