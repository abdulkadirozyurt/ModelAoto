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


        [DisplayName("Stok Miktarı")]
        public int StockAmount { get; set; }

        [DisplayName("Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }

        [DisplayName("Satış Fiyatı")]
        public decimal SalePrice { get; set; }

        [DisplayName("Durum")]
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [DisplayName("Fotoğraf")]
        public string Image { get; set; }

        public DateTime AddDate{ get; set; }



        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }


        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }


        public ICollection<Sale> Sales { get; set; }

        public ICollection<Detail> Details { get; set; }


    }
}