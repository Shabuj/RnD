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
    public class OrdersController : Controller
    {
        // GET: Orders

        string connectionString = WebConfigurationManager.ConnectionStrings["RND"].ConnectionString;
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT C.*, O.OrderId, O.ProductName, O.Quantity, O.Price, O.Amount FROM Customer as C INNER JOIN [Order] as O ON C.CustomerId = O.CustomerId";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<COrderViewModel> customerOrderList = new List<COrderViewModel>();
            while (reader.Read())
            {
                int CustomerId = Convert.ToInt32(reader["CustomerId"]);
                string Name = reader["Name"].ToString();
                string Address = reader["Address"].ToString();
                string OrderDate = reader["OrderDate"].ToString();

                int OrderId = Convert.ToInt32(reader["OrderId"]);
                string ProductName = reader["ProductName"].ToString();
                int Quantity = Convert.ToInt32(reader["Quantity"]);
                Decimal Price = Convert.ToDecimal(reader["Price"]);
                Decimal Amount = Convert.ToDecimal(reader["Amount"]);

                COrderViewModel CO = new COrderViewModel(CustomerId, Name, Address, OrderDate, OrderId, ProductName, Quantity, Price, Amount);
                customerOrderList.Add(CO);
            }
            reader.Close();
            connection.Close();

            return View(customerOrderList);


        }
        public ActionResult SaveOrder(string name, String address, Order[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
              
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "INSERT INTO Customer(Name, Address,OrderDate) Values('"+name+"','"+address+"',GETDATE())";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                command.ExecuteNonQuery();
                connection.Close();

                string query1 = "SELECT MAX(CustomerId) FROM Customer ";
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
               
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Index()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM Customer ";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<Customer> customerList = new List<Customer>();
        //    while (reader.Read())
        //    {
        //        int CustomerId = Convert.ToInt32(reader["CustomerId"]);
        //        string Name = reader["Name"].ToString();
        //        string Address = reader["Address"].ToString();
        //        string OrderDate = reader["OrderDate"].ToString();

        //        Customer CO = new Customer(CustomerId, Name, Address, OrderDate);

              

        //        string query1 = "SELECT * FROM [Order]  WHERE CustomerId = '"+ CustomerId + "'  ";
        //        SqlCommand command1 = new SqlCommand(query1, connection);
        //        SqlDataReader reader1 = command1.ExecuteReader();

        //        while (reader1.Read())
        //        {
        //            int OrderId = Convert.ToInt32(reader["OrderId"]);
        //            string ProductName = reader1["ProductName"].ToString();
        //            int Quantity = Convert.ToInt32(reader1["Quantity"]);
        //            Decimal Price = Convert.ToDecimal(reader1["Price"]);
        //            Decimal Amount = Convert.ToDecimal(reader1["Amount"]);

        //            Order O = new Order(OrderId, ProductName, Quantity, Price, Amount);
        //            CO.Orders = O;
        //        }
        //        reader1.Close();
        //        customerList.Add(CO);
        //    }
        //    reader.Close();
        //    connection.Close();

        //    return View(customerList);


        //}


    }
}