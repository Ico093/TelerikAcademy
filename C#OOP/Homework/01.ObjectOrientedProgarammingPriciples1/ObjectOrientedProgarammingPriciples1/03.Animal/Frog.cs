using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Frog:Animal
{
     public Frog(string name, int age, Sexes sex)
        : base(name, age, sex){    }

    public override string ProduceSound()
    {
        return "Graub";
    }

    public override string ToString()
    {
        return this.Speack(this);
    }
}
