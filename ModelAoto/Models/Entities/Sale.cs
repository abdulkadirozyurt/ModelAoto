using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }



        public ICollection<Product> Products { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}