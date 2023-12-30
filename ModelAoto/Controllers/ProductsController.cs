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

        //public ActionResult IndexMain()
        //{
        //    var products = db.Products.ToList();

        //    return View(products);
        //}



        //public ActionResult IndexSortBrands()
        //{
        //    var products = db.Products.OrderByDescending(x => x.BrandId).ToList();

        //    return View(products);
        //}

        //public ActionResult IndexSortScales()
        //{
        //    var products = db.Products.OrderByDescending(x => x.CategoryId).ToList();

        //    return View(products);
        //}

        //// GET: Products
        //public ActionResult IndexMiniGt()
        //{
        //    var products = db.Products.Where(x => x.BrandId == 1).ToList();

        //    return View(products);
        //}

        //public ActionResult IndexGreenLight()
        //{
        //    var products = db.Products.Where(x => x.BrandId == 2).ToList();

        //    return View(products);
        //}

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


        [HttpGet]
        public ActionResult Update(int id)
        {
            var product = db.Products.Find(id);

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
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            var productToUpdate = db.Products.Find(product.Id);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Description = product.Description;
            productToUpdate.StockAmount = product.StockAmount;
            productToUpdate.PurchasePrice = product.PurchasePrice;
            productToUpdate.SalePrice = product.SalePrice;
            productToUpdate.Status = product.Status;
            productToUpdate.Image = product.Image;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.BrandId = product.BrandId;


            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var products = db.Products.ToList();

            return View(products);
        }
    }
}