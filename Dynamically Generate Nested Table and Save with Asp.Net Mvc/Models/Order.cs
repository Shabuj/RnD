using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Order
    {
        public Order(int orderId, string productName, int quantity, decimal price, decimal amount)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Amount = amount;
        }

        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Customer> Customer { get; set; }

    }
}