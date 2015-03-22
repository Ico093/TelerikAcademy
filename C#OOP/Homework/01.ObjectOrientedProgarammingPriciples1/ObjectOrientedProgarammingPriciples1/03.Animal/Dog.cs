using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Dog:Animal
{
    public Dog(string name, int age, Sexes sex)
        : base(name, age, sex){    }

    public override string ProduceSound()
    {
        return "Bau";
    }

    public override string ToString()
    {
        return this.Speack(this);
    }
}

