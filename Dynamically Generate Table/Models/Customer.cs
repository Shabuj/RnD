using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int customerId, string name, string address, string orderDate)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
            OrderDate = orderDate;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OrderDate { get; set; }
        public Order Orders { get; set; }




       
    }
}