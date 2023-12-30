using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class LoginsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CustomerRegister()
        {


            List<SelectListItem> cities = db.Cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            }).ToList();

            List<SelectListItem> districts = db.Districts.Select(y => new SelectListItem
            {
                Text = y.DistrictName,
                Value = y.Id.ToString()

            }).ToList();

            ViewBag.Cities = cities;
            ViewBag.Districts = districts;

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CustomerRegister(Customer customer)
        {

            db.Customers.Add(customer);
            db.SaveChanges();


            List<SelectListItem> cities = db.Cities.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            }).ToList();

            List<SelectListItem> districts = db.Districts.Select(y => new SelectListItem
            {
                Text = y.DistrictName,
                Value = y.Id.ToString()

            }).ToList();

            ViewBag.Cities = cities;
            ViewBag.Districts = districts;

            return PartialView();
        }

        
    }
}