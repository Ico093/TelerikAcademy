using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses;

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Teacher Name");
                }
                name = value;
            }
        }

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder myReturn = new StringBuilder();
            myReturn.Append(String.Format("Teacher: Name={0}", this.Name));
            if (courses.Count != 0)
            {
                myReturn.Append("; Courses=[");
                myReturn.Append(String.Join(", ", this.courses.Select(x=>x.Name)));
                myReturn.Append("]");
            }
            return myReturn.ToString();
        }
    }
}
