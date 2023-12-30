using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class ProductDetailsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();
        // GET: ProductDetails
        public ActionResult Index()
        {
            ProductDetail productDetail = new ProductDetail();
            //var products = db.Products.ToList();

            productDetail.Products = db.Products.Where(x => x.Id == 1).ToList();
            productDetail.Details = db.Details.Where(y => y.Id == 1).ToList();
            return View(productDetail);
        }
    }
}