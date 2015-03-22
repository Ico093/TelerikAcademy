using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Kitten:Cat
{
     public Kitten(string name, int age)
        : base(name, age, Sexes.Female){    }

    public override string ProduceSound()
    {
        return "Mrrr";
    }

    public override string ToString()
    {
        return this.Speack(this);
    }
}

