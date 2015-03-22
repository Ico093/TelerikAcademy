﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext():base("StudentSystemDb")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
