using System;
using System.Collections.Generic;
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
        public string DepartmentName { get; set; }  


        public ICollection<Employee> Employees { get; set;}
    }
}