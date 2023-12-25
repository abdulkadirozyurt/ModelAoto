using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ModelAoto.Controllers
{
    public class DepartmentsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        public ActionResult Index()
        {
            var departments = db.EmployeeDepartments.ToList();
            return View(departments);
        }


        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeDepartment employeeDepartment)
        {
            db.EmployeeDepartments.Add(employeeDepartment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var employees = db.Employees.Where(x => x.EmployeeDepartmentId == id).ToList();
            var department = db.EmployeeDepartments.Where(x => x.Id == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.department = department;
            return View(employees);
        }

        public ActionResult EmployeeSalesDetails(int id)
        {
            var employeeSales = db.Sales.Where(x => x.EmployeeId == id).ToList();
            var employeeName= db.Employees.Where(x=>x.Id==id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.employeeName = employeeName;
            return View(employeeSales);
        }

        public ActionResult Delete(int id)
        {
            var department = db.EmployeeDepartments.Find(id);
            department.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var department = db.EmployeeDepartments.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Update(EmployeeDepartment employeeDepartment)
        {
            var departmentToUpdate = db.EmployeeDepartments.Find(employeeDepartment.Id);
            departmentToUpdate.DepartmentName = employeeDepartment.DepartmentName;
            departmentToUpdate.Status = employeeDepartment.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}