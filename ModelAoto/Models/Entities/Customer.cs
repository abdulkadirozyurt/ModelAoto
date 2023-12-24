using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }

    }
}