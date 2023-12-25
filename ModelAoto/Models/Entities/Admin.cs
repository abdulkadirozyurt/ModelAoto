using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Parola")]
        public string Password { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        [DisplayName("Yetki")]
        public string Authority { get; set; }

    }
}