using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    public abstract class Person
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
