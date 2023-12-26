using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Personel Adı")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Personel Soyadı")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [DisplayName("Fotoğraf")]
        public string Image { get; set; }

        public ICollection<Sale> Sales { get; set; }
        
        public virtual EmployeeDepartment EmployeeDepartment { get; set; }        
        public int EmployeeDepartmentId { get; set; }
    }
}





