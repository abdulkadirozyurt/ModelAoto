using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Marka Adı")]
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}