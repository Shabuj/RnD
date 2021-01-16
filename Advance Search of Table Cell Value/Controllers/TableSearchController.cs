using SelectCellValueSearch.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SelectCellValueSearch.Controllers
{
    public class TableSearchController : Controller
    {
        string connection = WebConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;
        // GET: TableSearch
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection(connection);
            string query = "SELECT E.Emp_Id, E.EmpName, E.Age, D.Dep_Name, D.Dep_Code, E.Dep_Id  FROM Department AS D INNER JOIN Employee AS E ON D.Dep_Id = E.Dep_Id";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            return View(ds);
        }

        public ActionResult TableCellSearch()
        {

            SqlConnection conn = new SqlConnection(connection);
            string query = "SELECT E.Emp_Id, E.EmpName, E.Age, D.Dep_Name, D.Dep_Code, E.Dep_Id  FROM Department AS D INNER JOIN Employee AS E ON D.Dep_Id = E.Dep_Id";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            var viewList = new List<EmpViewModel>();
            while (reader.Read())
            {
                int EmpId = Convert.ToInt32(reader["Emp_Id"]);
                string empName = reader["EmpName"].ToString();
                int age = Convert.ToInt32(reader["Age"]);
                int DepId = Convert.ToInt32(reader["Dep_Id"]);
                string DepName = reader["Dep_Name"].ToString();
                string DepCode = reader["Dep_Code"].ToString();


                EmpViewModel vm = new EmpViewModel(EmpId, empName, age, DepId, DepName, DepCode);
                viewList.Add(vm);
            }
            reader.Close();
            conn.Close();

            return View(viewList);
        }
    }
}