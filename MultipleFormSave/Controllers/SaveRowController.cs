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
    public class SaveRowController : Controller
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["SContext"].ConnectionString;
        // GET: SaveRow
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveTableRow()
        {
            ViewBag.customerId = "Entry Product Name";
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

            

            //string query1 = "SELECT MAX(CustomerId) FROM Customers ";
            string CustomerPK = "Select Ident_current('Customers')";  // Get data insert session primary key.
            SqlCommand command1 = new SqlCommand(CustomerPK, connection);
            int Id = Convert.ToInt32(command1.ExecuteScalar());   //Return the first column of the first row in the result set by the query.
            

            connection.Close();
            

            foreach (var item in order)
            {

                string query2 = "INSERT INTO [Order](ProductName, Quantity ,Price,Amount,CustomerId) Values('" + item.ProductName + "','" + item.Quantity + "','" + item.Price + "','" + item.Amount + "','" + Id + "')";
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