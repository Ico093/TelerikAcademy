using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitArray64 : IEnumerable<int>
{
    private ulong number;

    public BitArray64(ulong number)
    {
        this.number = number;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < 64; i++)
        {
            ulong p = (ulong)1 << i;
            yield return (int)((number & p) >> i);
        }
    }

    public override bool Equals(object obj)
    {
        BitArray64 arr = obj as BitArray64;
        for (int i = 0; i < 64; i++)
        {
            ulong p = (ulong)1 << i;
            if (((this.number & p) >> i) != ((arr.number & p) >> i))
            {
                return false;
            }
        }
        return true;
    }

    public override int GetHashCode()
    {
        return (int)(number / 3 + number ^ 4);
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();

        foreach (int integer in this)
        {
            myReturn.Insert(0, integer);
        }

        return myReturn.ToString();
    }

    public static bool operator ==(BitArray64 a, BitArray64 b)
    {
        return BitArray64.Equals(a, b);
    }

    public static bool operator !=(BitArray64 a, BitArray64 b)
    {
        return !BitArray64.Equals(a, b);
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index > 63)
            {
                throw new ArgumentException("Index must be between 0 and 63.");
            }
            else
            {
                return (int)((number & ((ulong)1 << index)) >>index);
            }
        }
        set
        {
            if (index < 0 || index > 63)
            {
                throw new ArgumentException("Index must be between 0 and 63.");
            }
            else if (value > 1 || value < 0)
            {
                throw new ArgumentException("Value must be 0 or 1.");
            }
            else
            {
                if (value == 1)
                {
                    number = number | ((ulong)1 << index);
                }
                else 
                {
                    number = number & (~((ulong)1 << index));
                }
            }
        }
    }

}
