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
    public class TableController : Controller
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RND"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateTable()
        {
            List<string> strList = new List<string>() { "IT", "Management", "Trainer", "Staff" };
            ViewBag.list = strList;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT T.TableName, F.* FROM [Table] as T INNER JOIN  [Field] as F ON T.TableId = F.TableId ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            var tableList = new List<TableViewModel>();
            while (reader.Read())
            {
                int TableId = Convert.ToInt32(reader["TableId"]);
                string TableName = reader["TableName"].ToString();
                int FieldId = Convert.ToInt32(reader["FieldId"]);
                string FieldName = reader["FieldName"].ToString();
                string Fieldtype = reader["Fieldtype"].ToString();
                int TableFieldId = Convert.ToInt32(reader["TableFieldId"]);

                TableViewModel vm = new TableViewModel(TableId,TableName, FieldId, FieldName, Fieldtype, TableFieldId);
                tableList.Add(vm);
            }
            reader.Close();
            connection.Close();
            return View(tableList);

          
        }

       
    }
}