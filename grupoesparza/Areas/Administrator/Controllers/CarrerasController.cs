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
                             select new Carreras {
                                 id_carrera = c.id_carrera,
                                 Universidad = p.NombreUniversidad,
                                 Carrera  = c.NombreCarrera,
                                 Generacion = c.Generacion
                             });

            return View(_carreras);
        }
    }
}