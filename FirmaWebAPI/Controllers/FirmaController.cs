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
    }
}