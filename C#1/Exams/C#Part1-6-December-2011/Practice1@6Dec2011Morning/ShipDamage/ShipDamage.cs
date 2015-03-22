using System;

class ShipDamage
{
    static void Main()
    {
        double Sx1, Sy1, Sx2, Sy2, H, Cx1, Cy1, Cx2, Cy2, Cx3, Cy3;
        int Damage = 0;
        Sx1 = double.Parse(Console.ReadLine());
        Sy1 = double.Parse(Console.ReadLine());
        Sx2 = double.Parse(Console.ReadLine());
        Sy2 = double.Parse(Console.ReadLine());
        H = double.Parse(Console.ReadLine());
        Cx1 = double.Parse(Console.ReadLine());
        Cy1 = double.Parse(Console.ReadLine());
        Cx2 = double.Parse(Console.ReadLine());
        Cy2 = double.Parse(Console.ReadLine());
        Cx3 = double.Parse(Console.ReadLine());
        Cy3 = double.Parse(Console.ReadLine());

        Cy1 = -Cy1 + 2 * H;
        Cy2 = -Cy2 + 2 * H;
        Cy3 = -Cy3 + 2 * H;

        double right = Math.Max(Sx1, Sx2);
        double top = Math.Max(Sy1, Sy2);
        double left = Math.Min(Sx1, Sx2);
        double bottom = Math.Min(Sy1, Sy2);


        if ((Cx1 == right || Cx1 == left) && (Cy1 == top || Cy1 == bottom))
            Damage += 25;
        if (((Cx1 > left && Cx1 < right) && (Cy1 == top || Cy1 == bottom)) || ((Cx1 == right || Cx1 == left) && (Cy1 > bottom && Cy1 < top)))
            Damage += 50;
        if (Cx1 > left && Cx1 < right && Cy1 > bottom && Cy1 < top)
            Damage += 100;
        if ((Cx2 == right || Cx2 == left) && (Cy2 == top || Cy2 == bottom))
            Damage += 25;
        if (((Cx2 > left && Cx2 < right) && (Cy2 == top || Cy2 == bottom)) || ((Cx2 == right || Cx2 == left) && (Cy2 > bottom && Cy2 < top)))
            Damage += 50;
        if (Cx2 > left && Cx2 < right && Cy2 > bottom && Cy2 < top)
            Damage += 100;
        if ((Cx3 == right || Cx3 == left) &&( Cy3 == top || Cy3 == bottom))
            Damage += 25;
        if (((Cx3 > left && Cx3 < right) && (Cy3 == top || Cy3 == bottom)) || ((Cx3 == right || Cx3 == left) && (Cy3 > bottom && Cy3 < top)))
            Damage += 50;
        if (Cx3 > left && Cx3 < right && Cy3 > bottom && Cy3 < top)
            Damage += 100;

        Console.WriteLine("{0}%", Damage);
    }
}

