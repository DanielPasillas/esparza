using grupoesparza.Models;
using System;
using grupoesparza.Areas.Administrator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly esparza_dbEntities _dbContext;

        public CarrerasController()
        {
            _dbContext = new esparza_dbEntities();
        }

        // GET: Administrator/Carreras
        public ActionResult Index()
        {
            var _carreras = (from c in _dbContext.carreras
                             join p in _dbContext.universidades
                             on c.id_universidad equals p.id_universidad
                             select new Carreras
                             {
                                 id_carrera = c.id_carrera,
                                 Universidad = p.NombreUniversidad,
                                 Carrera = c.NombreCarrera,
                                 Generacion = c.Generacion
                             });

            return View(_carreras);
        }

        [ActionName("nueva")]
        public ActionResult Nueva()
        {

            var list = new SelectList(_dbContext.universidades.Where(m => m.estatus == 1).ToList(), "id_universidad", "NombreUniversidad");
            ViewBag.Universidades = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Carreras _carreras)
        {
            if(ModelState.IsValid)
            {
                var carrera = new carreras()
                {
                    id_universidad = _carreras.id_universidad,
                    NombreCarrera  = _carreras.Carrera,
                    Generacion     = _carreras.Generacion,
                    estatus        = 1

                };

                _dbContext.carreras.Add(carrera);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Nueva", ModelState);
        }

    }
}