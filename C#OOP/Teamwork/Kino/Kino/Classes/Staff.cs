using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    abstract class Staff : Person
    {
        string password;
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public Staff(string name, string password):base(name)
        {
            Password = password;
        }
    }
}
