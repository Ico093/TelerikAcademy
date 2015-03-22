using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course:ICourse
    {
        private string name;
        ITeacher teacher;
        List<string> topics;

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Course Name");
                }
                name = value;
            }
        }

        public ITeacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder myReturn=new StringBuilder();
            myReturn.Append(String.Format("Course: Name={0}", this.Name));
            if (Teacher != null)
            {
                myReturn.Append(String.Format("; Teacher={0}", this.teacher.Name));
            }
            if (topics.Count != 0)
            {
                myReturn.Append("; Topics=[");
                myReturn.Append(String.Join(", ", this.topics));
                myReturn.Append("]");
            }
            return myReturn.ToString();
        }
    }
}
