using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Student
    {
        public Student(int studentId, string studentName, string studentRegNo)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentRegNo = studentRegNo;
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentRegNo { get; set; }
        public int DepartmentId { get; set; }

        ICollection<Department> Departments { get; set; }


    }
}