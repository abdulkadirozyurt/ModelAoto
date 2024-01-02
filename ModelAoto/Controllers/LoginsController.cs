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
    [AllowAnonymous]
    public class LoginsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: Logins
        public ActionResult Index()
        {
            return View();
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
                FormsAuthentication.SetAuthCookie(informations.Mail, false);
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
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["Username"] = informations.Username.ToString();
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                return RedirectToAction("Index", "Logins");
            }

        }


        [HttpGet]
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult FeCustomerLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FeCustomerLogin(Customer customer)
        {
            var informations = db.Customers.FirstOrDefault(x => x.Mail == customer.Mail && x.Password == customer.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Mail, false);
                Session["Mail"] = informations.Mail.ToString();
                return RedirectToAction("Index", "FeProducts");
            }
            else
            {
                return View("Index", "Logins");
            }
            
        }

        [HttpGet]
        public ActionResult FeCustomerLogout()
        { 
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","FeProducts");

        }


        [HttpGet]
        public ActionResult FeCustomerRegister()
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

            return View();

        }

        [HttpPost]
        public ActionResult FeCustomerRegister(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "FeProducts");

        }
    }
}