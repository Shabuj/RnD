using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class COrderViewModel
    {
        public COrderViewModel(int customerId, string name, string address, string orderDate, int orderId, string productName, int quantity, decimal price, decimal amount)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
            OrderDate = orderDate;
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Amount = amount;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OrderDate { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Amount { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}