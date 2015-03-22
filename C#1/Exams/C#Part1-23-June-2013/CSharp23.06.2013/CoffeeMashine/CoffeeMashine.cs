using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CoffeeMashine
{
    static void Main()
    {
        int[] coins = new int[5];
        double canReturn=0;
        for (int i = 0; i < 5; i++)
        {
            coins[i] =int.Parse(Console.ReadLine());
        }

        canReturn = 0.05 * coins[0] + 0.1 * coins[1] + 0.2 * coins[2] + 0.5 * coins[3] + coins[4];

        double amount = double.Parse(Console.ReadLine());
        double price = double.Parse(Console.ReadLine());

        if (amount < price)
        {
            Console.WriteLine("More {0:0.00}",price-amount);
        }
        else if (amount - price <= canReturn)
        {
            Console.WriteLine("Yes {0:0.00}", canReturn -(amount-price) );
        }
        else
        {
            Console.WriteLine("No {0:0.00}",amount-price-canReturn);
        }
    }
}

