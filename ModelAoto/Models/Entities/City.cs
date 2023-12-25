using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class City
    {
        [Key]
        [DisplayName("Plaka No")]
        public int Id { get; set; }

        [DisplayName("Şehir")]
        public string CityName { get; set; }



        public ICollection<District> Districts { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}