using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Customer
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
    }

    public int Age
    {
        get { return age; }
    }

    public Customer(string name, int age)
    {
        this.name = name;
        if (age > 0)
        {
            this.age = age;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Age can't be negative!");
        }
    }

}
