using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        string town;

        public string Town
        {
            get { return town; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("OffsiteCourse Town");
                }
                town = value;
            }
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public override string ToString()
        {
            StringBuilder myReturn = new StringBuilder();
            myReturn.Append(String.Format("Offsite{0}", base.ToString()));
            myReturn.Append(String.Format("; Town={0}", this.Town));
            return myReturn.ToString();
        }
    }
}
