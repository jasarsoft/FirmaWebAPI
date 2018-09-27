using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Prikazi()
        {
            ViewBag.Title = "Home Prikazi";
            return View("index");
        }

        public ActionResult Preusmjeri()
        {
            ViewBag.Title = "Redirekcija";
            return RedirectToAction("index");
        }

        public ActionResult PreusmjeriDirektno()
        {
            return Redirect("http://fit.ba");
        }

        public string Proba()
        {
            return "<h2>hello</h2>";
        }
    }
}
