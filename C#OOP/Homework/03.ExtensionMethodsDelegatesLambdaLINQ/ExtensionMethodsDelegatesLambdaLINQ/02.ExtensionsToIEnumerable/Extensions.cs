using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class Extensions
{
    public static T min<T>(this IEnumerable<T> enumarable) where T : IComparable
    {
        T min = enumarable.First();
        foreach (T item in enumarable)
        {
            if (min.CompareTo(item) > 0)
            {
                min = item;
            }
        }
        return min;
    }

    public static T max<T>(this IEnumerable<T> enumarable) where T : IComparable
    {
        T max = enumarable.First();
        foreach (T item in enumarable)
        {
            if (max.CompareTo(item) < 0)
            {
                max = item;
            }
        }
        return max;
    }

    public static decimal sum<T>(this IEnumerable<T> enumerable, Func<T, decimal> tramsformer = null)
    {
        if (tramsformer == null)
        {
            tramsformer = (x => Convert.ToDecimal(x));
        }
        decimal myReturn = 0;
        try
        {
            foreach (T elem in enumerable)
            {
                myReturn += tramsformer(elem);
            }
            return myReturn;
        }
        catch (FormatException formEx)
        {
            throw new ArgumentException("Collection cannot be modifed with the default transformer!", formEx);
        }
        catch (InvalidCastException invEx)
        {
            throw new ArgumentException("Collection cannot be modifed with the default transformer!", invEx);
        }
    }

    public static decimal product<T>(this IEnumerable<T> enumerable, Func<T, decimal> tramsformer = null)
    {
        if (tramsformer == null)
        {
            tramsformer = (x => Convert.ToDecimal(x));
        }
        decimal myReturn = 1;
        try
        {
            foreach (T elem in enumerable)
            {
                myReturn *= tramsformer(elem);
            }
            return myReturn;
        }
        catch (FormatException formEx)
        {
            throw new ArgumentException("Collection cannot be modifed with the default transformer!", formEx);
        }
        catch (InvalidCastException invEx)
        {
            throw new ArgumentException("Collection cannot be modifed with the default transformer!", invEx);
        }
    }
}

