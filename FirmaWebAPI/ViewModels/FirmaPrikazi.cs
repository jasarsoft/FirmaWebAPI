using FirmaWebAPI.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaWebAPI.ViewModels
{
    public class FirmaPrikazi
    {
        public int ID;
        public string Naziv;
        public string Adresa;
        public int BrojRacuna;
        public decimal? IznosBezPDV;
        public decimal? IznosSaPDV;

        public string JIB;
        public string PDVBroj;
        public string Opstina;
    }
}