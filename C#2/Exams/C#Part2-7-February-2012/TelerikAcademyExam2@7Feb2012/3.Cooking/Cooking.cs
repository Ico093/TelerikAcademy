using System;
using System.Collections.Generic;

class Cooking
{
    static void Main()
    {
        int howManyProduct = int.Parse(Console.ReadLine());
        List<string[]> products = new List<string[]>();
        for (int i = 0; i < howManyProduct; i++)
        {
            string[] product = Console.ReadLine().Split(':');
            bool isIn = false;
            for (int k = 0; k < products.Count; k++)
            {
                if ( string.Compare(products[k][2],product[2],true)== 0)
                {
                    products[k][0] = calculate(decimal.Parse(products[k][0]), products[k][1], decimal.Parse(product[0]), product[1]).ToString();
                    isIn = true;
                    break;
                }
            }
            if (!isIn)
            {
                products.Add(product);
            }
        }

        int howManyAreUsed = int.Parse(Console.ReadLine());
        string[] usedProducts;
        for (int i = 0; i < howManyAreUsed; i++)
        {
            usedProducts = Console.ReadLine().Split(':');
            for (int k = 0; k < products.Count; k++)
            {
                if (string.Compare( products[k][2],usedProducts[2],true)== 0)
                {
                    products[k][0] = calculate(-decimal.Parse(products[k][0]), products[k][1], -decimal.Parse(usedProducts[0]), usedProducts[1]).ToString();
                    break;
                }
            }
        }

        for (int i = 0; i < products.Count; i++)
        {
            if (decimal.Parse(products[i][0]) > 0)
            {
                Console.WriteLine("{0:0.00}:{1}:{2}", decimal.Parse(products[i][0]), products[i][1], products[i][2]);
            }
        }
    }

    static decimal calculate(decimal amaunt1, string mesure1, decimal amaunt2, string mesure2)
    {
        if (mesure1 == mesure2)
        {
            return amaunt1 + amaunt2;
        }
        else
        {
            switch (mesure1)
            {
                case "tbsps":
                    {
                        return amaunt1 + (amaunt2 / 3);
                    }
                case "tsps":
                    {
                        return amaunt1 + amaunt2 * 3;
                    }
                case "ls":
                    {
                        return amaunt1 + (amaunt2 / 1000);
                    }
                case "mls":
                    {
                        if (mesure2 == "teaspoons")
                        {
                            return amaunt1 + (amaunt2 * 5);
                        }
                        else
                        {
                            return amaunt1 + (amaunt2 * 1000);
                        }
                    }
                case "fl ozs":
                    {
                        return amaunt1 + (amaunt2 * 8);
                    }
                case "cups":
                    {
                        if (mesure2 == "pts")
                        {
                            return amaunt1 + (amaunt2 * 2);
                        }
                        else if (mesure2 == "teaspoons")
                        {
                            return amaunt1 + (amaunt2 / 48);
                        }
                        else
                        {
                            return amaunt1 + (amaunt2 / 8);
                        }
                    }
                case "teaspoons":
                    {
                        if (mesure2 == "cups")
                        {
                            return amaunt1 + (amaunt2 * 48);
                        }
                        else
                        {
                            return amaunt1 + (amaunt2 / 5);
                        }
                    }
                case "gallons":
                    {
                        return amaunt1 + (amaunt2 / 4);
                    }
                case "pts":
                    {
                        if (mesure2 == "quarts")
                        {
                            return amaunt1 + (amaunt2 * 2);
                        }
                        else
                        {
                            return amaunt1 + (amaunt2 / 2);
                        }
                    }
                case "quarts":
                    {
                        if (mesure2 == "gallons")
                        {
                            return amaunt1 + (amaunt2 * 4);
                        }
                        else
                        {
                            return amaunt1 + (amaunt2 / 2);
                        }
                    }
            }
            return 0;
        }
    }
}