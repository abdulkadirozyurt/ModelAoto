using ModelAoto.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    [AllowAnonymous]
    public class FeProductsController : Controller
    {

        ModelAotoDbContext db = new ModelAotoDbContext();

        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        public ActionResult ListJustArrivedProductsOnMainPage()
        {
            var products = db.Products.OrderByDescending(x => x.AddDate).Take(8).Where(x => x.Status == true).ToList();

            return View(products);
        }


        public ActionResult ListAllProducts()
        {
            var products = db.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }


        public ActionResult ListProductDetails(int id)
        {
            var product = db.Products.Find(id);

            return View(product);
        }


    }
}