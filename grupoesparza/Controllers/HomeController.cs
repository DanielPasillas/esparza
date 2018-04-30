using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using grupoesparza.utilerias;
using System.Threading.Tasks;

namespace grupoesparza.Controllers
{
    public class HomeController : Controller
    {
        private esparza_dbEntities _dbContext;

        public HomeController()
        {
            _dbContext = new esparza_dbEntities();
        }
        //---------------------

        public async Task<ActionResult> Index()
        {
            Inicio viewModel = new Inicio()
            {
                Gallery = await _dbContext.galerias.ToListAsync()
            };

            return View(viewModel);           
        }
        //---------------------


        // Home => Contacto
        [ActionName("contacto")]
        public ActionResult Contact()
        {
            return View("Contact");
        }
        
        [ActionName("gallery")]
        public ActionResult Galeria()
        {
            return View("Galeria");
        }
    }
}