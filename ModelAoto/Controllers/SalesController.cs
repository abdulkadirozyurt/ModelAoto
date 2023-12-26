using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class SalesController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.ToList();

            return View(sales);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> products = db.Products.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.Id.ToString(),
            }).ToList();

            List<SelectListItem> customers = db.Customers.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString(),
            }).ToList();

            List<SelectListItem> employees = db.Employees.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString(),
            }).ToList();

            ViewBag.Products = products;
            ViewBag.Customers = customers;
            ViewBag.Employees = employees;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Sale sale)
        {
            sale.Date= DateTime.Parse(DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString());
            db.Sales.Add(sale);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}