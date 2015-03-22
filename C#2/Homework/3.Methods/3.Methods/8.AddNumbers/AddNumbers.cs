using System;

class AddNumbers
{
    static void Main()
    {
        int[] arr1 = new int[10000];
        int[] arr2 = new int[10000];

        Console.WriteLine("Enter numbers for the first arr.");
        int number1;
        int arr1Length= 1;
        Console.Write("Enter a digit:");
        while (int.TryParse(Console.ReadLine(), out number1))
        {
            if (arr1Length == 10000)
                break;
            if (number1 < 0 || number1 > 9)
            {
                break;
            }
            else
            {
                arr1[arr1Length-1] = number1;
                arr1Length++;
                Console.Write("Enter a digit:");
            }
        }
        if (arr1Length > 1)
            arr1Length--;

        for (int k = 0; k < arr1Length/2; k++)
        {
            int var=arr1[k];
            arr1[k] = arr1[arr1Length - k-1];
            arr1[arr1Length - k-1] = var;
        }

        Console.WriteLine("\n\nEnter digits for the secound arr.");
        int number2;
        int arr2Length = 1;
        Console.Write("Enter a digit:");
        while (int.TryParse(Console.ReadLine(), out number2))
        {
            if (arr2Length >= 10000)
                break;
            if (number2 < 0 || number2 > 9)
            {
                break;
            }
            else
            {
                arr2[arr2Length-1] = number2;
                arr2Length++;
                Console.Write("Enter a digit:");
            }
        }
        if (arr2Length > 1)
            arr2Length--;
        
        for (int k = 0; k < arr2Length/ 2; k++)
        {
            int var = arr2[k];
            arr2[k] = arr2[arr2Length - k-1];
            arr2[arr2Length - k-1] = var;
        }

        int newArrLength=0;
        int[] newArr = _AddNumbers(arr1, arr2,arr1Length,arr2Length,ref newArrLength);

        Console.WriteLine("\n\n");
        for (int k = arr1Length-1; k >=0 ; k--)
        {
            Console.Write(arr1[k]);
        }
        Console.Write("+");
        for (int k = arr2Length-1; k >=0; k--)
        {
            Console.Write(arr2[k]);   
        }
        Console.Write("=");
        for (int k = newArrLength-1; k >=0 ; k--)
        {
            Console.Write(newArr[k]);
        }
        Console.WriteLine();
    }

    static int[] _AddNumbers(int[] arr1, int[] arr2,int arr1Length,int arr2Length,ref int newArrLength)
    {
        int[] newArr = new int[10001];
        
        int bigger=Math.Max(arr1Length,arr2Length);
        int remainings=0;

        for (int i = 0; i < bigger; i++)
        {
            newArr[i] += arr1[i] + arr2[i]+remainings;
            remainings=0;
            if (newArr[i] > 9)
            {
                newArr[i] %= 10;
                remainings = 1;
            }
        }
        if (remainings == 1)
        {
            newArr[bigger] += remainings;
            newArrLength = bigger + 1;
        }
        else
            newArrLength = bigger;

        return newArr;
    }
}

