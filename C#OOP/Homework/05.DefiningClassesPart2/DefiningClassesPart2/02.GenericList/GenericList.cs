using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericList<T> where T : IComparable, new()
{
    private T[] arr;
    private long size;
    private long count;

    public GenericList(long size)
    {
        if (size >= 0)
        {
            this.arr = new T[size];
        }
        else
        {
            throw new ArgumentOutOfRangeException("Size can't be negative or 0!");
        }
        this.size = size;
        this.count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }
            else
            {
                return arr[index];
            }
        }
    }

    public long Size
    {
        get { return size; }
    }

    public long Count
    {
        get { return count; }
    }

    public void Add(T elem)
    {
        if (count == size - 1)
        {
            T[] newArr = new T[size * 2];
            for (long i = 0; i < size; i++)
            {
                newArr[i] = arr[i];
            }
            size *= 2;
            arr = newArr;
        }
        arr[count] = elem;
        count++;
    }

    public void Insert(T elem, long position)
    {
        if (!(position >= 0 && position <= count))
        {
            throw new ArgumentOutOfRangeException("You can't insert there!");
        }
        else if (count == size - 1)
        {
            T[] newArr = new T[size * 2];
            for (long i = 0; i < position; i++)
            {
                newArr[i] = arr[i];
            }
            newArr[position] = elem;
            for (long i = position; i < count; i++)
            {
                newArr[i] = arr[i - 1];
            }
            size *= 2;
            count++;
            arr = newArr;
        }
        else
        {
            for (long i = count; i > position; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[position] = elem;
        }
    }

    public void Remove(long index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException("No such element exists!");
        }

        else if (count == 0)
        {
            throw new ArgumentOutOfRangeException("There aren't any elements in the list!");
        }

        else
        {
            for (long i = index; i < count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            count--;
            arr[count] = new T();
        }
    }

    public void Clear()
    {
        arr = new T[1];
        count = 0;
    }

    public long FindElemIndexByValue(T value)
    {
        for (int i = 0; i < count; i++)
        {
            if (value.CompareTo(arr[i]) == 0)
            {
                return i;
            }
        }
        return (-1);
    }

    public T Min() 
    {
        if (count > 0)
        {
            T min = arr[0];

            for (int i = 1; i < count; i++)
            {
                if (arr[i].CompareTo(min) < 0)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        else
        {
            throw new ArgumentException("There aren't any elements in the array!");
        }
    }

    public T Max() 
    {
        if (count > 0)
        {
            T max = arr[0];

            for (int i = 1; i < count; i++)
            {
                if (arr[i].CompareTo(max)>0)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        else
        {
            throw new ArgumentException("There aren't any elements in the array!");
        }
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            myReturn.Append(arr[i].ToString() + "\n");
        }
        return myReturn.ToString();
    }
}

