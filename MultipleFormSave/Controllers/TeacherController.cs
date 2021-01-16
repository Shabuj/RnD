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
    public class TeacherController : Controller
    {
        // GET: Teacher
        private string connectionString = WebConfigurationManager.ConnectionStrings["SContext"].ConnectionString;
        public ActionResult Index()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Teacher";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var teacherList = new List<Teacher>();
           
            while (reader.Read())
            {
                int    TeacherId = Convert.ToInt32(reader["TeacherId"]);
                string TeacherName = reader["TeacherName"].ToString();
                string TeacherEmail = reader["TeacherEmail"].ToString();
                string TeacherAddress = reader["TeacherAddress"].ToString();
                Teacher teacher = new Teacher(TeacherId, TeacherName, TeacherEmail, TeacherAddress);
                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return View(teacherList);
        }
        public ActionResult Create()
        {
            return View();

        }
    }
}