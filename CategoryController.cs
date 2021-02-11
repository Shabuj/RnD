using RND_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RND_1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        private string connectionString = WebConfigurationManager.ConnectionStrings["RND_1"].ConnectionString;
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> CategoryList = new List<Category>();
            while (reader.Read())
            {
                bool HasChild = Convert.ToBoolean(reader["HasChild"]);
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string CategoryName = reader["CategoryName"].ToString();
                string CategoryCode = reader["CategoryCode"].ToString();

                Category cp = new Category(CategoryId, CategoryName, CategoryCode, HasChild);
                CategoryList.Add(cp);
            }
            reader.Close();
            connection.Close();
            return View(CategoryList);
           
        }


        public ActionResult CategoryData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds);
            return View(ds);
        }

        public JsonResult GetProductById(int catId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Product where CategoryId = '"+catId+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Product> productList = new List<Product>();
            while (reader.Read())
            {


                int ProductId = Convert.ToInt32(reader["ProductId"]);
                string ProductName = reader["ProductName"].ToString();
                string ProductCode = reader["ProductCode"].ToString();

                Product cp = new Product(ProductId, ProductName, ProductCode);
                productList.Add(cp);
            }
            reader.Close();
            connection.Close();
            return Json(productList);
        }

        public ActionResult MultipleSelect()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> CategoryList = new List<Category>();
            while (reader.Read())
            {
                bool HasChild = Convert.ToBoolean(reader["HasChild"]);
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string CategoryName = reader["CategoryName"].ToString();
                string CategoryCode = reader["CategoryCode"].ToString();

                Category cp = new Category(CategoryId, CategoryName, CategoryCode, HasChild);
                CategoryList.Add(cp);
            }
            reader.Close();
            connection.Close();
            return View(CategoryList);
           
        }

        public JsonResult SaveCategory(List<int> categoryId)
        {

            return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Multiple1()
        {
            return View();
        }
     

    }
}