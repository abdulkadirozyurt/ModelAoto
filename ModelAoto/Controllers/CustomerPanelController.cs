using ModelAoto.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class CustomerPanelController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var customerMail = (string)Session["Mail"]; // mail değerini session değeri olarak aldık.
            var mail = db.Customers.FirstOrDefault(x => x.Mail == customerMail);

            ViewBag.Mail = customerMail;
            return View(mail);
        }


        public ActionResult ListOrders()
        {
            var mail = Convert.ToString(Session["Mail"]);
            var id = db.Customers.Where(x=>x.Mail==mail).Select(y=>y.Id).FirstOrDefault();
            
            var orders = db.Sales.Where(x=>x.CustomerId==id).ToList();
            
            return View(orders);
        }
    }
}