using MultipleFormSave.BLL;
using MultipleFormSave.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MultipleFormSave.Controllers
{
    public class FormController : Controller
    {
       
        private string connectionString = WebConfigurationManager.ConnectionStrings["SContext"].ConnectionString;
        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {

           /* ArrayList RowList = new ArrayList();
            ArrayList objectArray =new ArrayList();
            
            for(int n = 0; n< 3; n++)
            {
                for(int a =0; a< 2; a++)
                {
                    var N = collection["name[" + n + "][" + a + "]"];
                    var ag = collection["age[" + n + "][" + a + "]"];
                    var desig = collection["Designation[" + n + "][" + a + "]"];
                    RowList.Add(N);
                    RowList.Add(ag);
                    RowList.Add(desig);
                }

                ArrayList RowList1 = new ArrayList();
                RowList1 = (ArrayList)RowList.Clone();
                objectArray.Add(RowList1);
                RowList.Clear();
            }

            foreach (ArrayList item in objectArray)
            {
                foreach (var k in item)
                {
                    var v = k;
                }
            }
           */


            var formId = Convert.ToInt32(collection["form_id"]);
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM FormInfo WHERE FormId = '" + formId + "' ";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            var formList = new List<string>();
            
            while (reader.Read())
            {

                string FormElement = reader["FormElement"].ToString();
                formList.Add(FormElement);

            }
            reader.Close();
            connection.Close();

            StringBuilder sb = new StringBuilder(string.Empty);
            int countList = formList.Count();
            int i = 0;
            foreach (var item in formList)
            {
                sb.Append("@");
                sb.Append(item);
                if(i<countList)
                {
                    sb.Append(",");
                }
                i++;
            }
           
            string tableName = collection["table_name"];

            string query1 = "INSERT INTO "+tableName+" VALUES("+sb+")";
            SqlCommand command1 = new SqlCommand(query1, connection);
            StringBuilder sb1 = new StringBuilder();
       
            foreach (var item in formList)
            {
                sb1.Append("@");
                sb1.Append(item);
                command1.Parameters.AddWithValue(sb1.ToString(), collection[item] );
                sb1.Clear();
            }
            connection.Open();
            int rowEffect = command1.ExecuteNonQuery();
            connection.Close();

            string InController = tableName;
            if (rowEffect>0)
            {
                return RedirectToAction("Index", InController);
            }

            return View("Create", InController);
        }
    }
}