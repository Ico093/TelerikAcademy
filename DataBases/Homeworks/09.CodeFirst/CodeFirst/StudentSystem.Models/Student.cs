using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private int homeworkId;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public int HomeworkId
        {
            get { return homeworkId; }
            set { homeworkId = value; }
        }
        
        
    }
}
