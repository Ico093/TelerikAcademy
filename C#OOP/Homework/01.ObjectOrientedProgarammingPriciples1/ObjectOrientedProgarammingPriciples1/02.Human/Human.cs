using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Human
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public Human(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public override string ToString()
    {
        return string.Format("{0}\nFirst name: {1}\nLast name:{2}\n\n\n", this.GetType(), FirstName, LastName);
    }
}

