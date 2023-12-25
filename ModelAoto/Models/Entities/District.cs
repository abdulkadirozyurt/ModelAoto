using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İlçe")]
        public string DistrictName { get; set; }


        public int CityId { get; set; }
        public virtual City City { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}