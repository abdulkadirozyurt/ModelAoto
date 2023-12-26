using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class CustomersController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> cities = db.Cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString(),
            }).ToList();


            List<SelectListItem> districts = db.Districts.Select(y => new SelectListItem
            {

                Text = y.DistrictName,
                Value = y.Id.ToString()
            }).ToList();


            ViewBag.Cities = cities;
            ViewBag.Districts = districts;
            return View();


        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            customer.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> cities = db.Cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString(),
            }).ToList();


            List<SelectListItem> districts = db.Districts.Select(y => new SelectListItem
            {

                Text = y.DistrictName,
                Value = y.Id.ToString()
            }).ToList();

            var customer = db.Customers.Find(id);


            ViewBag.Cities = cities;
            ViewBag.Districts = districts;
            return View(customer);


        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            var customerToUpdate = db.Customers.Find(customer.Id);

            customerToUpdate.FirstName=customer.FirstName;  
            customerToUpdate.LastName=customer.LastName;
            customerToUpdate.CityId = customer.CityId;
            customerToUpdate.DistrictId = customer.DistrictId;
            customerToUpdate.Mail = customer.Mail;
            customerToUpdate.Status = customer.Status;

            db.SaveChanges();            
            return RedirectToAction("Index");
        }

        public ActionResult PurchaseHistory(int id)
        {
            var purchases = db.Sales.Where(x => x.CustomerId == id).ToList();
            var customerName = db.Customers.Where(x=>x.Id==id).Select(y=>y.FirstName+" "+y.LastName).FirstOrDefault();    
                
            ViewBag.CustomerName=customerName;
            return View(purchases);
        }
    }
}