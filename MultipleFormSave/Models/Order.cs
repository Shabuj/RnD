﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleFormSave.Models
{
    public class Order
    {
        public int OrderId { set; get; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}