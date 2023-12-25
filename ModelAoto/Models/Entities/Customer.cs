using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girilebilir.")]
        [Required(ErrorMessage ="Boş bırakılamaz.")]
        [DisplayName("Müşteri Adı")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girilebilir.")]
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [DisplayName("Müşteri Soyadı")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [DisplayName("Mail Adresi")]
        public string Mail { get; set; }


        [DisplayName("Durum")]
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public bool Status { get; set; }


        public ICollection<Sale> Sales { get; set; }

        [Required(ErrorMessage = "Lütfen şehir seçiniz..")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [Required(ErrorMessage = "Lütfen ilçe seçiniz..")]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
       
        
    }
}