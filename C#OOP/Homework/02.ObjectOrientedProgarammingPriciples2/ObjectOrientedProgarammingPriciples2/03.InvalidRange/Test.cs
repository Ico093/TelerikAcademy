using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter a value between 1 and 100.");
                int number = int.Parse(Console.ReadLine());
                if (number < 0 || number > 100)
                {
                    throw new InvalidRangeException<int>("Mi to umrq...", 1, 100);
                }

                Console.WriteLine("Enter a date between 1.1.1980 and 31.12.2013.");
                DateTime myDay = DateTime.ParseExact(Console.ReadLine(), "d.m.yyyy", null);

                if (myDay < new DateTime(1980, 1, 1) || myDay > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Mi to umrq...", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }

                break;
            }

            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}