using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> StudentId
        {
            get { return students; }
            set { students = value; }
        }

    }
}
