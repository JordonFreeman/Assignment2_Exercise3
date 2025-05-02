using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Models;


namespace OrderManagement.RazorWeb.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int AgentID { get; set; }

        // Navigation property - NO attributes!
        public Agent Agent { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
