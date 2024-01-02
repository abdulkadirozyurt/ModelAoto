using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class CategoriesController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();

        public ActionResult Index(int page =1)
        {
            var categories = db.Categories.OrderBy(x => x.CategoryName).ToList().ToPagedList(page,10);
            
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = db.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var categoryToUpdate = db.Categories.Find(category.Id);
            categoryToUpdate.CategoryName = category.CategoryName;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}