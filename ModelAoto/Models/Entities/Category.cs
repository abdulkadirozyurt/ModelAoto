using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }



        public ICollection<Product> Products { get; set; }


    }
}