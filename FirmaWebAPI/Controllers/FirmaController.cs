using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaWebAPI.Controllers
{
    public class FirmaController : Controller
    {
        public string Kvadriraj(int a)
        {
            return (a * a).ToString();
        }

        //http://localhost:4050/firma/stepenuj?a=2&b=3
        public string Stepenuj(int a, int b)
        {
            return Math.Pow(a, b).ToString();
        }

        public ActionResult Proba()
        {
            return View("Proba");
        }
    }
}