using System;

class PlayingWithNullable
{
    static void Main()
    {
        int? first = null;
        double? secound = null;
        Console.WriteLine("{0},{1}",first,secound);
        first = 5;
        secound = 3.14;
        Console.WriteLine("{0},{1}", first, secound);
        first = null;
        first += null;
        Console.WriteLine(first);
    }
}

