using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Controllers
{
    public class ServicesController : Controller
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

        [ActionName("documentacion")]
        public ActionResult Documentacion()
        {
            return View("Documentacion");
        }

    }
}