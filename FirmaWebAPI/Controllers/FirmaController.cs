using FirmaWebAPI.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaWebAPI.Controllers
{
    public class FirmaController : Controller
    {
        public ActionResult Stepen(int a, int b)
        {
            double r = Math.Pow(a, b);
            ViewData["rKey"] = r;
            return View("Rezultat");
        }

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

        public int Broj()
        {
            firma2Entities db = new DB.firma2Entities();

            return db.Firma.Where(s => s.Naziv.StartsWith("d")).Count();
        }

        public ActionResult Prikazi()
        {
            firma2Entities db = new firma2Entities();

            List<Firma> firme = db.Firma.ToList();

            ViewData["firmeKey"] = firme;

            return View("FirmeView");
        }
    }
}