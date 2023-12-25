using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]      

        //public string Brand { get; set; }
        public int StockAmount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image { get; set; }



        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        

        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }


        public ICollection<Sale> Sales { get; set; }


    }
}