using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleFormSave.Models
{
    public class Student
    {
        public Student(int studentId, string studentName, string studentAge)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentAge = studentAge;
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string  StudentAge { get; set; }

      
    }
}