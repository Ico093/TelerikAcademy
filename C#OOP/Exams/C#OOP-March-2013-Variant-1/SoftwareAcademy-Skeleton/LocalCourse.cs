using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public string Lab
        {
            get { return lab; }
          set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("LocalCourse Lab");
                }
                lab = value;
            }
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            StringBuilder myReturn = new StringBuilder();
            myReturn.Append(String.Format("Local{0}", base.ToString()));
            myReturn.Append(String.Format("; Lab={0}", this.Lab));
            return myReturn.ToString();
        }
    }
}
