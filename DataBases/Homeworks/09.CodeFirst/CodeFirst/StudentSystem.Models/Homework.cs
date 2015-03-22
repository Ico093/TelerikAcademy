using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Homework
    {
        private int studentId;

        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }   
    }
}
