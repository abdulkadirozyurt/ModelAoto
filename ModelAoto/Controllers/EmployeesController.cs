﻿using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class EmployeesController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> departments = db.EmployeeDepartments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (Request.Files.Count > 0)  // yani yaptığım işlemler içerisinde bir dosya mevcutsa 
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string filePath="~/images/"+fileName+fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                employee.Image = "/images/" + fileName + fileExtension;
            }

            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> departments = db.EmployeeDepartments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.Id.ToString()
            }).ToList();

            var employee = db.Employees.Find(id);

            ViewBag.Departments = departments;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if (Request.Files.Count > 0)  // yani yaptığım işlemler içerisinde bir dosya mevcutsa 
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/images/" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                employee.Image = "/images/" + fileName + fileExtension;
            }

            var employeeToUpdate = db.Employees.Find(employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employeeToUpdate.LastName;
            employeeToUpdate.EmployeeDepartmentId = employee.EmployeeDepartmentId;
            employeeToUpdate.Image = employee.Image;

            db.SaveChanges();
            return RedirectToAction("Index");

        }









        public ActionResult EmployeeList()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }

    }
}