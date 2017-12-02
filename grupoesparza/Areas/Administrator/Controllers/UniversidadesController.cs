using System;
using System.Collections.Generic;
using System.Linq;
using grupoesparza.Models;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly esparza_dbEntities _dbContext;


        public UniversidadesController()
        {
            _dbContext = new esparza_dbEntities();
        }

        // GET: Administrator/Universidades
        public ActionResult Index()
        {
            var universidades = _dbContext.universidades.ToList();
            return View(universidades);
        }

        [ActionName("nueva")]
        public ActionResult Nueva()
        {
            return View("Nueva");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireHttps]
        public ActionResult Save(universidades infoUni)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}