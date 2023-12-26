using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class EmployeeDepartment
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Departman Adı")]
        public string DepartmentName { get; set; }

        [DisplayName("Durum")]
        public bool Status { get; set; }


        public ICollection<Employee> Employees { get; set;}
    }
}