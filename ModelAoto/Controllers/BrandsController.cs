using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class BrandsController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();

        public ActionResult Index()
        {
            var brands = db.Brands.ToList();

            return View(brands);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(Brand brand)
        {
            if (Request.Files.Count > 0)  // yani yaptığım işlemler içerisinde bir dosya mevcutsa 
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/images/" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                brand.Image = "/images/" + fileName + fileExtension;
            }

            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var brand = db.Brands.Find(id);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Update(Brand brand)
        {
            var brandToUpdate = db.Brands.Find(brand.Id);
            brandToUpdate.BrandName = brand.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}