using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private int? age;

    public string Name
    {
        get { return name; }
    }

    public int? Age
    {
        get { return age; }
    }

    public Person(string name, int? age = null)
    {
        this.name = name;
        this.age = age;
    }



    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        myReturn.Append(string.Format("Name:{0}", Name));
        myReturn.Append(string.Format("\nAge:{0}\n\n", age==null ? "Not defined":age.ToString()));
        return myReturn.ToString();
    }
}
