using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleFormSave.Models
{
    public class Teacher
    {
        public Teacher(int teacherId, string teacherName, string teacherEmail, string teacherAddress)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
            TeacherEmail = teacherEmail;
            TeacherAddress = teacherAddress;
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherAddress { get; set; }
    }
}