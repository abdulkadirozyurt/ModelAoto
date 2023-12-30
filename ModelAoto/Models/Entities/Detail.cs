using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(2000)]
        public string ProductInfo { get; set; }



        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}