using MultipleFormSave.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MultipleFormSave.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        private string connectionString = WebConfigurationManager.ConnectionStrings["SContext"].ConnectionString;
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            var studentList = new List<Student>();
           
            while (reader.Read())
            {
                 int StudentId = Convert.ToInt32(reader["StudentId"]);
                 string StudentName = reader["StudentName"].ToString();
                 string StudentAge  = reader["StudentAge"].ToString();
                 Student students = new Student(StudentId, StudentName, StudentAge);

                 studentList.Add(students);
            }
            reader.Close();
            connection.Close();
            return View(studentList);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}