using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class ProductsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products./*Where(x => x.Status == true).*/ToList();

            return View(products);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.Id.ToString(),
                                               }).ToList();

            List<SelectListItem> brands = (from x in db.Brands.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BrandName,
                                                   Value = x.Id.ToString(),
                                               }).ToList();

            ViewBag.categories = categories;
            ViewBag.brands = brands;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            product.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}