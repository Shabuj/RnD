using RND.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RND.Controllers
{
    public class DepartmentController : Controller
    {

        string connectionString = WebConfigurationManager.ConnectionStrings["RND"].ConnectionString;
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDropDown()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);
            
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> DepartmentList = new List<Department>();
            while (reader.Read())
            {
                int DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                string DepartmentName = reader["DepartmentName"].ToString();
                string DepartmentCode = reader["DepartmentCode"].ToString();
                

                Department dept = new Department(DepartmentId, DepartmentName, DepartmentCode);
                DepartmentList.Add(dept);
            }
            ViewBag.single = "Shabuj";
            reader.Close();
            connection.Close();
            return View(DepartmentList);
            
        }

        public JsonResult GetStudentByDeptId(int departmentId)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student WHERE DepartmentId = '"+departmentId+"'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {
                int StudentId = Convert.ToInt32(reader["StudentId"]);
                string StudentName = reader["StudentName"].ToString();
                string StudentRegNo = reader["StudentRegNo"].ToString();


                Student student = new Student(StudentId, StudentName, StudentRegNo);
                studentList.Add(student);
            }
            reader.Close();
            connection.Close();
            
            return Json(studentList);
        }

        public ActionResult Validation()
        {
           return View();

        }

        public ActionResult MasterDetail()
        {
            return View();

        }
    }
}