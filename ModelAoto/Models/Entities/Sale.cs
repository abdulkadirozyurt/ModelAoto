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



        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }



    }
}