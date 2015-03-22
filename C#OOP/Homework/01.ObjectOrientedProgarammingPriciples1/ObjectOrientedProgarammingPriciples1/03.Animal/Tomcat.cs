using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tomcat : Cat
{
    public Tomcat(string name, int age)
        : base(name, age, Sexes.Male) { }

    public override string ProduceSound()
    {
        return "Miayayyayy";
    }

    public override string ToString()
    {
        return this.Speack(this);
    }
}
