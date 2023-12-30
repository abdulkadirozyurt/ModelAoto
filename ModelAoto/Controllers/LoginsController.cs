using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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


            db.Customers.Add(customer);
            db.SaveChanges();

            return PartialView();
        }

        [HttpGet]
        public ActionResult CustomerLogin()
        {



            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var informations = db.Customers.FirstOrDefault(x => x.Mail == customer.Mail && x.Password == customer.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Mail, true);
                Session["Mail"] = informations.Mail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return View("Index", "Logins");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var informations = db.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, true);
                Session["Username"] = informations.Username.ToString();
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                return RedirectToAction("Index", "Logins");
            }

        }

    }
}