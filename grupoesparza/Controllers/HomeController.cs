using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using grupoesparza.utilerias;

namespace grupoesparza.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (esparza_dbEntities _db = new esparza_dbEntities())
            {
                //Obtenemos la lista de galeria aleatoria.
                var randomGallery = _db.galerias.ToList();

                return View(randomGallery);
            }
           
        }


        // Home => Contacto
        [ActionName("contacto")]
        public ActionResult Contact()
        {
            return View("Contact");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contacto contacto)
        {

            return RedirectToAction("Contact");
        }
    }
}