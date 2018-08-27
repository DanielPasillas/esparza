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
        /*
         *  Services => Home => Index //Redirect to landing page.
         */
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        //---------------------------------------------

        /*
         *  Services => paquetes-graduación
         */
        [ActionName("paquetes-graduacion")]
        public ActionResult Graduacion()
        {
            ViewBag.Evento = "Paquetes de graduación";
            ViewBag.Descripcion = "Contamos con una gran variedad de paquetes de gradaución con los cuales podrás recordar ese momento tán especial.";
            return View("Graduacion");
        }
        //---------------------------------------------


        /*
        *  Services => Fotografía 
        */
        [ActionName("fotografia")]
        public ActionResult Fotografia()
        {
            return View("Fotografia");
        }
        //---------------------------------------------

        /*
         * Services => Documentación
         */
        [ActionName("documentacion")]
        public ActionResult Documentacion()
        {
            return View("Documentacion");
        }
        //---------------------------------------------
    }
}