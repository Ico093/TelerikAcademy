using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cat:Animal
{
     public Cat(string name, int age, Sexes sex)
        : base(name, age, sex){    }

    public override string ProduceSound()
    {
        return "Miaaaay";
    }

    public override string ToString()
    {
        return this.Speack(this);
    }
}

