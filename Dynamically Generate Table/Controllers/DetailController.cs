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
    public class DetailController : Controller
    {
        // GET: Detail
        private string connectionString = WebConfigurationManager.ConnectionStrings["RND"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveTableRow()
        {
            return View();
        }

        public ActionResult SaveOrder(string name, String address, Order[] order)
        {
            //string result = "Error! Order Is Not Complete!";
            //if (name != null && address != null && order != null)
            //{

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Customers(CustomerName, CustomerAddress) Values('" + name + "','" + address + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            command.ExecuteNonQuery();
            connection.Close();

            string query1 = "SELECT MAX(CustomerId) FROM Customers ";
            SqlCommand command1 = new SqlCommand(query1, connection);

            connection.Open();
            int CI = (int)command1.ExecuteScalar();
            connection.Close();

            foreach (var item in order)
            {

                string query2 = "INSERT INTO [Order](ProductName, Quantity ,Price,Amount,CustomerId) Values('" + item.ProductName + "','" + item.Quantity + "','" + item.Price + "','" + item.Amount + "','" + CI + "')";
                SqlCommand command2 = new SqlCommand(query2, connection);
                connection.Open();
                command2.ExecuteNonQuery();
                connection.Close();

            }

            string result = "Success! Order Is Complete!";
            //}
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}