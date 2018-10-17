using FirmaWebAPI.DB;
using FirmaWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            List<FirmaPrikazi> firme = db.Firma.Select(s => new FirmaPrikazi {
                ID = s.ID,
                Naziv = s.Naziv,
                Adresa = s.Adresa,
                BrojRacuna = s.Racun.Count,
                IznosBezPDV = s.Racun.Sum(r=>(decimal?)r.Iznos),
                IznosSaPDV = s.Racun.Sum(r=> (decimal?)(r.Iznos * (decimal)1.17))
            }).ToList();
            
            return Json(firme, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Obrisi(int id)
        {
            firma2Entities db = new firma2Entities();
            Firma f = db.Firma.Find(id);

            db.Firma.Remove(f);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}