using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Services
        //public ActionResult Index()
        //{
        //  return View();
        //}

        [ActionName("paquetes-graduacion")]
        public ActionResult Graduacion()
        {
            return View("Graduacion");
        }

        [ActionName("renta-togas")]
        public ActionResult Togas()
        {
            return View("Togas");
        }
    
           //Missing to add the documentation section.

    }
}