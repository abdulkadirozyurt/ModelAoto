using ModelAoto.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    [AllowAnonymous]
    public class FeCategoriesController : Controller
    {
       ModelAotoDbContext db = new ModelAotoDbContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SideBarCategories()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }


    }
}