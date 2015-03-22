using System;


class FighterAttack
{
    static void Main()
    {
        double Px1, Py1, Px2, Py2, Fx, Fy, D;
        double top, bottom, left, right;
        int damage = 0;
        Px1 = double.Parse(Console.ReadLine());
        Py1 = double.Parse(Console.ReadLine());
        Px2 = double.Parse(Console.ReadLine());
        Py2 = double.Parse(Console.ReadLine());
        Fx = double.Parse(Console.ReadLine());
        Fy = double.Parse(Console.ReadLine());
        D = double.Parse(Console.ReadLine());

        top = Math.Max(Py1, Py2);
        bottom = Math.Min(Py1, Py2);
        left = Math.Min(Px1, Px2);
        right = Math.Max(Px1, Px2);

        Fx += D;
        if (Fx >= left && Fx <= right && Fy >= bottom && Fy <= top)
            damage += 100;
        if (Fx >= left && Fx <= right && Fy+1 >= bottom && Fy+1 <= top)
            damage += 50;
        if (Fx >= left && Fx <= right && Fy-1 >= bottom && Fy-1 <= top)
            damage += 50;
        if (Fx+1 >= left && Fx+1 <= right && Fy >= bottom && Fy <= top)
            damage += 75;

        Console.WriteLine(damage+"%");
    }
}

