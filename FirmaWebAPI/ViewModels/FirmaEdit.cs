using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaWebAPI.ViewModels
{
    public class FirmaEdit
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int OpstinaID { get; set; }

        public string JIB { get; set; }
        public string PDVBroj { get; set; }
    }
}