using ModelAoto.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    [AllowAnonymous]
    public class FeMainPageController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {

            return View();
        }

    }
}