using RND.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RND.Controllers
{


    public class SaveRowController : Controller
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RND"].ConnectionString;
        // GET: SaveRow
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveTableRow()
        {
            return View();
        }


        public ActionResult SaveOrder(FormCollection collection)
        {



            ArrayList RowList = new ArrayList();

            ArrayList objectArray = new ArrayList();


            for (int t = 0; t < 2; t++)
            {
                if(t==0)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        if(r==0)
                        {
                            var pName = collection["productName[" + t + "][" + r + "]["+0+"]"];
                            var price = collection["price[" + t + "][" + r + "][" + 0 + "]"];
                            var quantity = collection["quantity[" + t + "][" + r + "][" + 0 + "]"];
                            var amount = collection["amount[" + t + "][" + r + "][" + 0 + "]"];
                            string row = pName + "," + price + "," + quantity + "," + amount;
                        }
                        else if(r==1)
                        {
                            for (int tr = 0; tr < 3; tr++)
                            {
                                var pName = collection["productName[" + t + "][" + r + "][" + tr + "]"];
                                var price = collection["price[" + t + "][" + r + "][" + tr + "]"];
                                var quantity = collection["quantity[" + t + "][" + r + "][" + tr + "]"];
                                string row = pName + "," + price + "," + quantity;
                            }
                          
                           
                          
                        }
                        else if(r==2)
                        {
                            var pName = collection["productName[" + t + "][" + r + "][" + 2 + "]"];
                            var price = collection["price[" + t + "][" + r + "][" + 2 + "]"];
                            var quantity = collection["quantity[" + t + "][" + r + "][" + 2 + "]"];
                            var amount = collection["amount[" + t + "][" + r + "][" + 2 + "]"];
                            string row = pName + "," + price + "," + quantity + "," + amount;
                        }

                    }
                }
                else
                {
                    for (int r = 0; r < 3; r++)
                    {
                        if (r == 0)
                        {
                            var pName = collection["productName[" + t + "][" + r + "][" + 0 + "]"];
                            var price = collection["price[" + t + "][" + r + "][" + 0 + "]"];
                            var quantity = collection["quantity[" + t + "][" + r + "][" + 0 + "]"];
                            var amount = collection["amount[" + t + "][" + r + "][" + 0 + "]"];
                            var status = collection["status[" + t + "][" + r + "][" + 0 + "]"];
                            string row = pName + "," + price + "," + quantity + "," + amount +","+status;
                        }
                        else if (r == 1)
                        {
                            for (int tr = 0; tr < 3; tr++)
                            {
                                
                                
                                    var pName = collection["productName[" + t + "][" + r + "][" + tr + "]"];
                                    var price = collection["price[" + t + "][" + r + "][" + tr + "]"];
                                    var quantity = collection["quantity[" + t + "][" + r + "][" + tr + "]"];
                                    string row = pName + "," + price + "," + quantity;
                                
                               
                                if(tr<2)
                                {
                                    for (int trr = 0; trr < 2; trr++)
                                    {


                                        var Name = collection["productName[" + t + "][" + r + "][" + 0 + "][" + trr + "]"];
                                        var Price = collection["price[" + t + "][" + r + "][" + tr + "][" + trr + "]"];
                                        var Quantity = collection["quantity[" + t + "][" + r + "][" + tr + "][" + trr + "]"];
                                        string row1 = Name + "," + Price + "," + Quantity;

                                    }
                                }
                                    
                                
                              
                            }



                        }
                        else if (r == 2)
                        {
                            var pName = collection["productName[" + t + "][" + r + "][" + 2 + "]"];
                            var price = collection["price[" + t + "][" + r + "][" + 2 + "]"];
                            var quantity = collection["quantity[" + t + "][" + r + "][" + 2 + "]"];
                            var amount = collection["amount[" + t + "][" + r + "][" + 2 + "]"];
                            string row = pName + "," + price + "," + quantity + "," + amount;
                        }

                    }
                }
               
            }
          
                
            //for (int n = 0; n < 2; n++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {


            //        var pName = collection["productName[" + n + "][" + j + "]"];
            //        var price = collection["price[" + n + "][" + j + "]"];
            //        var quantity = collection["quantity[" + n + "][" + j + "]"];
            //        var amount = collection["amount[" + n + "][" + j + "]"];

            //        string row = pName + "," + price + "," + quantity + "," + amount;

            //        RowList.Add(pName);
            //        RowList.Add(price);
            //        RowList.Add(quantity);
            //        RowList.Add(amount);

            //        ArrayList RowList1 = new ArrayList();
            //        RowList1 = (ArrayList)RowList.Clone();


            //    }
            //   // objectArray.Add(RowList1);
            //    RowList.Clear();

            //}


            //foreach (ArrayList objectlist in objectArray)
            //{

            //    foreach (var obj in objectlist)
            //    {

            //        var v = obj;
            //    }

            //}



            //string result = "Error! Order Is Not Complete!";
            //if (name != null && address != null && order != null)
            //{

            //    SqlConnection connection = new SqlConnection(connectionString);
            //    string query = "INSERT INTO Customers(CustomerName, CustomerAddress) Values('" + name + "','" + address + "')";
            //    SqlCommand command = new SqlCommand(query, connection);

            //    connection.Open();

            //    command.ExecuteNonQuery();
                
            //    connection.Close();

            //    string query1 = "SELECT MAX(CustomerId) FROM Customers ";
            //    SqlCommand command1 = new SqlCommand(query1, connection);

            //    connection.Open();
            //    int CI = (int)command1.ExecuteScalar();
            //    connection.Close();

            //    foreach (var item in order)
            //    {

            //        string query2 = "INSERT INTO [Order](ProductName, Quantity ,Price,Amount,CustomerId) Values('" + item.ProductName + "','" + item.Quantity + "','" + item.Price + "','" + item.Amount + "','" + CI + "')";
            //        SqlCommand command2 = new SqlCommand(query2, connection);
            //        connection.Open();
            //        command2.ExecuteNonQuery();
            //        connection.Close();

            //    }

            //    string result = "Success! Order Is Complete!";
                ////}
                //return Json(result, JsonRequestBehavior.AllowGet);

                return View();
        }


    }
}